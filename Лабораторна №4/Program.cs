using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введiть кiлькiсть рядкiв матрицi: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Введiть кiлькiсть стовпцiв матрицi: ");
        int cols = int.Parse(Console.ReadLine());

        int[,] matrix = new int[rows, cols];
        Random rand = new Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rand.Next(-10, 10); 
            }
        }

        Console.WriteLine("Матриця:"); for (int i = 0; i < rows; i++)
        {

            for (int j = 0; j < cols; j++)
            {
                Console.Write("{0,4}", matrix[i, j]);
            }

            Console.WriteLine();
        }
            int[] sums = new int[rows];
        for (int i = 0; i < rows; i++)
        {
            bool Negative = false;
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] < 0)
                {
                    Negative = true;
                }
                sums[i] += matrix[i, j];
            }
            if (Negative)
            {
                Console.WriteLine($"Рядок {i}: {string.Join(", ", GetRow(matrix, i))}");
            }
        }
        Console.WriteLine($"Суми елементiв у рядках з вiд'ємними елементами: {string.Join(", ", sums)}");

        
        for (int i = 0; i < rows; i++)
        {
            int rowMin = matrix[i, 0];
            int colIndex = 0;
            for (int j = 1; j < cols; j++)
            {
                if (matrix[i, j] < rowMin)
                {
                    rowMin = matrix[i, j];
                    colIndex = j;
                }
            }
            bool isSaddle = true;
            for (int k = 0; k < rows; k++)
            {
                if (matrix[k, colIndex] > rowMin)
                {
                    isSaddle = false;
                    Console.WriteLine($"Сiдлову точку не знайдено");
                    break;
                }
            }
            if (isSaddle)
            {
                Console.WriteLine($"Сiдлова точка у рядку {i}, стовпці {colIndex}");
            }
        }
    }

    
    static int[] GetRow(int[,] matrix, int rowIndex)
    {
        int cols = matrix.GetLength(1);
        int[] row = new int[cols];
        for (int j = 0; j < cols; j++)
        {
            row[j] = matrix[rowIndex, j];
        }
        return row;
    }
}