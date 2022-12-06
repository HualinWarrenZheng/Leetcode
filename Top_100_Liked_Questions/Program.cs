using System.Runtime.CompilerServices;

namespace Top_100_Liked_Questions
{
    internal class Program
    {
        static void Main()
        {
            Easy easy = new();
            Medium medium = new();
            Hard hard = new();

            easy.Run();
            medium.Run();
            hard.Run();
        }

    }
}