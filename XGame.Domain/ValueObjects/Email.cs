﻿using prmToolkit.NotificationPattern;
using XGame.Domain.Resources;

namespace XGame.Domain.ValueObjects
{
    public class Email: Notifiable
    {

        protected Email()
        {

        }

        public Email(string endereco)
        {
            Endereco = endereco;

            new AddNotifications<Email>(this).IfNotEmail(x => x.Endereco, string.Format(Message.X0_INVALIDO, "Email"));
        }

        public string Endereco { get; private set; }

    }

}