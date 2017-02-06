open Units
open Registers
open Memory
open CPU


[<EntryPoint>]
let main argv =
    let regs = new Registers()
    let ram = new Memory(1 * kB)

    let cpu = new CPU()


    //(regs.Get8BitRegister B).Value <- uint8 0;
    //(regs.Get8BitRegister C).Value <- uint8 2;

    //printfn "register B=%A" (regs.Get8BitRegister B).Value
    //printfn "register BC=%A" (regs.Get16BitRegister BC).Value

    //for i in 0 .. int ram.memsize - 1 do
    //    printfn "address=%d value=%d" i ram.memory.[i]

    //ram.Write 255uy 02

    //printfn "\n\n\taddress=%d value=%d" 0 (ram.Read 0)
    cpu.Init (argv.[0])
    cpu.Update() |> ignore

    System.Console.ReadKey() |> ignore
    0