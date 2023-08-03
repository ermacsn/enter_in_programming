//Объявление переменных
string str_number_1;
int number_1;
string str_number_2;
int number_2;

//Ввод первого числа
Console.WriteLine("Введите первое число");
str_number_1 = Console.ReadLine();
number_1 = int.Parse(str_number_1);

//Ввод второго числа
Console.WriteLine("Введите второе число");
str_number_2 = Console.ReadLine();
number_2 = int.Parse(str_number_2);

//Сравнение чисел и вывод результата
if (number_1 > number_2)
{
    Console.WriteLine("Первое число больше второго");
}
if (number_1 < number_2)
{
    Console.WriteLine("Второе число больше первого");
}
if (number_1 == number_2)
{
    Console.WriteLine("Числа равны");
}
