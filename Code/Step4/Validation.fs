namespace Step4

module Validation =
    open Rop

module FileValidation =
    open System.IO
    open Rop

    let validateFilename (filename) = 
        if filename = null then Result.Failure { Message = "The filename cannot be null" }
        else Result.Success filename

    let validateFileExists (filename) =
        if not (File.Exists filename) then Result.Failure { Message = "The file could not be found" }
        else Result.Success filename