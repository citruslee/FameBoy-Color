module Opcodes

type OpCode =
    | NOP = 0x00
    | LD_BC_NN = 0x01
    | LD_BC_A = 0x02
    | INC_BC = 0x03
    | INC_B = 0x04
    | DEC_B = 0x05
    | LD_B_N = 0x06
    | RLCA = 0x07
    | OP8 = 0x08
    | OP9 = 0x09
    | OP10 = 0x0a
    | OP11 = 0x0b
    | OP12 = 0x0c
    | OP13 = 0x0d
    | OP14 = 0x0e
    | OP15 = 0x0f


