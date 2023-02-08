#include <iostream>
using namespace std;

void hanoi(int i, int k, int n)
{
    if (n == 1) {
        cout << "Переложить диск 1 с места " << i << " на место " << k << ".\n";
    }
    else {
        int tmp = 6 - i - k;
        hanoi(i, tmp, n - 1);
        cout << "Переложить диск " << n << " c места " << i << " на место " << k << ".\n";
        hanoi(tmp, k, n - 1);
    }
}

int main()
{
    setlocale(0, "ru");
    int start, end, number_of_disks;
    cout << "Введите число дисков, положение башни в начальный момент,\nположение башни в конечный моменти в соответсвующем порядке: ";
    while(true)
    try
    {
        cin >> number_of_disks >> start >> end;
        if (!cin || number_of_disks < 1 || start <1 || end <1 || start == end) throw exception("Неправильный ввод, повторите попытку!");
        else break;
    }
    catch (const exception e)
    {
        cin.clear();
        cin.ignore('123', '\n');
        cout << e.what() << endl;
    }
    hanoi(start, end, number_of_disks);
    return 0;
}
