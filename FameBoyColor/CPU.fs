module CPU

open Opcodes
open Registers
open MemoryManagementUnit

type CPU () =

    //The amount of time used to execute the last instruction
    member val instructionTime = 0

    //The amount of time that the CPU has run in total
    member val CPUTime = 0

    member val regs = Registers()
    member val mmu = MemoryManagementUnit()

    //initialize the CPU, or call when reset
    member this.Init (cartridge) =
        this.regs = Registers() |> ignore
        this.mmu = MemoryManagementUnit() |> ignore

        this.instructionTime = 0 |> ignore
        this.CPUTime = 0 |> ignore
        this.mmu.LoadCartridge (cartridge)
        ()


    //the CPU update loop
    member this.Update () =
        let mutable continueLooping = true

        while continueLooping do
            let dispatch = async{
                let pc : uint16 = this.regs.PC.Value
                this.regs.PC.Value <- pc + 1us

                let opcode : byte = this.mmu.ReadByte (int pc)
                //printfn "opcode: %A" opcode
                //this.Decode opcode
               
                do! Async.Sleep(1)
                
            }
            //this.regs.Print() 
          
        
            Async.RunSynchronously dispatch
            ()

    member this.Decode opcode = 
        match (int opcode |> enum) with
            | OpCode.NOP -> printfn "NOP"
            | OpCode.LDBCnn -> printfn "LDBCnn"
            | OpCode.LDBCmA -> printfn "LDBCmA"
            | OpCode.INCBC -> printfn "INCBC"
            | OpCode.INCr_b -> printfn "INCr_b"
            | OpCode.DECr_b -> printfn "DECr_b"
            | OpCode.LDrn_b -> printfn "LDrn_b"
            | OpCode.RLCA -> printfn "RLCA"
            | OpCode.LDmmSP -> printfn "LDmmSP"
            | OpCode.ADDHLBC -> printfn "ADDHLBC"
            | OpCode.LDABCm -> printfn "LDABCm"
            | OpCode.DECBC -> printfn "DECBC"
            | OpCode.INCr_c -> printfn "INCr_c"
            | OpCode.DECr_c -> printfn "DECr_c"
            | OpCode.LDrn_c -> printfn "LDrn_c"
            | OpCode.RRCA -> 
                printfn "RRCA"
            | _ -> printfn "NotImplemented opcode %A" opcode    