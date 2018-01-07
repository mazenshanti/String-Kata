open System

let addString (x, y) = int(x) + int(y)

let add (str : string) = 
    let mutable sum = 0
    if str.Length > 0 then
      let strSplit = str.Split[|','|]
      let strLength = strSplit.Length
      if strLength = 1 then 
        sum <- addString (strSplit.[0], "0")
      elif strLength = 2 then
        sum <- addString (strSplit.[0], strSplit.[1])
      else sum <- -1
    else sum <- 0
    sum

let input = Console.ReadLine()
let answer = add(input)
printfn "%d" answer