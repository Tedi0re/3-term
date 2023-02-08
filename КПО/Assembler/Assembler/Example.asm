														;��� ������ ������ ���������� ����������� �������.
														;1)�������->����������� ������->���������->������� masm
														;2)������� ���� � ����������� .asm
														;3)������� �����->�����->��� ��������->Microsoft Macro Assembler
														;4)������->��������->Microsoft Macro Assembler->Listing File->Assembler Code Listing File $(IntDir) [�������� �����]
														;5)������->��������->�����������->�������->���������� Windows(/SUBSYSTEM:WINDOWS)
.586P													;������� ������ (��������� Pentium)
.MODEL FLAT, STDCALL									;������ ������, ���������� � �������
includelib kernel32.lib									;������������: ����������� � kernel32

ExitProcess PROTO : DWORD								;�������� ������� ��� ���������� �������� Windows
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD	;�������� API-������� MessageBoxA

.STACK 4096												;��������� ����� ������� 4 ���������

.CONST													;������� ��������

.DATA													;������� ������
MB_OK EQU 0												;EQU ���������� ���������
STR1 DB "��� ������ ���������", 0						;������, ������ ������� ������ + ������� ����
STR2 DB "������ ����!!!", 0								;������, ������ ������� ������ + ������� ����
HW   DD ?												;������� ����� ������ 4 �����, ������������������

.CODE													;������� ����

main PROC												;����� ����� main
START :													;�����
		;PUSH HW
		;PUSH MB_OK
		;PUSH OFFSET STR1
		;PUSH OFFSET STR2
		;CALL MessageBoxA								;����� �������

INVOKE MessageBoxA, HW, OFFSET STR2, OFFSET STR1, MB_OK


	push - 1											;��� �������� �������� Windows (�������� ExitProcess)
	call ExitProcess									;��� ����������� ����� ������� Windows
main ENDP												;����� ���������

end main	