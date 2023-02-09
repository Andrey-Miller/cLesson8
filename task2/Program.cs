// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить 
// строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

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
            matrix[i,j] = rand.Next(0, 21);
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

int RowMinSum(int[,] matrix)
{
    int min = 1000;
    int posMin = 0;
    int[] minSum = new int[matrix.GetLength(0)];
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int j=0; j < matrix.GetLength(1); j++)
        {
            minSum[row]+=matrix[row,j];
        }
    }
    //Console.WriteLine(string.Join(", ", minSum));
    for (int i=0; i < minSum.Length; i++)
    {
        if (minSum[i] < min) 
        {
            min = minSum[i];
            posMin = i;    
        }
    }
    return posMin+1;
}
int[] rowsCols = InputRowsCols("Введи кол-во строк и столбцов через пробел: ");
int[,] matrix = FillMatrix(rowsCols[0],rowsCols[1]);
PrintMatrix(matrix);
System.Console.WriteLine($"Строка с наименьшей суммой элементов: {RowMinSum(matrix)}");
