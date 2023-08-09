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
    Console.WriteLine("Введенное число является полиндромом");
else
    Console.WriteLine("Введенное число не является полиндромом");