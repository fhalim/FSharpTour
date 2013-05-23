module _06_TypeProviders
// #r "../lib/FSharp.Data.dll"
open FSharp.Data

type Stocks = CsvProvider<"stockinfo.csv">

let mystockData = Stocks.Load("stockinfo.csv")

printfn "Average volume in the file is: %f" (mystockData.Data |> Seq.map (fun r-> r.Volume) |> Seq.map (fun v-> float v) |> Seq.average)