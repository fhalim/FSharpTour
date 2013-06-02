let rec fac x =
    match x with
    | 0|1 -> 1
    | _ -> x * fac(x-1)

fac 30

let fac2 x =
    let rec facWithAccumulator n acc =
        match n with
        | 0|1 -> acc
        | _ -> facWithAccumulator(n-1) (acc * n)
    facWithAccumulator x 1

fac2 30




let rec tryFindMatch pred list =
    match list with
    | head :: tail -> if pred(head)
                        then Some(head)
                        else tryFindMatch pred tail
    | [] -> None
// val tryFindMatch : pred:('a -> bool) -> list:'a list -> 'a option

tryFindMatch (fun v-> v = 12) [14;16;3;4]
tryFindMatch (fun v-> v = "groucho") ["larry"; "curly"; "moe"; "shemp"]