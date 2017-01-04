module Memory

open Units

[<Struct>]
type Memory = 
    //memory size
    val memsize : int<b>
    val mutable memory : byte array

    new(size: int<b>) = 
    { 
        memsize = size;
        memory = Array.init (int size) (fun i -> byte(i))
    }

    member this.Write (value : byte) (address : int) =
        this.memory.[address] <- value

    member this.Read (address : int) =
        this.memory.[address]