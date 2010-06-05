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
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            Console.ReadLine();
        }
    }
}