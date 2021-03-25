using System;
using cadastro_series.Enum;
using cadastro_series.Entidades;

namespace cadastro_series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        
        static void Main(string[] args)
        {
            ExecutarOpcao(ObterOpcaoUsuario());            
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine("|| Cadastro de Séries ||");
            Console.WriteLine("- Informe a opção desejada:");
            Console.WriteLine("=============================");

            Console.WriteLine("[1] Listar");
            Console.WriteLine("[2] Inserir");
            Console.WriteLine("[3] Atualizar");
            Console.WriteLine("[4] Excluir");
            Console.WriteLine("[5] Visualizar");
            Console.WriteLine("[C] Limpar tela");
            Console.WriteLine("[X] Sair");

            Console.Write("> Opção: ");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            if (opcaoUsuario != "1" && opcaoUsuario != "2" && opcaoUsuario != "3" &&
                opcaoUsuario != "4" && opcaoUsuario != "5" && opcaoUsuario != "C" && opcaoUsuario != "X")
            {
                Console.WriteLine("Entrada de dados invalida!");
                Console.ReadKey();
                //Iniciar();
                ObterOpcaoUsuario();
            }

            //ExecutarOpcao(opcaoUsuario);
            return opcaoUsuario;
        }

        public static void ExecutarOpcao(string opcaoUsuario)
        {
            while (!opcaoUsuario.Equals("X"))
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Listar();
                        break;
                    case "2":
                        Inserir();
                        break;
                    case "3":
                        Atualizar();
                        break;
                    case "4":
                        Excluir();
                        break;
                    case "5":
                        Visualizar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            //Console.ReadKey();
        }

        private static void Listar()
        {
            Console.WriteLine("- Listar Séries");

            var series = repositorio.Lista();

            if (series.Count > 0)
            {
                int i = 0;
                foreach (var serie in series)
                {
                    Console.WriteLine($"#{ i } - { serie.GetTitulo() }");
                    i++;
                }
            }
            else
                Console.WriteLine("Nenhuma série cadastrada!");

            Console.ReadKey();
        }

        private static void Inserir()
        {
            Console.WriteLine("- Inserir Série");            

            Console.Write("Digite o título: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o descrição: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite o ano: ");
            int entradaAno = int.Parse(Console.ReadLine());

            foreach (int item in System.Enum.GetValues(typeof(Genero)))
                Console.WriteLine($"{ item } - {System.Enum.GetName(typeof(Genero), item) }");

            Console.Write("Digite número do gênero: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Serie serie = new Serie(id: repositorio.ProximoId(),
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno,
                                        genero: (Genero)entradaGenero);

            repositorio.Insere(serie);

            Console.WriteLine();
            Console.WriteLine($"> Série inserida! { Environment.NewLine }{ serie.ToString() }");
            Console.ReadKey();
        }

        private static void Atualizar()
        {
            Console.WriteLine("- Atualizar Série");

            Console.Write("Digite o id da Série: ");
            int entradaId = int.Parse(Console.ReadLine());

            Console.Write("Digite o título: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o descrição: ");
            string entradaDescricao = Console.ReadLine();

            Console.Write("Digite o ano: ");
            int entradaAno = int.Parse(Console.ReadLine());

            foreach (int item in System.Enum.GetValues(typeof(Genero)))
                Console.WriteLine($"{ item } - {System.Enum.GetName(typeof(Genero), item) }");

            Console.Write("Digite número do gênero: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Serie serie = new Serie(id: entradaId,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno,
                                        genero: (Genero)entradaGenero);

            repositorio.Atualiza(entradaId, serie);

            Console.WriteLine();
            Console.WriteLine($"> Série atualizada! { Environment.NewLine }{ serie.ToString() }");
            Console.ReadKey();
        }

        private static void Excluir()
        {
            Console.WriteLine("- Excluir Série");

            Console.Write("Digite o id da Série: ");
            int entradaId = int.Parse(Console.ReadLine());

            repositorio.Exclui(entradaId);

            Console.WriteLine();
            Console.WriteLine($"> Série excluída!");
            Console.ReadKey();
        }

        private static void Visualizar()
        {
            Console.WriteLine("- Visualizar Série");

            Console.Write("Digite o id da Série: ");
            int entradaId = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(entradaId);

            Console.WriteLine();
            Console.WriteLine($"> Visualizar { Environment.NewLine }{ serie.ToString() }");
            Console.ReadKey();
        }
    }
}

