﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentFundamentoCSharp_YacovRosenberg
{
    class Program
    {
        //static Repository r = new Repository();

        static void Main(string[] args)
        {

            int opt;


            do
            {
                Console.WriteLine("--- Gerenciador de Aniversários ---");
                Console.WriteLine("[ 1 ] Adicionar pessoas");
                Console.WriteLine("[ 2 ] Pesquisar arquivos");
                Console.WriteLine("[ 3 ] Pesquisar pessoas");
                Console.WriteLine("[ 0 ] Sair");
                Console.WriteLine("-------------------------------------");
                Console.Write("Selecione uma opção digitando o número correspondente: ");

                opt = Int32.Parse(Console.ReadLine());

                switch (opt)
                {
                    case 1:
                        AddPerson();
                        break;
                    case 2:
                        ListFiles();
                        break;
                    case 3:
                        SearchPerson();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:

                        Environment.Exit(0);
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
            while (opt != 0);
        }

        private static void ListFiles()
        {
            TxtFile.ListFile();
            
        }

        private static void SearchPerson()
        {
            Console.WriteLine("Entre com o nome que deseja procurar: ");
            TxtFile.ReadFile(Console.ReadLine());
        }

        private static void AddPerson()
        {
            Person p = new Person();

            Console.WriteLine("Escreva seu nome: ");
            p.Name = Console.ReadLine();

            Console.WriteLine("Escreva seu Sobrenome: ");
            p.LastName = Console.ReadLine();

            Console.WriteLine("Escreva seu aniversário no formato Dia/Mês/Ano: ");
            string inputDate = Console.ReadLine();
            DateTime birthDate;
            DateTime.TryParseExact(inputDate, "dd/MM/yyyy", null, DateTimeStyles.None, out birthDate);
            p.Birthday = birthDate;

            TxtFile.WriteData(p);
            
        }
    }
}

