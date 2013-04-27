module typesdemo

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


