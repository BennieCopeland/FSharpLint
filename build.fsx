#r "paket:
nuget Fake.DotNet.Cli
nuget Fake.DotNet.FSFormatting
nuget Fake.DotNet.Paket
nuget Fake.DotNet.MSBuild
nuget Fake.IO.FileSystem
nuget Fake.Tools.Git
nuget Fake.Core.ReleaseNotes
nuget Fake.Core.Target //"

open System
open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.IO.Globbing.Operators
open Fake.Tools

let project = "FSharpLint"

let release = ReleaseNotes.load "RELEASE_NOTES.md"
Environment.setEnvironVar "Version" release.NugetVersion

Target.create "Clean" (fun _ -> 
    !! "src/*/bin" 
    ++ "src/*/obj" 
    ++ "tests/*/bin" 
    ++ "tests/*/obj" 
    |> Shell.cleanDirs)

Target.create "Restore" (fun _ -> Paket.restore id)

Target.create "Build" (fun _ -> DotNet.build id "FSharpLint.sln")

let filterPerformanceTests (p:DotNet.TestOptions) = { p with Filter = Some "\"TestCategory!=Performance\""; Configuration = DotNet.Release }

Target.create "RunTests" (fun _ -> DotNet.test filterPerformanceTests "tests/FSharpLint.Core.Tests")
Target.create "RunFunctionalTests" (fun _ -> DotNet.test filterPerformanceTests "tests/FSharpLint.FunctionalTest")

Target.create "Package" (fun _ ->        
    let configure (c:DotNet.PackOptions) = { c with Configuration = DotNet.Release; OutputPath = Some "../../packaging" }
    DotNet.pack configure "src/FSharpLint.Core/FSharpLint.Core.fsproj"
    DotNet.pack configure "src/FSharpLint.Console/FSharpLint.Console.fsproj")

Target.create "PublishPackages" (fun _ -> Paket.push(fun p -> { p with WorkingDir = "packaging" }))

Target.create "Release" (fun _ ->
    Git.Staging.stageAll ""
    Git.Commit.exec "" (sprintf "Bump version to %s" release.NugetVersion)
    Git.Branches.push ""

    Git.Branches.tag "" release.NugetVersion
    Git.Branches.pushTag "" "origin" release.NugetVersion)

Target.create "GenerateDocs" (fun _ -> 
    let docsDir = "docs/output"
    Shell.cleanDir docsDir

    let projInfo =
        [ "project-name", "FSharpLint"
          "project-author", "Matthew Mcveigh"
          "project-summary", "A lint tool for F#."
          "project-github", "http://fsprojects.github.io/FSharpLint/"
          "project-nuget", "http://nuget.org/packages/FSharpLint.Core" ]

    Shell.copyDir (docsDir + "/content") "docs/files" FileFilter.allFiles
    FSFormatting.createDocs (fun s ->
        { s with
            Source = "docs/content"
            OutputDirectory = docsDir
            Template = "docs/tools/templates/template.html"
            ProjectParameters = projInfo
            LayoutRoots = [] }))

Target.create "Default" ignore

open Fake.Core.TargetOperators

"Clean" 
    ==> "Restore"
    ==> "Build" 
    ==> "RunTests"
    ==> "RunFunctionalTests" 
    ==> "Package" 
    ==> "Default"
    ==> "GenerateDocs" 
    ==> "PublishPackages" 
    ==> "Release"

Target.runOrDefault "Default"