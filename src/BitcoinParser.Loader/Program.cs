using BitcoinBlockchain.Data;
using BitcoinBlockchain.Parser;
using System;

namespace BitcoinParser.Loader
{
    class Program
    {
        static void Main(string[] args)
        {
            IBlockchainParser blockchainParser = new BlockchainParser("./../../../../Samples/");
            foreach (Block block in blockchainParser.ParseBlockchain())
            {
                using(var bContext = new BitcoinDbContext())
                {
                    bContext.Block.Add(new BitcoinDataLayerAdoNet.Data.Block(
                        (int) block.BlockHeader.BlockVersion,
                        block.BlockHeader.BlockHash.ToArray(),
                        block.BlockHeader.PreviousBlockHash.ToArray(),
                        block.BlockHeader.BlockTimestamp
                        ));
                    bContext.SaveChanges();
                }              
            }
        }
    }
}
