#include "stdafx.h"
#include <string>

using namespace std;

namespace Gener
{

	bool CodeGeneration(Lex::LEX& lex, Parm::PARM& parm, Log::LOG& log)
	{
		bool gen_ok;
		ofstream ofile(parm.out);
		ofile << BEGIN;
		ofile << EXTERN;
		ofile << ".const\n null_division BYTE 'ERROR: DIVISION BY ZERO', 0\n overflow BYTE 'ERROR: VARIABLE OVERFLOW', 0 \n";
		int conditionnum = 0, cyclenum = 0;
		for (int i = 0; i < lex.idtable.size; i++)
		{
			if (lex.idtable.table[i].idtype == IT::L)
			{
				ofile << "\t" << lex.idtable.table[i].id;
				if (lex.idtable.table[i].iddatatype == IT::SYM)
				{
					ofile << " BYTE \'" << lex.idtable.table[i].value.symbol << "\', 0\n";
				}
				if (lex.idtable.table[i].iddatatype == IT::STR)
				{
					ofile << " BYTE \'" << lex.idtable.table[i].value.vstr.str << "\', 0\n";
				}
				if (lex.idtable.table[i].iddatatype == IT::INT)
				{
					ofile << " SWORD " << lex.idtable.table[i].value.vint << endl;
				}
			}
		}
		ofile << ".data\n";
		for (int i = 0; i < lex.idtable.size; i++)
		{
			if (lex.idtable.table[i].idtype == IT::IDTYPE::V)
			{
				ofile << "\t" << lex.idtable.table[i].id;
				if (lex.idtable.table[i].iddatatype == IT::SYM)
				{
					ofile << " DWORD ?\n";
				}
				if (lex.idtable.table[i].iddatatype == IT::STR)
				{
					ofile << " DWORD ?\n";
				}
				if (lex.idtable.table[i].iddatatype == IT::INT)
				{
					ofile << " SWORD 0\n";
				}
			}
		}

		stack<string> stk;
		stack<IT::Entry> temp;
		string cyclecode = "", func_name = "";				
		bool flag_cycle = false,				
			flag_main = false,
			flag_if = false,				
			flag_true = false,
			flag_false = false,
			flag_return = false;

		ofile << "\n.code\n\n";
		for (int i = 0; i < lex.lextable.size; i++)
		{
			switch (lex.lextable.table[i].lexema)
			{
			case LEX_FUNCTION:
			{
				i++;
				flag_return = false;
				ofile << (func_name = ITENTRY(i).id) << " PROC ";
				int j = i + 2;
				while (LEXEMA(j) != LEX_RIGHTTHESIS) 
				{
					if (lex.lextable.table[j].lexema == LEX_ID) 
					{
						ofile << lex.idtable.table[lex.lextable.table[j].idxTI].id << " : ";
						if (ITENTRY(j).iddatatype == IT::IDDATATYPE::INT)
						{
							ofile << " SWORD ";
						}
						else if (ITENTRY(j).iddatatype == IT::IDDATATYPE::SYM)
						{
							ofile << " DWORD ";
						}
						else
						{
							ofile << " DWORD ";
						}
					}
					if (LEXEMA(j) == LEX_COMMA)
					{
						ofile << ", ";
					}
					j++;
				}
				ofile << endl;
				break;
			}
			case LEX_MAIN:
			{
				flag_main = true;
				ofile << "main PROC\n";
				break;
			}
			case LEX_RETURN:
			{
				if (flag_main)
				{
					Log::WriteError(log.stream, Error::geterrorin(320, lex.lextable.table[i].sn, 0));
					ofile.close();
					return false;
				}
				if (LEXEMA(i + 1) != LEX_SEPARATOR)
				{
					if (LEXEMA(i + 1) != LEX_LEFTHESIS && (ITENTRY(i + 1).iddatatype == IT::IDDATATYPE::INT || ITENTRY(i + 1).idtype == IT::IDTYPE::P || ITENTRY(i + 1).idtype == IT::IDTYPE::V))
						ofile << "\tmov ax, " << ITENTRY(i + 1).id << "\n";
					else if (LEXEMA(i + 1) != LEX_LEFTHESIS)
						ofile << "\tmov ax,offset " << ITENTRY(i + 1).id << "\n";
					else if (LEXEMA(i + 2) != LEX_MINUS)
						ofile << "\tmov ax, " << ITENTRY(i + 2).id << "\n";
					else
					{
						ofile << "\tmov ax, 0\n";
						ofile << "\tmov bx," << ITENTRY(i + 3).id;
						ofile << "\n\tsub ax, bx\n";
					}
				}
				ofile << "\tret\n";
				if (!flag_return)
				{
					ofile << "\nSOMETHINGWRONG:"\
						"\npush offset null_division"\
						"\ncall outstrline\n"\
						"call system_pause"\
						"\npush -1"\
						"\ncall ExitProcess\n"\
						"\nEXIT_OVERFLOW:"\
						"\npush offset overflow"\
						"\ncall outstrline\n"\
						"call system_pause"\
						"\npush -2"\
						"\ncall ExitProcess\n";
					flag_return = true;
				}
				break;
			}
			case LEX_BRACELET:
			{
				if (flag_main)
					break;
				ofile << func_name + " ENDP\n";
				break;
			}
			case LEX_EQUAL:
			{
				int result_position = i - 1;
				while (lex.lextable.table[i].lexema != LEX_SEPARATOR)
				{

					switch (LEXEMA(i))
					{
					case LEX_STDFUNC:
					case LEX_LITERAL:
					{
						if (ITENTRY(i).iddatatype == IT::IDDATATYPE::INT)
						{
							ofile << "\tpush " << ITENTRY(i).id << endl;
							stk.push(lex.idtable.table[lex.lextable.table[i].idxTI].id);
							break;
						}
						else
						{
							ofile << "\tpush offset " << ITENTRY(i).id << endl;
							stk.push("offset" + (string)lex.idtable.table[lex.lextable.table[i].idxTI].id);
							break;
						}
					}
					case LEX_ID:
					{

						ofile << "\tpush " << ITENTRY(i).id << endl;
						stk.push(lex.idtable.table[lex.lextable.table[i].idxTI].id);
						break;
					}
					case LEX_SUBST:
					{
						for (int j = 1; j <= (LEXEMA(i + 1) - '0') + 1; j++)
						{
							ofile << "\tpop dx\n";

						}
						for (int j = 1; j <= lex.lextable.table[i + 1].lexema - '0'; j++)
						{
							ofile << "\tpush " << stk.top() << endl;
							stk.pop();
						}
						ofile << "\t\tcall " << ITENTRY(i - (lex.lextable.table[i + 1].lexema - '0') - 1).id << "\n\tpush ax\n";
						break;
					}
					case LEX_TILDA:
					{
						ofile << "\tmov ax, 0\n\tpop bx\n";
						ofile << "\tsub ax, bx\n\tpush ax\n";
						break;
					}
					case LEX_STAR:
					{
						ofile << "\tpop ax\n\tpop bx\n";
						ofile << "\timul bx\n\tjo EXIT_OVERFLOW\n\tpush ax\n";

						break;
					}

					case LEX_PLUS:
					{
						ofile << "\tpop ax\n\tpop bx\n";
						ofile << "\tadd ax, bx\n\tjo EXIT_OVERFLOW\n\tpush ax\n";
						break;
					}
					case LEX_MINUS:
					{
						if (LEXEMA(i - 2) == LEX_EQUAL)
						{
							ofile << "\tmov ax, 0\n\tpop bx\n";
							ofile << "\tsub ax, bx\n\tpush ax\n";
							break;
						}
						ofile << "\tpop bx\n\tpop ax\n";
						ofile << "\tsub ax, bx\n\tpush ax\n";
						break;
					}
					case LEX_DIRSLASH:
					{
						ofile << "\tpop bx\n\tpop ax\n";
						ofile << "\tcmp bx,0\n"\
							"\tje SOMETHINGWRONG\n";
						ofile << "\tcdq\n";
						ofile << "\tidiv bx\n\tpush ax\n";
						break;
					}
					case LEX_PROCENT:
					{

						ofile << "\tpop bx\n\tpop ax\n";
						ofile << "\tcmp bx,0\n"\
							"\tje SOMETHINGWRONG\n";
						ofile << "\tcdq\n";
						ofile << "\tidiv bx\n\tpush dx\n";
						break;
					}
					}
					i++;
				}
				ofile << "\tpop " << ITENTRY(result_position).id << "\n";
				ofile << endl;
				break;
			}
			case LEX_ID:
			{
				if (LEXEMA(i + 1) == LEX_LEFTHESIS && LEXEMA(i - 1) != LEX_FUNCTION
					&& lex.lextable.table[i].sn > lex.lextable.table[i - 1].sn)
				{
					for (int j = i + 1; LEXEMA(j) != LEX_RIGHTTHESIS; j++)
					{
						if (LEXEMA(j) == LEX_ID || LEXEMA(j) == LEX_LITERAL)
							temp.push(ITENTRY(j));
					}
					while (!temp.empty())
					{
						if (temp.top().idtype == IT::IDTYPE::L && (temp.top().iddatatype == IT::IDDATATYPE::STR || temp.top().iddatatype == IT::IDDATATYPE::SYM))
							ofile << "\npush offset " << temp.top().id << "\n";
						else  ofile << "\npush " << temp.top().id << "\n";
						temp.pop();
					}
					ofile << "\ncall " << ITENTRY(i).id << "\n";
				}
				break;
			}
			case LEX_INCR:
			{
				ofile << "\tmov ax," << ITENTRY(i - 1).id << "\n";
				ofile << "\tmov bx," << 1 << "\n";
				switch (ITENTRY(i).id[1])
				{
				case LEX_PLUS:
				{
					ofile << "\tadd ax, bx\n\tjo EXIT_OVERFLOW\n";
					break;
				}
				case LEX_MINUS:
				{
					ofile << "\tsub ax, bx\n\tjo EXIT_OVERFLOW\n";
					break;
				}
				}
				ofile << "\tmov " << ITENTRY(i - 1).id << " , ax\n";
				break;
			}
			case LEX_NEWLINE: 
			{
				switch (ITENTRY(i + 1).iddatatype)
				{
				case IT::IDDATATYPE::INT:
					ofile << "\npush " << ITENTRY(i + 1).id << "\ncall outnumline\n";
					break;
				case IT::IDDATATYPE::SYM:
				case IT::IDDATATYPE::STR:
					if (ITENTRY(i + 1).idtype == IT::IDTYPE::L)
						ofile << "\npush offset " << ITENTRY(i + 1).id << "\ncall outstrline\n";
					else ofile << "\npush " << ITENTRY(i + 1).id << "\ncall outstrline\n";
					break;
				}
				break;
			}
			case LEX_WRITE:
			{
				switch (ITENTRY(i + 1).iddatatype)
				{
				case IT::IDDATATYPE::INT:
					ofile << "\npush " << ITENTRY(i + 1).id << "\ncall outnum\n";
					break;
				case IT::IDDATATYPE::SYM:
				case IT::IDDATATYPE::STR:
					if (ITENTRY(i + 1).idtype == IT::IDTYPE::L)
						ofile << "\npush offset " << ITENTRY(i + 1).id << "\ncall outstr\n";
					else ofile << "\npush " << ITENTRY(i + 1).id << "\ncall outstr\n";
					break;
				}
				break;
			}
			case LEX_IF: 
			{
				conditionnum++;
				flag_if = true;
				char* right = (char*)"", * wrong = (char*)"";
				int j = i;
				while (LEXEMA(j) != LEX_SQ_RBRACELET)
				{
					if (LEXEMA(j) == LEX_IFTRUE)
					{
						flag_true = true;
					}
					else if (LEXEMA(j) == LEX_IFFALSE)
					{
						flag_false = true;
					}
					j++;
				}
				if (LEXEMA(j + 1) == LEX_IFTRUE || LEXEMA(j + 1) == LEX_IFFALSE)
				{
					flag_true = true;
					flag_false = true;
				}
				switch (LEXEMA(i + 2))
				{
				case LEX_MORE:
					right = (char*)"jg";  wrong = (char*)"jle";
					break;
				case LEX_LESS:
					right = (char*)"jl";  wrong = (char*)"jge";
					break;
				case LEX_EQUALS:
					right = (char*)"jz";  wrong = (char*)"jnz";
					break;
				case LEX_NOTEQUALS:
					right = (char*)"jnz";  wrong = (char*)"jz";
					break;
				case LEX_MORE_E:
					right = (char*)"jge";  wrong = (char*)"jle";
					break;
				case LEX_LESS_E:
					right = (char*)"jle";  wrong = (char*)"jge";
					break;
				}
			
				if (ITENTRY(i + 1).iddatatype == IT::IDDATATYPE::INT)
				{
					if (LEXEMA(i+2) == LEX_IFTRUE || LEXEMA(i+2) == LEX_IFFALSE)
					{
						right = (char*)"jnz";  wrong = (char*)"jz";
						
						ofile << "\tmov dx, " << ITENTRY(i + 1).id << "\n\tcmp dx, " << '0' << "\n";

					}
					else
					{
						ofile << "\tmov dx, " << ITENTRY(i + 1).id << "\n\tcmp dx, " << ITENTRY(i + 3).id << "\n";
					}

				}
				if (ITENTRY(i + 1).iddatatype == IT::IDDATATYPE::SYM || ITENTRY(i + 1).iddatatype == IT::IDDATATYPE::STR)
				{
					throw Error::geterror(608);
					
				}
				if (flag_true)
					ofile << "\t" << right << " right" << conditionnum << "\n";
				if (flag_false)
					ofile << "\t" << wrong << " wrong" << conditionnum << "\n";
				ofile << "\t" << "jmp next" << conditionnum << "\n";
				if (LEXEMA(i + 2) == LEX_IFTRUE || LEXEMA(i + 2) == LEX_IFFALSE)
				{
					i += 1;
				}
				else
				{
					i += 2;
				}
				break;
			}
			case LEX_IFTRUE:
			{
				ofile << "right" << conditionnum << ":";
				break;
			}
			case LEX_IFFALSE:
			{
				ofile << "wrong" << conditionnum << ":";
				break;
			}
			case LEX_SQ_RBRACELET:
			{
				if (flag_cycle && !flag_if)
				{
					flag_cycle = false;
					ofile << cyclecode;
					ofile << "continue" << cyclenum << ":";
				}
				if (flag_if)
				{
					if (LEXEMA(i + 1) != LEX_IFTRUE && LEXEMA(i + 1) != LEX_IFFALSE)
					{
						ofile << "\nnext" << conditionnum << ":";
						flag_if = false;
						flag_true = false;
						flag_false = false;
					}
					else
					{
						ofile << "\tjmp next" << conditionnum << "\n\n";
					}
				}
				break;
			}
			case LEX_WHILE:
			{
				flag_cycle = true;
				cyclecode.clear();
				cyclenum++;
				char* right = (char*)"", * wrong = (char*)"";
				switch (LEXEMA(i + 2))
				{
				case LEX_MORE:
					right = (char*)"jg";  wrong = (char*)"jle";
					break;
				case LEX_LESS:
					right = (char*)"jl";  wrong = (char*)"jge";
					break;
				case LEX_EQUALS:
					right = (char*)"jz";  wrong = (char*)"jnz";
					break;
				case LEX_NOTEQUALS:
					right = (char*)"jnz";  wrong = (char*)"jz";
					break;
				case LEX_MORE_E:
					right = (char*)"jge";  wrong = (char*)"jle";
					break;
				case LEX_LESS_E:
					right = (char*)"jle";  wrong = (char*)"jge";
					break;
				}
				if (ITENTRY(i + 1).iddatatype == IT::IDDATATYPE::INT)
				{
					if (lex.lextable.table[i+2].lexema == LEX_DO)
					{
						right = (char*)"jnz";  wrong = (char*)"jz";

						ofile << "\tmov dx, " << ITENTRY(i + 1).id << "\n\tcmp dx, " << '0' << "\n";

					}
					else
					{
						ofile << "\tmov dx, " << ITENTRY(i + 1).id << "\n\tcmp dx, " << ITENTRY(i + 3).id << "\n";
					}

				}
				if (ITENTRY(i + 1).iddatatype == IT::IDDATATYPE::SYM || ITENTRY(i + 1).iddatatype == IT::IDDATATYPE::STR)
				{
					throw Error::geterror(608);
				}
				cyclecode += "\t" + (string)right + " cycle" + std::to_string(cyclenum) + "\n";
				ofile << cyclecode;
				ofile << "\t" << "jmp continue" << cyclenum << "\n";

				if (LEXEMA(i + 2) == LEX_DO)
				{
					i += 1;
				}
				else
				{
					i += 2;
				}
				
				
				break;
			}
			case LEX_DO:
			{
				ofile << " cycle" << cyclenum << ":";
			}

			}
		}
		ofile << END;
		ofile.close();
		return true;
	};
}