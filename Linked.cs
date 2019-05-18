using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList
{
   public class LinkedList<T>
   { 
        protected class Node<Type>
        {
            private Type data;
            public Node<Type> next;
            public Node<Type> previous;

            public Type Data { get { return this.data; } }

            public Node(Type data=default(Type),Node<Type>next=null,Node<Type>prev=null)
            {
                this.data = data;

                this.next = next;

                this.previous = prev;
            }

            public override bool Equals(object obj)
            {
                return this.Data.ToString().Equals(obj.ToString());
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

        }

        private Node<T> head;
        private Node<T> tail;

        public LinkedList()
        {
            this.head = null;

            this.tail = null;
        }

        public LinkedList<T> Insert(T value)
        {
            Node<T> cur_value = new Node<T>(value);

            if (this.head == null)
            {
                this.head = cur_value;

                this.tail = cur_value;
            }
            else
            {
                cur_value.previous = this.tail;

                this.tail.next = cur_value;

                this.tail = cur_value;
            }

            return this;
        }

        public void WithDrawLast()
        {

            if (this.head.Equals(this.tail))
            {

                this.head = null;

                this.tail = null;      
            }
            else
            {
                this.tail = this.tail.previous;

                this.tail.next = null;
            }
        }

        public void WithDrawValue(T value)
        {
            Node<T> tmp = this.head;

            while (tmp != null)
            {
                if (tmp.Equals(value))
                {
                    if (tmp == head)
                    {
                        head = head.next;

                    }
                    else if (tmp == tail)
                    {
                        this.WithDrawLast();
                    }
                    else
                    {
                        tmp.previous.next = tmp.next;

                        tmp.next.previous = tmp.previous;               
                    }

                    tmp = null;

                    break;
                }

                tmp = tmp.next;
            }


        }

        public void ForEach(Action<T> func)
        {
            Node<T> iter = this.head;

            while (iter != null)
            {
                func(iter.Data);

                iter = iter.next;
            }

        }

    }
}
