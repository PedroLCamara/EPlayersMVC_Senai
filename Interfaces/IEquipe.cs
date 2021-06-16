using System.Collections.Generic;
using EPlayersMVC.Models;

namespace EPlayersMVC.Interfaces
{
    public interface IEquipe
    {
        string Preparar (Equipe E);
        void Alterar(Equipe E);
        void Criar(Equipe E);
        void Deletar(int ID);
        List<Equipe> LerTodas();
    }
}