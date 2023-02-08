#include "stdafx.h"

#include <iostream>


namespace FST
{
	RELATION::RELATION(unsigned char c, short nn)
	{
		symbol = c;                         
		nnode = nn;                                   
	};

	NODE::NODE()                 
	{
		n_relation = 0;           
		relations = nullptr;     
	};

	NODE::NODE(short n, RELATION rel, ...)
	{
		n_relation = n;             
		RELATION* p = &rel;          
		relations = new RELATION[n];   

		for (size_t i = 0; i < n; i++)  
		{
			relations[i] = p[i];
		}
	};

	FST::FST(short ns, NODE n, ...)
	{
		nodes = new NODE[ns];        
		NODE* temp = &n;
		nstates = ns;                  
		rstates = new short[ns];       
		for (short i = 0; i < ns; i++)
			nodes[i] = *(temp + i);
		rstates[0] = 0;             
		position = -1;           
	}

	FST::FST(unsigned char* s, FST& fst)
	{
		nodes = new NODE[fst.nstates];	
		NODE* temp = fst.nodes;			
		string = s;						
		nstates = fst.nstates;				
		rstates = new short[nstates];		
		for (short i = 0; i < nstates; i++)
			nodes[i] = *(temp + i);			
		rstates[0] = 0;						
		position = -1;					
	}
	bool step(FST& fst, short*& rstates)        
	{
		bool rc = false;															
		std::swap(rstates, fst.rstates);										
		for (short i = 0; i < fst.nstates; i++)											
		{
			if (rstates[i] == fst.position)										
			{
				for (short j = 0; j < fst.nodes[i].n_relation; j++)						
				{
					if (fst.nodes[i].relations[j].symbol == fst.string[fst.position])	
					{
						fst.rstates[fst.nodes[i].relations[j].nnode] = fst.position + 1;
						rc = true;												
					};
				};
			}
				
		};
		return rc;
	};
	bool execute(FST& fst)											
	{
		short* rstates = new short[fst.nstates];				
		memset(rstates, 0xff, sizeof(short) * fst.nstates);		
		short lstring = _mbslen(fst.string);					
		bool rc = true;											
		for (short i = 0; i < lstring && rc; i++)					
		{
			fst.position++;										
			rc = step(fst, rstates);							
		};
		delete[] rstates;											
		return (rc ? (fst.rstates[fst.nstates - 1] == lstring) : rc);
	};


}