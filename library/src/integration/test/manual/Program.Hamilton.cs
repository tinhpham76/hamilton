namespace Core.Libs.Integration.Test.Manual
{
    partial class Program
    {
        static void TestHamilton()
        {
            var a = new int[,]
            {
                {1,0}, {1,1},{1,1} ,{1,0},{1, 1}, {1,1}, {1,0}, {1,0},{1, 0}, {1,0},
1 0 1 0 0 0 0 0 1 0
1 1 0 1 0 0 1 0 0 0
0 0 1 0 1 0 0 0 0 1
1 0 0 1 0 0 0 1 0 0
1 0 0 0 0 0 1 0 0 1
0 0 1 0 0 1 0 1 0 0
0 0 0 0 1 0 1 0 1 0
0 1 0 0 0 0 0 1 0 1
0 0 0 1 0 1 0 0 1 0
            };
            var b = new int[20];
            var c = new int[20];
        }
    }
}