module PatternMatchingCommandLine.OperationsTests

open PatternMatchingCommandLine.Domain
open PatternMatchingCommandLine.Operations
open NUnit.Framework

[<SetUp>]
let Setup () =
    ()

[<Test>]
let ``when /v passed, then verbose logging is parsed`` () =
    let result = "/v" |> parseOption defaultOptions
    Assert.AreEqual(result.verbose, VerboseOutput)

[<Test>]
let ``when /s passed, then subdirectories included`` () =
    let result = "/s" |> parseOption defaultOptions
    Assert.AreEqual(result.subdirectories, IncludeSubDirectories)