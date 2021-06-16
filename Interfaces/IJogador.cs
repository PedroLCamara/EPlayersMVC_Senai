using System.Collections.Generic;
using EPlayersMVC.Models;

namespace EPlayersMVC.Interfaces
{
    public interface IJogador
    {
        string Preparar (Jogador J);
        void Alterar(Jogador J);
        void Criar(Jogador J);
        void Deletar(int ID);
        List<Jogador> LerTodas();
    }
}