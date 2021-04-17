namespace Core.Libs.Integration.Test.Manual
{
    partial class Program
    {
        static void TestHamilton()
        {
            var hamilton = new Hamilton(6);

            int[,] A = new int[50, 50];

            A[0, 0] = 0;
            A[0, 1] = 1;
            A[0, 2] = 0;
            A[0, 3] = 1;
            A[0, 4] = 0;
            A[1, 0] = 1;
            A[1, 1] = 0;
            A[1, 2] = 1;
            A[1, 3] = 0;
            A[1, 4] = 1;
            A[2, 0] = 0;
            A[2, 1] = 1;
            A[2, 2] = 0;
            A[2, 3] = 1;
            A[2, 4] = 1;
            A[3, 0] = 1;
            A[3, 1] = 0;
            A[3, 2] = 1;
            A[3, 3] = 0;
            A[3, 4] = 1;
            A[4, 0] = 0;
            A[4, 1] = 1;
            A[4, 2] = 1;
            A[4, 3] = 1;
            A[4, 4] = 0;

            var arrayHamilton = hamilton.Check(A, 5);
        }
    }
}