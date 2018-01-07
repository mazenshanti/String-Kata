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
      if inp.[2] = '[' then
        delimiter <- string(inp.[3])
      else
        delimiter <- string(inp.[2])
    else delimiter <- ","
  else delimiter <- ","
  delimiter
  
let findMultipleDelimiter (inp: string)=
    let delimiters = new List<string>()
    if inp.Length > 0 then
        if inp.[0] = '/' then
          if inp.[2] = '[' then
              let delimiterL1 = inp.[3..].Split[|'['|]
              for del in delimiterL1 do
                let delimiterL2 = del.Split[|']'|]
                delimiters.Add(string(delimiterL2.[0].[0]))
          else delimiters.Add(string(inp.[2]))
          delimiters
        else delimiters
    else delimiters
    delimiters

let removeCompareThan (nums:int[], tool:string, number:int)=
    if tool = ">" then
        Array.choose (fun x -> if x > number then None else Some(x)) nums
    elif tool = "<" then
        Array.choose (fun x -> if x < number then None else Some(x)) nums
    elif tool = ">=" then
        Array.choose (fun x -> if x >= number then None else Some(x)) nums
    elif tool = "<=" then
        Array.choose (fun x -> if x >= number then None else Some(x)) nums
    else 
        Array.choose (fun x -> if x = number then None else Some(x)) nums
        
let input = Console.ReadLine()
let delimiters = (findMultipleDelimiter (input))
let input2 = input.Replace("\\n",",")
let mutable input3 = input2
for delimiter in delimiters do
    input3 <- input3.Replace(delimiter,",")
let nums = spliter (input3, ',')

let temp = checkForNegatives (nums)
if not(temp.Count > 0) then
  let comp = removeCompareThan (nums, ">", 1000)
  let answer = addArray (comp)
  printfn "%d" answer
else
  try
    raise (InnerError(temp))
  with
    | InnerError(temp) -> printfn "negatives not allowed %A" temp





