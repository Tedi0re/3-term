#pragma once
#include "stdafx.h"
#pragma warning (disable : 4996)//надо разобраться
namespace Lex
{
	Graph graphs[N_GRAPHS] =
	{
		{ LEX_SEPARATORS, FST::FST(GRAPH_SEPARATORS) },
		{ LEX_MORE_E, FST::FST(GRAPH_MORE_EQUALE) },
		{ LEX_LESS_E, FST::FST(GRAPH_LESS_EQUALE) },
		{ LEX_SEPARATORS, FST::FST(GRAPH_INKR) },
		{ LEX_ID_TYPE, FST::FST(GRAPH_INTEGER) },
		{ LEX_VOID, FST::FST(GRAPH_VOID) },
		{ LEX_STDFUNC, FST::FST(GRAPH_RANDOM) },
		{ LEX_STDFUNC, FST::FST(GRAPH_LENGTH) },
		{ LEX_LITERAL, FST::FST(GRAPH_INT_D_LITERAL) },
		{ LEX_LITERAL, FST::FST(GRAPH_INT_LITERAL) },
		{ LEX_LITERAL, FST::FST(GRAPH_STRING_LITERAL) },
		{ LEX_LITERAL, FST::FST(GRAPH_SYMBOL_LITERAL) },
		{ LEX_LITERAL, FST::FST(GRAPH_INT_NEGATIVE) },
		{ LEX_TYPE, FST::FST(GRAPH_TYPE) },
		{ LEX_MAIN, FST::FST(GRAPH_MAIN) },
		{ LEX_ID_TYPE, FST::FST(GRAPH_STRING) },
		{ LEX_FUNCTION, FST::FST(GRAPH_FUNCTION) },
		{ LEX_ID_TYPE, FST::FST(GRAPH_SYMBOL) },
		{ LEX_RETURN, FST::FST(GRAPH_RETURN) },
		{ LEX_WRITE, FST::FST(GRAPH_WRITE) },
		{ LEX_NEWLINE, FST::FST(GRAPH_WRITELINE) },
		{ LEX_IF, FST::FST(GRAPH_IF) },
		{ LEX_WHILE, FST::FST(GRAPH_WHILE) },
		{ LEX_DO, FST::FST(GRAPH_DO) },
		{ LEX_IFFALSE, FST::FST(GRAPH_IFFALSE) },
		{ LEX_IFTRUE, FST::FST(GRAPH_IFTRUE) },
		{ LEX_ID, FST::FST(GRAPH_ID) }

	};
	char* getScopeName(IT::IdTable idtable, char* prevword) //получить имя области видимости
	{
		char* a = new char[5];
		a = (char*)"main\0";
		if (strcmp(prevword, MAIN) == 0)		//если main
			return a;
		for (int i = idtable.size - 1; i >= 0; i--)
			if (idtable.table[i].idtype == IT::IDTYPE::F || idtable.table[i].idtype == IT::IDTYPE::S)
				return idtable.table[i].id;
		return nullptr; // не найдено имя функции
	}

	bool isLiteral(char* id)
	{
		if (isdigit(*id) || *id == IN_CODE_DQUOTE || *id == LEX_MINUS || *id == IN_CODE_SQUOTE || *id == NULL)
			return true;
		return false;
	}
	IT::STDFNC getStandFunction(char* id)
	{
		if (!strcmp(RANDOM, id))
			return IT::STDFNC::F_RANDOM;
		if (!strcmp(LENGHT, id))
			return IT::STDFNC::F_LENGTH;
		return IT::STDFNC::F_NOT_STD;
	}
	int getLiteralIndex(IT::IdTable ittable, char* value, IT::IDDATATYPE type) // получаем индекс повторного литерала(по значению)
	{
		for (int i = 0; i < ittable.size; i++)
		{
			if (ittable.table[i].idtype == IT::IDTYPE::L && ittable.table[i].iddatatype == type)
			{
				switch (type)
				{
				case IT::IDDATATYPE::INT:
					if (ittable.table[i].value.vint == atoi(value))
						return i;
					break;
				case IT::IDDATATYPE::STR:
					char buf[STR_MAXSIZE];
					for (unsigned j = 1; j < strlen(value) - 1; j++) // без кавычек
						buf[j - 1] = value[j];
					buf[strlen(value) - 2] = IN_CODE_NULL;
					if (strcmp((char*)ittable.table[i].value.vstr.str, buf) == 0)
						return i;
					break;
				case IT::IDDATATYPE::SYM:
					if (ittable.table[i].value.symbol == value[1])
						return i;
					break;
				}

			}

		}
		return TI_NULLIDX;
	}
	IT::IDDATATYPE getType(char* curword, char* idtype)
	{
		if (idtype == nullptr)
			return IT::IDDATATYPE::UNDEF;
		if (!strcmp(TYPE_SYMBOL, idtype))
			return IT::IDDATATYPE::SYM; // символьный ид
		if (!strcmp(TYPE_VOID, idtype))
			return IT::IDDATATYPE::PROC; // процедуры
		if (!strcmp(TYPE_STRING, idtype))
			return IT::IDDATATYPE::STR;  // строковый ид
		if (!strcmp(TYPE_INTEGER, idtype))
			return IT::IDDATATYPE::INT;	 // числовой  ид
		if (isdigit(*curword) || *curword == LEX_MINUS)
			return IT::IDDATATYPE::INT;				// числовой литерал
		else if (*curword == IN_CODE_DQUOTE)
			return IT::IDDATATYPE::STR;	// строковый литерал
		else if (*curword == IN_CODE_SQUOTE)
			return IT::IDDATATYPE::SYM;	// символьный литерал
		//else if ( /**curword == (char)"true" || *curword == (char)"false"*/)
		//	return IT::IDDATATYPE::BOOL;

		return IT::IDDATATYPE::UNDEF;		// неопределенный тип, индикатор ошибки
	}
	char* getNextLiteralName()						// сгенерировать следующее имя литерала
	{
		static int literalNumber = 1;
		char* buf = new char[SCOPED_ID_MAXSIZE];
		char num[3];
		strcpy_s(buf, ID_MAXSIZE, "L");
		_itoa_s(literalNumber++, num, 10);
		strcat(buf, num);
		return buf;
	}
	int getIndexInLT(LT::LexTable& lextable, int itTableIndex)					// индекс первой встречи в таблице лексем
	{
		if (itTableIndex == TI_NULLIDX)		// если идентификатор встречается впервые
			return lextable.size;
		for (int i = 0; i < lextable.size; i++)
			if (itTableIndex == lextable.table[i].idxTI)
				return i;
		return TI_NULLIDX;
	}
	IT::Entry* getEntry(		// формирует и возвращает строку ТИ
		Lex::LEX& tables,						// ТЛ + ТИ
		char lex,								// лексема
		char* id,								// идентификатор
		char* idtype,							// предыдущая (тип)
		bool isParam,							// признак параметра функции
		bool isFunc,							// признак функции
		Log::LOG log,							// протокол
		int line,								// строка в исходном тексте
		bool& lex_ok)							// флаг ошибки(по ссылке)
	{
		// тип данных
		IT::IDDATATYPE type = getType(id, idtype);
		int index = IT::isId(tables.idtable, id);	// индекс существующего идентификатора или -1
		if (lex == LEX_LITERAL)
			index = getLiteralIndex(tables.idtable, id, type);
		if (index != TI_NULLIDX)
			return nullptr;							// уже существует
		IT::Entry* itentry = new IT::Entry;
		itentry->iddatatype = type; // сохраняем тип данных


		itentry->idxfirstLE = getIndexInLT(tables.lextable, index); // индекс первой строки в таблице лексем 

		if (lex == LEX_LITERAL) // литерал
		{
			bool int_ok = IT::SetValue(itentry, id);
			if (int_ok && itentry->iddatatype == IT::IDDATATYPE::INT)
			{
				char p[11];
				itoa(itentry->value.vint, p, 10);
				index = getLiteralIndex(tables.idtable, p, type);
				if (index != TI_NULLIDX)
					return nullptr;
			}
			if (!int_ok)
			{
				// превышен максимальный размер числового литерала
				Log::WriteError(log.stream, Error::geterrorin(313, line, 0));
				lex_ok = false;
			}
			if (itentry->iddatatype == IT::IDDATATYPE::STR && itentry->value.vstr.len == 0)
			{
				Log::WriteError(log.stream, Error::geterrorin(310, line, 0));
				lex_ok = false;
			}
			strcpy_s(itentry->id, getNextLiteralName());
			itentry->idtype = IT::IDTYPE::L;
		}
		else // идентификатор
		{
			switch (type)
			{
			case IT::IDDATATYPE::STR:
				strcpy_s(itentry->value.vstr.str, "");
				itentry->value.vstr.len = TI_STR_DEFAULT;
				break;
			case IT::IDDATATYPE::INT:
				itentry->value.vint = TI_INT_DEFAULT;
				break;
			case IT::IDDATATYPE::SYM:
				itentry->value.symbol = TI_SYM_DEFAULT;
				break;
			}

			if (isFunc)
			{
				switch (getStandFunction(id))
				{
				case IT::STDFNC::F_RANDOM:
				{
					itentry->idtype = IT::IDTYPE::S;
					itentry->iddatatype = RANDOM_TYPE;
					itentry->value.params.count = RANDOM_PARAMS_CNT;
					itentry->value.params.types = new IT::IDDATATYPE[RANDOM_PARAMS_CNT];
					for (int k = 0; k < RANDOM_PARAMS_CNT; k++)
						itentry->value.params.types[k] = IT::RANDOM_PARAMS[k];
					break;
				}
				case IT::STDFNC::F_LENGTH:
				{
					itentry->idtype = IT::IDTYPE::S;
					itentry->iddatatype = LENGHT_TYPE;
					itentry->value.params.count = LENGHT_PARAMS_CNT;
					itentry->value.params.types = new IT::IDDATATYPE[LENGHT_PARAMS_CNT];
					for (int k = 0; k < LENGHT_PARAMS_CNT; k++)
						itentry->value.params.types[k] = IT::LENGHT_PARAMS[k];
					break;
				}
				case IT::STDFNC::F_NOT_STD:
					itentry->idtype = IT::IDTYPE::F;
					break;
				}
			}
			else if (isParam)
				itentry->idtype = IT::IDTYPE::P;
			else
				itentry->idtype = IT::IDTYPE::V;
			if (!isFunc)
			{
				memset(itentry->id, '\0', SCOPED_ID_MAXSIZE);
				strncat(itentry->id, id, SCOPED_ID_MAXSIZE);
			}
			else
			{
				char temp[SCOPED_ID_MAXSIZE] = "";
				strncat(temp, id, ID_MAXSIZE);
				memset(itentry->id, '\0', SCOPED_ID_MAXSIZE);
				strncat(itentry->id, id, SCOPED_ID_MAXSIZE);
			}
		}

		// -------------------------------------------------------
		int i = tables.lextable.size; // индекс в ТЛ текущего ИД

		if (i > 1 && itentry->idtype == IT::IDTYPE::V && tables.lextable.table[i - 2].lexema != LEX_TYPE)
		{
			// в объявлении отсутствует ключевое слово type
			Log::WriteError(log.stream, Error::geterrorin(304, line, 0));
			lex_ok = false;
		}
		if (i > 1 && itentry->idtype == IT::IDTYPE::F && tables.lextable.table[i - 1].lexema != LEX_FUNCTION)
		{
			// в объявлении не указан тип функции
			Log::WriteError(log.stream, Error::geterrorin(303, line, 0));
			lex_ok = false;
		}
		if (itentry->iddatatype == IT::IDDATATYPE::UNDEF)
		{
			// невозможно определелить тип
			Log::WriteError(log.stream, Error::geterrorin(300, line, 0));
			lex_ok = false;
		}
		return itentry;
	}

	bool analyze(LEX& tables, In::IN& in, Log::LOG& log, Parm::PARM& parm)
	{
		static bool lex_ok = true;										//результат работы лексического анализатора
		tables.lextable = LT::Create(LT_MAXSIZE);						//создание табицы лексем
		tables.idtable = IT::Create(MAXSIZE_TI);						//создание таблицы идентификаторов
		bool isParam = false, isFunc = false;							//флаги для функций и параметров
		int enterPoint = NULL;											//кол-во точек входа
		char curword[STR_MAXSIZE], nextword[STR_MAXSIZE];				//текущее слово и следующее слово
		int curline;													//текущая строка
		std::stack <char*> scopes;										// стек для хранения имени текущей области видимости
		for (int i = 0; i < in.words->size; i++)						//обход таблицы слов
		{
			strcpy_s(curword, in.words[i].word);						//копирование текущего слова из таблицы слов
			if (i < in.words->size - 1)									//если слово не является последним
			{
				if (strlen(in.words[i + 1].word) <= STR_MAXSIZE)
				{
					strcpy_s(nextword, in.words[i + 1].word);			//копирование следующего слова из таблицы слов
				}
				else
				{
					lex_ok = false;
					Log::WriteError(log.stream, Error::geterrorin(321, curline, 0));
					break;
				}
			}


			curline = in.words[i].line;									//задание текущей линии
			isFunc = false;												//Не функция
			int idxTI = TI_NULLIDX;										//значение id по-умолчанию
			for (int j = 0; j < N_GRAPHS; j++)							//обходы всех графов
			{
				FST::FST fst((unsigned char*)curword, graphs[j].graph);	//берем графы до тех пор, пока не найдется нужный
				if (FST::execute(fst))									//проверяем текущее слово на выбранном графе
				{
					char lexema = graphs[j].lexema;
					switch (lexema)
					{
					case LEX_MAIN:
						enterPoint++;
						break;
					case LEX_SEPARATORS:
					{
						switch (*curword)
						{
						case LEX_LEFTHESIS:		// открывающая скобка - параметры  функции (
						{
							isParam = true;
							if (*nextword == LEX_RIGHTTHESIS || ISTYPE(nextword)) //если следующее слово равно ) или не равно integer, string(где symbol)
							{
								char* functionname = new char[ID_MAXSIZE];								//функция для области видимости
								char* scopename = getScopeName(tables.idtable, in.words[i - 1].word);	//имя области видимости
								if (scopename == nullptr)
									break;
								memset(functionname, '\0', ID_MAXSIZE);
								strncat(functionname, scopename, ID_MAXSIZE);
								scopes.push(functionname);
							}
							break;
						}
						case LEX_RIGHTTHESIS:	// закрывающая скобка
						{
							isParam = false;
							// конец области видимости
							if (*in.words[i - 1].word == LEX_LEFTHESIS || (i > 2 && (tables.lextable.table[tables.lextable.size - 2].lexema == LEX_ID_TYPE)))
								scopes.pop();
							break;
						}
						case LEX_LEFTBRACE:		// начало области видимости {
						{
							char* functionname = new char[ID_MAXSIZE];
							char* scopename = getScopeName(tables.idtable, in.words[i - 1].word);
							if (scopename == nullptr)
								break;
							memset(functionname, '\0', ID_MAXSIZE);
							strncat(functionname, scopename, ID_MAXSIZE);
							scopes.push(functionname);
							break;
						}
						case LEX_BRACELET:		// конец области видимости
						{
							// только в этом случае закрываем область видимости
							if (*in.words[i + 1].word == LEX_ID_TYPE || *in.words[i + 1].word == LEX_MAIN)
							{
								if (!scopes.empty())
									scopes.pop();
							}
							break;
						}
						case LEX_INCR:  //:
						{
							int index = IT::isId(tables.idtable, curword);  //возврат номера строки
							IT::Entry* itentry = new IT::Entry;
							if (index != TI_NULLIDX)
							{
								idxTI = index;
							}
							else
							{
								memset(itentry->id, '\0', SCOPED_ID_MAXSIZE);
								strncat(itentry->id, curword, SCOPED_ID_MAXSIZE);
								itentry->idtype = IT::IDTYPE::Z;
								itentry->iddatatype = IT::IDDATATYPE::INT;
								itentry->idxfirstLE = getIndexInLT(tables.lextable, index);
								IT::Add(tables.idtable, *itentry);
								idxTI = tables.idtable.size - 1;
							}
							lexema = *curword;
							break;
						}
						}
						lexema = *curword;
						break;
					}

					case LEX_ID:
					case LEX_STDFUNC:
					case LEX_LITERAL:
					{
						char id[STR_MAXSIZE] = "";
						idxTI = NULLDX_TI;								
						if (*nextword == LEX_LEFTHESIS || IT::isId(tables.idtable, curword) != TI_NULLIDX)
						{
							isFunc = true;
							if (getStandFunction(curword) == IT::STDFNC::F_NOT_STD)
								strncat(id, "_", ID_MAXSIZE);
						}
						char* idtype = (isFunc && i > 1) ?			
							in.words[i - 2].word : in.words[i - 1].word;	
						if (i == 0)
							idtype = nullptr;
						if (!isFunc && !scopes.empty())
							strncpy_s(id, scopes.top(), ID_MAXSIZE);
						strncat(id, curword, ID_MAXSIZE);
						if (isLiteral(curword))
							strcpy_s(id, curword);
						IT::Entry* itentry = getEntry(tables, lexema, id, idtype, isParam, isFunc, log, curline, lex_ok);
						if (itentry != nullptr)
						{
							if (isFunc) 
							{
								itentry->value.params.count = NULL;
								itentry->value.params.types = new IT::IDDATATYPE[MAX_PARAMS_COUNT];
								for (int k = i; in.words[k].word[0] != LEX_RIGHTTHESIS; k++)
								{
									if (k == in.words->size || in.words[k].word[0] == LEX_SEPARATOR)
										break;
									if (ISTYPE(in.words[k].word))
									{
										if (itentry->value.params.count >= MAX_PARAMS_COUNT)
										{
											Log::WriteError(log.stream, Error::geterrorin(306, curline, 0));
											lex_ok = false;
											break;
										}
										itentry->value.params.types[itentry->value.params.count++] = getType(NULL, in.words[k].word);
									}
								}
							}
							IT::Add(tables.idtable, *itentry);
							idxTI = tables.idtable.size - 1;
						}
						else
						{
							int i = tables.lextable.size - 1;
							if (i > 0 && tables.lextable.table[i - 1].lexema == LEX_TYPE || tables.lextable.table[i].lexema == LEX_TYPE
								|| tables.lextable.table[i - 1].lexema == LEX_FUNCTION || tables.lextable.table[i].lexema == LEX_FUNCTION
								|| tables.lextable.table[i - 1].lexema == LEX_ID_TYPE || tables.lextable.table[i].lexema == LEX_ID_TYPE
								|| tables.lextable.table[i - 1].lexema == LEX_VOID || tables.lextable.table[i].lexema == LEX_VOID)
							{
								Log::WriteError(log.stream, Error::geterrorin(305, curline, 0));
								lex_ok = false;
							}
							idxTI = IT::isId(tables.idtable, id);	
							if (lexema == LEX_LITERAL)
							{
								idxTI = getLiteralIndex(tables.idtable, curword, getType(id, in.words[i - 1].word));
								if (idxTI == -1)
								{
									int temp;
									if ((getType(id, in.words[i - 1].word)) == IT::IDDATATYPE::INT)
									{
										if ((curword[0] == '-' && (curword[1] == '0' && curword[2] == 'x')) || (curword[0] == '0' && curword[1] == 'x'))
											temp = strtol(curword, NULL, 16);
										else if ((curword[0] == '-' && curword[1] == '0') || curword[0] == '0')
											temp = strtol(curword, NULL, 8);
										else if ((curword[0] == '-' && curword[1] == '0' && curword[2] == 'b') || curword[0] == '0' && curword[1] == 'b')
											temp = strtol(curword, NULL, 2);
									}
									char p[10];
									itoa(itentry->value.vint, p, 10);
									idxTI = getLiteralIndex(tables.idtable, p, getType(id, in.words[i - 1].word));
								}
							}
						}
					}
					break;
					}
					LT::Entry* ltentry = new LT::Entry(lexema, curline, idxTI);				
					LT::Add(tables.lextable, *ltentry);									
					break;
				}
				else if (j == N_GRAPHS - 1)
				{
					Log::WriteError(log.stream, Error::geterrorin(201, curline, 0));
					lex_ok = false;
				}

			}
		}
		if (enterPoint == NULL) 
		{
			Log::WriteError(log.stream, Error::geterror(301));
			lex_ok = false;
		}
		if (enterPoint > 1) 
		{
			Log::WriteError(log.stream, Error::geterror(302));
			lex_ok = false;
		}
		return lex_ok;
	}

}