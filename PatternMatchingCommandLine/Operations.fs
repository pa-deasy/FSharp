module PatternMatchingCommandLine.Operations

open PatternMatchingCommandLine.Domain

let defaultOptions =
    {orderBy = OrderByName; subdirectories = ExcludeSubdirectories; verbose = TerseOutput}

let parseOption options option =
    match option with 
    | "/v" -> 
        { options with verbose = VerboseOption.VerboseOutput }
    | "/s" ->
        { options with subdirectories = IncludeSubDirectories}
    | "/O" ->
        { options with orderBy = OrderByName }
    | _ -> 
        printfn "%s is not a valid option" option
        options

let parseCommandLine input =
    input 
    |>  List.fold parseOption defaultOptions