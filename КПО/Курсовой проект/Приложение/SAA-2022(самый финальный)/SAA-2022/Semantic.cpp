#include "stdafx.h" 
namespace Semantic 
{
	bool Semantic::semanticsCheck(Lex::LEX& tables, Log::LOG& log)
	{
		bool sem_ok = true;

		for (int i = 0; i < tables.lextable.size; i++)
		{
			switch (tables.lextable.table[i].lexema)
			{
	
			case LEX_TYPE:
			{
				if (tables.lextable.table[i + 1].lexema != LEX_ID_TYPE)
				{
					sem_ok = false;
					Log::WriteError(log.stream, Error::geterrorin(303, tables.lextable.table[i].sn, 0));
				}
				break;
			}
	
			case LEX_INCR:
			{
				IT::Entry e = tables.idtable.table[tables.lextable.table[i - 1].idxTI];
				if (e.iddatatype != IT::IDDATATYPE::INT)
				{
					sem_ok = false;
					Log::WriteError(log.stream, Error::geterrorin(314, tables.lextable.table[i].sn, 0));
				}
	

			}
	
			case LEX_DIRSLASH:
			case LEX_PROCENT:
			{
				int k = i;
				if (tables.lextable.table[i + 1].lexema == LEX_ID)
				{
					for (k; k > 0; k--)
					{
						if (tables.lextable.table[k].lexema == LEX_ID)
						{
							if (tables.idtable.table[tables.lextable.table[k].idxTI].id == tables.idtable.table[tables.lextable.table[i + 1].idxTI].id)
							{
								if (tables.lextable.table[k + 2].lexema == LEX_LITERAL && tables.idtable.table[tables.lextable.table[k + 2].idxTI].value.vint == 0)
								{
									sem_ok = false;
									Log::WriteError(log.stream, Error::geterrorin(318, tables.lextable.table[i].sn, 0));
								}
							}
						}
					}
				}
				if (tables.lextable.table[i + 1].lexema == LEX_LITERAL)
				{
					if (tables.idtable.table[tables.lextable.table[i + 1].idxTI].value.vint == 0)
					{
						sem_ok = false;
						Log::WriteError(log.stream, Error::geterrorin(318, tables.lextable.table[k].sn, 0));
					}
				}
				break;
			}
			case LEX_EQUAL: 
			{
				if (i > 0 && tables.lextable.table[i - 1].idxTI != TI_NULLIDX) 
				{
					IT::IDDATATYPE lefttype = tables.idtable.table[tables.lextable.table[i - 1].idxTI].iddatatype;
					bool ignore = false;

					for (int k = i + 1; tables.lextable.table[k].lexema != LEX_SEPARATOR; k++)
					{
						if (k == tables.lextable.size)
							break;
						if (tables.lextable.table[k].idxTI != TI_NULLIDX) 
						{
							if (!ignore)
							{
								IT::IDDATATYPE righttype = tables.idtable.table[tables.lextable.table[k].idxTI].iddatatype;
								if (lefttype != righttype) 
								{
									Log::WriteError(log.stream, Error::geterrorin(314, tables.lextable.table[k].sn, 0));
									sem_ok = false;
									break;
								}
							}
			
							if (tables.lextable.table[k + 1].lexema == LEX_LEFTHESIS)
							{
								ignore = true;
								continue;
							}
				
							if (ignore && tables.lextable.table[k + 1].lexema == LEX_RIGHTTHESIS)
							{
								ignore = false;
								continue;
							}
						}
						if (lefttype == IT::IDDATATYPE::STR || lefttype == IT::IDDATATYPE::SYM)
						{
							char l = tables.lextable.table[k].lexema;
							if (l == LEX_PLUS || l == LEX_MINUS || l == LEX_STAR || l == LEX_DIRSLASH || l == LEX_PROCENT)
							{
								Log::WriteError(log.stream, Error::geterrorin(316, tables.lextable.table[k].sn, 0));
								sem_ok = false;
								break;
							}
						}
					}
				}
				break;
			}
			case LEX_ID: 
			{
				IT::Entry e = tables.idtable.table[tables.lextable.table[i].idxTI];
				if (i > 0 && tables.lextable.table[i - 1].lexema == LEX_FUNCTION)
				{
					if (e.idtype == IT::IDTYPE::F) 
					{
						for (int k = i + 1; tables.lextable.table[k].lexema != LEX_BRACELET; k++)
						{
							char l = tables.lextable.table[k].lexema;
							if (l == LEX_RETURN)
							{
								int next = tables.lextable.table[k + 1].idxTI; 
								if (next != TI_NULLIDX)
								{
									if (tables.idtable.table[next].iddatatype != e.iddatatype)		
									{
										Log::WriteError(log.stream, Error::geterrorin(315, tables.lextable.table[k].sn, 0));
										sem_ok = false;
										break;
									}
								}
								if (next != TI_NULLIDX && e.iddatatype == IT::IDDATATYPE::PROC || next == TI_NULLIDX && e.iddatatype != IT::IDDATATYPE::PROC)
								{
									Log::WriteError(log.stream, Error::geterrorin(315, tables.lextable.table[k].sn, 0));
									sem_ok = false;
									break;
								}
							}

							if (k == tables.lextable.size)
								break;
						}
					}
				}
				if (tables.lextable.table[i + 1].lexema == LEX_LEFTHESIS && tables.lextable.table[i - 1].lexema != LEX_FUNCTION) 
				{
					if (e.idtype == IT::IDTYPE::F || e.idtype == IT::IDTYPE::S) 
					{
						int paramscount = NULL;

						for (int j = i + 1; tables.lextable.table[j].lexema != LEX_RIGHTTHESIS; j++)
						{
			
							if (tables.lextable.table[j].lexema == LEX_ID || tables.lextable.table[j].lexema == LEX_LITERAL)
							{
								paramscount++;
								if (e.value.params.count == NULL)
									break;
								IT::IDDATATYPE ctype = tables.idtable.table[tables.lextable.table[j].idxTI].iddatatype;
								if (ctype != e.value.params.types[paramscount - 1])
								{
				
									Log::WriteError(log.stream, Error::geterrorin(309, tables.lextable.table[i].sn, 0));
									sem_ok = false;
									break;
								}
							}
							if (j == tables.lextable.size)
								break;
						}
						if (paramscount != e.value.params.count)
						{
	
							Log::WriteError(log.stream, Error::geterrorin(308, tables.lextable.table[i].sn, 0));
							sem_ok = false;
						}
						if (paramscount > 5)
						{
			
							Log::WriteError(log.stream, Error::geterrorin(307, tables.lextable.table[i].sn, 0));
							sem_ok = false;
						}
					}
				}
				break;
			}
			case LEX_MORE:	case LEX_LESS: case LEX_MORE_E: case LEX_LESS_E:
			{
	
				bool flag = true;
				if (i > 1 && tables.lextable.table[i - 1].idxTI != TI_NULLIDX)
				{
					if (tables.idtable.table[tables.lextable.table[i - 1].idxTI].iddatatype != IT::IDDATATYPE::INT)
						flag = false;
				}
				if (tables.lextable.table[i + 1].idxTI != TI_NULLIDX)
				{
					if (tables.idtable.table[tables.lextable.table[i + 1].idxTI].iddatatype != IT::IDDATATYPE::INT)
						flag = false;
				}
				if (!flag)
				{
	
					Log::WriteError(log.stream, Error::geterrorin(317, tables.lextable.table[i].sn, 0));
					sem_ok = false;
				}
				break;
			}
			case LEX_EQUALS:   case LEX_NOTEQUALS:
			{
				bool flag = false;
				if (i > 1 && tables.lextable.table[i - 1].idxTI != TI_NULLIDX)
				{
					if (tables.idtable.table[tables.lextable.table[i - 1].idxTI].iddatatype == IT::IDDATATYPE::INT
						&& tables.idtable.table[tables.lextable.table[i + 1].idxTI].iddatatype == IT::IDDATATYPE::INT)
						flag = true;
					else if (tables.idtable.table[tables.lextable.table[i - 1].idxTI].iddatatype == IT::IDDATATYPE::SYM
						&& tables.idtable.table[tables.lextable.table[i + 1].idxTI].iddatatype == IT::IDDATATYPE::SYM)
						flag = true;
					else if (tables.idtable.table[tables.lextable.table[i - 1].idxTI].iddatatype == IT::IDDATATYPE::STR
						&& tables.idtable.table[tables.lextable.table[i + 1].idxTI].iddatatype == IT::IDDATATYPE::STR)
						flag = true;
				}
				if (!flag)
				{
			
					Log::WriteError(log.stream, Error::geterrorin(317, tables.lextable.table[i].sn, 0));
					sem_ok = false;
				}
				break;
			}
			}
		}
		return sem_ok;
	}
};