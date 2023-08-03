//Объявление переменных
string str_number;
int number;

//Ввод числа
Console.WriteLine("Введите число");
str_number = Console.ReadLine();
number = int.Parse(str_number);

//Вычисление четности и вывод результата
if (number != 0)
{
    if ((number % 2 == 0))
        Console.WriteLine("Число четное");
    else
        Console.WriteLine("Число нечетное");
}
else 
    Console.WriteLine("Ноль не имеет четности");