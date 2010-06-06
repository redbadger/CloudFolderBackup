namespace RedBadger.CloudFolderBackup.ConsoleApp
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "Cloud Folder Backup";

            if (IsSilentMode(args))
            {
                try
                {
                    Agent.Run();
                }
                catch
                {
                    // Fail Silently
                }
            }
            else
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
                Console.WriteLine("Press any key to exit.");
                Console.ReadLine();
            }
        }

        private static bool IsSilentMode(string[] args)
        {
            return args.Length > 0 && args[0].ToLower() == "-s";
        }
    }
}