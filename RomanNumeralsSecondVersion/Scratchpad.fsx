#load "Domain.fs"
#load "Operations.fs"

open RomanNumeralsSecondVersion.Domain
open RomanNumeralsSecondVersion.Operations


IIII |> digitToInt


[IIII]  |> digitsToInt
[IV]  |> digitsToInt
[V;I]  |> digitsToInt
[IX]  |> digitsToInt
[M;CM;L;X;X;IX]  |> digitsToInt // 1979
[M;CM;XL;IV] |> digitsToInt // 1944


let x = RomanNumeral [M;CM;XL;X;IX]
x |> toInt

"IIII"  |> toRomanNumeral
"IV"  |> toRomanNumeral
"VI"  |> toRomanNumeral
"IX"  |> toRomanNumeral
"MCMLXXIX"  |> toRomanNumeral
"MCMXLIV" |> toRomanNumeral
"" |> toRomanNumeral

// error cases
"MC?I" |> toRomanNumeral
"abc" |> toRomanNumeral

// test good cases
"IIII"  |> toRomanNumeral |> isValid
"IV"  |> toRomanNumeral |> isValid
"" |> toRomanNumeral |> isValid

// error cases
"IIXX" |> toRomanNumeral |> isValid
"VV" |> toRomanNumeral |> isValid