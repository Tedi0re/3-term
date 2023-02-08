#include "stdafx.h"
#pragma warning (disable : 4996)
#define W(x, y)\
		<< std::setw(x) << (y) <<
#define STR(n, line, type, id)\
		"|" W(4,n) " |  " W(6,line) "    |" W(21,type) " |  " W(SCOPED_ID_MAXSIZE, id) " |"
namespace IT
{
	IdTable Create(int size)
	{
		if (size > MAXSIZE_TI)
			throw ERROR_THROW(203);
		IdTable idtable;
		idtable.table = new Entry[idtable.maxsize = size];
		idtable.size = NULL;
		return idtable;
	}
	void Add(IdTable& idtable, Entry entry)
	{
		if (idtable.size >= idtable.maxsize)
			throw ERROR_THROW(203);
		idtable.table[idtable.size++] = entry;
	}


	int isId(IdTable& idtable, char id[SCOPED_ID_MAXSIZE])
	{
		for (int i = 0; i < idtable.size; i++)
		{
			if (strcmp(idtable.table[i].id, id) == 0)
				return i;
		}
		return TI_NULLIDX;
	}

	bool SetValue(IT::IdTable& idtable, int index, char* value)
	{
		return SetValue(&(idtable.table[index]), value);
	}
	bool SetValue(IT::Entry* entry, char* value)
	{
		bool rc = true;
		if (entry->iddatatype == INT)
		{
			int temp;
			if ((value[0] == '-' && (value[1] == '0' && value[2] == 'x')) || (value[0] == '0' && value[1] == 'x'))
				temp = strtol(value, NULL, 16);
			else if ((value[0] == '-' && value[1] == '0' && value[2] == 'b') || value[0] == '0' && value[1] == 'b')
			{
				int digit = 0;
				int count = 1;
				if (value[2] == 'b')
				{
					value[2] = '0';
					for (int i = strlen(value); i > 1; i--, count *= 2)
					{
						if ((value[i - 1] != '0') && (value[i - 1] != '1'))
						{
							std::cout << "Îøèáêà ââîäà ÷èñëà, íå ïðàâèëüíûé ôîðìàò" << std::endl;
							break;
						}
						if (value[i - 1] == '1')
						{
							digit -= count;
						}

						
					}
					temp = digit;
				}
					
				else
				{
					value[1] = '0';
					for (int i = strlen(value); i > 0; i--, count *= 2)
					{
						if ((value[i - 1] != '0') && (value[i - 1] != '1'))
						{
							std::cout << "Îøèáêà ââîäà ÷èñëà, íå ïðàâèëüíûé ôîðìàò" << std::endl;
							break;
						}
						if (value[i - 1] == '1')
						{
							digit += count;
						}
	
						
					}
					temp = digit;
				}
					
				
				
				
			}

			else if ((value[0] == '-' && value[1] == '0') || value[0] == '0')
				temp = strtol(value, NULL, 8);
			else
				temp = atoi(value);
			if (temp > TI_INT_MAXSIZE || temp < TI_INT_MINSIZE)
			{
				if (temp > TI_INT_MAXSIZE)
					temp = TI_INT_MAXSIZE;
				if (temp < TI_INT_MINSIZE)
					temp = TI_INT_MINSIZE;
				rc = false;
			}
			entry->value.vint = temp;
		}
		else if (entry->iddatatype == STR)
		{
			for (int i = 1; i < strlen(value) - 1; i++)
				entry->value.vstr.str[i - 1] = value[i];
			entry->value.vstr.str[strlen(value) - 2] = '\0';
			entry->value.vstr.len = strlen(value) - 2;
		}
		else if(entry->iddatatype == SYM)
		{
			entry->value.symbol = value[1];
		}
		return rc;
	}
	void writeIdTable(std::ostream* stream, IT::IdTable& idtable)
	{
		*stream << "---------------------------- ÒÀÁËÈÖÀ ÈÄÅÍÒÈÔÈÊÀÒÎÐÎÂ ------------------------\n" << std::endl;
		*stream << "|  N  |ÑÒÐÎÊÀ Â ÒË |  ÒÈÏ ÈÄÅÍÒÈÔÈÊÀÒÎÐÀ  |        ÈÌß         | ÇÍÀ×ÅÍÈÅ (ÏÀÐÀÌÅÒÐÛ)" << std::endl;
		for (int i = 0; i < idtable.size; i++)
		{
			IT::Entry* e = &idtable.table[i];
			char type[50] = "";

			switch (e->iddatatype)
			{
			case IT::IDDATATYPE::INT:
				strcat(type, "  int ");
				break;
			case IT::IDDATATYPE::STR:
				strcat(type, " string  ");
				break;
			case IT::IDDATATYPE::SYM:
				strcat(type, "   symbol  ");
				break;
			case IT::IDDATATYPE::UNDEF:
				strcat(type, "UNDEFINED");
				break;
			}
			switch (e->idtype)
			{
			case IT::IDTYPE::V:
				strcat(type, "  variable");
				break;
			case IT::IDTYPE::F:
				strcat(type, "  function");
				break;
			case IT::IDTYPE::P:
				strcat(type, " parameter");
				break;
			case IT::IDTYPE::L:
				strcat(type, "   literal");
				break;
			case IT::IDTYPE::S: strcat(type, "  LIB FUNC"); break;
			default:
				strcat(type, "UNDEFINED ");
				break;
			}

			*stream << STR(i, e->idxfirstLE, type, e->id);
			if (e->idtype == IT::IDTYPE::L || e->idtype == IT::IDTYPE::V && e->iddatatype != IT::IDDATATYPE::UNDEF)
			{
				if (e->iddatatype == IT::IDDATATYPE::INT)
					*stream << e->value.vint;
				else if (e->iddatatype == IT::IDDATATYPE::STR)
					*stream << "[" << (int)e->value.vstr.len << "]" << e->value.vstr.str;
				else
					*stream << e->value.symbol;
			}
			if (e->idtype == IT::IDTYPE::F || e->idtype == IT::IDTYPE::S)
			{
				for (int i = 0; i < e->value.params.count; i++)
				{
					*stream << " P" << i << ":";
					switch (e->value.params.types[i])
					{
					case IT::IDDATATYPE::INT:
						*stream << "INTEGER |";
						break;
					case IT::IDDATATYPE::STR:
						*stream << "STRING |";
						break;
					case IT::IDDATATYPE::SYM:
						*stream << "SYMBOL |";
						break;
					case IT::IDDATATYPE::UNDEF:
						*stream << "UNDEFINED";
						break;
					}
				}
			}
			*stream << std::endl;
		}
		*stream << "\n-------------------------------------------------------------------------\n\n";
	}


};