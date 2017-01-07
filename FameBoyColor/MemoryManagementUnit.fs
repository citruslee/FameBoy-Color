module MemoryManagementUnit

type MemoryManagementUnit () = 

    //read 8 bit value from address
    member this.ReadByte (address) = 
        0uy

    //read 16 bit value from address
    member this.ReadWord (address) = 
        0us

    //write 8 bit value to address
    member this.WriteByte (address, value) = 
        ()

    //write 16 bit value to address
    member this.WriteWord (address, value)= 
        ()
