namespace Step3

module ConsoleWriter =    
  let write messageFormat (name: string) = printfn messageFormat name

module DebugWriter =
  let write messageFormat (name: string) = 
    System.Diagnostics.Debug.WriteLine <| (sprintf messageFormat name)