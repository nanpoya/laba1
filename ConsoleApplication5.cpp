// ConsoleApplication5.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <cmath>
#include <Windows.h>
#define MAX_PASSENGERS 100 

using namespace std;

struct Passenger {
    int id;           
    int countItems;   
    double totalWeight;
    char type[20];    
};
void ZadanieB(Passenger passengers, int avgItemWeight) {
    double avgBagWeightPerItem = passengers.totalWeight / passengers.countItems;
    if (fabs(avgBagWeightPerItem - avgItemWeight) <= 0.5) {
        cout << passengers.id << " ";
    }
}
int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    Passenger passengers[MAX_PASSENGERS];
    int n; // Число пассажиров
    cout << "Введите количество пассажиров: ";
    cin >> n;

    for (int i = 0; i < n; ++i) {
        cout << "Введите айди пассажира, количество вещей, общий вес его багажа и является ли багаж габаритный (габ/негаб)" << endl;
        cin >> passengers[i].id >> passengers[i].countItems >> passengers[i].totalWeight;
        cin.getline(passengers[i].type, sizeof(passengers[i].type));
    }

    double sumCountItems = 0;
    double sumTotalWeights = 0;

    for (int i = 0; i < n; ++i) {
        sumCountItems += passengers[i].countItems;
        sumTotalWeights += passengers[i].totalWeight;
    }

    double avgNumItems = sumCountItems / n;
    double avgItemWeight = sumTotalWeights / sumCountItems;

    // Задача А: находим тех, у кого больше предметов, чем среднее количество
    cout << "Пассажиры с большим числом вещей:" << endl;
    for (int i = 0; i < n; i++) {
        if (passengers[i].countItems > avgNumItems) {
            cout << passengers[i].id << " ";
        }
    }
    cout << endl;

    // Задача Б: ищем номера багажа, где разница между средним весом предмета и общим средним менее 0.5 кг
    cout << "Номера багажа, подходящие по условию задачи Б:" << endl;
    for (int i = 0; i < n; i++) {
        ZadanieB(passengers[i], avgItemWeight);
    }
    cout << endl;

    // Задача В: выполняем фильтрацию по типу багажа и проверяем условие снова
    string filterType("габаритный"); // Например, выбираем именно этот тип
    cout << "Подходящие пассажиры с типом " << filterType << ":" << endl;
    for (int i = 0; i < n; i++) {
        if (strcmp(passengers[i].type, filterType.c_str()) == 0) {
            ZadanieB(passengers[i], avgItemWeight);
        }
    }
    cout << endl;

    return 0;
} 

// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
