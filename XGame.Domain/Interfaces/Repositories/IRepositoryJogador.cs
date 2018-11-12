using System;
using System.Collections.Generic;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories.Base;

namespace XGame.Domain.Interfaces.Repositories
{
    public interface IRepositoryJogador : IRepositoryBase<Jogador, Guid>
    {

        //Jogador AutenticarJogador(AutenticarJogadorRequest request);

        //Jogador AdicionarJogador(Jogador jogador);

        //IEnumerable<Jogador> ListarJogador();

        //Jogador ObterJogadorPorId(Guid Id);

        //void AlterarJogador(Jogador jogador);

    }

}