using System;

namespace TLS_HX.Lesson06_Indexer_Practice
{
    /// <summary>
    /// 【场景 4】矩阵运算类
    /// 
    /// 知识点：
    /// - 二维索引器 [row, col]
    /// - 边界检查与异常处理
    /// - 二维数组的包装与面向对象设计
    /// - 矩阵操作（转置、显示等）
    /// 
    /// 场景描述：
    /// 将二维数组封装成矩阵类，通过行列索引访问元素
    /// 索引器自动检查边界，越界时抛异常
    /// 
    /// 运行方式：
    /// dotnet run -- scenario4
    /// </summary>
    public class Matrix
    {
        private double[,] data;
        public int Rows { get; private set; }
        public int Cols { get; private set; }

        public Matrix(int rows, int cols)
        {
            data = new double[rows, cols];
            Rows = rows;
            Cols = cols;
        }

        /// <summary>
        /// 二维索引器：通过 [行, 列] 访问元素
        /// get/set 都带有边界检查，越界时抛 IndexOutOfRangeException
        /// </summary>
        public double this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= Rows || col < 0 || col >= Cols)
                    throw new IndexOutOfRangeException(
                        $"索引超出范围 [{row},{col}]，矩阵大小为 {Rows}x{Cols}");
                return data[row, col];
            }
            set
            {
                if (row < 0 || row >= Rows || col < 0 || col >= Cols)
                    throw new IndexOutOfRangeException(
                        $"索引超出范围 [{row},{col}]，矩阵大小为 {Rows}x{Cols}");
                data[row, col] = value;
            }
        }

        /// <summary>显示矩阵</summary>
        public void Display(string title = "矩阵")
        {
            Console.WriteLine($"\n【{title} {Rows}x{Cols}】");
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                    Console.Write($"{this[i, j]:F2,8} ");
                Console.WriteLine();
            }
        }

        /// <summary>矩阵转置</summary>
        public Matrix Transpose()
        {
            Matrix result = new Matrix(Cols, Rows);
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols; j++)
                    result[j, i] = this[i, j];
            return result;
        }

        /// <summary>矩阵转换为字符串</summary>
        public override string ToString()
        {
            return $"Matrix({Rows}x{Cols})";
        }
    }

    // ============ 测试用例 ============
    class Scenario04
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║   场景 4：矩阵运算类                    ║");
            Console.WriteLine("╚════════════════════════════════════════╝\n");

            // 创建 3x3 矩阵
            Matrix matrix = new Matrix(3, 3);

            Console.WriteLine("【初始化矩阵】");
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    matrix[i, j] = i * 3 + j + 1;

            matrix.Display("原矩阵");

            Console.WriteLine("\n【访问特定元素】");
            Console.WriteLine($"  matrix[0, 0] = {matrix[0, 0]}");
            Console.WriteLine($"  matrix[1, 1] = {matrix[1, 1]}");
            Console.WriteLine($"  matrix[2, 2] = {matrix[2, 2]}");

            Console.WriteLine("\n【修改元素】");
            matrix[0, 0] = 10;
            matrix[1, 1] = 50;
            Console.WriteLine($"修改后 matrix[0, 0] = {matrix[0, 0]}");
            Console.WriteLine($"修改后 matrix[1, 1] = {matrix[1, 1]}");
            matrix.Display("修改后的矩阵");

            Console.WriteLine("\n【矩阵转置】");
            Matrix transposed = matrix.Transpose();
            transposed.Display("转置后的矩阵");

            Console.WriteLine("\n【边界检查 - 尝试越界访问】");
            try
            {
                double value = matrix[5, 5];  // 超出 3x3 范围
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"✗ 异常捕获：{ex.Message}");
            }

            try
            {
                matrix[-1, 0] = 100;  // 负索引
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"✗ 异常捕获：{ex.Message}");
            }
        }
    }
}
