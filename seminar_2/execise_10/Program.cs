//Вводим число
Console.Write($"Введите трехзначное число: ");
int number = int.Parse(Console.ReadLine());

// Формируем и выводми результат
Console.WriteLine((number/10)%10);