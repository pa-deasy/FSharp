module RomanNumerals.Domain

type RomanDigit = I | V | X |L | C | D | M

type RomanNumeral = RomanNumeral of RomanDigit list

type ParsedChar =
    | Digit of RomanDigit
    | BadChar of char

