using System;
using GOLTestFullStack.Api.Entity;
using Microsoft.EntityFrameworkCore;

namespace GOLTestFullStack.Api.Context
{
    public enum EnumProvider
    {
        Unknown = 9999,
        SQLServer = 1,
        InMemory = 2
    }

    public class GolContext : DbContext
    {
        public EnumProvider Provider { get; private set; }
        public string ConnectionString { get; private set; }

        public DbSet<Airplane> Airplane { get; set; }


        public GolContext() { }

        public GolContext(DbContextOptions<GolContext> options, EnumProvider provider, string connectionString) : base(GetOptions(provider, connectionString, options)) { Provider = provider; ConnectionString = connectionString; EnsureCreated(); }
        public GolContext(EnumProvider provider, string connectionString = null) : base(GetOptions(provider, connectionString)) { Provider = provider; ConnectionString = connectionString; EnsureCreated(); }
        public GolContext(DbContextOptions<GolContext> options) : base(GetOptions(EnumProvider.InMemory, "", options)) { Provider = EnumProvider.InMemory; ConnectionString = ""; EnsureCreated(); }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Airplane>(new AirplaneConfiguration());
            modelBuilder.Entity<Airplane>().ToTable("PontoDeVenda");
            base.OnModelCreating(modelBuilder);
        }


        private void EnsureCreated()
        {
            try
            {
                this.Database.EnsureCreated();
            }
            catch
            {
                // ignored
            }
        }

        private static DbContextOptions<GolContext> GetOptions(EnumProvider provider, string connectionString = null, DbContextOptions<GolContext> dbContextOptions = null)
        {
            if (string.IsNullOrEmpty(connectionString) && dbContextOptions != null)
                return dbContextOptions;
            else
            {
                if (string.IsNullOrEmpty(connectionString) && provider == EnumProvider.InMemory)
                    connectionString = "InMemoryDataBase";

                if (string.IsNullOrEmpty(connectionString))
                    throw new ArgumentNullException(nameof(connectionString), "Não existe uma conexão.");

                DbContextOptions<GolContext> _dbContextOptions;
                switch (provider)
                {
                    case EnumProvider.SQLServer:
                        _dbContextOptions = dbContextOptions != null ? new DbContextOptionsBuilder<GolContext>(dbContextOptions).UseSqlServer<GolContext>(connectionString).Options : new DbContextOptionsBuilder<GolContext>().UseSqlServer<GolContext>(connectionString).Options;
                        break;
                    case EnumProvider.InMemory:
                        _dbContextOptions = dbContextOptions != null ? new DbContextOptionsBuilder<GolContext>(dbContextOptions).UseInMemoryDatabase<GolContext>(connectionString).Options : new DbContextOptionsBuilder<GolContext>().UseInMemoryDatabase<GolContext>(connectionString).Options;
                        break;
                    default:
                        _dbContextOptions = dbContextOptions != null ? new DbContextOptionsBuilder<GolContext>(dbContextOptions).UseInMemoryDatabase<GolContext>(connectionString).Options : new DbContextOptionsBuilder<GolContext>().UseInMemoryDatabase<GolContext>(connectionString).Options;
                        break;
                }
                return _dbContextOptions;
            }
        }
    }
}