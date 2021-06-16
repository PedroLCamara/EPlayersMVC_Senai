using System;
using System.Collections.Generic;
using System.IO;
using EPlayersMVC.Interfaces;

namespace EPlayersMVC.Models
{
    public class Equipe : EPlayersBase, IEquipe
    {
        public int IDEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        private const string CAMINHO = "Database/equipe.csv";

        public Equipe(){
            this.CriarPastaEArquivo(CAMINHO);
        }
        public string Preparar(Equipe E)
        {
            return $"{E.IDEquipe};{E.Nome};{E.Imagem}";
        }

        public void Alterar(Equipe E)
        {
            List <string> Linhas = this.LerTodasLinhasCSV(CAMINHO);
            Linhas.RemoveAll(x => x.Split(";")[0] == E.IDEquipe.ToString()); 
            Linhas.Add(Preparar(E));
            this.ReescreverCSV(CAMINHO, Linhas);
        }

        public void Criar(Equipe E)
        {
            string[] Linha = {Preparar(E)};
            File.AppendAllLines(CAMINHO, Linha);
        }

        public void Deletar(int ID)
        {
            List <string> Linhas = this.LerTodasLinhasCSV(CAMINHO);
            Linhas.RemoveAll(x => x.Split(";")[0] == ID.ToString()); 
            this.ReescreverCSV(CAMINHO, Linhas);
        }

        public List<Equipe> LerTodas()
        {
            List<Equipe> Equipes = new List<Equipe>();
            string[] Linhas = File.ReadAllLines(CAMINHO);
            foreach (var item in Linhas)
            {
                Equipe e = new Equipe();
                string[] linha = item.Split(";");
                e.IDEquipe = Int32.Parse(linha[0]);
                e.Nome = linha[1];
                e.Imagem = linha[2];
                Equipes.Add(e);
            }
            return Equipes;
        }
    }
}