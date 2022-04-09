﻿using System;

namespace OtusDictionary
{

    class OtusDictionary
    {
        Node[] data;
        Node[] dataTmp;
        public OtusDictionary()
        {
            data = new Node[32];
        }
        // индексатор
        public Node this[int index]
        {
            get => data[index];
            set => data[index] = value;
        }
        public void Add(int key, string value)
        {
            var node = new Node(key, value);
            var index = Math.Abs(node.GetHashCode() % data.Length);

            while (data[index] != null)
            {
                ResizeArr();
            }
            data[index] = node;
        }

        public Node Get(int key)
        {
            var (flag, index) = Contains(key);

            if (!flag)
            {
                throw new Exception("Ключ не найден");
            }

            return data[index];
        }

        public int Size()
        {
            return data.Length;
        }

        public int ElemetCounter()
        {
            int counter = 0;
            foreach (var item in data)
            {
                if (item != null)
                {
                    counter++;
                }
            }
            return counter;
        }

        private void ResizeArr()
        {
            dataTmp = new Node[data.Length * 2];
            foreach (var item in data)
            {
                if (item != null)
                {
                    var index = Math.Abs(item.GetHashCode() % dataTmp.Length);
                    if (dataTmp[index] != null)
                    {
                        ResizeArr();
                    }
                    dataTmp[index] = item;
                }
            }
            data = dataTmp;
            dataTmp = null;
        }

        private (bool flag, int index) Contains(int key)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != null)
                {
                    if (data[i].Key.Equals(key))
                    {
                        return (true, i);
                    }
                }
            }
            return (false, -1);
        }
    }
    class Node
    {
        public int Key { get; set; }
        public string Value { get; set; }
        public Node(int key, string value)
        {
            Key = key;
            Value = value;
        }
        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public override bool Equals(object node)
        {
            return Key == ((Node)node).Key;
        }

        public override string ToString()
        {
            return $"Ключ: {Key}.      Значение: {Value}";
        }
    }
}
