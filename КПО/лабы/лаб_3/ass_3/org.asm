.586P
.MODEL FLAT, STDCALL
includelib kernel32.lib

ExitProcess PROTO : DWORD
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD

.STACK 4098

.CONST

.DATA
MB_OK	EQU 0
STR1	DB "���� ���� ���������� 2 ���� 6 ������", 0
STR2	DB "� �������� EBX ��������� 0 (���� 0)", 0
STR3	DB "� �������� EBX ��������� 1 (��� 0)", 0
HW		DD ?

myDoubles DWORD 1, 2, 3, 4, 5, 6   
Array	  BYTE 8, 7, 9, 0, 1, 2, 4

.CODE

main PROC
START: 
			

		

	SC: 
			mov ecx, lengthof Array - 1 ;LENGTHOF ���������� ���������� ��������� � �������,�������������� � ����� ������
			mov ebx, 1
	Cycl:
			cmp [Array + ecx], 0 ;������� �������� �������� ������� �� �������� ���������� � ������������� �����,�������� ���������
			jne False  ;�������, ���� �� ����� ��������
			je	True   ;�������, ���� ����� ��������
	True:	
			mov	ebx, 0
			jmp EC; ��������� ����������� ������� � ��������� �����
	False:
			loop Cycl ;��������� ������� �� 1 � ���������� � 0,���� �� ����� 0,�� ������� �� ��������� �����
	EC:

	Check:
			cmp ebx, 0 ;�������� ���������
			je	ZR     ;������� ���� �������� �����

			invoke MessageBoxA, HW, OFFSET STR3, OFFSET STR1, MB_OK
			jmp EndCheck ;����������� �������
	ZR:
			invoke MessageBoxA, HW, OFFSET STR2, OFFSET STR1, MB_OK
	EndCheck:
	push	0     ;��� ��������
	call ExitProcess  ;���������� �������� �����
main ENDP   

end main   