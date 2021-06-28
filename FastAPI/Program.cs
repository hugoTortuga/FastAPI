using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Bienvenue dans le projet FastAPI");
            Console.WriteLine("Entrez le chemin du répertoire");

            string directoryPath = string.Empty;
            string objectName = "user";

            var listAttributes = new List<GenericAttribute>() { 
                new GenericAttribute(typeof(int), "id"),
                new GenericAttribute(typeof(string), "firstName"),
                new GenericAttribute(typeof(string), "lastName"),
                new GenericAttribute(typeof(DateTime), "birthDate")
            };

            var genericObject = new GenericObject("testschema", "user", listAttributes);

            try
            {
                var writer = new Writer(directoryPath, objectName, genericObject);
                writer.WriteFile(new OptionsWrite(true, true, true, true, true));
                Console.WriteLine("Traitement terminé");
                Console.WriteLine("");
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            

        }
    }
}
