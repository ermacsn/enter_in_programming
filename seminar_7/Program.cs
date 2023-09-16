using System.Numerics;  
/*
Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
m = 3, n = 4.
0,5 7 -2 -0,2
1 -3,3 8 -9,9
8 7,8 -7,1 9
*/
int SetNumberInt (string message) //получение числа от пользователя
{
    Console.Write(message);
    int number = Convert.ToInt32(Console.ReadLine());
    return number;
}

double[,] GetMatrixDouble(int rows, int columns, int minValue, int maxValue) //формирование матрицы вещественых чисел
{
    double [,] matrix = new double [rows, columns];
    var random = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix [i,j] = Math.Round((random.Next(minValue, maxValue) + random.NextDouble()), 2);
        }
    }
    return matrix;
}

void PrintMatrixDouble(double [,] matrix) // вывод матрицы в консоль
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i,j]} ");
        }
        Console.WriteLine();
    }
}

//Решение задачи 47
Console.Clear();
int rowsMatrix = SetNumberInt("Введите количество строк матрицы: ");
int columnsMatrix = SetNumberInt("Введите количество столбцов матрицы: ");
double[,] matrixDouble = GetMatrixDouble(rows: rowsMatrix, columns: columnsMatrix, minValue: 0, maxValue: 9);
Console.WriteLine("Сформированная матрица вещественных чисел: ");
PrintMatrixDouble(matrixDouble);

/*
Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, 
и возвращает значение этого элемента или же указание, что такого элемента нет.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
17 -> такого числа в массиве нет
*/

string GetElement(double[,] matrix, int row, int column) //получение значения элемента матрицы по номеру столбца и строки
{
    if (matrix.GetLength(0) <= row || matrix.GetLength(1) <= column) return "Элемент с такими параметрами отсутсвует";
    else
        return ($"{matrix[row, column]}");
} 

//Решение задачи 50
int rowElement = SetNumberInt("Введите номер строки элемента в матрице: ");
int columnElement = SetNumberInt("Введите номер столбца элемента в матрице: ");
Console.WriteLine(GetElement(matrixDouble, rowElement, columnElement));

/*
Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов 
в каждом столбце.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.
*/


int[,] GetMatrixInt(int rows, int columns, int minValue, int maxValue) //формирование матрицы целых чисел
{
    int [,] matrix = new int [rows, columns];
    var random = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix [i,j] = random.Next(minValue, maxValue);
        }
    }
    return matrix;
}


double [] AverageColumnsMatrix(int [,] matrix)//вычисление среднего арифметического по столбцам
{
   double [] averageArray = new double [matrix.GetLength(1)]; 
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        averageArray[i] = 0;
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            averageArray[i] = averageArray[i] + matrix[j,i];
        }
        averageArray[i] = averageArray[i]/matrix.GetLength(0);
    }
    return averageArray;
}


void PrintMatrixInt (int [,] matrix) // вывод матрицы в консоль
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i,j]} ");
        }
        Console.WriteLine();
    }
}

//Решение задачи 52.
int rowsMatrixInt = SetNumberInt("Введите количество строк матрицы: ");
int columnsMatrixInt = SetNumberInt("Введите количество столбцов матрицы: ");
int[,] matrixInt = GetMatrixInt(rows: rowsMatrixInt, columns: columnsMatrixInt, minValue: 0, maxValue: 9);
Console.WriteLine("Сформированная матрица целых чисел: ");
PrintMatrixInt(matrixInt);
Console.WriteLine("Средние арифметические столбцов: ");
double[] averageColumns = AverageColumnsMatrix(matrixInt);
Console.WriteLine(String.Join(" ", averageColumns));