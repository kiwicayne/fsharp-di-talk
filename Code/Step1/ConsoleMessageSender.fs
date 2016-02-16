namespace Step1
  
  open System;
  open System.IO;

  /// <summary>
  ///   Writes a message to the console for each name in a file
  /// 
  ///   This class has multiple responsibilities.  
  ///   Loading of names from a file and writing messages to a console. 
  /// </summary>
  type ConsoleMessageSender (filename) =
    do 
      if filename |> isNull then raise <| ArgumentNullException("The filename cannot be null")

    /// <summary>
    ///   Send a message to each person loaded from the name file
    /// </summary>
    /// <param name="formattedMessage"></param>
    /// <exception cref="InvalidDataException">The data file must contain at least one line</exception>
    /// <exception cref="FileNotFoundException">The file could not be found</exception>
    member this.Send formattedMessage =
      if not (File.Exists filename) then raise <| FileNotFoundException("The file could not be found")

      let names = File.ReadAllLines filename
      if names = null || names.Length < 1 then raise <| InvalidDataException("The data file must contain at least one line")

      for name in names do
        printfn formattedMessage name