module _06_TypeProviders
// #r "../lib/FSharp.Data.dll"
open FSharp.Data

type Stocks = CsvProvider<"stockinfo.csv">

let mystockData = Stocks.Load("stockinfo.csv")

printfn "Average volume in the file is: %f" (mystockData.Data |> Seq.map (fun r-> r.Volume) |> Seq.map (fun v-> float v) |> Seq.average)


type Glossary = JsonProvider<"sample-glossary.json">
let myGlossary = Glossary.Load "sample-glossary.json"
printfn "Title: %s" myGlossary.Glossary.Title
myGlossary.Glossary.GlossDiv.GlossList.GlossEntry.GlossDef.GlossSeeAlso |> Seq.iter (fun d-> printfn "See also: %s" d)

//#r "FSharp.Data.TypeProviders"
open Microsoft.FSharp.Data.TypeProviders
type Northwind = ODataService<"http://services.odata.org/Northwind/Northwind.svc">
let db = Northwind.GetDataContext()

// A query expression.
let query1 = query { for customer in db.Customers do
                     select customer }

query1
|> Seq.iter (fun customer -> printfn "Company: %s Contact: %s" customer.CompanyName customer.ContactName)
