using System;
using System.Collections.Generic;
using System.IO;
using EPlayersMVC.Interfaces;

namespace EPlayersMVC.Models
{
    public class Jogador : EPlayersBase, IJogador
    {
        public int IDJogador;
        public string Nome;
        public int IDEquipe;
        private const string CAMINHO = "Database/jogador.csv";

        public Jogador()
        {
            this.CriarPastaEArquivo(CAMINHO);
        }
        public string Preparar(Jogador J)
        {
            return $"{J.IDJogador};{J.Nome};{J.IDEquipe}";
        }

        public void Alterar(Jogador J)
        {
            List<string> Linhas = this.LerTodasLinhasCSV(CAMINHO);
            Linhas.RemoveAll(x => x.Split(";")[0] == J.IDJogador.ToString());
            Linhas.Add(Preparar(J));
            this.ReescreverCSV(CAMINHO, Linhas);
        }

        public void Criar(Jogador J)
        {
            List<string> Linhas = this.LerTodasLinhasCSV(CAMINHO);
            Linhas.Add(Preparar(J));
            this.ReescreverCSV(CAMINHO, Linhas);
        }

        public void Deletar(int ID)
        {
            List<string> Linhas = this.LerTodasLinhasCSV(CAMINHO);
            Linhas.RemoveAll(x => x.Split(";")[0] == ID.ToString());
            this.ReescreverCSV(CAMINHO, Linhas);
        }

        public List<Jogador> LerTodas()
        {
            List<Jogador> Jogadores = new List<Jogador>();
            string[] Linhas= File.ReadAllLines(CAMINHO);
            foreach (var item in Linhas)
            {
                Jogador j = new Jogador();
                string[] Linha = item.Split(";");
                j.IDJogador = Int32.Parse(Linha[0]);
                j.Nome = Linha[1];
                j.IDEquipe = Int32.Parse(Linha[2]);
                Jogadores.Add(j);
            }
            return Jogadores;
        }
        public List<string> LerIdsEquipesDisponiveis(){
            List<string> IDsEquipes = new List<string>();
            Equipe EquipeLeitura = new Equipe();
            string[] Linhas = File.ReadAllLines(EquipeLeitura.RetornarCaminho());
            foreach (var item in Linhas)
            {
                string[] Linha = item.Split(";");
                string ID = Linha[0];
                IDsEquipes.Add(ID);
            }
            return IDsEquipes;
        }
    }
}