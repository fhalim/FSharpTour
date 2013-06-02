module typesdemo

(* Units of measure *)
[<Measure>] type sec
let x = 12<sec>
[<Measure>] type m
let y = 145<m>
// y/x + 3




(* Classes *)

type Animal =
    abstract member Speak : unit -> string

type Dog() =
    interface Animal with
        member this.Speak() = "woof"

let dogAsAnimal = new Dog() :> Animal
printfn "%s" (dogAsAnimal.Speak())

let speak (a:Animal) = printfn "%s" (a.Speak())
speak (new Dog())

type Cat() =
    static let sound = "meow"
    member this.Speak() = (this :> Animal).Speak()
    interface Animal with
        member this.Speak() = sound

printfn "%s" ((new Cat()).Speak())

(* Object expression *)
speak {new Animal with member this.Speak() = "moo"}


type GenericAnimal(sound:string) =
    member val Prelude = "" with get, set
    interface Animal with
        member this.Speak() = sprintf "%s%s" this.Prelude sound
        

speak(new GenericAnimal("zoink!", Prelude = "Hello"))



(* Records *)
type Person = {firstName:string; lastName:string; nickName: string; abides:bool}
let dude = {firstName = "Jeffrey"; lastName = "Lebowski"; nickName = "The dude"; abides = true}
let mrlebowski = {firstName = "Jeffrey"; lastName = "Lebowski"; nickName = "Mr. Lewbowski"; abides = false}

printfn "%b" (dude = mrlebowski)

let bunnyLebowski = {mrlebowski with firstName="Bunny"}

let doesAbide person =
    match person with
    | {firstName = _; lastName = _; nickName = _; abides = true} -> person.nickName + " abides"
    | _ -> person.nickName + " shall have none of this nonsense"

printfn "%s" (doesAbide dude)
printfn "%s" (doesAbide mrlebowski)

(* Mutable records *)
type PersonWithAge = {name:string; mutable age:int}
let bob = {name = "Bob"; age = 17}
bob.age <- bob.age + 1




(* Discriminated unions *)
type 'a Expression =
    | Constant of 'a
    | Add of ('a Expression) * ('a Expression)

let one = Constant(1)
let two = Constant(2)

let sum = Add(one, two)

let rec calc exp =
    match exp with
    | Constant(x)   -> x
    | Add(x,y)      -> (calc x) + (calc y)

calc sum







(* Inlining *)

let inline divide a b = a / b

divide 1 2
divide 1.0 2.0









(* Active Pattern
   http://fssnip.net/B *)

open System

// definition of the active pattern
let (|Bool|Int|Float|String|) input =
    // attempt to parse a bool
    let sucess, res = Boolean.TryParse input
    if sucess then Bool(res)
    else 
        // attempt to parse an int
        let sucess, res = Int32.TryParse input
        if sucess then Int(res)
        else
            // attempt to parse a float (Double)
            let sucess, res = Double.TryParse input
            if sucess then Float(res)
            else String(input)

// function to print the results by pattern
// matching over the active pattern
let printInputWithType input =
    match input with
    | Bool b -> printfn "Boolean: %b" b
    | Int i -> printfn "Integer: %i" i
    | Float f -> printfn "Floating point: %f" f
    | String s -> printfn "String: %s" s

// print the results    
printInputWithType "true"
printInputWithType "12"
printInputWithType "-12.1"
