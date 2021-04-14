namespace Core.Libs.Integration.Test.Manual
{
    partial class Program
    {
        static void Main(string[] args)
        {
            TestGoogleMap();

            // TestHamilton();

            // StringTest();
        }

        static void StringTest()
        {
            var str1 = "Thành phố Bảo Lộc";
            var str2 = "tp. Bảo Lộc";

            var a = 0;

            if (string.Compare(str1, str2, true) == 0)
                a = 1;
        }
    }
}