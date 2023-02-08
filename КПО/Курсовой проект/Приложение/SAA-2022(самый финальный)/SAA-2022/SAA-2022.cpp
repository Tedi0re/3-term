#include "stdafx.h"

int _tmain(int argc, _TCHAR** argv)
{
	//_TCHAR t[] = (L"-in:../primer.txt");
	//argc = 2;
	//argv[1] = t;
	char MESSAGE[] = "\n--------------------�������� ������� ������ � ���������������-------------------\n";

	setlocale(0, "ru");
	Log::LOG log = Log::INITLOG;
	try
	{
		Parm::PARM parm = Parm::getparm(argc, argv);							
		log = Log::getlog(parm.log);										
		Log::WriteLog(log);												
		Log::WriteParm(log, parm);		
		std::cout << "������ ������������ �������..." << std::endl;
		In::IN in = In::getin(parm.in, log.stream);                           
		if (in.FS)
		{
			Log::WriteLine(log, "����������� ������ �������� � ��������", "");								
			Log::WriteLineConsole((char*)"����������� ������ �������� � ��������", "");						
			return 0;

		}
		Log::WriteIn(log, in);													
		in.words = In::getWordsTable(log.stream, in.text, in.code, in.size);	
		Lex::LEX tables;
		if (!Lex::analyze(tables, in, log, parm))
		{
			Log::WriteLine(log, "����������� ������ �������� � ��������", "");									
			Log::WriteLineConsole((char*)"����������� ������ �������� � ��������", "");						
			return 0;
		}
		LT::writeLexTable(log.stream, tables.lextable);									
		IT::writeIdTable(log.stream, tables.idtable);							
		LT::writeLexemsOnLines(log.stream, tables.lextable);					
		std::cout << "����������� ������ ������� ��������" << std::endl;
		std::cout << "������ ��������������� �������..." << std::endl;
		MFST_TRACE_START(log.stream);										
		MFST::Mfst mfst(tables, GRB::getGreibach());
		if (!mfst.start(log))
		{
			Log::WriteLine(log, "�������������� ������ �������� � ��������", "");								
			Log::WriteLineConsole((char*)"�������������� ������ �������� � ��������", "");
			return 0;
		}
		mfst.savededucation();											
		mfst.printrules(log);													
		std::cout << "�������������� ������ ������� ��������" << std::endl;
		std::cout << "������ �������������� �������..." << std::endl;
		if (!Semantic::semanticsCheck(tables, log))
		{
			Log::WriteLine(log, "������������� ������ �������� � ��������", "");							
			Log::WriteLineConsole((char*)"������������� ������ �������� � ��������", "");
			return 0;
		}			
		std::cout << "�������������� ���������..." << std::endl;

		tables.lextable.size = Polish::searchExpression(tables);				
		if (tables.lextable.size == 0)
		{
			Log::WriteLine(log, "�������������� ��������� ��������� � ��������", "");								
			Log::WriteLineConsole((char*)"�������������� ��������� ��������� � ��������", "");
			Log::WriteLine(log, "������������� ������ �������� � ��������", "");							
			Log::WriteLineConsole((char*)"������������� ������ �������� � ��������", "");
			return 0;
		}
		std::cout << "�������������� ��������� ������� ���������" << std::endl;
		std::cout << "������������� ������ ������� ��������" << std::endl;

		std::cout << "������ ��������� ����..." << std::endl;

		if (!Gener::CodeGeneration(tables, parm, log))
		{
			Log::WriteLine(log, "��������� ���� ��������� � ��������", "");						
			Log::WriteLineConsole((char*)"��������� ���� ��������� � ��������", "");
			return 0;
		}
		std::cout << "��������� ���� ������� ���������" << std::endl;
		Log::WriteLine(log, "��������� ������� ��������������", "");
		Log::WriteLineConsole((char*)"��������� ������� ��������������", "");
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
		std::cout << "������: ��������� ����" << std::endl;
	}
	return 0;
}