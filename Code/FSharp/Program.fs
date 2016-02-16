open System

[<EntryPoint>]
let main argv =     
  // Define a value
  let three = 3
  // Spaces in value name (great for unit test naming)
  let ``this is six`` = 6

  // list
  let list = [1;2;3;4]
  // array
  let array = [|1;2;3;4|]

  // Define a function that adds 1 to a number
  let add1 x = x + 1
  
  // Compose functions that are expressed in terms of the function above and themselves only
  let add2 = add1 >> add1
  let add3 = add1 >> add2

  // Define a function that uses partial application (currying)
  let show = printfn "%d is the result"
  let addAnother1 x = (+) 1 x
  let addAnother1 = (+) 1

  // Now compose everything we have defined so far into something interesting
  let add6AndShowTheResult = add1 >> add2 >> add3 >> show      
  add6AndShowTheResult 7

  // Reuse the show function in a different way
  show 9
  10 |> show 
  show <| 88

  // Tuples (x,y,z)
  show(5)
  show (5)
  let five = (5)  // Look at my type

  Console.ReadLine() |> ignore
  0
