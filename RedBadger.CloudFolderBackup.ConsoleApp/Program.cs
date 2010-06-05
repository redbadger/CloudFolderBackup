namespace RedBadger.CloudFolderBackup.ConsoleApp
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Agent.Run();
                Console.WriteLine("Success!");
            }
            catch (Exception exception)
            {
                Console.WriteLine("Failed:");
                Console.WriteLine(exception);
            }

            Console.WriteLine();
            Console.WriteLine(string.Format("Finished: {0}", DateTime.Now));
            Console.ReadLine();
        }
    }
}