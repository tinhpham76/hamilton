namespace Core.Libs.Integration.Test.Manual
{
    partial class Program
    {
        static void TestHamilton()
        {
            var hamilton = new Hamilton.Hamilton();

            int[,] A = new int[50, 50];

            A[1, 1] = 0;
            A[1, 2] = 1;
            A[1, 3] = 0;
            A[1, 4] = 1;
            A[1, 5] = 0;
            A[2, 1] = 1;
            A[2, 2] = 0;
            A[2, 3] = 1;
            A[2, 4] = 0;
            A[2, 5] = 1;
            A[3, 1] = 0;
            A[3, 2] = 1;
            A[3, 3] = 0;
            A[3, 4] = 1;
            A[3, 5] = 1;
            A[4, 1] = 1;
            A[4, 2] = 0;
            A[4, 3] = 1;
            A[4, 4] = 0;
            A[4, 5] = 1;
            A[5, 1] = 0;
            A[5, 2] = 1;
            A[5, 3] = 1;
            A[5, 4] = 1;
            A[5, 5] = 0;

            var ha = hamilton.Check(1, A, 5);
        }
    }
}