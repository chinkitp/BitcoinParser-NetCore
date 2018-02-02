//-----------------------------------------------------------------------
// <copyright file="Block.cs">
// Copyright © Ladislau Molnar. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace BitcoinDataLayerAdoNet.Data
{
    using System;
    using BitcoinBlockchain.Data;

    /// <summary>
    /// Contains information about a Bitcoin block as saved in the Bitcoin SQL database.
    /// For more information see: https://en.bitcoin.it/wiki/Block
    /// </summary>
    public class Block
    {
        public Block(int blockVersion, byte[] blockHash, byte[] previousBlockHash, DateTime blockTimestamp)
        {
            //this.BlockId = blockId;
            this.BlockchainFileId = 0;
            this.BlockVersion = blockVersion;
            this.BlockHash = blockHash;
            this.PreviousBlockHash = previousBlockHash;
            this.BlockTimestamp = blockTimestamp;
        }

        public long BlockId { get; private set; }

        public int BlockchainFileId { get; private set; }

        public int BlockVersion { get; private set; }

        public DateTime BlockTimestamp { get; private set; }

        public byte[] BlockHash { get; private set; }

        public byte[] PreviousBlockHash { get; private set; }
    }
}
