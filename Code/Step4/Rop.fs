namespace Step4

module Rop = 
    type Error = 
        { Message : string }
    
    type Result<'a> = 
        | Success of 'a
        | Failure of Error
    
    let bind f1 f2 x = 
        match f1 x with
        | Success y -> f2 y
        | Failure err -> Failure err
    
    let inline (>>=) f1 f2 = bind f1 f2

    // Iterate over each item in a list applying an action.
    // if a failure occures stop iterating and return a failure.
    let rec iter f x =
        match (x) with
        | x::xs -> 
            match (f x) with
            | Success () -> iter f xs
            | Failure msg -> Failure msg
        | [] -> Success ()
   