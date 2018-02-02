using BitcoinBlockchain.Data;
using BitcoinBlockchain.Parser;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace BitcoinParser.Loader
{
    class Program
    {
        static void Main(string[] args)
        {
            IBlockchainParser blockchainParser = new BlockchainParser("./../../../../Samples/");
            var blocks = blockchainParser.ParseBlockchain();
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < blocks.Count() % 1000 ; i++)
            {
                var subSet = blocks.Skip(i * 1000).Take(1000);
                var blocksToAdd = new List<BitcoinDataLayerAdoNet.Data.Block>();

                foreach (var item in subSet)
                {
                    blocksToAdd.Add(new BitcoinDataLayerAdoNet.Data.Block(
                        (int)item.BlockHeader.BlockVersion,
                        item.BlockHeader.BlockHash.ToArray(),
                        item.BlockHeader.PreviousBlockHash.ToArray(),
                        item.BlockHeader.BlockTimestamp));
                }

                using (var bContext = new BitcoinDbContext())
                {
                    bContext.Block.AddRange(blocksToAdd);
                    bContext.SaveChanges();
                }
            }


            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

        }
    }
}
