﻿//Объявление переменных
string str_number_1;
int number_1;
string str_number_2;
int number_2;
string str_number_3;
int number_3;

//Ввод первого числа
Console.WriteLine("Введите первое число");
str_number_1 = Console.ReadLine();
number_1 = int.Parse(str_number_1);

//Ввод второго числа
Console.WriteLine("Введите второе число");
str_number_2 = Console.ReadLine();
number_2 = int.Parse(str_number_2);

//Ввод третьего числа
Console.WriteLine("Введите третье число");
str_number_3 = Console.ReadLine();
number_3 = int.Parse(str_number_3);

//Сравнение чисел и вывод результата
if ((number_1 >= number_2) & (number_1 >= number_3))
{
    Console.WriteLine($"Максимальное число: {number_1}");
}
if ((number_2 >= number_1)&(number_2>number_3))
{
    Console.WriteLine($"Максимальное число: {number_2}");
}
if ((number_3 >= number_1)&(number_3>number_2))
{
    Console.WriteLine($"Максимальное число: {number_3}");
}

