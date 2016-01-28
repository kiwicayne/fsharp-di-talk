namespace Step4

module ConsoleWriter =    
    let write formattedMessage (name: string) =  
        Rop.Result.Success (printfn formattedMessage name)
        

module DebugWriter =
    let write formattedMessage (name: string) = 
        Rop.Result.Success (System.Diagnostics.Debug.WriteLine <| (sprintf formattedMessage name))