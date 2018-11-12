using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using XGame.Domain.Arguments.Base;
using XGame.Domain.Arguments.Jogo;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;
using XGame.Domain.Resources;

namespace XGame.Domain.Services
{
    public class ServiceJogo : Notifiable, IServiceJogo
    {
        private readonly IRepositoryJogo _repositoryJogo;

        public ServiceJogo()
        {
            
        }

        public ServiceJogo(IRepositoryJogo repositoryJogo)
        {
            _repositoryJogo = repositoryJogo;
        }

        public AdicionarJogoResponse AdicionarJogo(AdicionarJogoRequest request)
        {
            if (request == null)
            {
                AddNotification("Adicionar", string.Format(Message.X0_E_OBRIGATORIO, "AdicionarJogoRequest"));
            }

            var jogo = new Jogo(request.Nome, request.Descricao, request.Produtora, request.Distribuidora, request.Genero, request.Site);

            AddNotifications(jogo);

            if (this.IsInvalid())
            {
                return null;
            }

            jogo = _repositoryJogo.Adicionar(jogo);

            return (AdicionarJogoResponse)jogo;
        }

        public ResponseBase AlterarJogo(AlterarJogoRequest request)
        {
            if (request == null)
            {
                AddNotification("Alterar", string.Format(Message.X0_E_OBRIGATORIO, "AlterarJogoRequest"));

                return null;
            }

            var jogo = _repositoryJogo.ObterPorId(request.Id);

            if (jogo == null)
            {
                AddNotification("ID", string.Format(Message.DADOS_NAO_ENCONTRADOS));

                return null;
            }

            jogo.AlterarJogo(request.Nome, request.Descricao, request.Produtora, request.Distribuidora, request.Genero, request.Site);

            if (jogo.IsInvalid())
            {
                return null;
            }

            _repositoryJogo.Editar(jogo);

            return (ResponseBase)jogo;
        }

        public ResponseBase ExcluirJogo(Guid id)
        {
            var jogo = _repositoryJogo.ObterPorId(id);

            if (jogo == null)
            {
                AddNotification("ID", string.Format(Message.DADOS_NAO_ENCONTRADOS));

                return null;
            }

            _repositoryJogo.Remover(jogo);

            return new ResponseBase();
        }

        public IEnumerable<JogoResponse> ListarJogo()
        {
            return _repositoryJogo.Listar().ToList().Select(Jogo => (JogoResponse)Jogo).ToList();
        }

    }

}