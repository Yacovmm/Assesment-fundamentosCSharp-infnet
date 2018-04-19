using System;
using System.Collections.Generic;
using System.Globalization;
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

            Console.WriteLine("1- Edit");
            Console.WriteLine("0 - Exit");

            int opt = Convert.ToChar(Console.ReadLine());

            switch (opt) 
            {
                case '1':
                    Edit(name);
                    break;
                default:
                    break;
            }
        }

        private static void Edit(string nome)
        {
            var p = new Person();

            Console.WriteLine("Escreva seu nome: ");
            p.Name = Console.ReadLine();

            Console.WriteLine("Escreva seu Sobrenome: ");
            p.LastName = Console.ReadLine();

            Console.WriteLine("Escreva seu aniversário no formato Dia/Mês/Ano: ");
            string inputDate = Console.ReadLine();
            DateTime birthDate;
            DateTime.TryParseExact(inputDate, "dd/MM/yyyy", null, DateTimeStyles.None, out birthDate);
            p.Birthday = birthDate;


            StreamWriter sw = new StreamWriter(diretorio + nome + ".txt");


            sw.WriteLine("Nome: " + p.Name + "| Sobrenome: " + p.LastName + "| Data: " + p.Birthday);

            Console.WriteLine("Dados atualizados com sucesso!");

            sw.Close();
        }
    }
}
