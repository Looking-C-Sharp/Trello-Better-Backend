using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Queue
{
    class MessageQueueHolder
    {
        List<string> available = new List<string>();

        public string main { get; }

        ConcurrentDictionary<string, MessageQueue> projects = new ConcurrentDictionary<string, MessageQueue>();

        Int32 count;


        public MessageQueueHolder()
        {
            for (count = 0; count < 1; count++)
            {
                if (!MessageQueue.Exists(@".\private$\mq" + count))
                {
                    MessageQueue.Create(@".\private$\mq" + count);
                }
                available.Add(@".\private$\mq" + count);
            }

            //Main Message Queue
            if (!MessageQueue.Exists(@".\private$\main"))
            {
                MessageQueue.Create(@".\private$\main");
            }
            //save the string in case it needs to be referenced
             main = @".\private$\main";
        }

        public MessageQueue NewQueue(string id)
        {
            try { 
                if (projects.ContainsKey(id)){
                    MessageQueue mq;
                    projects.TryGetValue(id, out mq);
                    return mq;
                }
                //this lock may not be necessary as only the main thread should call it
                lock (available)
                {
                    if (available.Count == 0)
                    {
                        if (!MessageQueue.Exists(@".\private$\mq" + count))
                        {
                            MessageQueue.Create(@".\private$\mq" + count);
                        }

                        count += 1;
                        MessageQueue mq = new MessageQueue(@".\private$\mq" + count);
                        MessageQueue userMQ = new MessageQueue(@".\private$\mq" + count);
                        projects.TryAdd(id, mq);
                        return userMQ;

                    }
                    else
                    {
                        string mqName = available.ElementAt(0);
                        MessageQueue mq = new MessageQueue(mqName);
                        MessageQueue threadMQ = new MessageQueue(mqName);
                        projects.TryAdd(id, mq);
                        available.RemoveAt(0);
                        return threadMQ;
                    }
                }
             }
            catch(Exception e)
            {
                Debug.WriteLine(e.Data);
                return null;
            }
        }

        public MessageQueue GetUserQueue(string id)
        {
            MessageQueue mq;
            projects.TryGetValue(id, out mq);
            return mq;
        }

        public void ReturnQueue(string id)
        {
            lock (available)
            {
                MessageQueue mq;
                projects.TryRemove(id, out mq);
                available.Add(mq.Path);
            }
        }

    }
}
