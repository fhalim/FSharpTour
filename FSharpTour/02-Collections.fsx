let ilist = [1;2;3;4]
let iarr = [|1;2;3;4|]
let iseq = seq {1..10}  // 1-> 10
let evenseq = seq {2..2..10}
let moreevens = seq {for x in 2..100 do if x % 2 = 0 then yield x}

let multiplicationTable =
  seq { for i in 1..9 do 
            for j in 1..9 do 
               yield (i, j, i*j) }

let dude = ("Jeffrey", "Lebowski", 42)  // Not a collection

