#pragma once
#include <iostream>
#include <vector>
using namespace std;

class Tree
{
private:
	
	class Node
	{
	public:
		int value;
		Node* rightChild;
		Node* leftChild;
		Node(int value) 
		{
			this->value = value;  
			rightChild = NULL;
			leftChild = NULL;
		}
	};
public:
	Node* root;
	Tree(int minValue)
	{
		root = new Node(minValue);
	}
	void Insert(int value);
	int MaxLength();
};

void Tree::Insert(int value)
{
	static Node* currentNode = this->root; // устанавливаем текущий указатель на корень

	if (currentNode->rightChild == NULL)
	{
		currentNode->rightChild = new Node(value);
		return;
	}
	else
	{
		Node* parentNode = NULL; // хранит указатель на родительский элемент
		if (currentNode->leftChild != NULL) //если есть правое и левое поддерево, сначала заходим в левое
		{
			parentNode = currentNode;
			currentNode = currentNode->leftChild;
			Insert(value);
			currentNode = parentNode;

		}
		if (currentNode->rightChild->value < value)
		{
			parentNode = currentNode;
			currentNode = currentNode->rightChild;
			Insert(value);
			currentNode = parentNode;
		}
		if(parentNode == NULL)//если есть правое поддерево(условие не выполнилось) и нет левого
		{
			if (currentNode->leftChild == NULL)
			{
				currentNode->leftChild = new Node(value);
				return;
			}
			else if(currentNode->leftChild->value < value)
			{
				Node* parentNode = currentNode;
				currentNode = currentNode->leftChild;
				Insert(value);
				currentNode = parentNode;
				return;
			}
		}
	}


}

int Tree::MaxLength()//обход в глубину
{
	static Node* currentNode = this->root;
	static int numberOfvectors = 0;
	static vector<vector<int>> lengths;
	if (currentNode == root) lengths.push_back(vector<int>());
	if (currentNode == NULL) return 0;

	lengths[numberOfvectors].push_back(currentNode->value);

	Node* parentNode = currentNode;
	
	int right = 0, left = 0;
	vector<int> buf;
	if (currentNode->rightChild != NULL)
	{
		buf = lengths[numberOfvectors];
		currentNode = currentNode->rightChild;
		right = MaxLength();
		currentNode = parentNode;
		
	}

	if (currentNode->leftChild != NULL)
	{
		currentNode = currentNode->leftChild;
		numberOfvectors++;
		lengths.push_back(vector<int>());
		lengths[numberOfvectors] = buf;
		left = MaxLength();
		numberOfvectors--;
		
		currentNode = parentNode;
	}

	if (currentNode == root)
	{
		int indexMax = 0;
		int lengthMax = 0;
		for (int i = 0; i < lengths.size(); i++)
		{
			if (lengths[i].size() > lengthMax)
			{
				indexMax = i;
				lengthMax = lengths[i].size();
			}
		}
		for (int i = 1; i < lengthMax; i++)
		{
			cout << lengths[indexMax][i]<<" ";
		}
		cout << endl;
		return std::max(left, right);
	}
	else return max(left, right) + 1;
}

