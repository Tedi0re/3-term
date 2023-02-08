.586P
.MODEL FLAT, STDCALL
includelib kernel32.lib

ExitProcess PROTO : DWORD
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD

.STACK 4096

.CONST

.DATA

MB_OK	EQU 0
STR1	DB "Программа", 0
HW		DD ?
LONGF	SDWORD 1
BYTEF	DB 2
STRF	DB "vrvrv", 0

.CODE

main PROC

START: 
	INVOKE MessageBoxA, HW, OFFSET STRF, OFFSET STR1, MB_OK
	push 0
	call ExitProcess
main ENDP
end main
