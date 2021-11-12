using System;
using System.IO;

/*
 * 
 Aplicativo: Editor de textos

 Função: Cria, salva e lê os arquivos criados.

*/

namespace TextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        #region Methods

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");

            short option = short.Parse(Console.ReadLine()); //Usa-se o Parse pois o metodo Readline é uma String e não pode ser jogado direto em um tipo short ou int, ou double....

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;

            }
        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual caminho do arquivo?");
            Console.WriteLine("---------------------------------------------------");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path)) //StreamReader, pois vamos ler o arquivo. Como dito antes, sempre pede o local onde foi salvo.
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo");
            Console.WriteLine("--------------------------------------------------------");

            string text = "";

            do
            {
                text += Console.ReadLine(); //O sinal de mais antes do sinal de atribui é para concatenar o texto conforme o usuário vai digitando.
                                            //Ele soma o texto já digitado com a linha que está sendo digitada.
                                            //Se colocar só o igual ele vai substituir pelas linhas novas conforme são digitadas
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(text);



        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path)) //using: Usado no .NET para abrir e fechar arquivos, mais seguro do que o método StreamWrite / StreamReader .
                                                      //StreamWrite, pois vamos escrever em um arquivo
                                                      //Strem sinifica fluxo. Então aqui temos um fluxo de escrita, fluxo de bytes. Ele sempre irá pedir o caminho do arquivo.
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }

        #endregion



    }
}
