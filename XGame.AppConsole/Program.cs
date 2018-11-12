using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Services;

namespace XGame.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            var service = new ServiceJogador();
            Console.WriteLine("Criei a Instância do Service");

            //AutenticarJogadorRequest autenticarRequest = new AutenticarJogadorRequest();
            //Console.WriteLine("Criei a Instância do objeto Request");
            //autenticarRequest.Email = "paulo@outlook.com";
            //autenticarRequest.Senha = "123456789";

            //var adicionarRequest = new AdicionarJogadorRequest()
            //{
            //    Email = "paulo@outlook.com",
            //    PrimeiroNome = "Paulo Rogerio",
            //    UltimoNome = "Martins Marques",
            //    Senha = "123456"
            //};

            //var response = service.AutenticarJogador(autenticarRequest);

            //var response2 = service.AdicionarJogador(adicionarRequest);

            var result = service.ListarJogador();

            Console.WriteLine("Serviço é válido | " + service.IsValid());

            service.Notifications.ToList().ForEach(x =>
            {
                Console.WriteLine(x.Message);
            });

            Console.ReadKey();

        }

    }

}