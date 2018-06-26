using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQHelper
{
    public class MessageHelper
    {


        public const int MaxSize = 1024;
        private Dictionary<Guid, List<MessageBlock>> messageBlocksDictionary;

        public MessageHelper()
        {
            messageBlocksDictionary = new Dictionary<Guid, List<MessageBlock>>();
        }

        public MessageBlock[] GetMessageBlocks(byte[] data)
        {
            var messageId = Guid.NewGuid();
            if (data.Length <= MaxSize)
            {
                return new MessageBlock[]
                {
                    new MessageBlock()
                    {
                        Blocks = 1,
                        BlockSize = data.Length,
                        Index = 0,
                        MessageId = messageId,
                        Data = data
                    }
                };
            }
            else
            {
                var blocks = data.Length / MaxSize + 1;
                var result = new MessageBlock[blocks];
                int i;
                for (i = 0; i < blocks - 1; i++)
                {
                    var blockData = new byte[MaxSize];
                    Array.Copy(data, MaxSize * i, blockData, 0, MaxSize);
                    var block = new MessageBlock()
                    {
                        Blocks = blocks,
                        BlockSize = MaxSize,
                        Data = blockData,
                        Index = i,
                        MessageId = messageId
                    };
                    result[i] = block;
                }
                var lastBlockSize = data.Length % MaxSize;
                var lastBlockData = new byte[MaxSize];
                Array.Copy(data, MaxSize * i, lastBlockData, 0, lastBlockSize);
                var lastBlock = new MessageBlock()
                {
                    Blocks = blocks,
                    BlockSize = lastBlockSize,
                    Data = lastBlockData,
                    Index = i,
                    MessageId = messageId
                };
                result[i] = lastBlock;
                return result;
            }
        }

        public bool TryGetMessageFromBlocks(MessageBlock block, out byte[] data)
        {
            if (block.Blocks == 1)
            {
                data = new byte[block.BlockSize];
                Array.Copy(block.Data, 0, data, 0, block.BlockSize);
                return true;
            }

            List<MessageBlock> list;
            if (!messageBlocksDictionary.TryGetValue(block.MessageId, out list))
            {
                list = new List<MessageBlock>();
                messageBlocksDictionary[block.MessageId] = list;
            }
            messageBlocksDictionary[block.MessageId].Add(block);

            if (messageBlocksDictionary[block.MessageId].Count != block.Blocks)
            {
                data = null;
                return false;
            }

            list = messageBlocksDictionary[block.MessageId];
            list.Sort((x, y) => x.Index.CompareTo(y.Index));
            var blockCount = list.Count;
            var size = (blockCount - 1) * MaxSize + list[blockCount - 1].BlockSize;
            data = new byte[size];
            int i;
            for (i = 0; i < blockCount - 1; i++)
            {
                Array.Copy(list[i].Data, 0, data, i * MaxSize, MaxSize);
            }
            Array.Copy(list[i].Data, 0, data, i * MaxSize, list[i].BlockSize);
            return true;
        }
    }
}
