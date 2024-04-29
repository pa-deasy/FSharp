module PropertyBasedTesting.Calculator

let add x y =
    if (x < 25) || (y < 25) then
        x + y
    else
        x * y
