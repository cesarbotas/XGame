using System;
using XGame.Domain.Entities;

namespace XGame.Domain.Arguments.Jogo
{
    public class JogoResponse
    {

        public Guid Id { get; set; }

        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public string Produtora { get; private set; }

        public string Distribuidora { get; private set; }

        public string Genero { get; private set; }

        public string Site { get; private set; }

        public static explicit operator JogoResponse(Entities.Jogo entidade)
        {
            return new JogoResponse()
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                Descricao = entidade.Descricao,
                Produtora = entidade.Produtora,
                Distribuidora = entidade.Distribuidora,
                Genero = entidade.Genero,
                Site = entidade.Site
            };
        }

    }

}