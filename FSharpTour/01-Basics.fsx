(* Basics of F# *)

let x = 12;;
let y = 5

// Cannot do this
x = 13;;

let mutable mx = 12;;
mx <- 13;;

printfn "%d" (x + y);;
// Cannot do this printfn "%s" (x + y);;

let aunit = printfn "Hello"

let add x y = x + y
add x y |> printfn "%d";;
y |> add x |> printfn "%d";;


// Can use C# classes
open System
Console.WriteLine "Hello world"
Console.WriteLine("Hello, {0}", "Bob")


// Higher order function
let doStuffAndDouble fn x = fn x * 2
doStuffAndDouble (fun x-> x + 2) 5
doStuffAndDouble String.length "bob"

let mynum1 = 5
let mynumfunc() = 5
mynumfunc()


do (1+1 |> ignore)

open System.IO
let readfile (fileName:string) =
    use sr = new StreamReader(fileName)
    let length = sr.ReadToEnd().Length
    printfn "Length is %d" length

readfile @"c:\windows\DPINST.LOG"