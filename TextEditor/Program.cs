using System;
using System.Globalization;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();

            System.Console.WriteLine("O que deseja fazer?");
            System.Console.WriteLine("0- Sair");
            System.Console.WriteLine("1- Abrir arquivo");
            System.Console.WriteLine("2- Criar arquivo");

            int resp = int.Parse(Console.ReadLine());

            switch (resp)
            {
                case 0:
                    System.Console.WriteLine("obrigado, volte sempre!");
                    System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }

        }

        static void Abrir()
        {
            Console.Clear();

            System.Console.WriteLine("Qual o caminho do arquivo?");
            string path = Console.ReadLine();

            using (StreamReader file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                System.Console.WriteLine(text);
            }

            System.Console.WriteLine("Aperte ENTER para voltar ao menu");
            Console.ReadLine();
            Menu();
        }

        static void Editar()
        {
            Console.Clear();

            System.Console.WriteLine("Digite seu texto abaixo (para sair aperte ENTER e depois ESC)");
            System.Console.WriteLine("--------------------------------");

            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(text);

        }

        static void Salvar(string text)
        {
            Console.Clear();

            System.Console.WriteLine("Qual o caminho para salvar o arquivo?");
            string path = Console.ReadLine();

            using (StreamWriter file = new StreamWriter(path))
            {
                file.Write(text);
            }

            System.Console.WriteLine($"Arquivo ({path}) salvo com sucesso!");
            System.Console.WriteLine("Aperte ENTER para voltar ao menu");
            Console.ReadKey();
            Menu();
        }

    }
}
