.586P
.MODEL FLAT, STDCALL
includelib kernel32.lib

ExitProcess PROTO : DWORD
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD

.STACK 4098

.CONST

.DATA
MB_OK	EQU 0
STR1	DB "Муха Илья Валерьевич 2 курс 6 группа", 0
STR2	DB "В регистре EBX находится 0 (есть 0)", 0
STR3	DB "В регистре EBX находится 1 (нет 0)", 0
HW		DD ?

myDoubles DWORD 1, 2, 3, 4, 5, 6   
Array	  BYTE 8, 7, 9, 0, 1, 2, 4

.CODE

main PROC
START: 
			

		

	SC: 
			mov ecx, lengthof Array - 1 ;LENGTHOF определяет количество элементов в массиве,перечисленного в одной строке
			mov ebx, 1
	Cycl:
			cmp [Array + ecx], 0 ;Команда вычитает исходный операнд из операнда получателя и устанавливает флаги,операция сравнения
			jne False  ;переход, если не равны операнды
			je	True   ;переход, если равны операнды
	True:	
			mov	ebx, 0
			jmp EC; выполняет безусловный переход в указанное место
	False:
			loop Cycl ;уменьшаем регистр на 1 и сравниваем с 0,если не равен 0,то переход по указанной метке
	EC:

	Check:
			cmp ebx, 0 ;операция сравнения
			je	ZR     ;переход если операнды равны

			invoke MessageBoxA, HW, OFFSET STR3, OFFSET STR1, MB_OK
			jmp EndCheck ;безусловный переход
	ZR:
			invoke MessageBoxA, HW, OFFSET STR2, OFFSET STR1, MB_OK
	EndCheck:
	push	0     ;код возврата
	call ExitProcess  ;завершения процесса винды
main ENDP   

end main   