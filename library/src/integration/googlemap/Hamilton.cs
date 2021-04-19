using System.Collections.Generic;

namespace Core.Libs.Integration
{
    public class Hamilton
    {
        private int n = 0; // Total Point
        private int[,] A; // Matrix
        private int[] B; // Array Out Put
        private int[] C; // Array Temp
        private List<int[]> D = new List<int[]>(); // List Array Out Put
        public Hamilton(
            int SizeMemory = 100)
        {
            this.A = new int[SizeMemory, SizeMemory];
            this.B = new int[SizeMemory];
            this.C = new int[SizeMemory];
        }

        public List<int[]> FindHamilton(
            int[,] Matrix,
            int TotalPoint,
            int StartPoint = 0)
        {
            Init(Matrix, TotalPoint, StartPoint);

            CheckHamilton(1);

            return D;
        }

        private void Init(int[,] Matrix, int TotalPoint, int StartPoint)
        {
            A = Matrix;
            n = TotalPoint;
            B[0] = StartPoint;
        }

        private void CheckHamilton(
            int i)
        {
            for (int j = 0; j < n; j++)
            {
                if (A[B[i - 1], j] == 1 && C[j] == 0)
                {
                    B[i] = j;
                    C[j] = 1;

                    if (i < n)
                        CheckHamilton(i + 1);

                    else if (B[i] == B[0])
                        Result(B, n);

                    C[j] = 0;
                }
            }
        }

        private void Result(int[] B, int n)
        {
            var result = new int[n + 1];

            for (int i = 0; i < n + 1; i++)
                result[i] = B[i];

            D.Add(result);
        }
    }
}