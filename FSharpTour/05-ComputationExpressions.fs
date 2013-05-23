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


(* so are async workflows *)
open System.Net
open Microsoft.FSharp.Control.WebExtensions

let urlList = [ "Microsoft.com", "http://www.microsoft.com/" 
                "MSDN", "http://msdn.microsoft.com/" 
                "Bing", "http://www.bing.com"
                "Google", "http://www.google.com"
              ]

let fetchAsync(name, url:string) =
    async { 
        try 
            let uri = new System.Uri(url)
            let webClient = new WebClient()
            let! html = webClient.AsyncDownloadString(uri)
            printfn "Read %d characters for %s" html.Length name
        with
            | ex -> printfn "%s" (ex.Message);
    }

let runAll() =
    urlList
    |> Seq.map fetchAsync
    |> Async.Parallel 
    |> Async.RunSynchronously
    |> ignore

runAll()




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
        printfn "Returning %A" x
        x

let logged = new LoggingBuilder()

let cleanedWorflow = logged {
    let! x = 12
    let! y = 15
    let! sum = x + y
    return sum
}

type NullSafeBuilder() =
    member this.Bind(x, f) =
        if x = null then
            printfn "Got null. bailing out early"
            x
        else
            printfn "Proceeding because %A is not null" x
            f x

    member this.Return(x) = 
        printfn "Returning %A" x
        x

let nullsafe = new NullSafeBuilder()


let head x:string = nullsafe {
    let! n = x
    return n.Substring(0,1)
}

head null
head "fawad"