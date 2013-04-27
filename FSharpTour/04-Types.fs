module typesdemo

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


