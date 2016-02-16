open System
open System.IO;
open Step1

let exit () =
  printfn "\ngoodbye."
  Console.ReadLine()  |> ignore
  0

let runExample () =
  let filePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\names.txt")
  let sender = new ConsoleMessageSender(filePath) 
  // NOTE: could also write: let sender = ConsoleMessageSender filePath
  sender.Send("Hello %s")

[<EntryPoint>]
let main argv =     
    runExample()

    exit()
