module Opcodes

type OpCode =
    //opcodes 0x00
    | NOP     = 0x00
    | LDBCnn  = 0x01
    | LDBCmA  = 0x02
    | INCBC   = 0x03
    | INCr_b  = 0x04
    | DECr_b  = 0x05
    | LDrn_b  = 0x06
    | RLCA    = 0x07
    | LDmmSP  = 0x08
    | ADDHLBC = 0x09
    | LDABCm  = 0x0a
    | DECBC   = 0x0b
    | INCr_c  = 0x0c
    | DECr_c  = 0x0d
    | LDrn_c  = 0x0e
    | RRCA    = 0x0f

    //opcodes 0x10
    | DJNZn   = 0x10
    | LDDEnn  = 0x11
    | LDDEmA  = 0x12
    | INCDE   = 0x13
    | INCr_d  = 0x14
    | DECr_d  = 0x15
    | LDrn_d  = 0x16
    | RLA     = 0x17
    | JRn     = 0x18
    | ADDHLDE = 0x19
    | LDADEm  = 0x1a
    | DECDE   = 0x1b
    | INCr_e  = 0x1c
    | DECr_e  = 0x1d
    | LDrn_e  = 0x1e
    | RRA     = 0x1f

    //opcodes 0x20
    | JRNZn   = 0x20
    | LDHLnn  = 0x21
    | LDHLIA  = 0x22
    | INCHL   = 0x23
    | INCr_h  = 0x24
    | DECr_h  = 0x25
    | LDrn_h  = 0x26
    | XX0     = 0x27
    | JRZn    = 0x28
    | ADDHLHL = 0x29
    | LDAHLI  = 0x2a
    | DECHL   = 0x2b
    | INCr_l  = 0x2c
    | DECr_l  = 0x2d
    | LDrn_l  = 0x2e
    | CPL     = 0x2f  

    //opcodes 0x30
    | JRNCn   = 0x30
    | LDSPnn  = 0x31
    | LDHLDA  = 0x32
    | INCSP   = 0x33
    | INCHLm  = 0x34
    | DECHLm  = 0x35
    | LDHLmn  = 0x36
    | SCF     = 0x37
    | JRCn    = 0x38
    | ADDHLSP = 0x39
    | LDAHLD  = 0x3a
    | DECSP   = 0x3b
    | INCr_a  = 0x3c
    | DECr_a  = 0x3d
    | LDrn_a  = 0x3e
    | CCF     = 0x3f  

    //opcodes 0x40
    | LDrr_bb  = 0x40
    | LDrr_bc  = 0x41
    | LDrr_bd  = 0x42
    | LDrr_be  = 0x43
    | LDrr_bh  = 0x44
    | LDrr_bl  = 0x45
    | LDrHLm_b = 0x46
    | LDrr_ba  = 0x47
    | LDrr_cb  = 0x48
    | LDrr_cc  = 0x49
    | LDrr_cd  = 0x4a
    | LDrr_ce  = 0x4b
    | LDrr_ch  = 0x4c
    | LDrr_cl  = 0x4d
    | LDrHLm_c = 0x4e
    | LDrr_ca  = 0x4f  

    //opcodes 0x50
    | LDrr_db  = 0x50
    | LDrr_dc  = 0x51
    | LDrr_dd  = 0x52
    | LDrr_de  = 0x53
    | LDrr_dh  = 0x54
    | LDrr_dl  = 0x55
    | LDrHLm_d = 0x56
    | LDrr_da  = 0x57
    | LDrr_eb  = 0x58
    | LDrr_ec  = 0x59
    | LDrr_ed  = 0x5a
    | LDrr_ee  = 0x5b
    | LDrr_eh  = 0x5c
    | LDrr_el  = 0x5d
    | LDrHLm_e = 0x5e
    | LDrr_ea  = 0x5f  

    //opcodes 0x60
    | LDrr_hb  = 0x60
    | LDrr_hc  = 0x61
    | LDrr_hd  = 0x62
    | LDrr_he  = 0x63
    | LDrr_hh  = 0x64
    | LDrr_hl  = 0x65
    | LDrHLm_h = 0x66
    | LDrr_ha  = 0x67
    | LDrr_lb  = 0x68
    | LDrr_lc  = 0x69
    | LDrr_ld  = 0x6a
    | LDrr_le  = 0x6b
    | LDrr_lh  = 0x6c
    | LDrr_ll  = 0x6d
    | LDrHLm_l = 0x6e
    | LDrr_la  = 0x6f  

    //opcodes 0x70
    | LDHLmr_b = 0x70
    | LDHLmr_c = 0x71
    | LDHLmr_d = 0x72
    | LDHLmr_e = 0x73
    | LDHLmr_h = 0x74
    | LDHLmr_l = 0x75
    | HALT     = 0x76
    | LDHLmr_a = 0x77
    | LDrr_ab  = 0x78
    | LDrr_ac  = 0x79
    | LDrr_ad  = 0x7a
    | LDrr_ae  = 0x7b
    | LDrr_ah  = 0x7c
    | LDrr_al  = 0x7d
    | LDrHLm_a = 0x7e
    | LDrr_aa  = 0x7f  

    //opcodes 0x80
    | ADDr_b = 0x80
    | ADDr_c = 0x81
    | ADDr_d = 0x82
    | ADDr_e = 0x83
    | ADDr_h = 0x84
    | ADDr_l = 0x85
    | ADDHL  = 0x86
    | ADDr_a = 0x87
    | ADCr_b = 0x88
    | ADCr_c = 0x89
    | ADCr_d = 0x8a
    | ADCr_e = 0x8b
    | ADCr_h = 0x8c
    | ADCr_l = 0x8d
    | ADCHL  = 0x8e
    | ADCr_a = 0x8f

    //opcodes 0x90
    | SUBr_b = 0x90
    | SUBr_c = 0x91
    | SUBr_d = 0x92
    | SUBr_e = 0x93
    | SUBr_h = 0x94
    | SUBr_l = 0x95
    | SUBHL  = 0x96
    | SUBr_a = 0x97
    | SBCr_b = 0x98
    | SBCr_c = 0x99
    | SBCr_d = 0x9a
    | SBCr_e = 0x9b
    | SBCr_h = 0x9c
    | SBCr_l = 0x9d
    | SBCHL  = 0x9e
    | SBCr_a = 0x9f  

    //opcodes 0xA0
    | ANDr_b = 0xa0
    | ANDr_c = 0xa1
    | ANDr_d = 0xa2
    | ANDr_e = 0xa3
    | ANDr_h = 0xa4
    | ANDr_l = 0xa5
    | ANDHL  = 0xa6
    | ANDr_a = 0xa7
    | XORr_b = 0xa8
    | XORr_c = 0xa9
    | XORr_d = 0xaa
    | XORr_e = 0xab
    | XORr_h = 0xac
    | XORr_l = 0xad
    | XORHL  = 0xae
    | XORr_a = 0xaf

    //opcodes 0xB0
    | ORr_b = 0xb0
    | ORr_c = 0xb1
    | ORr_d = 0xb2
    | ORr_e = 0xb3
    | ORr_h = 0xb4
    | ORr_l = 0xb5
    | ORHL  = 0xb6
    | ORr_a = 0xb7
    | CPr_b = 0xb8
    | CPr_c = 0xb9
    | CPr_d = 0xba
    | CPr_e = 0xbb
    | CPr_h = 0xbc
    | CPr_l = 0xbd
    | CPHL  = 0xbe
    | CPr_a = 0xbf

    //opcodes 0xC0
    | RETNZ    = 0xc0
    | POPBC    = 0xc1
    | JPNZnn   = 0xc2
    | JPnn     = 0xc3
    | CALLNZnn = 0xc4
    | PUSHBC   = 0xc5
    | ADDn     = 0xc6
    | RST00    = 0xc7
    | RETZ     = 0xc8
    | RET      = 0xc9
    | JPZnn    = 0xca
    | MAPcb    = 0xcb
    | CALLZnn  = 0xcc
    | CALLnn   = 0xcd
    | ADCn     = 0xce
    | RST08    = 0xcf

    //opcodes 0xD0
    | RETNC    = 0xd0
    | POPDE    = 0xd1
    | JPNCnn   = 0xd2
    | XX1      = 0xd3
    | CALLNCnn = 0xd4
    | PUSHDE   = 0xd5
    | SUBn     = 0xd6
    | RST10    = 0xd7
    | RETC     = 0xd8
    | RETI     = 0xd9
    | JPCnn    = 0xda
    | XX2      = 0xdb
    | CALLCnn  = 0xdc
    | XX3      = 0xdd
    | SBCn     = 0xde
    | RST18    = 0xdf

    //opcodes 0xE0
    | LDIOnA = 0xe0
    | POPHL  = 0xe1
    | LDIOCA = 0xe2
    | XX4    = 0xe3
    | XX5    = 0xe4
    | PUSHHL = 0xe5
    | ANDn   = 0xe6
    | RST20  = 0xe7
    | ADDSPn = 0xe8
    | JPHL   = 0xe9
    | LDmmA  = 0xea
    | XX6    = 0xeb
    | XX7    = 0xec
    | XX8    = 0xed
    | ORn    = 0xee
    | RST28  = 0xef

    //opcodes 0xF0
    | LDAIOn  = 0xf0
    | POPAF   = 0xf1
    | LDAIOC  = 0xf2
    | DI      = 0xf3
    | XX9     = 0xf4
    | PUSHAF  = 0xf5
    | XORn    = 0xf6
    | RST30   = 0xf7
    | LDHLSPn = 0xf8
    | XX10    = 0xf9
    | LDAmm   = 0xfa
    | EI      = 0xfb
    | XX11    = 0xfc
    | XX12    = 0xfd
    | CPn     = 0xfe
    | RST38   = 0xff
