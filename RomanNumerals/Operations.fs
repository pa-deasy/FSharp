module RomanNumerals.Operations

open RomanNumerals.Domain

let digitToInt =
    function
    | I -> 1
    | V -> 5
    | X -> 10
    | L -> 50
    | C -> 100
    | D -> 500
    | M -> 1000

let rec digitsToInt = 
    function
    | [] -> 0
    | smaller::larger::ns when smaller < larger ->
        (digitToInt larger - digitToInt smaller) + digitsToInt ns
    | digit::ns ->
        digitToInt digit + digitsToInt ns

let toInt (RomanNumeral digits) =
    digitsToInt digits

let charToRomanDigit = 
    function
    | 'I' -> Digit I
    | 'V' -> Digit V
    | 'X' -> Digit X
    | 'L' -> Digit L
    | 'C' -> Digit C
    | 'D' -> Digit D
    | 'M' -> Digit M
    | ch -> BadChar ch

let toRomanDigitsList (s:string) =
    s.ToCharArray()
    |> List.ofArray
    |> List.map charToRomanDigit

let toRomanNumeral s = 
    s |> toRomanDigitsList
    |> List.choose (
        function 
        | Digit digit -> 
            Some digit
        | BadChar char ->
            eprintf "%c is not a valid character" char 
            None
       )
    |> RomanNumeral

let runsAllowed =
    function
    | I | X | C | M -> true
    | V | L | D -> false

let noRunsAllowed = runsAllowed >> not

let rec isValidDigitList digitList =
    match digitList with
    | [] -> true

    | d1::d2::d3::d4::d5::_ 
        when d1=d2 && d1=d3 && d1=d4 && d1=d5 -> 
            false

    | d1::d2::_
        when d1=d2 && d1 |> noRunsAllowed ->
        false

    | d1::d2::d3::d4::higher::ds
        when d1=d2 && d1=d3 && d1=d4
        && d1 |> runsAllowed
        && higher > d1 ->
            false

    | d1::d2::d3::higher::ds
        when d1=d2 && d1=d3
        && d1 |> runsAllowed
        && higher > d1 ->
            false

    | d1::d2::higher::ds
        when d1=d2
        && d1 |> runsAllowed
        && higher > d1 ->
            false

    | d1::d2::d3::_
        when d1<d2 && d2<=d3 ->
        false

    | _::ds ->
        ds |> isValidDigitList

let isValid (RomanNumeral digitList) =
    digitList |> isValidDigitList

let parse input = 
    input |> toRomanNumeral
    |> (function
        | n when n |> isValid ->
            printfn "%A is valid and it's integer is %i" n (n |> toInt)
        | n -> 
            printfn "%A is not valid" n
        )