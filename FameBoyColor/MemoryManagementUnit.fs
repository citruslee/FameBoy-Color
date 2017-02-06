module MemoryManagementUnit

open System.IO
open Cartridge

type MemoryManagementUnit () = 

    
        //read 8 bit value from address
    member this.ReadByte (address) : byte= 
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
    member this.LoadCartridge (cartridgePath) =
        let cartridge = new Cartridge()
        cartridge.LoadCartridge (cartridgePath)
        ()