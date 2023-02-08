#include "Graph.h"


int main()
{
	setlocale(0, "ru");
	cout << "������� ���������� ������: ";
	int n;
	while (true)
	{
		try
		{
			cin >> n;
			if (!cin) throw exception("������������ ����!");
			else break;

		}
		catch (const std::exception e)
		{
			cout << e.what() << endl;
			cin.clear();
			cin.ignore('123', '\n');
		}
	}
	
	
	
	Graph G(n);
	G = G.input(G);
	G.output(G);

	cout << "�������� �������, � ������� ������ ����� � ������: ";
	int current;
	while (true)
	{
		try
		{
			cin >> current;
			if (!cin || current > G.number_of_point || current < 1) throw exception("������������ ����!");
			else
			{
				G.BFS(G, current);
				break;
			}
		}
		catch (const std::exception e)
		{
			cout << e.what() << endl;
			cin.clear();
			cin.ignore('123', '\n');
		}
	}

	cout << endl << "�������� �������, � ������� ������ ����� � �������: ";
	while (true)
	{
		try
		{
			cin >> current;
			if (!cin || current > G.number_of_point || current < 1) throw exception("������������ ����!");
			else
			{
				G.DFS(G, current);
				break;
			}
		}
		catch (const std::exception e)
		{
			cout << e.what() << endl;
			cin.clear();
			cin.ignore('123', '\n');
		}
	}
	G.output_2(G.input_2(G));
	G.output_3(G.input_3(G.input_2(G)));
}