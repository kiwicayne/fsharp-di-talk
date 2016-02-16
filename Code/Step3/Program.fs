namespace Step3

module Program = 
  open System
  open System.IO
  
  let exit () =
    printfn "\ngoodbye."
    Console.ReadLine()  |> ignore
    0 

  [<EntryPoint>]
  let main argv = 
    let filePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\names.txt")
   
    // The use of () just means nameReader is a function that takes a single parameter of type unit
    // otherwise it would execute immediately.  Could also write it as a lambda.
    let readNamesFromFile() = FileNameReader.readNames filePath
    let writeMessageToConsole = ConsoleWriter.write "Hello %s"
    MessageSender.sendAll readNamesFromFile writeMessageToConsole

    let readNamesFromMemory() = InMemoryNameReader.readNames
    let writeMessageToDebugger = DebugWriter.write "Hello from debug %s"
    MessageSender.sendAll readNamesFromMemory writeMessageToDebugger

    // Compiler doesn't allow null's so no need to test for them in code
    // MessageSender.sendAll null null

    // I wouldn't bother with the MessageSender module unless there was a lot of extra logic, so 
    // in reality you would just have NameReaders and Writers modules and the following code.
    readNamesFromFile() |> Array.iter writeMessageToConsole 

    exit()   
