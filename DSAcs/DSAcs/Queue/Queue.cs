﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSAcs.Nodes;

namespace DSAcs.Queue
{
    // queue is open at both ends (2 pointers), with direction front to back
    public class Queue<T> : IQueue<T>
    {
        public Node Front { get; set; }
        public Node Back { get; set; }
        public Queue()
        {
            Front = null;
            Back = null;
        }
        public Queue(T data)
        {
            Node node = new NodeS(data);
            Front = node;
            Back = node;
        }
        public NodeS Dequeue()
        {
            if (Front == null) throw new ArgumentNullException("Cannot dequeue from an empty queue.");

            NodeS temp = (NodeS)Front;
            Front = Front.Next;
            if (Front == null) Back = null;
            return temp;
        }

        public void Enqueue(T data)
        {
            Node node = new NodeS(data);
            if (IsEmpty())
            {
                Front = node;
                Back = node;
            }
            else
            {
                Back.Next = node;
                Back = Back.Next;
            }

        }

        public object Peek()
        {
            if (Front != null)
            {
                return Front.Data;
            }
            throw new ArgumentNullException("Queue is empty.");
        }

        public bool IsEmpty()
        {
            return Front == null;
        }
    }
}