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
.data
	maina SWORD 0
	mainb SWORD 0

.code

main PROC
	push L1
	pop maina

	push lenght
	push maina
	pop dx
	pop dx
	push maina
		call lenght
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