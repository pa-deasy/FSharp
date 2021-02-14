module PropertyBasedTesting.CalculatorTests

open NUnit.Framework
open PropertyBasedTesting.Calculator
open FsCheck

[<SetUp>]
let Setup () =
    ()

let config = {
    Config.Quick with 
        EndSize = 1000
}

let rand = System.Random()
let randomInt = rand.Next()

//let propertyCheck (property : (int -> int -> bool)) =
//    for _ in [1..100] do
//        let x = randomInt
//        let y = randomInt
//        let result = property x y
//        Assert.IsTrue(result)

let commutativeProperty x y =
    let result1 = add x y
    let result2 = add y x
    result1 = result2

[<Test>]
let ``When 2 numbers are added, then the order of the paramters does not matter`` () =
    commutativeProperty |> Check.Quick

let adding1TwiceIsAdding2OnceProperty x _ =
    let plusOneTwice = x |> add 1 |> add 1
    let plusTwoOnce = x |> add 2
    plusOneTwice = plusTwoOnce

[<Test>]
let ``When one is added twice, then it is the same as adding two`` () =
    adding1TwiceIsAdding2OnceProperty |> Check.Quick

let identityProperty x _ = 
    let plusZero = add x 0
    plusZero = x

[<Test>]
let ``When adding zero, then result is same as doing nothing`` () =
    identityProperty |> Check.Verbose

let associativeProperty x y z =
    let result1 = add (add x y) z
    let result2 = add x (add y z)
    result1 = result2

[<Test>]
let ``When adding x and y with z, then the result is the same as adding y and z with x`` () =
    Check.One(config, associativeProperty)


//[<Test>]
//let ``When I add 1 + 2, I expect 3`` ()=
//    let result = Add 1 2
//    Assert.AreEqual(3, result)
//
//[<Test>]
//let ``When I add 12 + 77, I expect 89`` () =
//    let result = Add 12 77
//    Assert.AreEqual(89, result)
//
//[<Test>]
//let ``When 2 random numbers are added, the sum is expected`` () =
//    for _ in [1..100] do
//        let x = randomInt
//        let y = randomInt
//
//        let result = Add x y
//        Assert.AreEqual(x + y, result)