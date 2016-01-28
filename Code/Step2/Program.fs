namespace Step2

module Program =
  open System
  open System.IO;
  open Step2.ConsoleMessageSender
  open Step2.ConsoleMessageSender2
  open Step2.ConsoleMessageSender3
  open Step2.ConsoleMessageSender4

  let exit () =
    printfn "\ngoodbye."
    Console.ReadLine()  |> ignore
    0

  // This is same as Step1, exceptions are thrown when something goes wrong despite them being
  // things we should expect to happen
  let runExample filePath =  
    ConsoleMessageSender.send filePath "Hello %s"

  let runExample2 filePath =  
    ConsoleMessageSender2.send filePath "Hello %s"    

  let runExample3 filePath =  
    let getNames = (fun _ -> NameReader3.readNames filePath)
    ConsoleMessageSender3.send getNames "Hello %s"  
    
  // A more functional solution is to pipe functions together, rather than pass in a function as a parameter
  // This requires the name being the last parameter on the send function
  let runExample4 filePath =  
    NameReader4.readNames filePath
    |> Array.iter (ConsoleMessageSender4.send "Hello %s") // what happens if you change to %d?

  // We can use partial application on the send function, makes the code very readable...
  let runExample4Again filePath =
    let sendMessage = ConsoleMessageSender4.send "Hello %s"
    NameReader4.readNames filePath
    |> Array.iter sendMessage

  // Parameterize sending the message.  
  let runExample4WithFunc filePath sendMessage =
    NameReader4.readNames filePath
    |> Array.iter sendMessage

  [<EntryPoint>]
  let main argv =     
    let filePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\names.txt")

    printfn "Running example 1..."
    runExample filePath

    printfn "Running example 2..."
    runExample2 filePath

    printfn "Running example 3..."
    runExample3 filePath

    printfn "Running example 4..."
    runExample4 filePath

    printfn "Running example 4 again..."
    // Using example 4 with parameterized send message, partial application.  Looks like dependency injection...
    let runExample4 = runExample4WithFunc filePath // a function that takes a sender, filePath dependency already applied, could be done in a bootstrapper
    let sendMessageToConsole = ConsoleMessageSender4.send "Hello %s" // We could user any "sender" that has the type (string -> unit)
    
    runExample4 sendMessageToConsole
    
    exit()   
