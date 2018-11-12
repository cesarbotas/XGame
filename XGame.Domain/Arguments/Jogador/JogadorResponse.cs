﻿using System;
using XGame.Domain.Entities;

namespace XGame.Domain.Arguments.Jogador
{
    public class JogadorResponse
    {

        public Guid Id { get; set; }

        public string NomeCompleto { get; set; }

        public string PrimeiroNome { get; set; }

        public string UltimoNome { get; set; }

        public string Email { get; set; }

        public string Status { get; set; }

        public static explicit operator JogadorResponse(Entities.Jogador entidade)
        {
            return new JogadorResponse()
            {
                Id = entidade.Id,
                NomeCompleto = entidade.Nome.PrimeiroNome + " " + entidade.Nome.UltimoNome,
                PrimeiroNome = entidade.Nome.PrimeiroNome,
                UltimoNome = entidade.Nome.UltimoNome,
                Email = entidade.Email.Endereco,
                Status = entidade.Status.ToString()
            };
        }

    }

}