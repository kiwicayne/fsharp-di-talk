namespace Step4

type PersonNames = string []

module FileNameReader = 
    open System
    open System.IO
    open Rop
    open FileValidation
     
    let private toValidList (names: string[]) = 
      if names = null || names.Length < 1 then Result.Failure { Message = "The data file must contain at least one name" }
      else Result.Success (Array.toList names)

    let private readNamesFromFile filename =
        File.ReadAllLines filename
        |> toValidList                

    let readNames = 
        validateFilename
        >>= validateFileExists
        >>= readNamesFromFile        
        
module InMemoryNameReader = 
    let readNames = Rop.Result.Success [ "Rick"; "John"; "Billy" ]
