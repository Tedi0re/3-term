#include <iostream>
#include <vector>

using namespace std;

int  Convert(char letter) {
	switch (letter) {
	case 'A': return 1;
	case 'B': return 2;
	case 'C': return 3;
	case 'D': return 4;
	case 'E': return 5;
	case 'F': return 6;
	case 'G': return 7;
	case 'H': return 8;
	case 'I': return 9;
	default:
	{
		cout << "\nДанной вершины не существует!!!\n";
		return 0;
	}
	}
}
char Convert(int number) {
	switch (number) {
	case 1: return 'A';
	case 2: return 'B';
	case 3: return 'C';
	case 4: return 'D';
	case 5: return 'E';
	case 6: return 'F';
	case 7: return 'G';
	case 8: return 'H';
	case 9: return 'I';
	}
}
void Dijkstra(int matrix[9][9], int startPoint = 0)
{
	bool checkedNode[9];
	int pointValue[9];
	int minPointValue;
	int minPointIndex;

	for (int i = 0; i < 9; i++) // Очистка и заполнение узлов
	{
		checkedNode[i] = false;
		pointValue[i] = INT32_MAX;
	}

	pointValue[startPoint] = 0; // Стартовый узел

	for (int j = 0; j < 8; j++)
	{
		minPointValue = INT32_MAX;

		for (int i = 0; i < 9; i++) // Находим минимальное значение узла из всех и его индекс
		{
			if (checkedNode[i] == false && pointValue[i] < minPointValue)
			{
				minPointValue = pointValue[i];
				minPointIndex = i;
			}
		}

		checkedNode[minPointIndex] = true; // Помечаем как посещенный узел

		for (int i = 0; i < 9; i++) { // Рассчитываем расстояние до точек
			if (checkedNode[i] == false && matrix[minPointIndex][i] > 0 && pointValue[minPointIndex] != INT32_MAX && pointValue[minPointIndex] + matrix[minPointIndex][i] < pointValue[i]) {
				pointValue[i] = pointValue[minPointIndex] + matrix[minPointIndex][i];
			}
		}
	}

	for (int i = 0; i < 9; i++) {
		if (i != startPoint) {
			cout << "\nПуть от вершины " << Convert(startPoint + 1) << " до вершины " << Convert(i + 1) << " = " << pointValue[i];
		}
	}
}

int main()
{
	setlocale(0, "rus");

	int matrix[9][9] = {
		/*	  A   B   C   D   E   F   G   H   I	 */
		/*A*/	{ 0,  7,  10, 0,  0,  0,  0,  0,  0  },
		/*B*/	{ 7,  0,  0,  0,  0,  9,  27, 0,  0  },
		/*C*/	{ 10, 0,  0,  0,  31, 8,  0,  0,  0  },
		/*D*/	{ 0,  0,  0,  0,  32, 0,  0,  17, 21 },
		/*E*/	{ 0,  0,  31, 32, 0,  0,  0,  0,  0  },
		/*F*/	{ 0,  9,  8,  0,  0,  0,  0,  11, 0  },
		/*G*/	{ 0,  27, 0,  0,  0,  0,  0,  0,  15 },
		/*H*/	{ 0,  0,  0,  17, 0,  11, 0,  0,  15 },
		/*I*/	{ 0,  0,  0,  21, 0,  0,  15, 15, 0  }
	};

	char letter;
	int node = 0;

	do {
		cout << "\nВведите вершину (A - I): ";

		cin >> letter;

		node = Convert(letter);
	} while (node == 0);

	Dijkstra(matrix, node - 1);
}