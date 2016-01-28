namespace Step4

module Program = 
  open System
  open System.IO
  open Rop
  
  let exit () =
    Console.ReadLine()  |> ignore
    0 

  [<EntryPoint>]
  let main argv = 
    let filePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\names.txt")
   
    let sendMessageToPerson = ConsoleWriter.write "Hello %s"
    let sendMessageToPeople = 
      FileNameReader.readNames 
      >>= iter sendMessageToPerson

    match (sendMessageToPeople filePath) with
    | Success _ -> printfn "\ngoodbye."
    | Failure e -> printfn "\nERROR: Unable to send messages %s" e.Message   

    exit()   
