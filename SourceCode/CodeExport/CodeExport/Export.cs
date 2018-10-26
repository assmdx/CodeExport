using System;
using System.Collections;
using System.IO;
namespace CodeExport
{
    class Export
    {
        int _lastLine = 0;
        string _sourceCodeDir;
        string _desCodeFile;
        ArrayList _codeFileFormat = new ArrayList();

        protected void copyDir(string dir)
        {
            try
            {
                DirectoryInfo TheFolder = new DirectoryInfo(dir);
                //copy all code file of this dir
                foreach (FileInfo file in TheFolder.GetFiles())
                {
                    copyCode(file.FullName);
                }
                //
                foreach (DirectoryInfo directory in TheFolder.GetDirectories())
                {
                    copyDir(directory.FullName);
                }
            }
            catch(Exception e)
            {
                throw e;
            }                  
        }
        protected  void copyCode(string fullFilePath)
        {
            try
            {
                if (_codeFileFormat.Contains(fullFilePath.Substring(fullFilePath.LastIndexOf(".") + 1)))
                {
                    Console.WriteLine(fullFilePath);

                    string line = string.Empty;
                    FileStream readFileStream = new FileStream(fullFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using (StreamReader reader = new StreamReader(readFileStream))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            File.AppendAllText(_desCodeFile, _lastLine.ToString() + "    " + line + "\r\n");
                            _lastLine++;
                        }
                    }
                }
                return;
            }
            catch(Exception e)
            {
                throw e;
            }           
        }
        public void start()
        {
            try
            {
                copyDir(_sourceCodeDir);
            }
            catch (Exception e)
            {
                throw e;
            }            
        }
        public Export(string sourceCodeDir,string desCodeFile,string []codeFormat)
        {
            if (!Directory.Exists(sourceCodeDir))
            {
                throw new FileNotFoundException("源代码目录不存在");
            }
            _sourceCodeDir = sourceCodeDir;
            _desCodeFile = desCodeFile;
            try
            {
                if (File.Exists(_desCodeFile))
                {
                    File.Delete(_desCodeFile);
                }
                File.Create(_desCodeFile).Close();
            }
            catch(Exception e)
            {
                throw new FileNotFoundException("目标文本文件所在目录不存在或无权限访问");
            }           
            foreach(string format in codeFormat)
            {
                _codeFileFormat.Add(format);
            }
        }
    }
}
