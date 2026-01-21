module FSharpLint.Framework.Configuration

open System
open FSharpLint.Framework.Rules
open FSharpLint.Framework.HintParser
open FSharpLint.Rules

exception ConfigurationException of string

type RuleConfig<'Config> =
    | Enabled of 'Config
    | Disabled

type EnabledConfig = RuleConfig<unit>

type GlobalConfig = {
    NumIndentationSpaces:int
}
type HintConfig = {
    Add: string list
    Ignore: string list
}

type CustomGlobalConfig = {
    numIndentationSpaces:int option
}

type CustomConfiguration =
    {
        Global: CustomGlobalConfig option
        ModuleDeclSpacing: EnabledConfig option
    }

[<RequireQualifiedAccess>]
type RuleIdentifier =
    | TypedItemSpacing
    | TypePrefixing
    | UnionDefinitionIndentation
    | ModuleDeclSpacing
    | ClassMemberSpacing
    | TupleCommaSpacing
    | TupleIndentation
    | TupleParentheses
    | PatternMatchClausesOnNewLine
    | PatternMatchOrClausesOnNewLine
    | PatternMatchClauseIndentation
    | PatternMatchExpressionIndentation
    | RecursiveAsyncFunction
    | RedundantNewKeyword
    | NestedStatements
    | CyclomaticComplexity
    | ReimplementsFunction
    | CanBeReplacedWithComposition
    | AvoidSinglePipeOperator
    | UsedUnderscorePrefixedElements
    | FailwithWithSingleArgument
    | RaiseWithSingleArgument
    | NullArgWithSingleArgument
    | InvalidOpWithSingleArgument
    | InvalidArgWithTwoArguments
    | FailwithfWithArgumentsMatchingFormatString
    | FailwithBadUsage
    | MaxLinesInLambdaFunction
    | MaxLinesInMatchLambdaFunction
    | MaxLinesInValue
    | MaxLinesInFunction
    | MaxLinesInMember
    | MaxLinesInConstructor
    | MaxLinesInProperty
    | MaxLinesInModule
    | MaxLinesInRecord
    | MaxLinesInEnum
    | MaxLinesInUnion
    | MaxLinesInClass
    | InterfaceNames
    | ExceptionNames
    | TypeNames
    | RecordFieldNames
    | EnumCasesNames
    | UnionCasesNames
    | ModuleNames
    | LiteralNames
    | NamespaceNames
    | MemberNames
    | ParameterNames
    | MeasureTypeNames
    | ActivePatternNames
    | GenericTypesNames
    | PublicValuesNames
    | PrivateValuesNames
    | InternalValuesNames
    | UnnestedFunctionNames
    | NestedFunctionNames
    | MaxNumberOfItemsInTuple
    | MaxNumberOfFunctionParameters
    | MaxNumberOfMembers
    | MaxNumberOfBooleanOperatorsInCondition
    | FavourIgnoreOverLetWild
    | WildcardNamedWithAsPattern
    | UselessBinding
    | TupleOfWildcards
    | FavourTypedIgnore
    | FavourNonMutablePropertyInitialization
    | FavourReRaise
    | FavourStaticEmptyFields
    | FavourConsistentThis
    | SuggestUseAutoProperty
    | AvoidTooShortNames
    | AsyncExceptionWithoutReturn
    | UnneededRecKeyword
    | Indentation
    | MaxCharactersOnLine
    | TrailingWhitespaceOnLine
    | MaxLinesInFile
    | TrailingNewLineInFile
    | NoTabCharacters
    | NoPartialFunctions
    | EnsureTailCallDiagnosticsInRecursiveFunctions
    | FavourAsKeyword

type Rule =
    | TypedItemSpacing of RuleConfig<TypedItemSpacing.Config>
    | TypePrefixing of RuleConfig<TypePrefixing.Config>
    | UnionDefinitionIndentation of EnabledConfig
    | ModuleDeclSpacing of EnabledConfig
    | ClassMemberSpacing of EnabledConfig
    | TupleCommaSpacing of EnabledConfig
    | TupleIndentation of EnabledConfig
    | TupleParentheses of EnabledConfig
    | PatternMatchClausesOnNewLine of EnabledConfig
    | PatternMatchOrClausesOnNewLine of EnabledConfig
    | PatternMatchClauseIndentation of RuleConfig<PatternMatchClauseIndentation.Config>
    | PatternMatchExpressionIndentation of EnabledConfig
    | RecursiveAsyncFunction of EnabledConfig
    | RedundantNewKeyword of EnabledConfig
    | NestedStatements of RuleConfig<NestedStatements.Config>
    | CyclomaticComplexity of RuleConfig<CyclomaticComplexity.Config>
    | ReimplementsFunction of EnabledConfig
    | CanBeReplacedWithComposition of EnabledConfig
    | AvoidSinglePipeOperator of EnabledConfig
    | UsedUnderscorePrefixedElements of EnabledConfig
    | FailwithWithSingleArgument of EnabledConfig
    | RaiseWithSingleArgument of EnabledConfig
    | NullArgWithSingleArgument of EnabledConfig
    | InvalidOpWithSingleArgument of EnabledConfig
    | InvalidArgWithTwoArguments of EnabledConfig
    | FailwithfWithArgumentsMatchingFormatString of EnabledConfig
    | FailwithBadUsage of EnabledConfig
    | MaxLinesInLambdaFunction of RuleConfig<Helper.SourceLength.Config>
    | MaxLinesInMatchLambdaFunction of RuleConfig<Helper.SourceLength.Config>
    | MaxLinesInValue of RuleConfig<Helper.SourceLength.Config>
    | MaxLinesInFunction of RuleConfig<Helper.SourceLength.Config>
    | MaxLinesInMember of RuleConfig<Helper.SourceLength.Config>
    | MaxLinesInConstructor of RuleConfig<Helper.SourceLength.Config>
    | MaxLinesInProperty of RuleConfig<Helper.SourceLength.Config>
    | MaxLinesInModule of RuleConfig<Helper.SourceLength.Config>
    | MaxLinesInRecord of RuleConfig<Helper.SourceLength.Config>
    | MaxLinesInEnum of RuleConfig<Helper.SourceLength.Config>
    | MaxLinesInUnion of RuleConfig<Helper.SourceLength.Config>
    | MaxLinesInClass of RuleConfig<Helper.SourceLength.Config>
    | InterfaceNames of RuleConfig<NamingConfig>
    | ExceptionNames of RuleConfig<NamingConfig>
    | TypeNames of RuleConfig<NamingConfig>
    | RecordFieldNames of RuleConfig<NamingConfig>
    | EnumCasesNames of RuleConfig<NamingConfig>
    | UnionCasesNames of RuleConfig<NamingConfig>
    | ModuleNames of RuleConfig<NamingConfig>
    | LiteralNames of RuleConfig<NamingConfig>
    | NamespaceNames of RuleConfig<NamingConfig>
    | MemberNames of RuleConfig<NamingConfig>
    | ParameterNames of RuleConfig<NamingConfig>
    | MeasureTypeNames of RuleConfig<NamingConfig>
    | ActivePatternNames of RuleConfig<NamingConfig>
    | GenericTypesNames of RuleConfig<NamingConfig>
    | PublicValuesNames of RuleConfig<NamingConfig>
    | PrivateValuesNames of RuleConfig<NamingConfig>
    | InternalValuesNames of RuleConfig<NamingConfig>
    | UnnestedFunctionNames of RuleConfig<NamingConfig>
    | NestedFunctionNames of RuleConfig<NamingConfig>
    | MaxNumberOfItemsInTuple of RuleConfig<Helper.NumberOfItems.Config>
    | MaxNumberOfFunctionParameters of RuleConfig<Helper.NumberOfItems.Config>
    | MaxNumberOfMembers of RuleConfig<Helper.NumberOfItems.Config>
    | MaxNumberOfBooleanOperatorsInCondition of RuleConfig<Helper.NumberOfItems.Config>
    | FavourIgnoreOverLetWild of EnabledConfig
    | WildcardNamedWithAsPattern of EnabledConfig
    | UselessBinding of EnabledConfig
    | TupleOfWildcards of EnabledConfig
    | FavourTypedIgnore of EnabledConfig
    | FavourNonMutablePropertyInitialization of EnabledConfig
    | FavourReRaise of EnabledConfig
    | FavourStaticEmptyFields of EnabledConfig
    | FavourConsistentThis of RuleConfig<FavourConsistentThis.Config>
    | SuggestUseAutoProperty of EnabledConfig
    | AvoidTooShortNames of EnabledConfig
    | AsyncExceptionWithoutReturn of EnabledConfig
    | UnneededRecKeyword of EnabledConfig
    | Indentation of EnabledConfig
    | MaxCharactersOnLine of RuleConfig<MaxCharactersOnLine.Config>
    | TrailingWhitespaceOnLine of RuleConfig<TrailingWhitespaceOnLine.Config>
    | MaxLinesInFile of RuleConfig<MaxLinesInFile.Config>
    | TrailingNewLineInFile of EnabledConfig
    | NoTabCharacters of EnabledConfig
    | NoPartialFunctions of RuleConfig<NoPartialFunctions.Config>
    | EnsureTailCallDiagnosticsInRecursiveFunctions of EnabledConfig
    | FavourAsKeyword of EnabledConfig    

type Configuration =
    {
        IgnoreFiles: string list
        Global: GlobalConfig
        Hints: HintConfig
        Rules: Rule list
    }
        
let defaultRules =
    [
        TypedItemSpacing Disabled
        TypePrefixing Disabled
        UnionDefinitionIndentation Disabled
        ModuleDeclSpacing Disabled
        ClassMemberSpacing Disabled
        TupleCommaSpacing Disabled
        TupleIndentation Disabled
        TupleParentheses Disabled
        PatternMatchClausesOnNewLine Disabled
        PatternMatchOrClausesOnNewLine Disabled
        PatternMatchClauseIndentation Disabled
        PatternMatchExpressionIndentation Disabled
        RecursiveAsyncFunction Disabled
        RedundantNewKeyword <| Enabled ()
        NestedStatements Disabled
        CyclomaticComplexity Disabled
        ReimplementsFunction <| Enabled ()
        CanBeReplacedWithComposition <| Enabled ()
        AvoidSinglePipeOperator Disabled
        UsedUnderscorePrefixedElements <| Enabled ()
        FailwithWithSingleArgument <| Enabled ()
        RaiseWithSingleArgument <| Enabled ()
        NullArgWithSingleArgument <| Enabled ()
        InvalidOpWithSingleArgument <| Enabled ()
        InvalidArgWithTwoArguments <| Enabled ()
        FailwithfWithArgumentsMatchingFormatString <| Enabled ()
        FailwithBadUsage <| Enabled ()
        MaxLinesInLambdaFunction Disabled
        MaxLinesInMatchLambdaFunction Disabled
        MaxLinesInValue Disabled
        MaxLinesInFunction Disabled
        MaxLinesInMember Disabled
        MaxLinesInConstructor Disabled
        MaxLinesInProperty Disabled
        MaxLinesInModule Disabled
        MaxLinesInRecord Disabled
        MaxLinesInEnum Disabled
        MaxLinesInUnion Disabled
        MaxLinesInClass Disabled
        InterfaceNames (Enabled {
            Naming = Some NamingCase.PascalCase
            Underscores = Some NamingUnderscores.None
            Prefix = Some "I"
            Suffix = None 
        })
        ExceptionNames (Enabled {
            Naming = Some NamingCase.PascalCase
            Underscores = Some NamingUnderscores.None
            Prefix = None
            Suffix = Some "Exception"
        })
        TypeNames (Enabled {
            Naming = Some NamingCase.PascalCase
            Underscores = Some NamingUnderscores.None
            Prefix = None
            Suffix = None
        })
        RecordFieldNames <| Enabled {
            Naming = Some NamingCase.PascalCase
            Underscores = Some NamingUnderscores.None
            Prefix = None
            Suffix = None
        }
        EnumCasesNames <| Enabled {
            Naming = Some NamingCase.PascalCase
            Underscores = Some NamingUnderscores.None
            Prefix = None
            Suffix = None
        }
        UnionCasesNames <| Enabled {
            Naming = Some NamingCase.PascalCase
            Underscores = Some NamingUnderscores.None
            Prefix = None
            Suffix = None
        }
        ModuleNames <| Enabled {
            Naming = Some NamingCase.PascalCase
            Underscores = Some NamingUnderscores.None
            Prefix = None
            Suffix = None
        }
        LiteralNames <| Enabled {
            Naming = Some NamingCase.PascalCase
            Underscores = Some NamingUnderscores.None
            Prefix = None
            Suffix = None
        }
        NamespaceNames <| Enabled {
            Naming = Some NamingCase.PascalCase
            Underscores = Some NamingUnderscores.None
            Prefix = None
            Suffix = None
        }
        MemberNames <| Enabled {
            Naming = Some NamingCase.PascalCase
            Underscores = Some NamingUnderscores.AllowPrefix
            Prefix = None
            Suffix = None
        }
        ParameterNames <| Enabled {
            Naming = Some NamingCase.CamelCase
            Underscores = Some NamingUnderscores.AllowPrefix
            Prefix = None
            Suffix = None
        }
        MeasureTypeNames <| Enabled {
            Naming = None
            Underscores = Some NamingUnderscores.None
            Prefix = None
            Suffix = None
        }
        ActivePatternNames <| Enabled {
            Naming = Some NamingCase.PascalCase
            Underscores = Some NamingUnderscores.None
            Prefix = None
            Suffix = None
        }
        GenericTypesNames <| Enabled {
            Naming = Some NamingCase.PascalCase
            Underscores = Some NamingUnderscores.None
            Prefix = None
            Suffix = None
        }
        PublicValuesNames <| Enabled {
            Naming = None
            Underscores = Some NamingUnderscores.AllowPrefix
            Prefix = None
            Suffix = None
        }
        PrivateValuesNames <| Enabled {
            Naming = Some NamingCase.CamelCase
            Underscores = Some NamingUnderscores.AllowPrefix
            Prefix = None
            Suffix = None
        }
        InternalValuesNames <| Enabled {
            Naming = Some NamingCase.CamelCase
            Underscores = Some NamingUnderscores.AllowPrefix
            Prefix = None
            Suffix = None
        }
        UnnestedFunctionNames Disabled
        NestedFunctionNames Disabled
        MaxNumberOfItemsInTuple Disabled
        MaxNumberOfFunctionParameters Disabled
        MaxNumberOfMembers Disabled
        MaxNumberOfBooleanOperatorsInCondition Disabled
        FavourIgnoreOverLetWild <| Enabled ()
        WildcardNamedWithAsPattern <| Enabled ()
        UselessBinding <| Enabled ()
        TupleOfWildcards <| Enabled ()
        FavourTypedIgnore Disabled
        FavourNonMutablePropertyInitialization Disabled
        FavourReRaise <| Enabled ()
        FavourStaticEmptyFields Disabled
        FavourConsistentThis Disabled
        SuggestUseAutoProperty Disabled
        AvoidTooShortNames Disabled
        AsyncExceptionWithoutReturn Disabled
        UnneededRecKeyword <| Enabled ()
        Indentation Disabled
        MaxCharactersOnLine Disabled
        TrailingWhitespaceOnLine Disabled
        MaxLinesInFile Disabled
        TrailingNewLineInFile Disabled
        NoTabCharacters <| Enabled ()
        NoPartialFunctions Disabled
        EnsureTailCallDiagnosticsInRecursiveFunctions Disabled
        FavourAsKeyword <| Enabled ()
    ]

let defaultConfiguration =
    {
        IgnoreFiles = [
            "assemblyinfo.*"
        ]
        Global = {
            NumIndentationSpaces = 4 
        }
        Hints = {
            Add = [
                "not (a =  b) ===> a <> b"
                "not (a <> b) ===> a =  b"
                "not (a >  b) ===> a <= b"
                "not (a >= b) ===> a <  b"
                "not (a <  b) ===> a >= b"
                "not (a <= b) ===> a >  b"
                "compare x y <> 1 ===> x <= y"
                "compare x y = -1 ===> x < y"
                "compare x y <> -1 ===> x >= y"
                "compare x y = 1 ===> x > y"
                "compare x y <= 0 ===> x <= y"
                "compare x y <  0 ===> x <  y"
                "compare x y >= 0 ===> x >= y"
                "compare x y >  0 ===> x >  y"
                "compare x y =  0 ===> x =  y"
                "compare x y <> 0 ===> x <> y"    
                "List.head (List.sort x) ===> List.min x"
                "List.head (List.sortBy f x) ===> List.minBy f x"    
                "List.map f (List.map g x) ===> List.map (g >> f) x"
                "Array.map f (Array.map g x) ===> Array.map (g >> f) x"
                "Seq.map f (Seq.map g x) ===> Seq.map (g >> f) x"
                "List.nth x 0 ===> List.head x"
                "List.map f (List.replicate n x) ===> List.replicate n (f x)"
                "List.rev (List.rev x) ===> x"
                "Array.rev (Array.rev x) ===> x"
                "List.fold (@) [] x ===> List.concat x"
                "List.map id x ===> id x"
                "Array.map id x ===> id x"
                "Seq.map id x ===> id x"
                "(List.length x) = 0 ===> List.isEmpty x"
                "(Array.length x) = 0 ===> Array.isEmpty x"
                "(Seq.length x) = 0 ===> Seq.isEmpty x"
                "x = [] ===> List.isEmpty x"
                "x = [||] ===> Array.isEmpty x"
                "(List.length x) <> 0 ===> not (List.isEmpty x)"
                "(Array.length x) <> 0 ===> not (Array.isEmpty x)"
                "(Seq.length x) <> 0 ===> not (Seq.isEmpty x)"
                "(List.length x) > 0 ===> not (List.isEmpty x)"
                "(Array.length x) <> 0 ===> not (Array.isEmpty x)"
                "(Seq.length x) <> 0 ===> not (Seq.isEmpty x)"    
                "List.concat (List.map f x) ===> List.collect f x"
                "Array.concat (Array.map f x) ===> Array.collect f x"
                "Seq.concat (Seq.map f x) ===> Seq.collect f x"    
                "List.isEmpty (List.filter f x) ===> not (List.exists f x)"
                "Array.isEmpty (Array.filter f x) ===> not (Array.exists f x)"
                "Seq.isEmpty (Seq.filter f x) ===> not (Seq.exists f x)"
                "not (List.isEmpty (List.filter f x)) ===> List.exists f x"
                "not (Array.isEmpty (Array.filter f x)) ===> Array.exists f x"
                "not (Seq.isEmpty (Seq.filter f x)) ===> Seq.exists f x"    
                "List.length x >= 0 ===> true"
                "Array.length x >= 0 ===> true"
                "Seq.length x >= 0 ===> true"    
                "x = true ===> x"
                "x = false ===> not x"
                "true = a ===> a"
                "false = a ===> not a"
                "a <> true ===> not a"
                "a <> false ===> a"
                "true <> a ===> not a"
                "false <> a ===> a"
                "if a then true else false ===> a"
                "if a then false else true ===> not a"
                "not (not x) ===> x"    
                "(fst x, snd x) ===> x"    
                "true && x ===> x"
                "false && x ===> false"
                "true || x ===> true"
                "false || x ===> x"
                "not true ===> false"
                "not false ===> true"
                "fst (x, y) ===> x"
                "snd (x, y) ===> y"
                "List.fold f x [] ===> x"
                "Array.fold f x [||] ===> x"
                "List.foldBack f [] x ===> x"
                "Array.foldBack f [||] x ===> x"
                "x - 0 ===> x"
                "x * 1 ===> x"
                "x / 1 ===> x"    
                "List.fold (+) 0 x ===> List.sum x"
                "Array.fold (+) 0 x ===> Array.sum x"
                "Seq.fold (+) 0 x ===> Seq.sum x"
                "List.sum (List.map x y) ===> List.sumBy x y"
                "Array.sum (Array.map x y) ===> Array.sumBy x y"
                "Seq.sum (Seq.map x y) ===> Seq.sumBy x y"
                "List.average (List.map x y) ===> List.averageBy x y"
                "Array.average (Array.map x y) ===> Array.averageBy x y"
                "Seq.average (Seq.map x y) ===> Seq.averageBy x y"
                "(List.take x y, List.skip x y) ===> List.splitAt x y"
                "(Array.take x y, Array.skip x y) ===> Array.splitAt x y"
                "(Seq.take x y, Seq.skip x y) ===> Seq.splitAt x y"    
                "List.empty ===> []"
                "Array.empty ===> [||]"    
                "x::[] ===> [x]"
                "pattern: x::[] ===> [x]"    
                "x @ [] ===> x"    
                "List.isEmpty [] ===> true"
                "Array.isEmpty [||] ===> true"    
                "fun _ -> () ===> ignore"
                "fun x -> x ===> id"
                "id x ===> x"
                "id >> f ===> f"
                "f >> id ===> f"    
                "x = null ===> isNull x"
                "null = x ===> isNull x"
                "x <> null ===> not (isNull x)"
                "null <> x ===> not (isNull x)"    
                "Array.append a (Array.append b c) ===> Array.concat [|a; b; c|]"
            ]
            Ignore = [] 
        }
        Rules = defaultRules
    }

let private constructTypePrefixingRuleWithConfig rule (ruleConfig: RuleConfig<TypePrefixing.Config>) =
    match ruleConfig with
    | Enabled config ->
        Some(rule config)
    | Disabled -> None

let private constructRuleIfEnabled rule = function
    | Enabled _ -> Some rule
    | Disabled -> None

let private constructRuleWithConfig rule = function
    | Enabled config -> Some (rule config)
    | Disabled -> None

let private flattenRule = function
    | TypedItemSpacing rule -> rule |> constructRuleWithConfig TypedItemSpacing.rule
    | TypePrefixing rule -> rule |> constructTypePrefixingRuleWithConfig TypePrefixing.rule
    | UnionDefinitionIndentation rule -> rule |> constructRuleIfEnabled UnionDefinitionIndentation.rule
    | ModuleDeclSpacing rule -> rule |> constructRuleIfEnabled ModuleDeclSpacing.rule
    | ClassMemberSpacing rule -> rule |> constructRuleIfEnabled ClassMemberSpacing.rule
    | TupleCommaSpacing rule -> rule |> constructRuleIfEnabled TupleCommaSpacing.rule
    | TupleIndentation rule -> rule |> constructRuleIfEnabled TupleIndentation.rule
    | TupleParentheses rule -> rule |> constructRuleIfEnabled TupleParentheses.rule
    | PatternMatchClausesOnNewLine rule -> rule |> constructRuleIfEnabled PatternMatchClausesOnNewLine.rule
    | PatternMatchOrClausesOnNewLine rule -> rule |> constructRuleIfEnabled PatternMatchOrClausesOnNewLine.rule
    | PatternMatchClauseIndentation rule -> rule |> constructRuleWithConfig PatternMatchClauseIndentation.rule
    | PatternMatchExpressionIndentation rule -> rule |> constructRuleIfEnabled PatternMatchExpressionIndentation.rule
    | RecursiveAsyncFunction rule -> rule |> constructRuleIfEnabled RecursiveAsyncFunction.rule
    | RedundantNewKeyword rule -> rule |> constructRuleIfEnabled RedundantNewKeyword.rule
    | NestedStatements rule -> rule |> constructRuleWithConfig NestedStatements.rule
    | CyclomaticComplexity rule -> rule |> constructRuleWithConfig CyclomaticComplexity.rule
    | ReimplementsFunction rule -> rule |> constructRuleIfEnabled ReimplementsFunction.rule
    | CanBeReplacedWithComposition rule -> rule |> constructRuleIfEnabled CanBeReplacedWithComposition.rule
    | AvoidSinglePipeOperator rule -> rule |> constructRuleIfEnabled AvoidSinglePipeOperator.rule
    | UsedUnderscorePrefixedElements rule -> rule |> constructRuleIfEnabled UsedUnderscorePrefixedElements.rule
    | FailwithWithSingleArgument rule -> rule |> constructRuleIfEnabled FailwithWithSingleArgument.rule
    | RaiseWithSingleArgument rule -> rule |> constructRuleIfEnabled RaiseWithSingleArgument.rule
    | NullArgWithSingleArgument rule -> rule |> constructRuleIfEnabled NullArgWithSingleArgument.rule
    | InvalidOpWithSingleArgument rule -> rule |> constructRuleIfEnabled InvalidOpWithSingleArgument.rule
    | InvalidArgWithTwoArguments rule -> rule |> constructRuleIfEnabled InvalidArgWithTwoArguments.rule
    | FailwithfWithArgumentsMatchingFormatString rule -> rule |> constructRuleIfEnabled FailwithfWithArgumentsMatchingFormatString.rule
    | FailwithBadUsage rule -> rule |> constructRuleIfEnabled FailwithBadUsage.rule
    | MaxLinesInLambdaFunction rule -> rule |> constructRuleWithConfig MaxLinesInLambdaFunction.rule
    | MaxLinesInMatchLambdaFunction rule -> rule |> constructRuleWithConfig MaxLinesInMatchLambdaFunction.rule
    | MaxLinesInValue rule -> rule |> constructRuleWithConfig MaxLinesInValue.rule
    | MaxLinesInFunction rule -> rule |> constructRuleWithConfig MaxLinesInFunction.rule
    | MaxLinesInMember rule -> rule |> constructRuleWithConfig MaxLinesInMember.rule
    | MaxLinesInConstructor rule -> rule |> constructRuleWithConfig MaxLinesInConstructor.rule
    | MaxLinesInProperty rule -> rule |> constructRuleWithConfig MaxLinesInProperty.rule
    | MaxLinesInModule rule -> rule |> constructRuleWithConfig MaxLinesInModule.rule
    | MaxLinesInRecord rule -> rule |> constructRuleWithConfig MaxLinesInRecord.rule
    | MaxLinesInEnum rule -> rule |> constructRuleWithConfig MaxLinesInEnum.rule
    | MaxLinesInUnion rule -> rule |> constructRuleWithConfig MaxLinesInUnion.rule
    | MaxLinesInClass rule -> rule |> constructRuleWithConfig MaxLinesInClass.rule
    | InterfaceNames rule -> rule |> constructRuleWithConfig InterfaceNames.rule
    | ExceptionNames rule -> rule |> constructRuleWithConfig ExceptionNames.rule
    | TypeNames rule -> rule |> constructRuleWithConfig TypeNames.rule
    | RecordFieldNames rule -> rule |> constructRuleWithConfig RecordFieldNames.rule
    | EnumCasesNames rule -> rule |> constructRuleWithConfig EnumCasesNames.rule
    | UnionCasesNames rule -> rule |> constructRuleWithConfig UnionCasesNames.rule
    | ModuleNames rule -> rule |> constructRuleWithConfig ModuleNames.rule
    | LiteralNames rule -> rule |> constructRuleWithConfig LiteralNames.rule
    | NamespaceNames rule -> rule |> constructRuleWithConfig NamespaceNames.rule
    | MemberNames rule -> rule |> constructRuleWithConfig MemberNames.rule
    | ParameterNames rule -> rule |> constructRuleWithConfig ParameterNames.rule
    | MeasureTypeNames rule -> rule |> constructRuleWithConfig MeasureTypeNames.rule
    | ActivePatternNames rule -> rule |> constructRuleWithConfig ActivePatternNames.rule
    | GenericTypesNames rule -> rule |> constructRuleWithConfig GenericTypesNames.rule
    | PublicValuesNames rule -> rule |> constructRuleWithConfig PublicValuesNames.rule
    | PrivateValuesNames rule -> rule |> constructRuleWithConfig PrivateValuesNames.rule
    | InternalValuesNames rule -> rule |> constructRuleWithConfig InternalValuesNames.rule
    | UnnestedFunctionNames rule -> rule |> constructRuleWithConfig UnnestedFunctionNames.rule
    | NestedFunctionNames rule -> rule |> constructRuleWithConfig NestedFunctionNames.rule
    | MaxNumberOfItemsInTuple rule -> rule |> constructRuleWithConfig MaxNumberOfItemsInTuple.rule
    | MaxNumberOfFunctionParameters rule -> rule |> constructRuleWithConfig MaxNumberOfFunctionParameters.rule
    | MaxNumberOfMembers rule -> rule |> constructRuleWithConfig MaxNumberOfMembers.rule
    | MaxNumberOfBooleanOperatorsInCondition rule -> rule |> constructRuleWithConfig MaxNumberOfBooleanOperatorsInCondition.rule
    | FavourIgnoreOverLetWild rule -> rule |> constructRuleIfEnabled FavourIgnoreOverLetWild.rule
    | WildcardNamedWithAsPattern rule -> rule |> constructRuleIfEnabled WildcardNamedWithAsPattern.rule
    | UselessBinding rule -> rule |> constructRuleIfEnabled UselessBinding.rule
    | TupleOfWildcards rule -> rule |> constructRuleIfEnabled TupleOfWildcards.rule
    | FavourTypedIgnore rule -> rule |> constructRuleIfEnabled FavourTypedIgnore.rule
    | FavourNonMutablePropertyInitialization rule -> rule |> constructRuleIfEnabled FavourNonMutablePropertyInitialization.rule
    | FavourReRaise rule -> rule |> constructRuleIfEnabled FavourReRaise.rule
    | FavourStaticEmptyFields rule -> rule |> constructRuleIfEnabled FavourStaticEmptyFields.rule
    | FavourConsistentThis rule -> rule |> constructRuleWithConfig FavourConsistentThis.rule
    | SuggestUseAutoProperty rule -> rule |> constructRuleIfEnabled SuggestUseAutoProperty.rule
    | AvoidTooShortNames rule -> rule |> constructRuleIfEnabled AvoidTooShortNames.rule
    | AsyncExceptionWithoutReturn rule -> rule |> constructRuleIfEnabled AsyncExceptionWithoutReturn.rule
    | UnneededRecKeyword rule -> rule |> constructRuleIfEnabled UnneededRecKeyword.rule
    | Indentation rule -> rule |> constructRuleIfEnabled Indentation.rule
    | MaxCharactersOnLine rule -> rule |> constructRuleWithConfig MaxCharactersOnLine.rule
    | TrailingWhitespaceOnLine rule -> rule |> constructRuleWithConfig TrailingWhitespaceOnLine.rule
    | MaxLinesInFile rule -> rule |> constructRuleWithConfig MaxLinesInFile.rule
    | TrailingNewLineInFile rule -> rule |> constructRuleIfEnabled TrailingNewLineInFile.rule
    | NoTabCharacters rule -> rule |> constructRuleIfEnabled NoTabCharacters.rule
    | NoPartialFunctions rule -> rule |> constructRuleWithConfig NoPartialFunctions.rule
    | EnsureTailCallDiagnosticsInRecursiveFunctions rule -> rule |> constructRuleIfEnabled EnsureTailCallDiagnosticsInRecursiveFunctions.rule
    | FavourAsKeyword rule -> rule |> constructRuleIfEnabled FavourAsKeyword.rule

type LineRules =
    { GenericLineRules:RuleMetadata<LineRuleConfig> []
      NoTabCharactersRule:RuleMetadata<NoTabCharactersRuleConfig> option
      IndentationRule:RuleMetadata<IndentationRuleConfig> option }

type LoadedRules =
    { GlobalConfig: GlobalRuleConfig
      AstNodeRules:RuleMetadata<AstNodeRuleConfig> []
      LineRules:LineRules }

let private getGlobalConfig (globalConfig: GlobalConfig) =
    { GlobalRuleConfig.numIndentationSpaces =
        globalConfig.NumIndentationSpaces }

let private parseHints (hints:string list) =
    let parseHint hint =
        match FParsec.CharParsers.run phint hint with
        | FParsec.CharParsers.Success(hint, _, _) -> hint
        | FParsec.CharParsers.Failure(error, _, _) ->
            raise <| ConfigurationException $"Failed to parse hint: {hint}{Environment.NewLine}{error}"

    hints
    |> List.filter (System.String.IsNullOrWhiteSpace >> not)
    |> List.map parseHint
    |> MergeSyntaxTrees.mergeHints

let flattenConfig (config: Configuration) =
    let hints =
        config.Hints.Add
        |> parseHints
        |> fun hints -> HintMatcher.rule { HintTrie = hints }
            
    let allRules =
        config.Rules
        |> List.map flattenRule
        |> List.choose id
    
    let astNodeRules = ResizeArray()
    let lineRules = ResizeArray()
    let mutable indentationRule = None
    let mutable noTabCharactersRule = None
    
    hints :: allRules
    |> List.iter (function
        | AstNodeRule rule -> astNodeRules.Add rule
        | LineRule rule -> lineRules.Add(rule)
        | IndentationRule rule -> indentationRule <- Some rule
        | NoTabCharactersRule rule -> noTabCharactersRule <- Some rule)

    { LoadedRules.GlobalConfig = getGlobalConfig config.Global
      AstNodeRules = astNodeRules.ToArray()
      LineRules =
        { GenericLineRules = lineRules.ToArray()
          IndentationRule = indentationRule
          NoTabCharactersRule = noTabCharactersRule } }

let identifierToString = function
    | RuleIdentifier.TypedItemSpacing -> Identifiers.TypedItemSpacing
    | RuleIdentifier.TypePrefixing -> Identifiers.TypePrefixing
    | RuleIdentifier.UnionDefinitionIndentation -> Identifiers.UnionDefinitionIndentation
    | RuleIdentifier.ModuleDeclSpacing -> Identifiers.ModuleDeclSpacing
    | RuleIdentifier.ClassMemberSpacing -> Identifiers.ClassMemberSpacing
    | RuleIdentifier.TupleCommaSpacing -> Identifiers.TupleCommaSpacing
    | RuleIdentifier.TupleIndentation -> Identifiers.TupleIndentation
    | RuleIdentifier.TupleParentheses -> Identifiers.TupleParentheses
    | RuleIdentifier.PatternMatchClausesOnNewLine -> Identifiers.PatternMatchClausesOnNewLine
    | RuleIdentifier.PatternMatchOrClausesOnNewLine -> Identifiers.PatternMatchOrClausesOnNewLine
    | RuleIdentifier.PatternMatchClauseIndentation -> Identifiers.PatternMatchClauseIndentation
    | RuleIdentifier.PatternMatchExpressionIndentation -> Identifiers.PatternMatchExpressionIndentation
    | RuleIdentifier.RecursiveAsyncFunction -> Identifiers.RecursiveAsyncFunction
    | RuleIdentifier.RedundantNewKeyword -> Identifiers.RedundantNewKeyword
    | RuleIdentifier.NestedStatements -> Identifiers.NestedStatements
    | RuleIdentifier.CyclomaticComplexity -> Identifiers.CyclomaticComplexity
    | RuleIdentifier.ReimplementsFunction -> Identifiers.ReimplementsFunction
    | RuleIdentifier.CanBeReplacedWithComposition -> Identifiers.CanBeReplacedWithComposition
    | RuleIdentifier.AvoidSinglePipeOperator -> Identifiers.AvoidSinglePipeOperator
    | RuleIdentifier.UsedUnderscorePrefixedElements -> Identifiers.UsedUnderscorePrefixedElements
    | RuleIdentifier.FailwithWithSingleArgument -> Identifiers.FailwithWithSingleArgument
    | RuleIdentifier.RaiseWithSingleArgument -> Identifiers.RaiseWithSingleArgument
    | RuleIdentifier.NullArgWithSingleArgument -> Identifiers.NullArgWithSingleArgument
    | RuleIdentifier.InvalidOpWithSingleArgument -> Identifiers.InvalidOpWithSingleArgument
    | RuleIdentifier.InvalidArgWithTwoArguments -> Identifiers.InvalidArgWithTwoArguments
    | RuleIdentifier.FailwithfWithArgumentsMatchingFormatString -> Identifiers.FailwithfWithArgumentsMatchingFormattingString
    | RuleIdentifier.FailwithBadUsage -> Identifiers.FailwithBadUsage
    | RuleIdentifier.MaxLinesInLambdaFunction -> Identifiers.MaxLinesInLambdaFunction
    | RuleIdentifier.MaxLinesInMatchLambdaFunction -> Identifiers.MaxLinesInMatchLambdaFunction
    | RuleIdentifier.MaxLinesInValue -> Identifiers.MaxLinesInValue
    | RuleIdentifier.MaxLinesInFunction -> Identifiers.MaxLinesInFunction
    | RuleIdentifier.MaxLinesInMember -> Identifiers.MaxLinesInMember
    | RuleIdentifier.MaxLinesInConstructor -> Identifiers.MaxLinesInConstructor
    | RuleIdentifier.MaxLinesInProperty -> Identifiers.MaxLinesInProperty
    | RuleIdentifier.MaxLinesInModule -> Identifiers.MaxLinesInModule
    | RuleIdentifier.MaxLinesInRecord -> Identifiers.MaxLinesInRecord
    | RuleIdentifier.MaxLinesInEnum -> Identifiers.MaxLinesInEnum
    | RuleIdentifier.MaxLinesInUnion -> Identifiers.MaxLinesInUnion
    | RuleIdentifier.MaxLinesInClass -> Identifiers.MaxLinesInClass
    | RuleIdentifier.InterfaceNames -> Identifiers.InterfaceNames
    | RuleIdentifier.ExceptionNames -> Identifiers.ExceptionNames
    | RuleIdentifier.TypeNames -> Identifiers.TypeNames
    | RuleIdentifier.RecordFieldNames -> Identifiers.RecordFieldNames
    | RuleIdentifier.EnumCasesNames -> Identifiers.EnumCasesNames
    | RuleIdentifier.UnionCasesNames -> Identifiers.UnionCasesNames
    | RuleIdentifier.ModuleNames -> Identifiers.ModuleNames
    | RuleIdentifier.LiteralNames -> Identifiers.LiteralNames
    | RuleIdentifier.NamespaceNames -> Identifiers.NamespaceNames
    | RuleIdentifier.MemberNames -> Identifiers.MemberNames
    | RuleIdentifier.ParameterNames -> Identifiers.ParameterNames
    | RuleIdentifier.MeasureTypeNames -> Identifiers.MeasureTypeNames
    | RuleIdentifier.ActivePatternNames -> Identifiers.ActivePatternNames
    | RuleIdentifier.GenericTypesNames -> Identifiers.GenericTypesNames
    | RuleIdentifier.PublicValuesNames -> Identifiers.PublicValuesNames
    | RuleIdentifier.PrivateValuesNames -> Identifiers.PrivateValuesNames
    | RuleIdentifier.InternalValuesNames -> Identifiers.InternalValuesNames
    | RuleIdentifier.UnnestedFunctionNames -> Identifiers.UnnestedFunctionNames
    | RuleIdentifier.NestedFunctionNames -> Identifiers.NestedFunctionNames
    | RuleIdentifier.MaxNumberOfItemsInTuple -> Identifiers.MaxNumberOfItemsInTuple
    | RuleIdentifier.MaxNumberOfFunctionParameters -> Identifiers.MaxNumberOfFunctionParameters
    | RuleIdentifier.MaxNumberOfMembers -> Identifiers.MaxNumberOfMembers
    | RuleIdentifier.MaxNumberOfBooleanOperatorsInCondition -> Identifiers.MaxNumberOfBooleanOperatorsInCondition
    | RuleIdentifier.FavourIgnoreOverLetWild -> Identifiers.FavourIgnoreOverLetWild
    | RuleIdentifier.WildcardNamedWithAsPattern -> Identifiers.WildcardNamedWithAsPattern
    | RuleIdentifier.UselessBinding -> Identifiers.UselessBinding
    | RuleIdentifier.TupleOfWildcards -> Identifiers.TupleOfWildcards
    | RuleIdentifier.FavourTypedIgnore -> Identifiers.FavourTypedIgnore
    | RuleIdentifier.FavourNonMutablePropertyInitialization -> Identifiers.FavourNonMutablePropertyInitialization
    | RuleIdentifier.FavourReRaise -> Identifiers.FavourReRaise
    | RuleIdentifier.FavourStaticEmptyFields -> Identifiers.FavourStaticEmptyFields
    | RuleIdentifier.FavourConsistentThis -> Identifiers.FavourConsistentThis
    | RuleIdentifier.SuggestUseAutoProperty -> Identifiers.SuggestUseAutoProperty
    | RuleIdentifier.AvoidTooShortNames -> Identifiers.AvoidTooShortNames
    | RuleIdentifier.AsyncExceptionWithoutReturn -> Identifiers.AsyncExceptionWithoutReturn
    | RuleIdentifier.UnneededRecKeyword -> Identifiers.UnneededRecKeyword
    | RuleIdentifier.Indentation -> Identifiers.Indentation
    | RuleIdentifier.MaxCharactersOnLine -> Identifiers.MaxCharactersOnLine
    | RuleIdentifier.TrailingWhitespaceOnLine -> Identifiers.TrailingWhitespaceOnLine
    | RuleIdentifier.MaxLinesInFile -> Identifiers.MaxLinesInFile
    | RuleIdentifier.TrailingNewLineInFile -> Identifiers.TrailingNewLineInFile
    | RuleIdentifier.NoTabCharacters -> Identifiers.NoTabCharacters
    | RuleIdentifier.NoPartialFunctions -> Identifiers.NoPartialFunctions
    | RuleIdentifier.EnsureTailCallDiagnosticsInRecursiveFunctions -> Identifiers.EnsureTailCallDiagnosticsInRecursiveFunctions
    | RuleIdentifier.FavourAsKeyword -> Identifiers.FavourAsKeyword

let ruleToIdentifier = function
    | TypedItemSpacing _ -> RuleIdentifier.TypedItemSpacing
    | TypePrefixing _ -> RuleIdentifier.TypePrefixing
    | UnionDefinitionIndentation _ -> RuleIdentifier.UnionDefinitionIndentation
    | ModuleDeclSpacing _ -> RuleIdentifier.ModuleDeclSpacing
    | ClassMemberSpacing _ -> RuleIdentifier.ClassMemberSpacing
    | TupleCommaSpacing _ -> RuleIdentifier.TupleCommaSpacing
    | TupleIndentation _ -> RuleIdentifier.TupleIndentation
    | TupleParentheses _ -> RuleIdentifier.TupleParentheses
    | PatternMatchClausesOnNewLine _ -> RuleIdentifier.PatternMatchClausesOnNewLine
    | PatternMatchOrClausesOnNewLine _ -> RuleIdentifier.PatternMatchOrClausesOnNewLine
    | PatternMatchClauseIndentation _ -> RuleIdentifier.PatternMatchClauseIndentation
    | PatternMatchExpressionIndentation _ -> RuleIdentifier.PatternMatchExpressionIndentation
    | RecursiveAsyncFunction _ -> RuleIdentifier.RecursiveAsyncFunction
    | RedundantNewKeyword _ -> RuleIdentifier.RedundantNewKeyword
    | NestedStatements _ -> RuleIdentifier.NestedStatements
    | CyclomaticComplexity _ -> RuleIdentifier.CyclomaticComplexity
    | ReimplementsFunction _ -> RuleIdentifier.ReimplementsFunction
    | CanBeReplacedWithComposition _ -> RuleIdentifier.CanBeReplacedWithComposition
    | AvoidSinglePipeOperator _ -> RuleIdentifier.AvoidSinglePipeOperator
    | UsedUnderscorePrefixedElements _ -> RuleIdentifier.UsedUnderscorePrefixedElements
    | FailwithWithSingleArgument _ -> RuleIdentifier.FailwithWithSingleArgument
    | RaiseWithSingleArgument _ -> RuleIdentifier.RaiseWithSingleArgument
    | NullArgWithSingleArgument _ -> RuleIdentifier.NullArgWithSingleArgument
    | InvalidOpWithSingleArgument _ -> RuleIdentifier.InvalidOpWithSingleArgument
    | InvalidArgWithTwoArguments _ -> RuleIdentifier.InvalidArgWithTwoArguments
    | FailwithfWithArgumentsMatchingFormatString _ -> RuleIdentifier.FailwithfWithArgumentsMatchingFormatString
    | FailwithBadUsage _ -> RuleIdentifier.FailwithBadUsage
    | MaxLinesInLambdaFunction _ -> RuleIdentifier.MaxLinesInLambdaFunction
    | MaxLinesInMatchLambdaFunction _ -> RuleIdentifier.MaxLinesInMatchLambdaFunction
    | MaxLinesInValue _ -> RuleIdentifier.MaxLinesInValue
    | MaxLinesInFunction _ -> RuleIdentifier.MaxLinesInFunction
    | MaxLinesInMember _ -> RuleIdentifier.MaxLinesInMember
    | MaxLinesInConstructor _ -> RuleIdentifier.MaxLinesInConstructor
    | MaxLinesInProperty _ -> RuleIdentifier.MaxLinesInProperty
    | MaxLinesInModule _ -> RuleIdentifier.MaxLinesInModule
    | MaxLinesInRecord _ -> RuleIdentifier.MaxLinesInRecord
    | MaxLinesInEnum _ -> RuleIdentifier.MaxLinesInEnum
    | MaxLinesInUnion _ -> RuleIdentifier.MaxLinesInUnion
    | MaxLinesInClass _ -> RuleIdentifier.MaxLinesInClass
    | InterfaceNames _ -> RuleIdentifier.InterfaceNames
    | ExceptionNames _ -> RuleIdentifier.ExceptionNames
    | TypeNames _ -> RuleIdentifier.TypeNames
    | RecordFieldNames _ -> RuleIdentifier.RecordFieldNames
    | EnumCasesNames _ -> RuleIdentifier.EnumCasesNames
    | UnionCasesNames _ -> RuleIdentifier.UnionCasesNames
    | ModuleNames _ -> RuleIdentifier.ModuleNames
    | LiteralNames _ -> RuleIdentifier.LiteralNames
    | NamespaceNames _ -> RuleIdentifier.NamespaceNames
    | MemberNames _ -> RuleIdentifier.MemberNames
    | ParameterNames _ -> RuleIdentifier.ParameterNames
    | MeasureTypeNames _ -> RuleIdentifier.MeasureTypeNames
    | ActivePatternNames _ -> RuleIdentifier.ActivePatternNames
    | GenericTypesNames _ -> RuleIdentifier.GenericTypesNames
    | PublicValuesNames _ -> RuleIdentifier.PublicValuesNames
    | PrivateValuesNames _ -> RuleIdentifier.PrivateValuesNames
    | InternalValuesNames _ -> RuleIdentifier.InternalValuesNames
    | UnnestedFunctionNames _ -> RuleIdentifier.UnnestedFunctionNames
    | NestedFunctionNames _ -> RuleIdentifier.NestedFunctionNames
    | MaxNumberOfItemsInTuple _ -> RuleIdentifier.MaxNumberOfItemsInTuple
    | MaxNumberOfFunctionParameters _ -> RuleIdentifier.MaxNumberOfFunctionParameters
    | MaxNumberOfMembers _ -> RuleIdentifier.MaxNumberOfMembers
    | MaxNumberOfBooleanOperatorsInCondition _ -> RuleIdentifier.MaxNumberOfBooleanOperatorsInCondition
    | FavourIgnoreOverLetWild _ -> RuleIdentifier.FavourIgnoreOverLetWild
    | WildcardNamedWithAsPattern _ -> RuleIdentifier.WildcardNamedWithAsPattern
    | UselessBinding _ -> RuleIdentifier.UselessBinding
    | TupleOfWildcards _ -> RuleIdentifier.TupleOfWildcards
    | FavourTypedIgnore _ -> RuleIdentifier.FavourTypedIgnore
    | FavourNonMutablePropertyInitialization _ -> RuleIdentifier.FavourNonMutablePropertyInitialization
    | FavourReRaise _ -> RuleIdentifier.FavourReRaise
    | FavourStaticEmptyFields _ -> RuleIdentifier.FavourStaticEmptyFields
    | FavourConsistentThis _ -> RuleIdentifier.FavourConsistentThis
    | SuggestUseAutoProperty _ -> RuleIdentifier.SuggestUseAutoProperty
    | AvoidTooShortNames _ -> RuleIdentifier.AvoidTooShortNames
    | AsyncExceptionWithoutReturn _ -> RuleIdentifier.AsyncExceptionWithoutReturn
    | UnneededRecKeyword _ -> RuleIdentifier.UnneededRecKeyword
    | Indentation _ -> RuleIdentifier.Indentation
    | MaxCharactersOnLine _ -> RuleIdentifier.MaxCharactersOnLine
    | TrailingWhitespaceOnLine _ -> RuleIdentifier.TrailingWhitespaceOnLine
    | MaxLinesInFile _ -> RuleIdentifier.MaxLinesInFile
    | TrailingNewLineInFile _ -> RuleIdentifier.TrailingNewLineInFile
    | NoTabCharacters _ -> RuleIdentifier.NoTabCharacters
    | NoPartialFunctions _ -> RuleIdentifier.NoPartialFunctions
    | EnsureTailCallDiagnosticsInRecursiveFunctions _ -> RuleIdentifier.EnsureTailCallDiagnosticsInRecursiveFunctions
    | FavourAsKeyword _ -> RuleIdentifier.FavourAsKeyword