namespace Step4

module FileNameReader = 
    open System
    open System.IO
    open Rop
    open FileValidation
     
    let private toValidList (names: string[]) = 
      if isNull names || names.Length < 1 then Result.Failure { Message = "The data file must contain at least one name" }
      else Result.Success (Array.toList names)

    let private readNamesFromFile filename =
        File.ReadAllLines filename
        |> toValidList                

    // Very easy to understand!  No cyclomatic complexity.  No try/catch logic or if statements.
    let readNames = 
        validateFilename
        >>= validateFileExists
        >>= readNamesFromFile        
        
module InMemoryNameReader = 
    let readNames = Rop.Result.Success [ "Rick"; "John"; "Billy" ]
