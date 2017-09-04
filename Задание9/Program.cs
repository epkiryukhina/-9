using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание9
{
    public class Point
    {
        public double info;//информационное поле

        public Point next;//адресное поле 1

        public Point last;//адресное поле 2

        public Point()
        {
            info = 0;
            next = null;
            last = null;
        }

        public Point(double i)
        {
            info = i;
            next = null;
            last = null;
        }

        public override string ToString()
        {
            return info + " ";
        }
    }

    class Program
    {
        public static double Imput()//Ввод вещественных чисел
        {
            bool rightValue;
            double value;

            do
            {
                string userImput = Console.ReadLine();
                rightValue = double.TryParse(userImput, out value);
                if (!rightValue) Console.Write(@"Ожидалось число. Повторите ввод - ");
            }
            while (!rightValue);

            return value;
        }

        public static void Rec(Point head, ref double sum)//Рекурсивная функция
        {
            if (head != null)
            {
                sum += head.info;
                Rec(head.next, ref sum);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите эл-ты двунаправленного списка. Признак конца ввода - 0: ");
            double a = Imput();
            Point head = new Point();

            if (a != 0)//Ввод первого эл-та
            {
                head.info = a;

                Point p = new Point();//Ввод остального списка
                Point q = head;
                a = Imput();

                while (a != 0)
                {
                    p = new Point(a);
                    q.next = p;
                    p.last = q;
                    q = p;
                    a = Imput();
                }

                Console.WriteLine("Ваш список: ");//Печать списка
                p = head;

                while (p != null)
                {
                    Console.Write("{0} ", p);
                    p = p.next;
                }
                Console.WriteLine();

                double sum = 0;//Нерекурсивный подсчет суммы
                p = head;

                while (p != null)
                {
                    sum += p.info;
                    p = p.next;
                }
                Console.WriteLine(sum);

                sum = 0;

                Rec(head, ref sum);//Рекурсивный подсчет суммы
                Console.WriteLine(sum);
            }
            else Console.WriteLine("Список пуст");

            Console.ReadLine();
        }
    }
}

