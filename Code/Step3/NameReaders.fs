namespace Step3

module FileNameReader =

  open System;
  open System.IO;
  
  let readNames filename =
    if filename |> isNull then raise <| ArgumentNullException("The filename cannot be null")
    if not (File.Exists filename) then raise <| FileNotFoundException("The file could not be found")

    let names = File.ReadAllLines filename
    if names = null || names.Length < 1 then raise <| InvalidDataException("The data file must contain at least one line")
    names

module InMemoryNameReader =
  
  let readNames = [|"Rick"; "John"; "Billy"|]