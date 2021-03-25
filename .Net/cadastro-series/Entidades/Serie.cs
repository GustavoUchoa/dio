using System;
using cadastro_series.Enum;

namespace cadastro_series.Entidades
{
    public class Serie : EntidadeBase
    {        
        private string Titulo { get; set; }

        private string Descricao { get; set; }

        private int Ano { get; set; }
        
        private Genero Genero { get; set; }

        private bool Excluido { get; set; }

        public int GetId()
        {
            return this.Id;
        }

        public string GetTitulo()
        {
            return this.Titulo;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

        public Serie(int id, string titulo, string descricao, int ano, Genero genero)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Genero = genero;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = string.Empty;

            retorno += $"Título: { this.Titulo }" + Environment.NewLine;
            retorno += $"Descrição: { this.Descricao }" + Environment.NewLine;
            retorno += $"Ano: { this.Ano }" + Environment.NewLine;
            retorno += $"Gênero: { this.Genero }" + Environment.NewLine;
            retorno += $"Excluído: { this.Excluido }";

            return retorno;
        }        
    }
}