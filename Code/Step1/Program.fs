open System
open System.IO;
open Step1

let exit () =
  printfn "\ngoodbye."
  Console.ReadLine()  |> ignore
  0

let runExample () =
  let filePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\names.txt")
  let sender = new ConsoleMessageSender(filePath) // NOTE: new can be left off
  sender.send("Hello %s")

[<EntryPoint>]
let main argv =     
    runExample()

    exit()   
