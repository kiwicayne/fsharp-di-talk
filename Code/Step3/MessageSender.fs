namespace Step3

module MessageSender =
  let sendAll getNames writeMessage = getNames() |> Array.iter writeMessage   