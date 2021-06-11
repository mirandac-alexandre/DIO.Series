using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;
using System.Linq;

namespace DIO.Series
{
	public class FilmeRepositorio : IRepositorio<Filme>
	{
        private List<Filme> listaFilme = new List<Filme>();
		public void Atualiza(int id, Filme objeto)
		{
			listaFilme[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaFilme[id].Excluir();
		}

		public void Insere(Filme objeto)
		{
			listaFilme.Add(objeto);
		}

		public List<Filme> Lista()
		{
			return listaFilme;
		}

		public int ProximoId()
		{
			return listaFilme.Count;
		}

		public Filme RetornaPorId(int id)
		{
			return listaFilme[id];
		}

		public void FilmePorGenero()
		{

			if (listaFilme.Count == 0)
			{
				Console.WriteLine("Nenhum filme cadastrado.");
				return;
			}

			var filmesGenero = 
    			listaFilme.OrderBy(item => item.retornaGenero())
				.ThenBy(item => item.retornaTitulo()) 
				.GroupBy(item => item.retornaGenero()).ToList();
				// .OrderBy(item => item.Key.).ToList();

			foreach(var genero in filmesGenero)    
			{   
			Console.WriteLine(); 
			Console.WriteLine("Filmes do gênero " + genero.Key + " (quantidade de filmes: " + genero.Count() + "):");   
			foreach(var filme in genero)    
				Console.WriteLine("* " + filme.retornaTitulo());
			}    
		}
	}
}