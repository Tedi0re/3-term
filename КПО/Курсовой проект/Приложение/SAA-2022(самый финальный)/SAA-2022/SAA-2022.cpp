#include "stdafx.h"

int _tmain(int argc, _TCHAR** argv)
{
	//_TCHAR t[] = (L"-in:../primer.txt");
	//argc = 2;
	//argv[1] = t;
	char MESSAGE[] = "\n--------------------КОНЕЧНЫЕ ТАБЛИЦЫ ЛЕКСЕМ И ИДЕНТИФИКАТОРОВ-------------------\n";

	setlocale(0, "ru");
	Log::LOG log = Log::INITLOG;
	try
	{
		Parm::PARM parm = Parm::getparm(argc, argv);							
		log = Log::getlog(parm.log);										
		Log::WriteLog(log);												
		Log::WriteParm(log, parm);		
		std::cout << "Начало лексического анализа..." << std::endl;
		In::IN in = In::getin(parm.in, log.stream);                           
		if (in.FS)
		{
			Log::WriteLine(log, "Лексический анализ завершен с ошибками", "");								
			Log::WriteLineConsole((char*)"Лексический анализ завершен с ошибками", "");						
			return 0;

		}
		Log::WriteIn(log, in);													
		in.words = In::getWordsTable(log.stream, in.text, in.code, in.size);	
		Lex::LEX tables;
		if (!Lex::analyze(tables, in, log, parm))
		{
			Log::WriteLine(log, "Лексический анализ завершен с ошибками", "");									
			Log::WriteLineConsole((char*)"Лексический анализ завершен с ошибками", "");						
			return 0;
		}
		LT::writeLexTable(log.stream, tables.lextable);									
		IT::writeIdTable(log.stream, tables.idtable);							
		LT::writeLexemsOnLines(log.stream, tables.lextable);					
		std::cout << "Лексический анализ успешно завершен" << std::endl;
		std::cout << "Начало синтаксического анализа..." << std::endl;
		MFST_TRACE_START(log.stream);										
		MFST::Mfst mfst(tables, GRB::getGreibach());
		if (!mfst.start(log))
		{
			Log::WriteLine(log, "Синтаксический анализ завершен с ошибками", "");								
			Log::WriteLineConsole((char*)"Синтаксический анализ завершен с ошибками", "");
			return 0;
		}
		mfst.savededucation();											
		mfst.printrules(log);													
		std::cout << "Синтаксический анализ успешно завершен" << std::endl;
		std::cout << "Начало семантического анализа..." << std::endl;
		if (!Semantic::semanticsCheck(tables, log))
		{
			Log::WriteLine(log, "Семантический анализ завершен с ошибками", "");							
			Log::WriteLineConsole((char*)"Семантический анализ завершен с ошибками", "");
			return 0;
		}			
		std::cout << "Преобразование выражений..." << std::endl;

		tables.lextable.size = Polish::searchExpression(tables);				
		if (tables.lextable.size == 0)
		{
			Log::WriteLine(log, "Преобразование выражений завершено с ошибками", "");								
			Log::WriteLineConsole((char*)"Преобразование выражений завершено с ошибками", "");
			Log::WriteLine(log, "Семантический анализ завершен с ошибками", "");							
			Log::WriteLineConsole((char*)"Семантический анализ завершен с ошибками", "");
			return 0;
		}
		std::cout << "Преобразование выражений успешно завершено" << std::endl;
		std::cout << "Семантический анализ успешно завершен" << std::endl;

		std::cout << "Начало генерации кода..." << std::endl;

		if (!Gener::CodeGeneration(tables, parm, log))
		{
			Log::WriteLine(log, "Генерация кода завершена с ошибками", "");						
			Log::WriteLineConsole((char*)"Генерация кода завершена с ошибками", "");
			return 0;
		}
		std::cout << "Генерация кода успешно завершена" << std::endl;
		Log::WriteLine(log, "Программа успешно скомпилирована", "");
		Log::WriteLineConsole((char*)"Программа успешно скомпилирована", "");
		Log::WriteLine(log, MESSAGE, "");
		LT::writeLexTable(log.stream, tables.lextable);
		IT::writeIdTable(log.stream, tables.idtable);
		LT::writeLexemsOnLines(log.stream, tables.lextable);
		Log::WriteLineConsole(MESSAGE, "");
		IT::writeIdTable(&std::cout, tables.idtable);
		LT::writeLexTable(&std::cout, tables.lextable);
		LT::writeLexemsOnLines(&std::cout, tables.lextable);
		Log::Close(log);
		system("pause");
	}
	catch (Error::ERROR e)
	{
		Log::WriteError(log.stream, e);
		Log::WriteLineConsole(e.message, "");

	}
	catch (...)
	{
		std::cout << "Ошибка: Системный сбой" << std::endl;
	}
	return 0;
}