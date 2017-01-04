module Registers

type Registers =
    struct
        //accumulator and arithmetic flags
        val mutable AF : uint16

        //general purpose 8bit registers
        val mutable BC : uint16
        val mutable DE : uint16

        //general-use memory pointer
        val mutable HL : uint16

        //stack pointer pointing to the top of the stack
        val mutable SP : uint16 

        //program counter
        val mutable PC : uint16 

        override this.ToString() =
            sprintf "registers -> AF=%A BC=%A DE=%A HL=%A SP=%A PC=%A" this.AF this.BC this.DE this.HL this.SP this.PC
        
    end