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
    // A lambda function that when called reads names from a file into an array
    let getNames = (fun _ -> NameReader3.readNames filePath)
    // send calls the getNames function and for each name say hello
    ConsoleMessageSender3.send getNames "Hello %s"  
    
  // A more functional solution is to pipe functions together, rather than pass in a function as a parameter
  // This requires the name being the last parameter on the send function
  // We can use partial application on the send function, makes the code very readable...
  let runExample4 filePath =
    // partial application
    let sendMessage = ConsoleMessageSender4.send "Hello %s" // what happens if you change to %d?

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
    
    // DEPENDENCY INJECTION EXAMPLE!!!
        
    // Create a new function that takes a sender function, with the filePath dependency already applied
    // this could be done in a bootstrapper...
    let runExample4 = runExample4WithFunc filePath 
    
    // We could user any "sender" that has the type (string -> unit)
    // also could be done in a bootstrapper...
    let sendMessageToConsole = ConsoleMessageSender4.send "Hello %s" 
    
    runExample4 sendMessageToConsole
    
    exit()   
