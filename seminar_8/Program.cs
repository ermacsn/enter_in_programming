﻿using System.Globalization;
using System.Security.Principal;
using System.Xml.XPath;
using System.Threading;

//Семинар

//Задача 53: Задайте двумерный массив. Напишите программу, которая поменяет местами первую
// и последнюю строку массива.

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

Console.Clear();
Console.WriteLine("Задача 53.");
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

Console.WriteLine();
Console.WriteLine("Задача 55.");
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

Console.WriteLine();
Console.WriteLine("Задача 57.");
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
                    max = newMatrix[i, j - 1];
                    newMatrix[i, j - 1] = newMatrix[i, j];
                    newMatrix[i, j] = max;
                }
            }
        }
    }
    return newMatrix;
}

Console.WriteLine();
Console.WriteLine("Задача 54.");
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

int MinSumElementsRows(int[,] matrix)//поиск строки с миниальной суммой элементов
{
    int numberRows = matrix.GetLength(0);
    int numberColumns = matrix.GetLength(1);
    int[] SumRows = new int[numberRows];
    //формирование массива сумм элементов строк матрицы
    for (int i = 0; i < numberRows; i++)
    {
        for (int j = 0; j < numberColumns; j++)
        {
            SumRows[i] = SumRows[i] + matrix[i, j];
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
    return minIndex;
}

Console.WriteLine();
Console.WriteLine("Задача 56.");
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
                array[i, j, k] = random.Next(min, max);
            }
        }
    }
    return array;
}
void PrintArray3D(int[,,] array)
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
                Console.Write($"{array[i, j, k]}({i},{j},{k}) ");
            }
            Console.WriteLine();
        }
    }
}

Console.WriteLine();
Console.WriteLine("Задача 60.");
int dimensionXArray3D = SetNumberInt("Введите первую размерность трехмерного массива: ");
int dimensionYArray3D = SetNumberInt("Введите вторую размерность трехмерного массива: ");
int dimensionZArray3D = SetNumberInt("Введите третью размерность трехмерного массива: ");
int minValue3D = SetNumberInt("Введите минимальное значение элементов массива: ");
int maxValue3D = SetNumberInt("Введите максимальное значение элемeнтов массива: ");
Console.WriteLine("Сформированный трехмерный массив: ");
int[,,] ArrayInt3D = GetMatrixInt3D(dimensionX: dimensionXArray3D, dimensionY: dimensionYArray3D,
                                    dimensionZ: dimensionZArray3D, min: minValue3D, max: maxValue3D);
PrintArray3D(ArrayInt3D);

/*
Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/

int[,] FillSpiralMatrixInt(int countRows, int countColumns)
{
    int beginRows = 0;
    int beginColumns = 0;
    int endRows = countRows - 1;
    int endColumns = countColumns -1;
    int[,] matrix = new int[countRows, countColumns];
    int countElements = countRows * countColumns;
    int sum = 0;

    while (sum <= countElements - 1)
    {
        for (int j = beginColumns; j <= endColumns; j++)//горизонтально слева направо
        {
            matrix[beginRows, j] = sum;
            sum++;
        }

        for (int i = beginRows + 1; i <= endRows; i++)//вертикально сверху вниз
        {
            matrix[i, endColumns] = sum;
            sum++;
        }

        for (int j = endColumns - 1; j >= beginColumns; j--)//горизонтально справа налево
        {
            matrix[endRows, j] = sum;
            sum++;
        }

        for (int i = endRows - 1; i >= beginRows + 1; i--)//вертикально снизу вверх
        {
            matrix[i, beginColumns] = sum;
            sum++;
        }

        beginRows++;
        beginColumns++;
        endRows--;
        endColumns--;
    }
    return matrix;
}

void PrintSpiralMatrixInt(int[,] matrix) // вывод сиральной матрицы в консоль
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j].ToString("000")} ");
        }
        Console.WriteLine();
    }
}

Console.WriteLine();
Console.WriteLine("Задача 60.");
int spiralRowsMatrixInt = SetNumberInt("Введите количесво строк спиральной матрицы: ");
int spiralColumnsMatrixInt = SetNumberInt("Введите количество столбцов спиральной матрицы: ");
Console.WriteLine("Матрица, заполненная спиралью: ");
int[,] filedSpiralmarixInt = FillSpiralMatrixInt(spiralRowsMatrixInt, spiralColumnsMatrixInt);
PrintSpiralMatrixInt(filedSpiralmarixInt);