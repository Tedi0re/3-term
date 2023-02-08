#pragma once
#include "stdafx.h"
namespace FST
{
	struct RELATION							
	{
		unsigned char symbol;				
		short nnode;						
		RELATION(
			unsigned char c = 0x00,			
			short ns = 0					
		);
	};

	struct NODE								
	{
		short n_relation;					
		RELATION* relations;				
		NODE();
		NODE
		(short n,							
			RELATION rel, ...				
		);
	};

	struct FST								
	{
		unsigned char* string;				
		short position;						
		short nstates;						
		NODE* nodes;						
		short* rstates;						
		FST(short ns,						
			NODE n, ...);					
		FST(unsigned char* s,				
			FST& fst);						
		
	};
	bool execute(							
		FST& fst);							
}