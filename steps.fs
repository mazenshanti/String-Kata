open System

let addArray (arr) = Array.sum arr

let spliter (strs : string) = 
  let mutable nums = Array.zeroCreate 1
  if strs.Length > 0 then
    let strsSplit = strs.Split[|','|]
    let strLength = strsSplit.Length
    nums <- Array.zeroCreate strLength 
    for i in [0 .. (strLength - 1)] do
      nums.[i] <- int(strsSplit.[i])
    nums
  else
  nums
    

let input = Console.ReadLine()
let nums = spliter (input)
let answer = addArray (nums)
printfn "%d" answer