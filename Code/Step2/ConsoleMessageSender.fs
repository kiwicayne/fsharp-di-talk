namespace Step2

module ConsoleMessageSender =
  
  open System;
  open System.IO;

  // This removes the class and moves the logic into a simple function
  // encapsulated within a module
  let send filename formattedMessage =
    if filename |> isNull then raise <| ArgumentNullException("The filename cannot be null")
    if not (File.Exists filename) then raise <| FileNotFoundException("The file could not be found")

    let names = File.ReadAllLines filename
    if names = null || names.Length < 1 then raise <| InvalidDataException("The data file must contain at least one line")

    for name in names do
      printfn formattedMessage name
