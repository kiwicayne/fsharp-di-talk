namespace Step2

// A big part of Functional programming is composing functions together, so we will split things up
// Also introduce forward piping
module ConsoleMessageSender2 =

  open System;
  open System.IO;

  // Scoped private to module
  let private readNames filename =
    if filename |> isNull then raise <| ArgumentNullException("The filename cannot be null")
    if not (File.Exists filename) then raise <| FileNotFoundException("The file could not be found")

    let names = File.ReadAllLines filename
    if names = null || names.Length < 1 then raise <| InvalidDataException("The data file must contain at least one line")
    names


  let send filename formattedMessage =
    readNames filename // read names from file into an array    
    |> Array.iter (printfn formattedMessage) // iterate over each item in array executing the print action

    // could also have done this
    // string -> unit
    // let printMessage = printfn formattedMessage
    // Arrary.iter printMessage