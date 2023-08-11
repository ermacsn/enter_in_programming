
//Задача 19
//Напишите программу, которая принимает на вход число и проверяет, 
//является ли оно палиндромом.


//Ввод числа

Console.Write("Введите число: ");
int Number = int.Parse(Console.ReadLine());

//Вспомогательные переменные
int CountSymbol = 0; // количество цифр в числе
int NumberBuffer1 = Number;// буфер для обработки введенного числа
int NumberBuffer2 = Number;// буфер для обработки введенного числа
int divider = 1; // делитель для старшего разряда
int SymbolEnd, SymbolBegin; // переменные, которые будут содержать парные цифры числа
bool PolindromTrue = true; // true если число - полиндром

//Вычисление количества цифр в числе и делителя 
while (NumberBuffer1 != 0)
{
    NumberBuffer1 = NumberBuffer1 / 10;
    CountSymbol = CountSymbol + 1;
    divider = divider * 10;
}

divider = divider / 10; // уменьшаем в 10 раз так как немного пролетаем и делитель получается слишком большим
NumberBuffer1 = Number; // переопределяем буфер так как значение в нем изменилось


// Перебор и сравнение цифр числа

for (int i = 1; i <= CountSymbol / 2; i++) //количество итераций - половина количества цифр
{
    SymbolEnd = NumberBuffer1% 10; // определяем последнюю цифру числа
    NumberBuffer1 = NumberBuffer1 / 10; // уменьшаем буфер, дробная часть отбрасывается так как int

    SymbolBegin = NumberBuffer2 / divider; // определяем первую цифру числа
    NumberBuffer2 = NumberBuffer2 - (NumberBuffer2 / divider) * divider; //удаляем из буфера первую цифру числа
    divider = divider / 10; //уменьшаем делитель
    
    if (SymbolBegin != SymbolEnd)
    {
        PolindromTrue = false;  //если хоть одна пара чисел не совпадает это не полиндром
        break; //выходим из цикла
    }    
        Console.WriteLine($"{SymbolBegin}, {SymbolEnd}");
}
// Вывод результата
if (PolindromTrue && (CountSymbol > 1)) 
    Console.WriteLine("Введенное число является пaлиндромом");
else
    Console.WriteLine("Введенное число не является пaлиндромом");



//Задача 21
//Напишите программу, которая принимает на вход координаты двух 
//точек и находит расстояние между ними в 3D пространстве.

//Вводим координаты точек    
Console.Write("Введите координату Х точки 1:");
int coordX1 = int.Parse(Console.ReadLine());
Console.Write("Введите кооpдинату Y точки 1:");
int coordY1 = int.Parse(Console.ReadLine());
Console.Write("Введите кооpдинату Z точки 1:");
int coordZ1 = int.Parse(Console.ReadLine());

Console.Write("Введите координату Х точки 2:");
int coordX2 = int.Parse(Console.ReadLine());
Console.Write("Введите кооpдинату Y точки 2:"); 
int coordY2 = int.Parse(Console.ReadLine());
Console.Write("Введите кооpдинату Z точки 2:");
int coordZ2 = int.Parse(Console.ReadLine());


// Вычисляем и выводим расстояние
double distance = Math.Sqrt(Math.Pow((coordX2-coordX1),2) + Math.Pow((coordY2-coordY1),2) + Math.Pow((coordZ2-coordZ1),2));
Console.WriteLine($"Расстояние между точками равно {distance}");



//Задача 23
//Напишите программу, которая принимает на вход число (N)
//и выдаёт таблицу кубов чисел от 1 до N.

//Ввод числа

System.Console.Write("Введите число: ");
int numbersqrt = int.Parse(Console.ReadLine());
int sign = 1;

if (numbersqrt < 0)
{
    numbersqrt = numbersqrt * (-1); //определяем количество итераций цикла for
    sign = -1; //запоминаем знак числа
}

// Вычисляем и выводим результат
for (int i = 0; i <= numbersqrt; i++)
{
    Console.WriteLine($"Куб числа {sign * i} равен: {sign * i * i * i}");
}
 
