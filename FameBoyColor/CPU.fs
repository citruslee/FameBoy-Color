module CPU

open Opcodes
open Registers
open MemoryManagementUnit

type CPU () =

    //The amount of time used to execute the last instruction
    member val instructionTime = 0

    //The amount of time that the CPU has run in total
    member val CPUTime = 0

    member val regs = new Registers()
    member val mmu = new MemoryManagementUnit()

    //initialize the CPU, or call when reset
    member this.Init =
        this.regs = new Registers() |> ignore
        this.mmu = new MemoryManagementUnit() |> ignore

        this.instructionTime = 0 |> ignore
        this.CPUTime = 0 |> ignore
        ()


    //the CPU update loop
    member this.Update () =
        let mutable continueLooping = true
        while continueLooping do
            let dispatch = async{
                let opcode = (this.mmu.ReadByte (this.regs.PC.Value <- (this.regs.PC.Value + 1us)) - 1uy)
                do! Async.Sleep(100)
                this.regs.Print() 
            }
            Async.RunSynchronously dispatch
            ()