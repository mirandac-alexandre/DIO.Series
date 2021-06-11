using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;
using System.Linq;

namespace DIO.Series
{
	public class SerieRepositorio : IRepositorio<Serie>
	{
        private List<Serie> listaSerie = new List<Serie>();
		public void Atualiza(int id, Serie objeto)
		{
			listaSerie[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaSerie[id].Excluir();
		}

		public void Insere(Serie objeto)
		{
			listaSerie.Add(objeto);
		}

		public List<Serie> Lista()
		{
			return listaSerie;
		}

		public int ProximoId()
		{
			return listaSerie.Count;
		}

		public Serie RetornaPorId(int id)
		{
			return listaSerie[id];
		}

		public void SeriePorGenero()
		{

			if (listaSerie.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			var seriesGenero = 
    			listaSerie.OrderBy(item => item.retornaGenero())
				.ThenBy(item => item.retornaTitulo()) 
				.GroupBy(item => item.retornaGenero()).ToList();
				// .OrderBy(item => item.Key.).ToList();

			foreach(var genero in seriesGenero)    
			{   
			Console.WriteLine(); 
			Console.WriteLine("Séries do gênero " + genero.Key + " (quantidade de séries: " + genero.Count() + "):");   
			foreach(var serie in genero)    
				Console.WriteLine("* " + serie.retornaTitulo());
			}    
		}
	}
}