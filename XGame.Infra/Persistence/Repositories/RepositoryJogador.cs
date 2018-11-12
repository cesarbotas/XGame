using System;
using System.Linq;
using System.Collections.Generic;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Infra.Persistence.Repositories.Base;

namespace XGame.Infra.Persistence.Repositories
{
    public class RepositoryJogador : RepositoryBase<Jogador, Guid>, IRepositoryJogador
    {

        protected readonly XGameContext _context;

        public RepositoryJogador(XGameContext context) : base(context)
        {
            _context = context;
        }

        //public Jogador AdicionarJogador(Jogador jogador)
        //{
        //    _context.Jogadores.Add(jogador);
        //    _context.SaveChanges();

        //    return jogador;
        //}

        //public void AlterarJogador(Jogador jogador)
        //{
        //    throw new NotImplementedException();
        //}

        //public Jogador AutenticarJogador(AutenticarJogadorRequest request)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<Jogador> ListarJogador()
        //{
        //    return _context.Jogadores.ToList();
        //}

        //public Jogador ObterJogadorPorId(Guid Id)
        //{
        //    throw new NotImplementedException();
        //}

    }

}