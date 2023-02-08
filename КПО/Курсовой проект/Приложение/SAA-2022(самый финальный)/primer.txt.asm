.586
.model flat, stdcall
includelib libucrt.lib
includelib kernel32.lib
includelib "../LIB.lib"
ExitProcess PROTO:DWORD 
.stack 4096

 outnum PROTO : DWORD

 outstr PROTO : DWORD

 outstrline PROTO : DWORD

 outnumline PROTO : DWORD

 system_pause PROTO 

 random PROTO  

 lenght PROTO  : DWORD
.const
 null_division BYTE 'ERROR: DIVISION BY ZERO', 0
 overflow BYTE 'ERROR: VARIABLE OVERFLOW', 0 
	L1 BYTE 'Procedure write', 0
	L2 SWORD 10
	L3 BYTE 'it is random number: ', 0
	L4 BYTE 'H', 0
	L5 BYTE 'ello!', 0
	L6 BYTE 'Length of string: ', 0
	L7 SWORD 5
	L8 BYTE 'random number >= 5', 0
	L9 BYTE 'random number < 5', 0
	L10 SWORD 80
	L11 SWORD 288
	L12 SWORD 6
	L13 BYTE 'circle', 0
.data
	_randomNua SWORD 0
	mains DWORD ?
	mainstr DWORD ?
	mainl SWORD 0
	mainr SWORD 0
	maino SWORD 0
	mainh SWORD 0
	maind SWORD 0

.code

_FV PROC 

push offset L1
call outstrline
	ret

SOMETHINGWRONG:
push offset null_division
call outstrline
call system_pause
push -1
call ExitProcess

EXIT_OVERFLOW:
push offset overflow
call outstrline
call system_pause
push -2
call ExitProcess
_FV ENDP
_randomNum PROC 
	push random
	pop dx
		call random
	push ax
	push L2
	pop bx
	pop ax
	cmp bx,0
	je SOMETHINGWRONG
	cdq
	idiv bx
	push dx
	pop _randomNua


push offset L3
call outstr

push _randomNua
call outnumline
	mov ax, _randomNua
	ret

SOMETHINGWRONG:
push offset null_division
call outstrline
call system_pause
push -1
call ExitProcess

EXIT_OVERFLOW:
push offset overflow
call outstrline
call system_pause
push -2
call ExitProcess
_randomNum ENDP
main PROC
	push offset L4
	pop mains

	push offset L5
	pop mainstr


push mains
call outstr

push mainstr
call outstrline
	push lenght
	push mainstr
	pop dx
	pop dx
	push mainstr
		call lenght
	push ax
	pop mainl


push offset L6
call outstr

push mainl
call outnumline

call _FV
	push _randomNum
	pop dx
		call _randomNum
	push ax
	pop mainr

	mov dx, mainr
	cmp dx, L7
	jge right1
	jle wrong1
	jmp next1
right1:
push offset L8
call outstrline
	jmp next1

wrong1:
push offset L9
call outstrline

next1:	push L10
	pop maino

	push L11
	pop mainh

	push L12
	pop maind


push maino
call outnumline

push mainh
call outnumline

push maind
call outnumline

push offset L13
call outstrline
	mov dx, mainr
	cmp dx, 0
	jnz cycle1
	jmp continue1
 cycle1:
push mainr
call outnumline
	jnz cycle1
continue1:call system_pause
push 0
call ExitProcess
SOMETHINGWRONG:
push offset null_division
call outstrline
call system_pause
push -1
call ExitProcess
EXIT_OVERFLOW:
push offset overflow
call outstrline
call system_pause
push -2
call ExitProcess
main ENDP
end main