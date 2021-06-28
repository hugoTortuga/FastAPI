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

        public void WriteFile(OptionsWrite options)
        {
            if (DirectoryExist(DirectoryPath))
            {
                if(GenericObject != null && GenericObject.Attributes != null && GenericObject.Attributes.Count > 0)
                {
                    File.AppendAllText(DirectoryPath, "export class BeerRepository { " + "constructor(private pool: Pool) { }");
                    
                    
                    if (options.ReadAll)
                    {
                        string readMethod = string.Empty;
                        foreach (var attribute in GenericObject.Attributes)
                        {
                            readMethod += "async get" + GenericObject.ObjectName + "() { \n";
                            readMethod += "return await this.pool.query(\"SELECT * FROM " + GenericObject.Schema + "." + GenericObject.ObjectName + "\"); \n";
                            readMethod += "}\n";
                        }
                        File.AppendAllText(DirectoryPath, readMethod);
                    }

                    File.AppendAllText(DirectoryPath, "}");
                }
            }
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
