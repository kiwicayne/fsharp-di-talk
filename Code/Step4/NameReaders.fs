namespace Step4

type PersonNames = string []

module FileNameReader = 
    open System
    open System.IO
    open Rop
    open FileValidation
       
    let readNamesFromFile filename =
        let names = File.ReadAllLines filename
        if names = null || names.Length < 1 then Result.Failure { Message = "The data file must contain at least one name" }
        else Result.Success (Array.toList names)

    let readNames = 
        validateFilename
        >>= validateFileExists
        >>= readNamesFromFile
        
module InMemoryNameReader = 
    let readNames = Rop.Result.Success [ "Rick"; "John"; "Billy" ]
