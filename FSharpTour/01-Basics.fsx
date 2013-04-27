(* Basics of F# *)

let x = 12;;
let y = 5

printfn "%d" (x + y);;
// Cannot do this printfn "%s" (x + y);;

let add x y = x + y
add x y |> printfn "%d";;
y |> add x |> printfn "%d";;

// Can use C# classes
open System
Console.WriteLine "Hello world"
Console.WriteLine("Hello, {0}", "Bob")