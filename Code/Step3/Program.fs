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
   
    let nameReader() = FileNameReader.readNames filePath
    let messageWriter = ConsoleWriter.write "Hello %s"
    MessageSender.sendAll nameReader messageWriter

    let memoryReader() = InMemoryNameReader.readNames
    let debugWriter = DebugWriter.write "Hello from debug %s"
    MessageSender.sendAll memoryReader debugWriter

    // Compiler doesn't allow null's so no need to test for them in code
    //MessageSender.sendAll null null

    // I wouldn't bother with the MessageSender module unless there was a lot of extra logic, so 
    // in reality you would just have NameReaders and Writers modules and the following code.
    nameReader() |> Array.iter messageWriter 

    exit()   
