module ComputationExpressions

(* seqs are computation expressions *)
let colors = [|"red";"green";"blue"|]
let vehicles = ["car";"truck";"bus"]
let myseq = seq {
    for color in colors do
    for vehicle in vehicles do
    yield sprintf "A %s %s" color vehicle
}
Seq.iter (printfn "%s") myseq


(* Make some of our own *)
let log x = printfn "Value: %A" x

let initialWorkflow =
    let x = 12
    log x
    let y = 15
    log y
    let sum = x + y
    log sum

type LoggingBuilder() =
    member this.Bind(x, f) = 
        log x
        f x

    member this.Return(x) = 
        x

let logged = new LoggingBuilder()

let cleanedWorflow = logged {
    let! x = 12
    let! y = 15
    let! sum = x + y
    return ()
}