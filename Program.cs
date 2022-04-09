using System;

namespace OtusDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }

        private void Start()
        {
            var ot = new OtusDictionary();

            int sizeArrOt = ot.Size();
            Console.WriteLine($"Количество элементов в словаре: {ot.ElemetCounter()}.\n" +
                                $"Длина массива словаря: {sizeArrOt}");

            NodeCreator(ot);
            
            sizeArrOt = ot.Size();

            Console.WriteLine($"Количество элементов в словаре: {ot.ElemetCounter()}.\n" +
                                $"Длина массива словаря: {sizeArrOt}");
            for (int i = 0; i < sizeArrOt; i++)
            {
                if (ot[i] != null)
                {
                    Console.WriteLine(ot[i].ToString());
                }
            }

            //Console.WriteLine(ot.Get(0).ToString());


        }

        private void NodeCreator(OtusDictionary ot)
        {
            var random = new Random();
            for(int i = 0; i < 200; i++)
            {
                var key = random.Next(int.MinValue, int.MaxValue);

                string tmp = "";
                for (int j=0; j < 10; j++)
                {
                    char a = (char)random.Next(33,126);
                    tmp += a;
                }
                
                ot.Add(key, tmp);
            }
        }
    }
}
