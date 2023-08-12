/*
//Задача 25: Напишите цикл, который принимает на вход два числа (A и B)
// и возводит число A в натуральную степень B.

//Ввод одномерного массива
int[] FillNumberTwo(string B, string C)
{
    int[] number = {0, 0};
    Console.Write($"{B}: ");
    number[0] = int.Parse(Console.ReadLine());
    Console.Write($"{C}: ");
    number[1] = int.Parse(Console.ReadLine());
    return number;
}

int[] arr = FillNumberTwo("Введите основание степени","Введите степень числа");

double Exp (int number, int step)
{
    double result = 1;
    for (int i = 1; i <= step; i++)
    {
        result = result*number;
    }
    return result;
}

Console.WriteLine($"Число {arr[0]} возведенное в степень {arr[1]} равно: {Exp (arr[0], arr[1])}");

*/

//Задача 27: Напишите программу, которая принимает на вход число и выдаёт сумму цифр в числе.

// Функия ввода скалярного числа
int InputNumber(string message)
{
    Console.Write($"Введите {message}: ");
    int number = int.Parse(Console.ReadLine());
    return number;
}

// Функция определения количества цифр числа
int CountNumber(int number)
{
    int count = 0;
    if (number != 0)
    {
        while (number != 0)
        {
            number = number / 10;
            count = count + 1;
        }
    } 
    else    
        count = 1;
    return count;
}

//Вызов функций и вывод результата
Console.WriteLine($"Количество цифр в числе: {CountNumber(InputNumber("число"))}");


//Задача 29: Напишите программу, которая задаёт массив из 8 элементов и выводит их на экран.

// Функция формирует массив указанной длины и заполняет его числами, которые находятся в лимитах 
int[] CreatArray(int count, int min, int max)
{
    int[] array = new int[count];
    Random rand = new Random();

    for (int i = 0; i < count; i++)
    {
        array[i] = rand.Next(min, max + 1);
    }
    return array;
}

//Фунция выводит элементы мвссива 
void ArrayPrint(int[] numbers)
{
    Console.Write("Сформированный массив: [");
    for (int i = 0; i < numbers.Length; i++)
    {
        Console.Write($"{numbers[i]},");
    }
    Console.WriteLine("]");
}

//Вызов функций и вывод результата
ArrayPrint(CreatArray(10, 0, 10));