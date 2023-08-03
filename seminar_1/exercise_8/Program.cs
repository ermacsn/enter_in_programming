// Объявление переменных
string str_number;
int number;

//Ввод числа
Console.WriteLine("Введите число");
str_number = Console.ReadLine();
number = int.Parse(str_number);
Console.WriteLine();

//Вычисление и вывод результата
for (int i = 2; i <= number; i = i + 2)
{
    Console.WriteLine(i);
}

