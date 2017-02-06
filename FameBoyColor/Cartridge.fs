module Cartridge

open System.IO

type CartridgeSize = 
    | Cartridge_32_Kbyte_no_rom_bank  = 0x00
    | Cartridge_64_Kbyte_4_rom_bank   = 0x01
    | Cartridge_128_Kbyte_8_rom_bank  = 0x02
    | Cartridge_256_Kbyte_16_rom_bank = 0x03
    | Cartridge_512_Kbyte_32_rom_bank = 0x04
    | Cartridge_1_Mbyte_64_rom_bank   = 0x05
    | Cartridge_2_Mbyte_128_rom_bank  = 0x06
    | Cartridge_4_Mbyte_256_rom_bank  = 0x07
    | Cartridge_1_1Mbyte_72_rom_bank  = 0x52
    | Cartridge_1_2Mbyte_80_rom_bank  = 0x53
    | Cartridge_1_5_Mbyte_96_rom_bank = 0x54

type CartridgeType = 
    | Cartridge_ROM_ONLY            = 0x00
    | Cartridge_MBC1                = 0x01
    | Cartridge_MBC1_RAM            = 0x02
    | Cartridge_MBC1_RAM_BATTERY    = 0x03
    | Cartridge_MBC2                = 0x05
    | Cartridge_MBC2_BATTERY        = 0x06
    | Cartridge_ROM_RAM             = 0x08
    | Cartridge_ROM_RAM_BATTERY


type Cartridge () = 

    let rom : ResizeArray<byte> = ResizeArray()
    let eeprom : ResizeArray<byte> = ResizeArray()
    let mutable cartridgeName : string = ""
    let mutable cartridgeSize : int = 0

    member this.IsSGBCCapable : bool =
        rom.[0x0146] = 0x03uy

    member this.IsGBCCapable : bool =
        rom.[0x0143] = 0x80uy


    member this.GetCartridgeSize = 
        let ctype = rom.[0x0148]

        let matchSize (size) =
           
            match (size |> enum) with
                | CartridgeSize.Cartridge_32_Kbyte_no_rom_bank  -> printfn "32KByte (no ROM banking)"
                | CartridgeSize.Cartridge_64_Kbyte_4_rom_bank   -> printfn "64KByte (4 banks)"
                | CartridgeSize.Cartridge_128_Kbyte_8_rom_bank  -> printfn "128KByte (8 banks)"
                | CartridgeSize.Cartridge_256_Kbyte_16_rom_bank -> printfn "256KByte (16 banks)"
                | CartridgeSize.Cartridge_512_Kbyte_32_rom_bank -> printfn "512KByte (32 banks)"
                | CartridgeSize.Cartridge_1_Mbyte_64_rom_bank   -> printfn "1MByte (64 banks)  - only 63 banks used by MBC1"
                | CartridgeSize.Cartridge_2_Mbyte_128_rom_bank  -> printfn "2MByte (128 banks) - only 125 banks used by MBC1"
                | CartridgeSize.Cartridge_4_Mbyte_256_rom_bank  -> printfn "4MByte (256 banks)"
                | CartridgeSize.Cartridge_1_1Mbyte_72_rom_bank  -> printfn "1.1MByte (72 banks)"
                | CartridgeSize.Cartridge_1_2Mbyte_80_rom_bank  -> printfn "1.2MByte (80 banks)"
                | CartridgeSize.Cartridge_1_5_Mbyte_96_rom_bank -> printfn "1.5MByte (96 banks)"
                | _ -> printfn "The Fuck?"
        
        if ctype <= 0x7uy then
            matchSize (int ctype)
        else
            matchSize (int ctype - 0x4A)
        ()

    member this.ParseOtherInfo =
        if rom.[0x014a] = 0uy then
            printfn "Version: Japanese version"
        else
            printfn "Version: Non-Japanese version"
        ()
    member this.ParseCartridgeHeader =
        if this.IsSGBCCapable then
            printfn "Super FameBoy Color capable cartridge"
        elif this.IsGBCCapable then
            printfn "FameBoy Color capable cartridge"

        this.GetCartridgeSize

        this.ParseOtherInfo
        ()

    member this.LoadCartridge (cartridgePath) =
        printfn "Loading cartridge: %A" cartridgePath
        let binary = File.ReadAllBytes (cartridgePath)
        cartridgeSize <- binary.Length
        cartridgeName <- cartridgePath

        for i  in 0 .. binary.Length - 1 do
            rom.Add(binary.[i])
        
        printfn "Loaded cartridge size: %A" cartridgeSize

        this.ParseCartridgeHeader
        //Array.blit binary 0 this.cartridge 0 binary.Length
        ()