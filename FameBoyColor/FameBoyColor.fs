open Units
open Registers
open Memory


[<EntryPoint>]
let main argv =
    let regs = new Registers()
    let ram = new Memory(1 * kB)


    (regs.Get8BitRegister A).Value <- uint8 2;

    printfn "register A=%A" (regs.Get8BitRegister A).Value

    for i in 0 .. int ram.memsize - 1 do
        printfn "address=%d value=%d" i ram.memory.[i]

    ram.Write (byte 255) 02

    printfn "\n\n\taddress=%d value=%d" 0 (ram.Read 0)


    System.Console.ReadKey() |> ignore
    0