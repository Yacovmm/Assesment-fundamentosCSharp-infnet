using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentFundamentoCSharp_YacovRosenberg
{
    internal static class TxtFile
    {
        static string diretorio = @"C:\MeuTxtFiles\";

        private static void VerifyFile(string fileName)
        {
            Directory.CreateDirectory(diretorio);
            string caminhoArquivo = Path.Combine(diretorio, fileName + ".txt");

            if (!File.Exists(caminhoArquivo))
            {
                File.Create(caminhoArquivo);
            }
        }
        public static void WriteData(Person person)
        {
            VerifyFile(person.Name); 

            StreamWriter sw = new StreamWriter(diretorio + person.Name + ".txt");
          

            sw.WriteLine("Nome: " + person.Name + "| Sobrenome: " + person.LastName + "| Data: " + person.Birthday);
            
            Console.WriteLine("Dados salvos com sucesso!");

            sw.Close();
        }

        public static void ListFile()
        {
            
            string[] arquivos = Directory.GetFiles(diretorio);

            Console.WriteLine("Arquivos:");
            foreach (string arq in arquivos)
            {
                Console.WriteLine(arq);
            }
        }

        public static void ReadFile(string name)
        {

            string text = ""; 

            VerifyFile(name); 

            StreamReader sr = new StreamReader(diretorio + name + ".txt"); 

             
                while(sr.EndOfStream == false){
                 text += sr.ReadLine();
                }

            sr.Close(); 

            Console.WriteLine(text); 
        }
    }
}
