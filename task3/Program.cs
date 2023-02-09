// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

int[] InputRowsCols(string str)
{
    int[] input = new int[4];
    string text;
newTry:
    Console.Write(str);
    text = Console.ReadLine();
    string[] split = text.Split(' ');
    for (int i = 0; i < split.Length; i++)
    {
        if (!(int.TryParse(split[i], out input[i])) || split.Length != 4 || (Convert.ToInt32(input[i]) <= 0))
        {
            System.Console.WriteLine("Введены некорректные данные, повторите ввод");
            goto newTry;
        }
        else if (split[1] != split[2])
        {
            System.Console.WriteLine("Число столбцов 1й матрицы должно быть равным числу строк 2й матрицы");
            goto newTry;
        }
    }
    return input;
}

int[,] FillMatrix(int rows, int cols)
{
    Random rand = new Random();
    int[,] matrix = new int[rows, cols];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            matrix[i, j] = rand.Next(0, 11);
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

int[,] MatrixMultiplication(int[,] matrixA, int[,] matrixB)
{
    int[,] matrixMult = new int[matrixA.GetLength(0), matrixB.GetLength(1)];
    for (int i = 0; i < matrixA.GetLength(0); i++)  
    { 
        for (int j = 0; j < matrixB.GetLength(1); j++) 
        { 
            for (int k = 0; k < matrixA.GetLength(1); k++)
            {
                matrixMult[i,j] += matrixA[i,k] * matrixB[k,j];
            }
        }
    }
    return matrixMult;
}

int[] rowsCols = InputRowsCols("Введи кол-во строк и столбцов 1й матрицы и 2й матрицы (4 числа через пробел): ");
int[,] matrixA = FillMatrix(rowsCols[0], rowsCols[1]);
int[,] matrixB = FillMatrix(rowsCols[2], rowsCols[3]);
//------- для быстрой проверки
//int[,] matrixA = {{2, 4},{3, 2}};
//int[,] matrixB = {{3, 4},{3, 3}};
//-------
int[,] matrixMult = MatrixMultiplication(matrixA,matrixB);
PrintMatrix(matrixA);
System.Console.WriteLine("------------");
PrintMatrix(matrixB);
System.Console.WriteLine($"Произведение двух матриц:");
PrintMatrix(matrixMult);
