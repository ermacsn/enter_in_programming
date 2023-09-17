//Семинар

//Задача 53: Задайте двумерный массив. Напишите программу, которая поменяет местами первую
// и последнюю строку массива.

using System.Globalization;
using System.Security.Principal;
using System.Xml.XPath;

int SetNumberInt(string message) //получение числа от пользователя
{
    Console.Write(message);
    int number = Convert.ToInt32(Console.ReadLine());
    return number;
}

int[,] GetMatrixInt(int rows, int columns, int min, int max) //формирование матрицы целых чисел
{
    int[,] matrix = new int[rows, columns];
    var random = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = random.Next(min, max);
        }
    }
    return matrix;
}

void PrintMatrixInt(int[,] matrix) // вывод матрицы с целыми числами в консоль
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        Console.WriteLine();
    }
}

int[,] ReplaceRowsMatrixInt(int[,] matrix)// замена строк в  матрице
{
    int numberRows = matrix.GetLength(0);
    int numberColumns = matrix.GetLength(1);
    int[,] replaceMatrix = matrix.Clone() as int[,];
    int temp = 0;
    for (int i = 0; i < numberColumns; i++)
    {
        temp = replaceMatrix[0, i];
        replaceMatrix[0, i] = replaceMatrix[numberRows - 1, i];
        replaceMatrix[numberRows - 1, i] = temp;
    }
    return replaceMatrix;
}

//Решение задачи 53.
Console.Clear();
int rowsMatrixInt = SetNumberInt("Введите количество строк матрицы: ");
int columnsMatrixInt = SetNumberInt("Введите количество столбцов матрицы: ");
int minValue = SetNumberInt("Введите минимальное значение элементов матрицы: ");
int maxValue = SetNumberInt("Введите максимальное значение элемeнтов матрицы: ");
int[,] matrixInt = GetMatrixInt(rows: rowsMatrixInt, columns: columnsMatrixInt, min: minValue, max: maxValue);
Console.WriteLine("Сформированная матрица целых чисел: ");
PrintMatrixInt(matrixInt);
int[,] newMatrixInt = ReplaceRowsMatrixInt(matrixInt);
Console.WriteLine("Матрица с переставленными строками: ");
PrintMatrixInt(newMatrixInt);


//Задача 55.Задайте двумерный массив. Напишите программу, которая заменяет строки на столбцы.
//В случае, когда это невозможно, программа должна вывести сообщение для пользователя.

int[,] TransposeMatrixInt(int[,] matrix) // транспонируем матрицу
{
    int numberRows = matrix.GetLength(0);
    int numberColumns = matrix.GetLength(1);
    int[,] newMatrix = new int[numberColumns, numberRows];
    for (int i = 0; i < numberRows; i++)
    {
        for (int j = 0; j < numberColumns; j++)
        {
            newMatrix[j, i] = matrix[i, j];
        }
    }
    return newMatrix;
}

//Решение задачи 55.
int[,] TMatrixInt = TransposeMatrixInt(matrixInt);
Console.WriteLine("Транспонированная матрица: ");
PrintMatrixInt(TMatrixInt);

//Задача 57.
//Составить частотный словарь элементов двумерного массива. Частотный словарь содержит информацию о том,
//сколько раз встречается элемент входных данных.

int CountElement(int[,] matrix, int valueElement)//Определяем колчество числа в матрице
{
    int count = 0;
    foreach (int item in matrix)
    {
        if (item == valueElement) count++;
    }
    return count;
}

bool IsFindUnique(List<int> array, int findValue) //Определяет уникальное значение
{
    foreach (var item in array)
    {
        if (item == findValue) return false;
    }
    return true;
}

void Rider(int[,] matrix)// поиск и вывод чисел
{
    List<int> array = new List<int>();
    foreach (var item in matrix)
    {
        if (IsFindUnique(array, item))
        {
            Console.WriteLine($"{item} встречается {CountElement(matrix, item)}");
            array.Add(item);
        }
    }
}

//Решение задачи 57.
Console.WriteLine("Словарь элементов матрицы: ");
Rider(matrixInt);

//Домашнее задание
/*
Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
*/

int[,] SortMatrix(int[,] matrix) //сортировка элементов в строках матрицы
{
    int numberRows = matrix.GetLength(0);
    int numberColumns = matrix.GetLength(1);
    int[,] newMatrix = matrix.Clone() as int[,];
    int max = 0;
    for (int i = 0; i < numberRows; i++)
    {
        for (int k = numberColumns; k > 0; k--)
        {
            for (int j = 1; j < k; j++)
            {
                if (newMatrix[i, j - 1] > newMatrix[i, j])
                {
                    max = newMatrix[i, j-1];
                    newMatrix[i, j-1] = newMatrix[i, j];
                    newMatrix[i,j] = max;
                }
            }
        }
    }
    return newMatrix;
}

//Решение задачи 54.
int[,] SortedMatrixInt = SortMatrix(matrixInt);
Console.WriteLine("Отсортированный по строкам массив: ");
PrintMatrixInt(SortedMatrixInt);

/*
Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку 
с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой 
элементов: 1 строка
*/

int MinSumElementsRows (int [,] matrix)//поиск строки с миниальной суммой элементов
{
    int numberRows = matrix.GetLength(0);
    int numberColumns = matrix.GetLength(1);
    int[] SumRows = new int[numberRows];
    //формирование массива сумм элементов строк матрицы
    for (int i = 0; i < numberRows; i++)
    {
        for (int j = 0; j < numberColumns; j++)
        {
            SumRows[i] = SumRows[i] + matrix[i,j];
        }
    }
    //поиск в массиве минимального элемента
    int min = SumRows[0];
    int minIndex = 0;
    for (int i = 1; i < numberRows; i++)
    {
        if (min > SumRows[i]) 
        {
            min = SumRows[i];
            minIndex = i;
        }
    }    
    Console.WriteLine(string.Join(" ", SumRows));
    return minIndex;
}

//Решение задачи 54.
int MinRowMatrixInt = MinSumElementsRows(matrixInt);
Console.WriteLine($"Строка с миниммальной суммой элементов(первая): {MinRowMatrixInt}");

/*
Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, 
которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
*/

//формирование трехмерного массива целых чисел
int[,,] GetMatrixInt3D(int dimensionX, int dimensionY, int dimensionZ, int min, int max) 
{
    int[,,] array = new int[dimensionX, dimensionY, dimensionZ];
    var random = new Random();
    for (int i = 0; i < dimensionX; i++)
    {
        for (int j = 0; j < dimensionY; j++)
        {
            for (int k = 0; k < dimensionZ; k++)
            {
                array[i,j,k] = random.Next(min, max);
            }
        }
    }
    return array;
}
void PrintArray3D(int [,,] array)
{
    int dimensionX = array.GetLength(0);
    int dimensionY = array.GetLength(1);
    int dimensionZ = array.GetLength(2);
    for (int i = 0; i < dimensionX; i++)
    {
        for (int j = 0; j < dimensionY; j++)
        {
            for (int k = 0; k < dimensionZ; k++)
            {
                Console.WriteLine($"array[i,j,k]
            }
        }
    }
}