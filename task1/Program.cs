// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

int[] InputRowsCols(string str)
{
    int[] input = new int[2];
    string text;
    newTry:
    Console.Write(str);
    text = Console.ReadLine();
    string[] split = text.Split(' ');
    for (int i = 0; i <= 1; i++)
    {
        if (!(int.TryParse(split[i], out input[i])) || split.Length != 2 || (Convert.ToInt32(input[i]) <= 0))
        {
            System.Console.WriteLine("Введены некорректные данные, повторите ввод");
            goto newTry;
        }
    }
    return input;
}

int[,] FillMatrix(int rows, int cols)
{
    Random rand = new Random();
    int[,] matrix = new int[rows,cols];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            matrix[i,j] = rand.Next(0, 11);
        }        
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            System.Console.Write(matrix[i, j] + "\t");
        }
        System.Console.WriteLine();
    }
}

int[,] SortMatrix(int[,] matrix)
{
    int temp = 0;
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int i = 0; i < matrix.GetLength(1); i++)  //Пузырьковая сортировка
        {
            for (int j = 0; j < matrix.GetLength(1) - 1 - i; j++)
            {
                if (matrix[row, j] < matrix[row, j + 1])
                {
                    temp = matrix[row, j];
                    matrix[row, j] = matrix[row, j + 1];
                    matrix[row, j + 1] = temp;
                }
            }
        }
    }
    return matrix;
}

int[] rowsCols = InputRowsCols("Введи кол-во строк и столбцов через пробел: ");
int[,] matrix = FillMatrix(rowsCols[0],rowsCols[1]);
System.Console.WriteLine("Исходная матрица:");
PrintMatrix(matrix);
System.Console.WriteLine("Отсортированная матрица:");
PrintMatrix(SortMatrix(matrix));