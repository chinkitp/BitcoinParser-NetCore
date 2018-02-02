using BitcoinDataLayerAdoNet.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinParser.Loader
{
    class BitcoinDbContext : DbContext
    {
       // public DbSet<BitcoinTransaction> BitCoinTransaction { get; set; }
        public DbSet<Block> Block { get; set; }
        //public DbSet<BlockchainFile> BlockchainFile { get; set; }
        //public DbSet<TransactionInput> TransactionInput { get; set; }
        //public DbSet<TransactionInputSource> TransactionInputSource { get; set; }
        //public DbSet<TransactionOutput> TransactionOutput { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\chinkitpatel\source\repos\cp\bitcoinparser-netcore\src\BitcoinParser.Loader\App_Data\Bitcoin_Db.mdf;Integrated Security=True;Connect Timeout=30");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
