namespace Step2

// The arguments of the send function are swapped to allow piping
// rather than dealing with an array of names, the message sender will 
// just handle one name at a time, moving logic for iteration to the caller.
// This allows for more flexibility when dealing with functional collection operations
// like map, reduce, iterate etc

// No changes here.  It knows nothing about the ConsuleMessageSender4 module
module NameReader4 =
  open System;
  open System.IO;

  let readNames filename =
    if filename = null then raise <| ArgumentNullException("The filename cannot be null")
    if not (File.Exists filename) then raise <| FileNotFoundException("The file could not be found")

    let names = File.ReadAllLines filename
    if names = null || names.Length < 1 then raise <| InvalidDataException("The data file must contain at least one line")
    names

// This now just defines how to send a message to a single person, it has no relationship to NameReader4 at all
module ConsoleMessageSender4 =

  // Look at the signiture.  Name no longer needs to be a string, this is very generic
  let send formattedMessage name =
    printfn formattedMessage name