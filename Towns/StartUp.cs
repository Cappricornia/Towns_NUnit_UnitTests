using System;
using Towns;

public class StartUp
{
    public static void Main(string[] strings)
    {
        TownsProcessor townsProcessor = new TownsProcessor();

        while (true)
        {
            string cmd = Console.ReadLine();
            
            if (cmd == "END")
                break;

            string result = townsProcessor.ExecuteCommand(cmd);

            Console.WriteLine(result);
        }
    }
}