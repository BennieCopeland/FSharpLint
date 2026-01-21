module FSharpLint.Framework.CustomConfiguration

open FSharpLint.Framework.Configuration
open FSharpLint.Rules

type CustomHintConfig = {
    Add: string list option
    Ignore: string list option
}

type CustomGlobalConfig = {
    NumIndentationSpaces: int option
}

type CustomConfiguration =
    {
        IgnoreFiles: string list
        Global: CustomGlobalConfig option
        Hints: CustomHintConfig option
        Rules: Rule list
    }

let applyRuleConfig (merge: 't -> 't -> 't) (oldConfig: RuleConfig<'t>, newConfig: RuleConfig<'t>) =
    match oldConfig, newConfig with
    | Enabled oldConfig, Enabled newConfig -> Enabled (merge oldConfig newConfig)
    | Disabled , Enabled newConfig -> Enabled newConfig
    | Enabled _, Disabled
    | Disabled, Disabled -> Disabled

let applyTypedItemSpacing (oldConfig: TypedItemSpacing.Config) (newConfig: TypedItemSpacing.Config) =
    { oldConfig with TypedItemStyle = newConfig.TypedItemStyle }

let applyTypePrefixing (oldConfig: TypePrefixing.Config) (newConfig: TypePrefixing.Config) =
    { oldConfig with Mode = newConfig.Mode }

let applyEnabledConfig (_: EnabledConfig, newConfig: EnabledConfig) =
    newConfig

let mergeSettings (oldRule: Rule) (newRule: Rule) =
    match oldRule, newRule with
    | TypedItemSpacing oldRule, TypedItemSpacing newRule ->
        (oldRule, newRule)
        |> applyRuleConfig applyTypedItemSpacing
        |> TypedItemSpacing
    | TypePrefixing oldRule, TypePrefixing newRule ->
        (oldRule, newRule)
        |> applyRuleConfig applyTypePrefixing
        |> TypePrefixing
    | UnionDefinitionIndentation oldRule, UnionDefinitionIndentation newRule ->
        (oldRule, newRule)
        |> applyEnabledConfig
        |> UnionDefinitionIndentation
    | ModuleDeclSpacing oldRule, ModuleDeclSpacing newRule ->
        (oldRule, newRule)
        |> applyEnabledConfig
        |> ModuleDeclSpacing
    | ClassMemberSpacing oldRule, ClassMemberSpacing newRule -> ClassMemberSpacing newRule
    | TupleCommaSpacing oldRule, TupleCommaSpacing newRule -> TupleCommaSpacing newRule
    | TupleIndentation oldRule, TupleIndentation newRule -> TupleIndentation newRule
    | TupleParentheses oldRule, TupleParentheses newRule -> TupleParentheses newRule
    | PatternMatchClausesOnNewLine oldRule, PatternMatchClausesOnNewLine newRule -> PatternMatchClausesOnNewLine newRule
    | PatternMatchOrClausesOnNewLine oldRule, PatternMatchOrClausesOnNewLine newRule -> PatternMatchOrClausesOnNewLine newRule
    

let applyCustomConfig (config: Configuration) (custom: CustomConfiguration) =
    let customRules =
        custom.Rules
        |> List.map (fun rule -> ruleToIdentifier rule, rule)
        |> Map.ofList
    
    let rules =
        config.Rules
        |> List.map (fun rule ->
                let ruleId = ruleToIdentifier rule
                match customRules.TryFind ruleId with
                | Some customRule -> mergeSettings rule customRule
                | None -> rule
            )
    
    ()