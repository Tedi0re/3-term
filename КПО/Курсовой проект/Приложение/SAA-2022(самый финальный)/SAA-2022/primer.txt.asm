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
	L1 SWORD 2
	L2 SWORD 3
	L3 SWORD 1
	L4 SWORD 0
	L5 SWORD 10000
.data
	maina SWORD 0
	mainb SWORD 0

.code

main PROC
	push L1
	pop maina

	mov dx, maina
	cmp dx, L2
	jg right1
	jle wrong1
	jmp next1
right1:
push L3
call outnumline
	jmp next1

wrong1:
push L4
call outnumline

next1:	mov dx, maina
	cmp dx, L4
	jge cycle1
	jmp continue1
 cycle1:
push maina
call outnumline
	mov ax,maina
	mov bx,1
	sub ax, bx
	jo EXIT_OVERFLOW
	mov maina , ax
	jge cycle1
continue1:	push L5
	pop mainb

	push mainb
	push mainb
	pop bx
	pop ax
	sub ax, bx
	push ax
	pop mainb

	push mainb
	push mainb
	pop bx
	pop ax
	cmp bx,0
	je SOMETHINGWRONG
	cdq
	idiv bx
	push ax
	pop mainb

call system_pause
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