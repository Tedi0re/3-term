														;Для начала работы необходимо подготовить решение.
														;1)Решение->Зависимости сборки->Настройки->выбрать masm
														;2)Создать файл с расширением .asm
														;3)Свойсва файла->Общие->Тип элемента->Microsoft Macro Assembler
														;4)Проект->Свойства->Microsoft Macro Assembler->Listing File->Assembler Code Listing File $(IntDir) [название файла]
														;5)Проект->Свойства->Компоновщик->Система->Подсистема Windows(/SUBSYSTEM:WINDOWS)
.586P													;система команд (процессор Pentium)
.MODEL FLAT, STDCALL									;модель памяти, соглашение о вызовах
includelib kernel32.lib									;компановщику: компоновать с kernel32

ExitProcess PROTO : DWORD								;прототип функции для завершения процесса Windows
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD	;прототип API-функции MessageBoxA

.STACK 4096												;выделение стека объемом 4 мегабайта

.CONST													;сегмент констант

.DATA													;сегмент данных
MB_OK EQU 0												;EQU определяет константу
STR1 DB "моя первая программа", 0						;строка, первый элемент данные + нулевой байт
STR2 DB "привет всем!!!", 0								;строка, первый элемент данные + нулевой байт
HW   DD ?												;двойное слово длиной 4 байта, неинициализировано

.CODE													;сегмент кода

main PROC												;точка входа main
START :													;метка
		;PUSH HW
		;PUSH MB_OK
		;PUSH OFFSET STR1
		;PUSH OFFSET STR2
		;CALL MessageBoxA								;вызов функции

INVOKE MessageBoxA, HW, OFFSET STR2, OFFSET STR1, MB_OK


	push - 1											;код возврата процесса Windows (параметр ExitProcess)
	call ExitProcess									;так завершается любой процесс Windows
main ENDP												;конец процедуры

end main	