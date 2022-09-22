// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;

namespace HelloWorld
{
    class Hello
    {
        static void Main1(string[] args)
        {
            int[] myTicket = BuyTicket();
            int level;
            int count = 0;

                do
                {
                    count++;
                    int[] creatRandomTicket = CreatRandomTicket();
                    level = TicketEquals(myTicket, creatRandomTicket);
                if (level != 0)
                {
                    Console.WriteLine("恭喜中{0}等奖,累计消费{1:c}", level,count * 2);
                } 
                } while (level != 3);
        }

        private static int[] BuyTicket()
        {
            int[] ticket = new int[7];

            //前六个红球
            for (int i = 0; i < 6;)
            {
                Console.WriteLine("请输入第{0}个红球号码：",i+1);
                int redNumber = int.Parse(Console.ReadLine());
                if (redNumber < 1 || redNumber > 33)
                    Console.WriteLine("购买的号码超过范围:");
                else if (Array.IndexOf(ticket, redNumber) >= 0)
                    Console.WriteLine("号码已经存在");
                else
                    ticket[i++] = redNumber;
            }
            //第七个篮球
            int blueNumber;
            while (true)
            {
                Console.WriteLine("请输入蓝球号码：");
                blueNumber = int.Parse(Console.ReadLine());
                if (blueNumber >= 1 && blueNumber <= 16)
                {
                    ticket[6] = blueNumber;
                    break;
                }
                else
                    Console.WriteLine("号码超过范围");
            }
            return ticket;

        }


        static Random random = new Random();
        private static int[] CreatRandomTicket()
        {
            int[] ticket = new int[7];
            //前六个号码球
            for (int i = 0; i < 6;)
            {
                int redNumber = random.Next(1, 34);
                if (Array.IndexOf(ticket, redNumber) < 0)
                {
                    ticket[i] = redNumber;
                    i++;
                }
            }
            //第七个号码球
            ticket[6] = random.Next(1, 17);
            //号码球排序
            Array.Sort(ticket, 1, 6);
            return ticket;
        }

        //比较相同的号码
        private static int TicketEquals(int[] myTicket, int[] randomTicket)
        {
            int buleCount = (myTicket[6] == randomTicket[6]) ? 1 : 0;
            int redCount = 0;
            for (int i = 0; i < 6; i++)
            {
                if ((Array.IndexOf(randomTicket, myTicket[i], 1, 6)) >= 0)
                {
                    redCount += 1;
                }
            }

            int level;
            if (redCount + buleCount == 7)
                level = 1;
            else if (redCount == 6)
                level = 2;
            else if (redCount + buleCount == 6)
                level = 3;
            else if (redCount + buleCount == 5)
                level = 4;
            else if (redCount + buleCount == 5)
                level = 4;
            else if (redCount + buleCount == 4)
                level = 5;
            else if (buleCount == 1)
                level = 6;
            else
                level = 0;
            return level;
        }

        static void Main2(string[] args)
        {
            for (int i = 0; i < 4;i++)
            {
                for (int c = 0; c < i; c++)
                {
                        Console.Write(" ");
                }
                for (int a = 4; a > i; a--)
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("请输入四个数：");
            int[] array = new int[4];
            for(int i = 0;i < 4;i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            for(int j = 0;j < 3;j++)
            {
                for(int a = 0;a < 3-j;a++)
                {
                    if (array[a] > array[a+1])
                    {
                        int temp = 0;
                        temp = array[a];
                        array[a] = array[a + 1];
                        array[a + 1 ] = temp;
                    }
                }
            }

            Console.WriteLine("这四个数从小到大排列为：");

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
