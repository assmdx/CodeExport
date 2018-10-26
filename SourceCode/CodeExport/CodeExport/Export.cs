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
        protected  void copyCode(string fullFilePath)
        {
            if (_codeFileFormat.Contains(fullFilePath.Substring(fullFilePath.LastIndexOf(".")+1)))
            {
                File.AppendAllText(_desCodeFile, _lastLine.ToString() + "    START\r\n");
                _lastLine++;

                string line = string.Empty;
                FileStream readFileStream = new FileStream(fullFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using (StreamReader reader = new StreamReader(readFileStream))
                {                   
                    while ((line = reader.ReadLine()) != null)
                    {                        
                        File.AppendAllText(_desCodeFile,_lastLine.ToString() + "    "+line+"\r\n");                        
                        _lastLine++;
                    }                    
                }

                File.AppendAllText(_desCodeFile, _lastLine.ToString() + "    END\r\n");
                _lastLine++;
            }
            return;
        }
        public void start()
        {
            copyDir(_sourceCodeDir);
        }
        public Export(string sourceCodeDir,string desCodeFile,string []codeFormat)
        {            
            _sourceCodeDir = sourceCodeDir;
            _desCodeFile = desCodeFile;
            if (File.Exists(_desCodeFile))
            {
                File.Delete(_desCodeFile);
            }
            File.Create(_desCodeFile).Close();
            foreach(string format in codeFormat)
            {
                _codeFileFormat.Add(format);
            }
        }
    }
}
