using System.IO;
using System;
using System.Collections.Generic;

namespace EPlayersMVC.Models
{
    public class EPlayersBase
    {
        public void CriarPastaEArquivo(string Caminho)
        {
            string Pasta = Caminho.Split("/")[0];
            string Arquivo = Caminho.Split("/")[1];
            if (!Directory.Exists(Pasta))
            {
                Directory.CreateDirectory(Pasta);
            }
            if (!File.Exists(Caminho))
            {
                File.Create(Caminho).Close();
            }
        }
        public List<string> LerTodasLinhasCSV(string Caminho)
        {
            List<string> Linhas = new List<string>();
            string Linha;
            using (StreamReader file = new StreamReader(Caminho))
            {
                while ((Linha = file.ReadLine()) != null)
                {
                    Linhas.Add(Linha);
                }
            }
            return Linhas;
        }
        public void ReescreverCSV(string Caminho, List<string> Linhas){
            using (StreamWriter output = new StreamWriter(Caminho))
            {
                foreach (var item in Linhas)
                {
                    output.Write(item + "\n");
                }
            }
        }
    }
}