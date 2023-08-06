//Задача 13: Напишите программу, которая выводит третью цифру 
//заданного числа или сообщает, что третьей цифры нет. 

//Вводим число
Console.Write($"Введите число: ");
int number = int.Parse(Console.ReadLine());

//Определяем количество цифр в числе: count
int count = 0;
int result = number;

while (result != 0)
{
    result=result/10;
    count++;
}

//Уменьшаем число до трехзначного и выводим цифру либо пишем что что меньше 3
if (count < 3) 
{
    Console.WriteLine("В представленном числе меньше трех цифр");
}
else 
{
    for (int i = 1; i <= count-3; i++)
    {
        number=number/10;
    }

    Console.WriteLine($"Третья цифра в числе: {number%10}");
}


