using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAPI
{
    public class Writer
    {

        public string DirectoryPath { get; set; }
        public string  FileName { get; set; }
        public string FileContent { get; set; }

        public GenericObject GenericObject { get; set; }

        public Writer(string directoryPath, string fileName, GenericObject genericObject)
        {
            DirectoryPath = directoryPath;
            FileName = fileName;
            GenericObject = genericObject;
        }

        public async void WriteFile(OptionsWrite options)
        {
            if (DirectoryExist(DirectoryPath) && !string.IsNullOrWhiteSpace(FileName))
            {
                if(GenericObject != null && GenericObject.Attributes != null && GenericObject.Attributes.Count > 0)
                {
                    string filePath = DirectoryPath + FileName + ".ts";
                    using (var stream = File.Create(filePath))
                    {
                        string fileStart = "export class BeerRepository { \n" +
                            "     constructor(private pool: Pool) { }\n";
                        await WriteLineUTF8(fileStart, stream);

                        if (options.ReadAll)
                        {
                            string readMethod = string.Empty;
                            readMethod += "     async get" + GenericObject.ObjectName + "() { \n";
                            readMethod += "         return await this.pool.query(\"SELECT * FROM " + GenericObject.Schema + "." + GenericObject.ObjectName + "\"); \n";
                            readMethod += "     }\n";
                            await WriteLineUTF8(readMethod, stream);
                        }
                        await WriteLineUTF8("}", stream);
                    }
                }
            }
        }

        private async Task WriteLineUTF8(string line, FileStream stream)
        {
            var encodedShit = Encoding.UTF8.GetBytes(line);
            await stream.WriteAsync(encodedShit, 0, encodedShit.Length);
        }

        private bool DirectoryExist(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                Console.WriteLine("Le chemin du dossier est vide");
                return false;
            }
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Le dossier n'existe pas : " + path);
                return false;
            }
            else return true;
        }

    }
}
