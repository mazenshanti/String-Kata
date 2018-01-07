open System

let addArray (arr) = Array.sum arr

let strContainsOnlyNumber (s:string) = System.Int32.TryParse s |> fst

let strip (stripChars:string) (text:string) =
    text.Split(stripChars.ToCharArray(), StringSplitOptions.RemoveEmptyEntries) |> String.Concat
    
let spliter (strs : string, splitType) = 
  let mutable nums = Array.zeroCreate 1
  if strs.Length > 0 then
    let strsSplit = strs.Split[|splitType|]
    let strLength = strsSplit.Length
    nums <- Array.zeroCreate strLength
    let mutable count = 0
    for str in strsSplit do
      if (strContainsOnlyNumber (str)) = true then
        nums.[count] <- int(str)
        count <- count + 1
    nums
  else
  nums
    

let input = (Console.ReadLine()).Replace("\\n",",")
let nums = spliter (input, ',')
let answer = addArray (nums)
printfn "%d" answer