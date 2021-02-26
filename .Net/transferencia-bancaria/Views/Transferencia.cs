using System;
using transferencia_bancaria.Controllers;
using transferencia_bancaria.Enum;

namespace transferencia_bancaria.Views
{
    public class Transferencia
    {        
        public Transferencia()
        {
            
        }
        
        string opcaoUsuario;        

        public void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine("$$ Transferência Bancária $$");
            Console.WriteLine("- Informe a opção desejada:");
            Console.WriteLine("=============================");
            
            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");

            Console.Write("-> Opção: ");
            opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
        }

        public void ExecutarOpcao()
        {
            while (!opcaoUsuario.ToUpper().Equals("X"))
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        OpcaoInserir();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                Menu();
            }
        }

        private static void ListarContas()
        {
            Console.WriteLine("- Listar Contas");
            ContaController contaController = new ContaController();
            var contas = contaController.Listar();
            
            if (contas.Count > 0)
            {
                foreach (var conta in contas)
                {
                    Console.WriteLine($"> { conta.ToString() }");
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Nenhuma conta cadastrada!");
                Console.ReadKey();
            }
        }

        private static void OpcaoInserir()
        {
            Console.WriteLine("- Nova Conta");

            Console.Write("Escolha: 1- Conta Física |  2- Conta Jurídica: ");
            // TODO:validar entrada de dados
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite seu nome: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite seu saldo: ");
            // TODO:validar entrada de dados
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite seu crédito: ");
            // TODO:validar entrada de dados
            double entradaCredito = double.Parse(Console.ReadLine());

            ContaController contaController = new ContaController();
            var conta = contaController.Adicionar((TipoConta)entradaTipoConta, entradaNome, entradaSaldo, entradaCredito);
            
            Console.WriteLine($"> Conta criada: { conta.ToString() }");
            Console.ReadKey();
        }
    }
}