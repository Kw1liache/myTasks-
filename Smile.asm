//    Читаем клавишу
//
//    Если клавиша нажата:
//        Очищаем предыдущий смайл
//        Рисуем смайл
//        Запоминаем позицию, чтобы потом удалить
//    Иначе:
//        Очищаем экран
(SMILE)
@row1
@row2
@row3
@row4
@row5
@row6
@row7
@row8

@row1
D=A
@R1
M=D

@7224
D=A
@R1
A=M
M=D
@R1
M=M+1

@7224
D=A
@R1
A=M
M=D
@R1
M=M+1

@7224
D=A
@R1
A=M
M=D
@R1
M=M+1

@0
D=A
@R1
A=M
M=D
@R1
M=M+1

@0
D=A
@R1
A=M
M=D
@R1
M=M+1

@24582
D=A
@R1
A=M
M=D
@R1
M=M+1

@14364
D=A
@R1
A=M
M=D
@R1
M=M+1

@4080
D=A
@R1
A=M
M=D
@R1
M=M+1

(CONSTANTS)
@3968
D=A
@left
M=D
@10
D=A
@left
M=M+D
@SCREEN
D=A
@left
M=M+D

@2624
D=A
@up
M=D
@16
D=A
@up
M=M+D
@SCREEN
D=A
@up
M=M+D

@3968
D=A
@right
M=D
@21
D=A
@right
M=M+D
@SCREEN
D=A
@right
M=M+D

@5280
D=A
@down
M=D
@16
D=A
@down
M=M+D
@SCREEN
D=A
@down
M=M+D

(READKEY)
@130
D=A
@KBD
D=D-M
@DRAWSMILELEFT
D;JEQ

@131
D=A
@KBD
D=D-M
@DRAWSMILEUP
D;JEQ

@132
D=A
@KBD
D=D-M
@DRAWSMILERIGHT
D;JEQ

@133
D=A
@KBD
D=D-M
@DRAWSMILEDOWN
D;JEQ

@READKEY
D=A
@R1
M=D

(CLEARPREVIOUS)
@previousPosition
D=M
@R0
M=D
@CLEARSMILE
0;JMP

(DRAWSMILEDOWN)
@down
D=M
@smilePosition
M=D
@DRAWING
0;JMP

(DRAWSMILEUP)
@up
D=M
@smilePosition
M=D
@DRAWING
0;JMP

(DRAWSMILELEFT)
@left
D=M
@smilePosition
M=D
@DRAWING
0;JMP

(DRAWSMILERIGHT)
@right
D=M
@smilePosition
M=D
@DRAWING
0;JMP

(DRAWING)
@DRAWINGCONTINUE
D=A
@R1
M=D
@smilePosition
D=M
@previousPosition
D=D-M
@CLEARPREVIOUS
D;JNE

(DRAWINGCONTINUE)
@smilePosition
D=M
@R0
M=D
@previousPosition
M=D
@READKEY
D=A
@R1
M=D

(DRAWSMILE)
@8
D=A
@i
M=D
@row1
D=A
@R2
M=D
@DRAWWHILE
D=A
@R3
M=D

(DRAWWHILE)
@i
M=M-1
@R2
A=M
D=M
@R0
A=M
M=D
@R2
M=M+1
@32
D=A
@R0
M=M+D
@IF
0;JMP

(IF)
@i
D=M
@R3
A=M
D;JGT
@R1
A=M
0;JMP

(CLEARSMILE)
@8
D=A
@i
M=D
@CLEARWHILE
D=A
@R3
M=D

(CLEARWHILE)
@i
M=M-1
@R0
A=M
M=0
@32
D=A
@R0
M=M+D
@IF
0;JMP

(END)
@END
0;JMP
