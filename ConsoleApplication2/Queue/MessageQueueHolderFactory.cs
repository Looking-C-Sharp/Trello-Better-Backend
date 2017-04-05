using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Queue
{
    static class MessageQueueHolderFactory
    {

        public static MessageQueueHolder mqh { get; } = new MessageQueueHolder();

        public static MessageQueueHolder GetMessageQueueHolder()
        {
            return mqh;
        }

    }
}
