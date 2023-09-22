//Задания семинара

//Задача 63: Задайте значение N. Напишите программу, которая выведет все натуральные числа в 
//промежутке от 1 до N.
//N = 5 -> "1, 2, 3, 4, 5"
//N = 6 -> "1, 2, 3, 4, 5, 6

using System.ComponentModel;
using System.Reflection;

int SetNumberInt(string message) //получение числа от пользователя
{
    Console.Write(message);
    int number = Convert.ToInt32(Console.ReadLine());
    return number;
}

string StringNumber (int number, int value = 1)//рекурсивная функция для формирования строки чисел
{
    if (value == number) return $"{value}";
    return ($"{value}, ") + StringNumber(number, value + 1);
}

//Решение задачи 63.
Console.Clear();
Console.WriteLine("Задача 63.");
int numberString = SetNumberInt("Введите число: ");
Console.WriteLine($"Числа в промежутке от 1 до {numberString}: {StringNumber(numberString)}");

//Задача 65: Задайте значения M и N. Напишите программу, которая выведет все натуральные числа
//в промежутке от M до N.

//Решение задачи 65.
Console.WriteLine("Задача 65.");
int numberStringM = SetNumberInt("Введите число M: ");
int numberStringN = SetNumberInt("Введите число N: ");
Console.WriteLine($"Числа в промежутке от {numberStringM} до {numberStringN}: {StringNumber(numberStringN, numberStringM)}");

//Задача 69: Напишите программу, которая на вход принимает два числа A и B, и возводит 
//число А в целую степень B с помощью рекурсии.
//A = 3; B = 5 -> 243 (3⁵)
//A = 2; B = 3 -> 8

int Exponentiation (int number, int degree, int currentDegree = 1) //рекурсивная функция возведения в степень
{
    if (degree < 0) return 0;
    if (number == 0 && degree == 0) return 0; //вообще то это неопределенность
    if (degree == 0 ||  currentDegree  > degree) return 1;
    return number * Exponentiation(number, degree, currentDegree + 1);
}

//Решение задачи 69.
Console.WriteLine("Задача 69.");
int number = SetNumberInt("Введите число: ");
int numberDegree = SetNumberInt("Введите степень числа : ");
Console.WriteLine($"Число {number} в степени {numberDegree}: {Exponentiation(number, numberDegree)}");

//Задача 67: Напишите программу, которая будет принимать на вход число и возвращать сумму его цифр.
//453 -> 12
//45 -> 9

int SumNumber (int value) //рекурсивная функция вычисления суммы
{
    if (value < 10)
    {    
        return value;
    }
    return value % 10 + SumNumber(value/10);
}

//Решение задачи 67.
Console.WriteLine("Задача 67.");
int numberForSum = SetNumberInt("Введите число: ");
Console.WriteLine($"Сумма цифр числа {numberForSum} равна {SumNumber(numberForSum)}");


//Домашняя работа

//Задача 64: Задайте значение N. Напишите программу, которая выведет все натуральные числа в 
//промежутке от N до 1. Выполнить с помощью рекурсии.
//N = 5 -> "5, 4, 3, 2, 1"
//N = 8 -> "8, 7, 6, 5, 4, 3, 2, 1"

string StringNumberMinus (int number)//формирование строки чисел от N до 1
{
    if (number == 1) return $"{1}";
    return ($"{number}, ") + StringNumberMinus(number - 1);
}

//Решение задачи 64.
Console.WriteLine("Задача 64.");
int numberStringMinus = SetNumberInt("Введите число: ");
Console.WriteLine($"Числа в промежутке от {numberStringMinus} до 1 : {StringNumberMinus(numberStringMinus)}");

//Задача 66: Задайте значения M и N. Напишите программу, которая найдёт сумму натуральных 
//элементов в промежутке от M до N.
//M = 1; N = 15 -> 120
//M = 4; N = 8. -> 30

int SumNumberMN (int numberM, int numberN)//формирование суммы чисел от M до N
{
    if (numberM >= numberN) return numberN;
    return numberM + SumNumberMN(numberM + 1, numberN);
}


//Решение задачи 66.
Console.WriteLine("Задача 66.");
numberStringM = SetNumberInt("Введите число M: ");
numberStringN = SetNumberInt("Введите число N: ");

int temp = numberStringM;
if (numberStringM > numberStringN) //защита от переполнения стека
{
    numberStringM = numberStringN;
    numberStringN = temp;
}
Console.WriteLine($"Сумма чисел в промежутке от {numberStringM} до {numberStringN}: {SumNumberMN(numberStringM, numberStringN)}");




//Задача 68: Напишите программу вычисления функции Аккермана с помощью рекурсии. Даны два 
//неотрицательных числа m и n.
//m = 2, n = 3 -> A(m,n) = 9    
//m = 3, n = 2 -> A(m,n) = 29
//В решении выше, возможно, ошибка. Должно быть наоборот: А(2,3) = 29, А(3,2) = 9
//Формула:
//          |n + 1              , m = 0
// A(m,n) = |A(m-1,1)           , m > 0, n = 0
//          |A(m-1, A(m, n - 1)), m > 0, n > 0              

int FunctionAkkerman(int mValue,int nValue )
{
    if (mValue == 0) 
        return nValue + 1;
    if (mValue > 0 && nValue == 0)
        return FunctionAkkerman(mValue - 1, 1);
    if (mValue > 0 && nValue > 0)
        return FunctionAkkerman(mValue - 1, FunctionAkkerman(mValue, nValue - 1));
    return 0;             
}

//Решение задачи 68.
Console.WriteLine("Задача 68.");
int nValueAkkerman = SetNumberInt("Введите число m: ");
int mValueAkkerman = SetNumberInt("Введите число n: ");
Console.WriteLine($"Функция Аккермана: {FunctionAkkerman(mValueAkkerman, nValueAkkerman)}");


