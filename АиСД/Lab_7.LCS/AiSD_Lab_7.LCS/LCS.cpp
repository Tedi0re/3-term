#include "LCS.h"

int main()
{
	Tree tree = Tree(0);
	tree.Insert(1);
	tree.Insert(999);
	tree.Insert(998);
	tree.Insert(2);
	tree.Insert(3);
	tree.Insert(4);
	tree.Insert(5);
	tree.Insert(10);

	cout << tree.MaxLength();
}