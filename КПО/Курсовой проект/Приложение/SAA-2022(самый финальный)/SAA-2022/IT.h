#pragma once
#include"stdafx.h"
#define ID_MAXSIZE	9					
#define SCOPED_ID_MAXSIZE   (ID_MAXSIZE*2-1)
#define MAXSIZE_TI		4096			 
#define TI_INT_DEFAULT	0x00000000		 
#define TI_STR_DEFAULT	0x00			 
#define TI_SYM_DEFAULT	0x00			 
#define TI_NULLIDX		0xffffffff		 
#define STR_MAXSIZE	255					
#define TI_INT_MAXSIZE   32767			
#define TI_INT_MINSIZE  -32768			
#define MAX_PARAMS_COUNT 5			   	
#define POW_PARAMS_CNT 2				
#define RANDOM_PARAMS_CNT 1				
#define LENGHT_PARAMS_CNT 1				
#define RANDOM_TYPE IT::IDDATATYPE::INT
#define LENGHT_TYPE IT::IDDATATYPE::INT

namespace IT			
{
	enum IDDATATYPE { INT = 1, STR = 2, SYM = 3, PROC = 5,UNDEF };								
	enum IDTYPE {
		V = 1, 
		F = 2, 
		P = 3, 
		L = 4, 
		S = 5, 
		Z = 6 };									
	enum STDFNC { F_RANDOM, F_LENGTH, F_NOT_STD };								
	static const IDDATATYPE POW_PARAMS[] = { IT::IDDATATYPE::INT, IT::IDDATATYPE::INT };	
	static const IDDATATYPE RANDOM_PARAMS[] = { IT::IDDATATYPE::INT };						
	static const IDDATATYPE LENGHT_PARAMS[] = { IT::IDDATATYPE::STR };						
	struct Entry							
	{
		int			idxfirstLE;				
		char	id[SCOPED_ID_MAXSIZE];		
		IDDATATYPE	iddatatype;				
		IDTYPE		idtype;					

		union
		{
			int vint;						
			struct
			{
				int len;					
				char str[STR_MAXSIZE - 1];	
			} vstr;							
			char symbol;					
			struct
			{
				int count;					
				IDDATATYPE* types;			
			} params;
		} value;							

		Entry()								
		{
			this->value.vint = TI_INT_DEFAULT;
			this->value.vstr.len = NULL;
			this->value.params.count = NULL;
			this->value.symbol = NULL;
		};
		Entry(char* id, int idxLT, IDDATATYPE datatype, IDTYPE idtype)
		{
			strncpy_s(this->id, id, SCOPED_ID_MAXSIZE - 1);
			this->idxfirstLE = idxLT;
			this->iddatatype = datatype;
			this->idtype = idtype;
		};
	};

	struct IdTable				
	{
		int maxsize;			
		int size;			

		Entry* table;		
	};

	IdTable Create(int size);		

	void Add(				
		IdTable& idtable,
		Entry entry			
	);
	int isId(			
		IdTable& idtable,	
		char id[SCOPED_ID_MAXSIZE]	
	);
	bool SetValue(IT::Entry* entry, char* value);	
	bool SetValue(IT::IdTable& idtable, int index, char* value);
	void writeIdTable(std::ostream* stream, IT::IdTable& idtable); 
};