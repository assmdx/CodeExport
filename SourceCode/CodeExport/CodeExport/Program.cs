using System;
using System.IO;

namespace CodeExport
{
    class Program
    {
        static void Main(string[] args)
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
            if (args.Length >2)
            {               
                string[] codeFormat = new string[args.Length -2];
                for(int i = 2; i < args.Length; i++)
                {
                    codeFormat[i - 2] = args[i];
                }
                Export _export = new Export(args[0], args[1], codeFormat);
                _export.start();
            }           
        }
    }
}
