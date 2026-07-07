namespace CSharpLearning.Class01;

public class Lesson16
{
    public static void Run()
    {
        Console.WriteLine("---------------方阵数组");
        int[,] arrays1 = new int[3, 2]; //3行2列
        int[,] arrays2 = {{1, 2}, {3, 4}, {5, 6} }; //3行2列
        Console.WriteLine("Lesson16: 处理命令行参数");
        
        for (int i = 0; i < arrays2.GetLength(0); i++)
        {
            for (int j = 0; j < arrays2.GetLength(1); j++)
            {
                Console.Write(arrays2[i,j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("---------------交错数组1");
        int[][] arrays3 = new int[3][]; //3行,每行的列数不固定
        arrays3[0] = new int[] { 1, 2 };
        arrays3[1] = new int[] { 3, 4, 5 };
        arrays3[2] = new int[] { 6 };
        
        for (int i = 0; i < arrays3.Length; i++)
        {
            for (int j = 0; j < arrays3[i].Length; j++)
            {
                Console.Write(arrays3[i][j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("---------------交错数组2a");
        int[][] arrays4 = {
            new int[] { 7, 8 },
            new int[] { 9, 10, 11 },
            new int[] { 12 }
        };

        for (int i = 0; i < arrays4.Length; i++)
        {
            foreach (var item in arrays4[i])
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        Console.WriteLine("---------------交错数组2b");
        foreach (int[] i in arrays4)
        {
            foreach (var j in i)
            {
                Console.WriteLine(j);
            }
        }
    }
}
