/////////////////////////////////////////////////////////////
//Patricks attempt at understanding the problem
/////////////////////////////////////////////////////////////

#load "PatricksDomain.fs"
#load "PatricksOperations.fs"

open PatternMatchingCommandLine.PatricksDomain
open PatternMatchingCommandLine.PatricksOperations


let verboseTrue = Verbose Flag.Enabled
let subDirFalse = Subdir Flag.Disabled
let orderByName = Order OrderBy.Name
let optionsList =[ verboseTrue; subDirFalse; orderByName]

verboseTrue |> executeArgument

subDirFalse |> executeArgument

orderByName |> executeArgument

optionsList |> executeArguments


/////////////////////////////////////////////////////////////
//Example from website
/////////////////////////////////////////////////////////////

#load "Domain.fs"
#load "Operations.fs"

open PatternMatchingCommandLine.Domain
open PatternMatchingCommandLine.Operations


"/v" |> parseOption defaultOptions 


parseCommandLine ["/v"; "/s"] 

parseCommandLine ["/v"; "/k"] 