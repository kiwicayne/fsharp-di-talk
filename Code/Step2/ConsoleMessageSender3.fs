namespace Step2

// As in Step2 of the C# demo we split the reading of names from the sending of names, lets do that here now
// This reproduces how the C# code did it by using a lamba expression rather than an interface, however in the next
// attempt we will remove it and show another way if names don't have to be retrieved on each call.
module NameReader3 =
  open System;
  open System.IO;

  let readNames filename =
    if filename |> isNull then raise <| ArgumentNullException("The filename cannot be null")
    if not (File.Exists filename) then raise <| FileNotFoundException("The file could not be found")

    let names = File.ReadAllLines filename
    if names = null || names.Length < 1 then raise <| InvalidDataException("The data file must contain at least one line")
    names

module ConsoleMessageSender3 =

  let send (getNames: _ -> string[]) (formattedMessage) =
    getNames() |> Array.iter (printfn formattedMessage)