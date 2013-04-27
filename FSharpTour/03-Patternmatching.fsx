let rec tryFindMatch pred list =
    match list with
    | head :: tail -> if pred(head)
                        then Some(head)
                        else tryFindMatch pred tail
    | [] -> None
// val tryFindMatch : pred:('a -> bool) -> list:'a list -> 'a option

tryFindMatch (fun v-> v = 12) [14;16;3;4]
tryFindMatch (fun v-> v = "groucho") ["larry"; "curly"; "moe"; "shemp"]