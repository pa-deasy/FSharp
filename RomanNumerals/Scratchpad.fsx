
#load "Domain.fs"
#load "Operations.fs"

open RomanNumerals.Domain
open RomanNumerals.Operations


I |> digitToInt
V |> digitToInt
C |> digitToInt


[I;I;I;I] |> digitsToInt
[I;V] |> digitsToInt
[V;I] |> digitsToInt
[V] |> digitsToInt
[V;I;I] |> digitsToInt

let FFVII = RomanNumeral [V;I;I]
FFVII |> toInt

'I' |> charToRomanDigit

"VII" |> toRomanNumeral

"PL" |> toRomanNumeral


let validList = [
    [I;I;I;I]
    [I;V]
    [I;X]
    [I;X;V]
    [V;X]
    [X;I;V]
    [X;I;X]
    [X;X;I;I]
    ]

let testValid = validList |> List.map isValidDigitList

let invalidList = [
    // Five in a row of any digit is not allowed
    [I;I;I;I;I]
    // Two in a row for V,L, D is not allowed
    [V;V] 
    [L;L] 
    [D;D]
    // runs of 2,3,4 in the middle are invalid if next digit is higher
    [I;I;V]
    [X;X;X;M]
    [C;C;C;C;D]
    // three ascending numbers in a row is invalid
    [I;V;X]
    [X;L;D]
    ]

let testInvalid = invalidList |> List.map isValidDigitList

"IIII"  |> toRomanNumeral |> isValid
"IV"  |> toRomanNumeral |> isValid
"" |> toRomanNumeral |> isValid

// error cases
"IIXX" |> toRomanNumeral |> isValid
"VV" |> toRomanNumeral |> isValid

[ "IIII"; "XIV"; "MMDXC"; "VII"; 
"IIXX"; "VV"; ]
|> List.iter parse