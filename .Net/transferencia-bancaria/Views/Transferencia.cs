using System;
using transferencia_bancaria.Enum;
using transferencia_bancaria.Controllers;

namespace transferencia_bancaria.Views
{
    public class Transferencia
    {
        string opcaoUsuario;

        public Transferencia()
        {

        }        

        public void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine("$$ Transferência Bancária $$");
            Console.WriteLine("- Informe a opção desejada:");
            Console.WriteLine("=============================");

            Console.WriteLine("[1] Listar contas");
            Console.WriteLine("[2] Nova conta");            
            Console.WriteLine("[3] Sacar");
            Console.WriteLine("[4] Depositar");
            Console.WriteLine("[5] Transferir");
            Console.WriteLine("[C] Limpar tela");
            Console.WriteLine("[X] Sair");

            Console.Write("> Opção: ");
            opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            if (opcaoUsuario != "1" && opcaoUsuario != "2" && opcaoUsuario != "3" &&
                opcaoUsuario != "4" && opcaoUsuario != "5" && opcaoUsuario != "C" && opcaoUsuario != "X")
            {
                Console.WriteLine("Entrada de dados invalida!");
                Console.ReadKey();
                Menu();
            }
        }

        public void ExecutarOpcao()
        {
            while (!opcaoUsuario.Equals("X"))
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        NovaConta();
                        break;
                    case "3":
                        Sacar();
                        break;
                    case "4":
                        Depositar();
                        break;
                    case "5":
                        Transferir();
                        break;                    
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Menu();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadKey();
        }

        private static void ListarContas()
        {
            Console.WriteLine("- Listar Contas");
            
            ContaController contaController = new ContaController();
            var contas = contaController.Listar();

            if (contas.Count > 0)
            {
                int i = 0;
                foreach (var conta in contas)
                {
                    Console.WriteLine($"#{ i } - { conta.ToString() }");
                    i++;
                }
            }
            else
                Console.WriteLine("Nenhuma conta cadastrada!");

            Console.ReadKey();
        }

        private static void NovaConta()        
        {
            Console.WriteLine("- Nova Conta");

            int entradaTipoConta = validarEntradaInt();

            Console.Write("Digite seu nome: ");
            string entradaNome = Console.ReadLine();

            double entradaSaldo = validarEntradaDouble("saldo");

            double entradaCredito = validarEntradaDouble("credito");

            ContaController contaController = new ContaController();
            var conta = contaController.Adicionar((TipoConta)entradaTipoConta, entradaNome, entradaSaldo, entradaCredito);

            Console.WriteLine($"> Conta criada: { conta.ToString() }");
            Console.ReadKey();
        }

        private static void Sacar()
        {
            Console.WriteLine("- Sacar");            
            
            int indiceConta = validarEntradaNumeroConta();            
            double entradaSaque = validarEntradaDouble("sacar");

            ContaController contaController = new ContaController();            
            var conta = contaController.Sacar(indiceConta, entradaSaque);

            if (conta != null)
                Console.WriteLine($"Saldo atual da conta de { conta.Nome } é { conta.Saldo }");
            else
                Console.WriteLine("Saldo insuficiente!");

            Console.ReadKey();
        }

        private static void Depositar()
        {
            Console.WriteLine("- Depositar");
        }
        
        private static void Transferir()
        {
            Console.WriteLine("- Transferência");
        }
    
        private static double validarEntradaDouble(string dado)
        {
            bool valido = false;
            double saida;
            do
            {
                Console.Write($"Digite seu { dado }: ");
                valido = double.TryParse(Console.ReadLine(), out saida);

                if (!valido)
                    Console.WriteLine("Entrada de dados inválida!");
            } while (!valido);

            return saida;
        }
    
        private static int validarEntradaInt()
        {
            bool valido = false;
            int saida;
            do
            {          
                Console.Write("Escolha: 1- Conta Física |  2- Conta Jurídica: ");      
                valido = Int32.TryParse(Console.ReadLine(), out saida);

                if (!valido)
                    Console.WriteLine("Entrada de dados inválida! *insira um inteiro");
                else if (saida != 1 && saida != 2)
                {                    
                    valido = false;
                    Console.WriteLine("Entrada de dados inválida!");
                }
            } while (!valido);

            return saida;
        }

        private static int validarEntradaNumeroConta()
        {
            bool valido = false;
            int saida;
            
            ContaController contaController = new ContaController();
            var contas = contaController.Listar();
            do
            {     
                Console.Write("Digite o número da conta: ");
                valido = Int32.TryParse(Console.ReadLine(), out saida);

                if (!valido)
                    Console.WriteLine("Entrada de dados inválida! *insira um inteiro");
                else if (saida > contas.Count -1)
                {                    
                    valido = false;
                    Console.WriteLine("Conta inexistente!");
                }
            } while (!valido);

            return saida;
        }
    }
}