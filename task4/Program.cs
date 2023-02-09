// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, 
// которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

int[] InputRowsCols(string str)
{
    int[] input = new int[3];
    string text;
    newTry:
    Console.Write(str);
    text = Console.ReadLine();
    string[] split = text.Split(' ');
    for (int i = 0; i < split.Length; i++)
    {
        if (!(int.TryParse(split[i], out input[i])) || split.Length != 3 || (Convert.ToInt32(input[i]) <= 0))
        {
            System.Console.WriteLine("Введены некорректные данные, повторите ввод");
            goto newTry;
        }
    }
    return input;
}

int[,,] FillMatrix(int x, int y, int z)
{
    List<Int32> repeats = new List<Int32>();
    Random rand = new Random();
    int[,,] matrix = new int[x, y, z];
    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < y; j++)
        {
            for (int k = 0; k < z; k++)
            {
                while (true)
                {
                    matrix[i, j, k] = rand.Next(10, 100);
                    if (!repeats.Contains(matrix[i, j, k])) //если сгенерированное число не содержиться в списке ранее сгенерировнанных чисел
                    {
                        repeats.Add(matrix[i, j, k]);
                        break;
                    }
                }
            }

        }
    }
    return matrix;
}

void PrintCubeMatrix(int[,,] matrix)
{
    for (int z = 0; z < matrix.GetLength(2); z++)
    {
        for (int x = 0; x < matrix.GetLength(0); x++)
        {
            for (int y = 0; y < matrix.GetLength(1); y++)
            {
                System.Console.Write(matrix[x, y, z] +"("+x+","+y+","+z+")" + "\t");
            }
        System.Console.WriteLine();
        }
    }
}

int[] rowsCols = InputRowsCols("Введи размеры кубической матрицы (3 числа через пробел): ");
int[,,] cubeMatrix = FillMatrix(rowsCols[0],rowsCols[1],rowsCols[2]);
PrintCubeMatrix(cubeMatrix);