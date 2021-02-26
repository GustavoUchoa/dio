using System;
using transferencia_bancaria.Views;
using transferencia_bancaria.Controllers;
using transferencia_bancaria.Enum;

namespace transferencia_bancaria
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string opcaoUsuario = Menu();
            ExecutarOpcao(opcaoUsuario);*/

            Conta novaConta = new Conta();
            novaConta.Menu();
            novaConta.ExecutarOpcao();
        }
        /*
        private static string Menu()
        {
            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine("$$ Transferência Bancária $$");
            Console.WriteLine("- Informe a opção desejada:");
            Console.WriteLine("=============================");
            
            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");

            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }

        private static void ExecutarOpcao(string opcaoUsuario)
        {
            while (!opcaoUsuario.ToUpper().Equals("X"))
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        //ListarContas
                        break;
                    case "2":
                        OpcaoInserir();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private static void OpcaoInserir()
        {
            Console.Write("Escolha: 1- Conta Física |  2- Conta Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite seu nome: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite seu saldo: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite seu crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            ContaController novaConta = new ContaController();
            novaConta.InserirConta((TipoConta)entradaTipoConta, entradaNome, entradaSaldo, entradaCredito);
            Console.WriteLine($"Conta criada: { novaConta.ToString() }");
        }
        */
    }
}
