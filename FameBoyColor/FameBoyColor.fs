open Units
open Registers
open Memory


[<EntryPoint>]
let main argv =
    let mutable registers = new Registers()
    registers.AF <- uint16 1
    registers.BC <- uint16 2
    registers.DE <- uint16 3
    registers.HL <- uint16 4

    registers.SP <- uint16 5
    registers.PC <- uint16 6

    let ram = new Memory(1 * kB)


    registers.ToString() |> printfn "%s" 

    for i in 0 .. int ram.memsize - 1 do
        printfn "address=%d value=%d" i ram.memory.[i]

    ram.Write (byte 255) 02

    printfn "\n\n\taddress=%d value=%d" 0 (ram.Read 0)


    //System.Console.ReadKey() |> ignore
    0