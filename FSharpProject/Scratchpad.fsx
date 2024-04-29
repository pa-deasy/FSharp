
#r @"C:\Users\Pa-De\source\repos\FSharpProject\CSharpProject\bin\Debug\netstandard2.0\CSharpProject.dll"

open CSharpProject
open System.Collections.Generic
open System

let nicole = Person "Nicole"

nicole.PrintName()

let longhand =
    ["Patrick"; "Michael"; "Jimmy"; "Kathleen"]
    |> List.map(fun name -> Person(name))

let shorthand = 
    ["Patrick"; "Michael"; "Jimmy"; "Kathleen"]
    |> List.map Person


shorthand |> List.map(fun person -> person.PrintName())

type PersonComparer() =
    interface IComparer<Person> with 
    member this.Compare(x, y) = x.Name.CompareTo(y.Name)

let pComparer = PersonComparer():> IComparer<Person>
pComparer.Compare(nicole, Person "Denise")

let p2Comparer = 
    { new IComparer<Person> with
    member this.Compare(x, y) = x.Name.CompareTo(y.Name)}


let blank:string = null
let name = "Vera"
let number = Nullable 10
let blankAsOption = blank |> Option.ofObj
let nameAsOption = name |> Option.ofObj
let numbberAsOption = number |> Option.ofNullable
let unsafeName = Some "Fred" |> Option.toObj