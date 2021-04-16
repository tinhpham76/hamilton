using System.Collections.Generic;

namespace Core.Libs.Integration.Hamilton
{
    public interface IHamilton
    {
        List<int[]> Check(
            int start,
            int[,] matrix,
            int point);
    }

    public class Hamilton : IHamilton
    {
        private int n = 0;
        private int[,] A = new int[50, 50];
        private int[] B = new int[50];
        private int[] C = new int[50];
        private List<int[]> D = new List<int[]>();
        public Hamilton()
        {
        }

        public List<int[]> Check(
            int start,
            int[,] matrix,
            int point)
        {
            Init(point, matrix);

            B[0] = start;

            int i = 1;

            CheckHamilton(i);

            return D;
        }

        public void Init(int point, int[,] matrix)
        {
            A = matrix;
            n = point;
        }

        public void CheckHamilton(
            int i)
        {
            for (int j = 1; j <= n; j++)
            {

                if (A[B[i - 1], j] == 1 && C[j] == 0)
                {
                    B[i] = j;
                    C[j] = 1;

                    if (i < n)
                        CheckHamilton(i + 1);

                    else if (B[i] == B[0])
                    {
                        D.Add(B);
                    }

                    C[j] = 0;
                }
            }
        }
    }
}