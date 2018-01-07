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

let findDelimiter (inp: string)= 
  let mutable delimiter = ""
  if inp.[0] = '/' then
    delimiter <- string(inp.[2])
  else delimiter <- ","
  delimiter
    
let input = Console.ReadLine()
let delimiter = (findDelimiter (input))
let input2 = input.Replace("\\n",delimiter)
let nums = spliter (input2, delimiter.[0])

let answer = addArray (nums)
printfn "%d" answer





