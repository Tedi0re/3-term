#pragma once
#include <iostream>
using namespace std;

class Graph
{
public:
	Graph input(Graph G);
	Graph input_2(Graph G);
	Graph input_3(Graph G);
	void output(Graph G);
	void output_2(Graph G);
	void output_3(Graph G);
	void BFS(Graph G, int current);
	void DFS(Graph G, int current);

	int number_of_point;
	int** point;

	void create_graph()
	{
		point = new int* [number_of_point];
		for (int i = 0; i < number_of_point; i++)
		{
			point[i] = new int [number_of_point];
			for (int j = 0; j < number_of_point; j++)
			{
				point[i][j] = -1;
				if (j + 1 == number_of_point) point[i][j] = 0;
			}
		}
	}

	Graph(int number_of_point)
	{
		this->number_of_point = number_of_point;
		create_graph();
	}

	
};



Graph Graph::input(Graph G)
{
	cout << endl << "укажите пары соединеных вершин(в конце укажите 0 0 для вывода графа)" << endl;
	while (true)
	{
		int first, second;
		bool first_flag, second_flag;
		cin >> first >> second;
		if (first == 0 || second == 0) break;

		try
		{
			if (first == second) throw exception("Такой пары не может быть");
			if (first > G.number_of_point || second > G.number_of_point) throw exception("Такой пары не может быть");
			first_flag = false, second_flag = false;
			first--; second--;
			for (int i = 0; i < G.number_of_point; i++)
			{
				if (G.point[first][i] == -1) first_flag = true;
				if (G.point[second][i] == -1) second_flag = true;
				if (G.point[first][i] == second+1) throw exception("Такой пары не может быть");
				if (G.point[second][i] == first+1) throw exception("Такой пары не может быть");
				if (first_flag && second_flag) break;
			}
			if (first_flag && second_flag)
			{
				for (int i = 0; i < G.number_of_point; i++)
				{
					if (G.point[first][i] == -1)
					{
						G.point[first][i] = second + 1;
						break;
					}
				}
				for (int i = 0; i < G.number_of_point; i++)
				{

					if (G.point[second][i] == -1)
					{
						G.point[second][i] = first + 1;
						break;
					}
				}
			}
			else { throw exception("Такой пары не может быть"); }

		}
		catch (const std::exception e)
		{
			cout << e.what() << endl;
		}
		cin.clear();
		cin.ignore('123', '\n');


	}
	return G;

}

void Graph::output(Graph G)
{
	cout << endl << "Вывод графа в виде списка смежности:" << endl;
	for (int i = 0; i < G.number_of_point; i++)
	{
		cout << i + 1 << "={";
		for (int j = 0; G.point[i][j] != 0; j++)
		{
			if (G.point[i][j] == -1) break;
			cout << " " << G.point[i][j] << " ";
		}
		cout << "}" << endl;
	}
}

void Graph::BFS(Graph G, int current)
{
	static int* queue = new int[G.number_of_point + 1];
	static int* pp = new int[G.number_of_point + 1];//passed_points
	static int qc = 0;//queue_counter
	
	if (qc == 0)
	{
		for (int i = 0; i < G.number_of_point; i++)
		{
			queue[i] = -1;
			pp[i] = -1;
			if (i + 1 == G.number_of_point)
			{
				queue[i + 1] = 0;
				pp[i + 1] = 0;
				//queue[i + 2] = 0;
			}
		}
		queue[qc] = current;
	}

	if (queue[qc] == 0 || queue[qc] == -1)
	{
		cout << "Вершины пройдены в порядке: ";
		for (int i = 0; pp[i] != 0 && pp[i] != -1; i++)//
		{
			cout << pp[i];
			if ( pp[i + 1] != 0 && pp[i + 1] != -1)
			{
				cout << "-";
			}
		}
		return;
	}
	
	else
	{
		for (int i = 0; i < G.number_of_point; i++)
		{
			if (G.point[current -1][i] == -1 || G.point[current -1][i] == 0) break;
			else
			{
				bool flag_q = false, flag_pp = false;
				for (int j = 0; j < G.number_of_point; j++)
				{
					if (G.point[current -1][i] == queue[j]) flag_q = true;//
					if (G.point[current -1][i] == pp[j]) flag_pp = true;
					if (flag_pp || flag_q) break;
				}
				if (flag_pp || flag_q) continue;
				else
				{
					for (int j = 0; j < G.number_of_point; j++)
					{
						if (queue[j] == -1)
						{
							queue[j] = G.point[current - 1][i];//
							break;
						}
					}
					
				}
				
			}
		}

		pp[qc] = queue[qc];
		qc++;
		BFS(G, queue[qc]);
	}
}

void Graph::DFS(Graph G, int current)
{
	static int* queue = new int[G.number_of_point + 1];
	static int* pp = new int[G.number_of_point + 1];//passed_points
	static int qc = 0;//queue_counter

	if (qc == 0)
	{
		for (int i = 0; i < G.number_of_point; i++)
		{
			queue[i] = -1;
			pp[i] = -1;
			if (i + 1 == G.number_of_point)
			{
				queue[i + 1] = 0;
				pp[i + 1] = 0;
			}
		}
		queue[qc] = current;
	}

	if (queue[0] == 0 || queue[0] == -1)
	{
		cout << "Вершины пройдены в порядке: ";
		for (int i = 0; pp[i] != 0 && pp[i] != -1; i++)//
		{
			cout << pp[i];
			if (pp[i + 1] != 0 && pp[i + 1] != -1)
			{
				cout << "-";
			}
		}
		return;
	}

	else
	{
		for (int i = 0; i < G.number_of_point; i++)
		{
			if (G.point[current - 1][i] == -1 || G.point[current - 1][i] == 0) break;
			else
			{
				bool flag_q = false, flag_pp = false;
				for (int j = 0; j < G.number_of_point; j++)
				{
					if (G.point[current - 1][i] == queue[j]) flag_q = true;//
					if (G.point[current - 1][i] == pp[j]) flag_pp = true;
					if (flag_pp || flag_q) break;
				}
				if (flag_pp || flag_q) continue;
				else
				{
					for (int j = 0; j < G.number_of_point; j++)
					{
						if (queue[j] == -1)
						{
							queue[j] = G.point[current - 1][i];
							break;
						}
					}

				}

			}
		}

		for (int i = 0; i < G.number_of_point; i++)//
		{
			if (queue[i] == current)
			{
				pp[qc] = queue[i];
				//queue[i] = -1;//
				for (int j = i; queue[j+1] != 0 && queue[j + 1] != -1; j++)
				{
					swap(queue[j], queue[j + 1]);
				}
			}
			if (queue[i + 1] == -1 || queue[i + 1] == 0)
			{
				current = queue[i - 1];//
				queue[i] = -1;
				qc++;
				DFS(G, current);
				break;
			}
		}
	}
}

Graph Graph::input_2(Graph G)
{
	Graph G_2(G.number_of_point);

	G_2.point = new int* [G_2.number_of_point];
	for (int i = 0; i < G_2.number_of_point; i++)
	{
		G_2.point[i] = new int[G_2.number_of_point];
		for (int j = 0; j < G_2.number_of_point; j++)
		{
			G_2.point[i][j] = 0;
		}
	}

	for (int i = 0; i < G_2.number_of_point; i++)
	{
		for (int j = 0; G.point[i][j] != 0; j++)
		{
			if (G.point[i][j] == -1 || G.point[i][j] == 0)
			{
				G_2.point[i][G.point[i][j] - 1] = 0;
			}
			else
			{
				G_2.point[i][G.point[i][j] - 1] = 1;
			}
		}
	}

	return G_2;

}

Graph Graph::input_3(Graph G)
{
	Graph G_3(G.number_of_point);

	G_3.point = new int* [(G_3.number_of_point * (G_3.number_of_point - 1)) / 2];
	for (int i = 0; i < (G_3.number_of_point* (G_3.number_of_point-1))/2; i++)
	{
		G_3.point[i] = new int[G_3.number_of_point];
		for (int j = 0; j < 4; j++)
		{
			G_3.point[i][j] = 0;
		}
	}

	for (int i = 0; i < G_3.number_of_point; i++)
	{
		for (int j = i; j < G_3.number_of_point; j++)
		{
			if (G.point[i][j] == 1)
			{
				for (int k = 0; k < (G_3.number_of_point * (G_3.number_of_point - 1)) / 2; k++)
				{
					if (G_3.point[ k][0] == 0)
					{
						G_3.point[k][0] = j + 1;
						G_3.point[k][3] = j + 1;

						G_3.point[ k][1] = i + 1;
						G_3.point[ k][2] = i + 1;
						break;
					}	
				}
				
			}
		}
	}

	return G_3;
}
		
void Graph::output_2(Graph G)
{
	cout << endl << "Вывод графа в виде матрицы смежности:" << endl;
	for (int i = 0; i < G.number_of_point; i++)
	{
		for (int j = 0;  j < G.number_of_point; j++)
		{
			cout << " " << G.point[i][j] << " ";
		}
		cout << endl;
	}
}

void Graph::output_3(Graph G)
{
	cout << endl << "Вывод графа в виде списка ребер:" << endl;
	for (int i = 0; i < (G.number_of_point * (G.number_of_point - 1)) / 2; i++)
	{
		
		for (int j = 0; j < 4; j++)
		{
			if (j == 0 && G.point[i][j] != 0) cout << "{ ";
			if (G.point[i][j] == 0) break;
			if (j == 2) cout << " } { ";
			cout << " " << G.point[i][j] << " ";
			if (j == 3) cout << " }" << endl;
		}
		
	}
}
