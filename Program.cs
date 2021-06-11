using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
		static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterMenu();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						while (opcaoUsuario.ToUpper() != "X")
						{
							opcaoUsuario = ObterOpcaoUsuario();
							switch (opcaoUsuario)
							{
							case "1":
								ListarSeries();
								break;
							case "2":
								InserirSerie();
								break;
							case "3":
								AtualizarSerie();
								break;
							case "4":
								ExcluirSerie();
								break;
							case "5":
								VisualizarSerie();
								break;
							case "6":
								SeriePorGenero();
								break;
							case "C":
								Console.Clear();
								break;
							case "X":
								break;
							default: throw new ArgumentOutOfRangeException();
								
							}
							// opcaoUsuario = ObterOpcaoUsuario();
						}
					break;
				
					case "2":
						while (opcaoUsuario.ToUpper() != "X")
						{
							opcaoUsuario = ObterOpcaoUsuarioFilme();
							switch (opcaoUsuario)
							{
							case "1":
								ListarFilmes();
								break;
							case "2":
								InserirFilme();
								break;
							case "3":
								AtualizarFilme();
								break;
							case "4":
								ExcluirFilme();
								break;
							case "5":
								VisualizarFilme();
								break;
							case "6":
								FilmePorGenero();
								break;
							case "C":
								Console.Clear();
								break;
							case "X":
								break;
							default: throw new ArgumentOutOfRangeException();
								
							}
							// opcaoUsuario = ObterOpcaoUsuario();
						}
					break;
					default: throw new ArgumentOutOfRangeException();
				}
				opcaoUsuario = ObterMenu();
			}
			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }
		#region Series
        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Console.Write("Digite a Classificação Indicativa da Série: ");
			int idadeMinima = int.Parse(Console.ReadLine());

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao,
										idadeMinima: idadeMinima);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Console.Write("Digite a Classificação Indicativa da Série: ");
			int idadeMinima = int.Parse(Console.ReadLine());

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao,
										idadeMinima: idadeMinima);

			repositorio.Insere(novaSerie);
		}

		private static void SeriePorGenero()
		{
			repositorio.SeriePorGenero();
		}
		#endregion
		#region Filmes
		private static void ExcluirFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			repositorioFilme.Exclui(indiceFilme);
		}

        private static void VisualizarFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			var Filme = repositorioFilme.RetornaPorId(indiceFilme);

			Console.WriteLine(Filme);
		}

        private static void AtualizarFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do filme: ");
			string entradaDescricao = Console.ReadLine();

			Console.Write("Digite a Classificação Indicativa do filme: ");
			int idadeMinima = int.Parse(Console.ReadLine());

			Filme atualizaFilme = new Filme(id: indiceFilme,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao,
										idadeMinima: idadeMinima);

			repositorioFilme.Atualiza(indiceFilme, atualizaFilme);
		}
        private static void ListarFilmes()
		{
			Console.WriteLine("Listar filmes");

			var lista = repositorioFilme.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum filme cadastrado.");
				return;
			}

			foreach (var Filme in lista)
			{
                var excluido = Filme.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", Filme.retornaId(), Filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirFilme()
		{
			Console.WriteLine("Inserir novo filme");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do filme: ");
			string entradaDescricao = Console.ReadLine();

			Console.Write("Digite a Classificação Indicativa do filme: ");
			int idadeMinima = int.Parse(Console.ReadLine());

			Filme novoFilme = new Filme(id: repositorioFilme.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao,
										idadeMinima: idadeMinima);

			repositorioFilme.Insere(novoFilme);
		}

		private static void FilmePorGenero()
		{
			repositorioFilme.FilmePorGenero();
		}
		#endregion
        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Seção séries. :D");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("6- Série por Gênero");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		private static string ObterOpcaoUsuarioFilme()
		{
			Console.WriteLine();
			Console.WriteLine("Seção filmes. :D");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar filmes");
			Console.WriteLine("2- Inserir novo filme");
			Console.WriteLine("3- Atualizar filme");
			Console.WriteLine("4- Excluir filme");
			Console.WriteLine("5- Visualizar filme");
			Console.WriteLine("6- Filme por Gênero");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		private static string ObterMenu()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Séries");
			Console.WriteLine("2- Filmes");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
