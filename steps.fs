open System
open System.Collections.Generic
exception InnerError of List<int>

let addArray (arr) = Array.sum arr

let strContainsOnlyNumber (s:string) = System.Int32.TryParse s |> fst

let strip (stripChars:string) (text:string) =
    text.Split(stripChars.ToCharArray(), StringSplitOptions.RemoveEmptyEntries) |> String.Concat
    

let checkForNegatives (arr)= 
  let temp = new List<int>()
  let positive = new List<int>()
  let mutable x = 0
  for ar in arr do
    match ar < 0 with
    | true -> temp.Add(ar)
    | false -> positive.Add(ar)
  temp
   
    
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
  let mutable delimiter = ","
  if inp.Length > 0 then
    if inp.[0] = '/' then
      delimiter <- string(inp.[2])
    else delimiter <- ","
  else delimiter <- ","
  delimiter
  
let input = Console.ReadLine()
let delimiter = (findDelimiter (input))
let input2 = input.Replace("\\n",delimiter)
let nums = spliter (input2, delimiter.[0])
let temp = checkForNegatives (nums)
if not(temp.Count > 0) then
  let answer = addArray (nums)
  printfn "%d" answer
else
  try
    raise (InnerError(temp))
  with
    | InnerError(temp) -> printfn "negatives not allowed %A" temp
  





