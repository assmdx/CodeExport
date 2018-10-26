using System;
using System.IO;

namespace CodeExport
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start...............................................................................................................................");
            try
            {
                if (args.Length == 1)
                {
                    string[] codeFormat = { };
                    Export _export = new Export(args[0], Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "code.txt"), codeFormat);
                    _export.start();
                }
                if (args.Length == 2)
                {
                    string[] codeFormat = { };
                    Export _export = new Export(args[0], args[1], codeFormat);
                    _export.start();
                }
                if (args.Length > 2)
                {
                    string[] codeFormat = new string[args.Length - 2];
                    for (int i = 2; i < args.Length; i++)
                    {
                        codeFormat[i - 2] = args[i];
                    }
                    Export _export = new Export(args[0], args[1], codeFormat);
                    _export.start();
                }
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("出错了!");
            }
            Console.WriteLine("Finish...............................................................................................................................");
        }       
    }
}
