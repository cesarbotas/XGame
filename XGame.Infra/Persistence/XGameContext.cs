using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using XGame.Domain.Entities;

namespace XGame.Infra.Persistence
{
    public class XGameContext : DbContext
    {

        public XGameContext() : base("XGameConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<Jogador> Jogadores { get; set; }

        public IDbSet<Plataforma> Plataformas { get; set; }

        public IDbSet<Jogo> Jogos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Seta o Schema Default
            //modelBuilder.HasDefaultSchema("Apoio");

            //Remove a pluralização dos Nomes das Tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Remove exclusões em cascata
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Setar para usar VARCHAR invés de NVARCHAR
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            //Caso eu esqueça de informar o tamanho do campo ele irá colocar varchar de 100
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            //Mapeia as Entidades
            //modelBuilder.Configurations.Add(new JogadorMap());
            //modelBuilder.Configurations.Add(new JogoMap());
            //modelBuilder.Configurations.Add(new PlataformaMap());

            #region Adiciona as Entidades Mapeadas - Automaticamente via Assembly
            modelBuilder.Configurations.AddFromAssembly(typeof(XGameContext).Assembly);
            #endregion

            #region Adiciona Entidades Mapeadas - Automaticamente via NameSpace

            //Assembly.GetExecutingAssembly().GetTypes()
            //    .Where(type => type.Namespace == "XGame.Domain.Entities.Jogador")
            //    .ToList()
            //    .ForEach(type =>
            //    {
            //        dynamic instance = Activator.CreateInstance(type);
            //        modelBuilder.Configurations.Add(instance);
            //    });

            #endregion

            base.OnModelCreating(modelBuilder);
        }

    }

}