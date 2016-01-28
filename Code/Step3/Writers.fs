namespace Step3

module ConsoleWriter =    
  let write formattedMessage (name: string) = printfn formattedMessage name

module DebugWriter =
  let write formattedMessage (name: string) = 
    System.Diagnostics.Debug.WriteLine <| (sprintf formattedMessage name)