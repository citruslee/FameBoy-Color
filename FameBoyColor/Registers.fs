module Registers

type Flags = 
    | Z 
    | N 
    | H 
    | C

type Register8BitNames = 
    | A 
    | B 
    | C 
    | D 
    | E 
    | F 
    | H 
    | L

type Register16BitNames = 
    | AF 
    | BC 
    | DE 
    | HL 
    | SP 
    | PC

[<AbstractClass>]
type BaseRegister<'a>() =
    abstract Value: 'a with get, set
    member this.Update fn = 
        this.Value <- fn this.Value

// read/write register
type ReadWriteDataRegister<'T>(value: 'T) =
    inherit BaseRegister<'T>()

    let mutable data = value

    override this.Value
        with get () = 
            data
        and set (value) = 
            data <- value

//general purpose 8 bit register
type DataRegister8Bit(value: uint8) =
    inherit ReadWriteDataRegister<uint8>(value)

type FlagRegister8Bit(z,n,h,c) =
    inherit BaseRegister<uint8>()

    //top 4 bits, flags
    member val Z = z with get, set // Zero flag
    member val N = n with get, set // Substract flag
    member val H = h with get, set // Half carry flag
    member val C = c with get, set // Carry flag

    //unused lower 4 bits, always zero
    member val UNUSED0 = 0
    member val UNUSED1 = 0
    member val UNUSED2 = 0
    member val UNUSED3 = 0

    //TODO: Add getter/setters for flags 
    override this.Value
        with get () =
            uint8 0
        and set (value) =
            ()

//SP
type StackPointerRegister (init) =
    inherit ReadWriteDataRegister<uint16>(init)

//PC
type ProgramCounterRegister (value) =
    inherit ReadWriteDataRegister<uint16>(value)
    member this.Advance (offset: int) = 
        this.Value <- this.Value + (uint16 offset)

//two 8 bit registers combined into 16 bit
type CombinedDataRegister16Bit (R1: BaseRegister<uint8>, R2: BaseRegister<uint8>) =
    inherit BaseRegister<uint16>()

    override this.Value
        with get () = 
            ((uint16 R1.Value) <<< 8) ||| (uint16 R2.Value)
        and set (value) =
            R1.Value <-  uint8 ((value >>> 8) &&& uint16 0xFF)
            R2.Value <- uint8 (value &&& uint16 0xFF)


type Registers () =
    let a = DataRegister8Bit(0uy) 
    let b = DataRegister8Bit(0uy) 
    let c = DataRegister8Bit(0uy) 
    let d = DataRegister8Bit(0uy) 
    let e = DataRegister8Bit(0uy) 
    let f = FlagRegister8Bit(0,0,0,0)
    let h = DataRegister8Bit(0uy) 
    let l = DataRegister8Bit(0uy) 

    let af = CombinedDataRegister16Bit(a,f)
    let bc = CombinedDataRegister16Bit(b,c)
    let de = CombinedDataRegister16Bit(d,e)
    let hl = CombinedDataRegister16Bit(h,l) 

    let sp = StackPointerRegister(0us) 
    let pc = ProgramCounterRegister(0us) 

    member val A = a
    member val B = b
    member val C = c
    member val D = d
    member val E = e
    member val F = f
    member val H = h
    member val L = l

    member val AF = af
    member val BC = bc
    member val DE = de
    member val HL = hl

    member val SP = sp
    member val PC = pc

    member this.Get8BitRegister (name: Register8BitNames) =
        match name with
        | A -> a :> BaseRegister<uint8>
        | B -> b :> BaseRegister<uint8>
        | C -> c :> BaseRegister<uint8>
        | D -> d :> BaseRegister<uint8>
        | E -> e :> BaseRegister<uint8>
        | F -> f :> BaseRegister<uint8>
        | H -> h :> BaseRegister<uint8>
        | L -> l :> BaseRegister<uint8>

    member this.Get16BitRegister (name: Register16BitNames) =
        match name with
        | AF -> af :> BaseRegister<uint16>
        | BC -> bc :> BaseRegister<uint16>
        | DE -> de :> BaseRegister<uint16>
        | HL -> hl :> BaseRegister<uint16>
        | PC -> pc :> BaseRegister<uint16>
        | SP -> sp :> BaseRegister<uint16> 
