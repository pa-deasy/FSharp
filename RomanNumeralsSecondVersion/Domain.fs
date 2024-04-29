module RomanNumeralsSecondVersion.Domain

type RomanDigit =
    | I | II | III | IIII
    | IV | V 
    | IX | X | XX | XXX | XXXX
    | XL | L
    | XC | C | CC | CCC | CCCC
    | CD | D
    | CM | M | MM | MMM | MMMM

type RomanNumeral = RomanNumeral of RomanDigit list

type ParsedChar = 
    | Digit of RomanDigit
    | BadChar of char