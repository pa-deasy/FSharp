module PatternMatchingCommandLine.PatricksOperations

open PatternMatchingCommandLine.PatricksDomain

let executeArgument argument = 

    match argument with
    | Verbose v -> 
        match v with
        | Enabled ->
            printfn "Verbose enabled"
        | Disabled ->
            printfn "Verbose disabled"
    | Subdir s ->
        match s with
        | Enabled ->
            printfn "Subdir enabled"
        | Disabled ->
            printfn "Subdir disabled"
    | Order order -> 
        match order with
        | Name -> 
            printfn "Order by name"
        | Size ->
            printfn "Order by size"

let executeArguments arguments =
    List.map(fun e -> e |> executeArgument)