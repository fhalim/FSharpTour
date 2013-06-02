let ilist = [1;2;3;4]
let cleanerlist = [1..100]
let iarr = [|1;2;3;4|]
let iseq = seq {1..100}
let evenseq = seq {2..2..10}
let moreevens = seq {for x in 2..100 do if x % 2 = 0 then yield x}

let multiplicationTable =
  seq { for i in 1..9 do 
            for j in 1..9 do 
               yield (i, j, i*j) }

multiplicationTable
|> Seq.take 20
|> Seq.iter (fun t -> match t with
    |(i, j, sum) -> printfn "%i * %i = %i" i j sum)

let dude = ("Jeffrey", "Lebowski", 42)  // Not a collection