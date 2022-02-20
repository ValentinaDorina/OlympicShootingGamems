using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlymicShootingGamems
{
    class Program
    {
        #region Переменные
        public static int menu;
        public static int Num = 1;
        public static string[] Name = new string[Num];
        public static int fire;
        public static string[] shot = new string[Num];
        public static double upshot;
        public static double[] valuernd = new double[3];
        public static double[] result = new double[Num];
        public static int numm = 1;
        public static string[] request = new string[numm];
        #endregion

        static void Main(string[] args)
        {
        #region Меню
        menu:
            Console.WriteLine("Меню: \n 1-регистрация \n 2-результаты \n 3-жалобы \n 4-информация о данных соревнования");
            menu = Convert.ToInt32(Console.ReadLine());
            switch (menu)
            {
                case 1:
                    goto backTo1;
                case 2:
                    goto backTo2;
                case 3:
                    goto backTo3;
                case 4:
                    goto backTo4;
            }
        #endregion

        #region   Блок регистрации с рандомом
        backTo1:
            Console.Write("Введите Фамилию Имя Отчество: ");
            Array.Resize(ref Name, Num);
            Name[Num - 1] = Console.ReadLine();
        registration:
            Console.WriteLine("Введите номер лука: 1) Классический лук 2) Блочный лук");
            fire = int.Parse(Console.ReadLine());
            if (fire == 1)
            {
                Array.Resize(ref shot, Num);
                shot[Num - 1] = "Классический лук";
            }
            else if (fire == 2)
            {
                Array.Resize(ref shot, Num);
                shot[Num - 1] = "Блочный лук";
            }
            else
            {
                Console.WriteLine("Попробуйте повторить.");
                goto registration;
            }
            // рандом - подбор 3 значений
            Random randoms = new Random();
            for (int i = 0; i < 3; i++)
            {
                int random = randoms.Next(30);
                upshot = random * 3;
                valuernd[i] = upshot;
            }
            Array.Resize(ref result, Num);
            result[Num - 1] = (valuernd[0] + valuernd[1] + valuernd[2]) / 3;
            Num++;
            goto menu;
        #endregion

        #region Блок результатов
        backTo2:
            if (Name[0] == null)
                Console.WriteLine("Пройдите регистрацию!");
            else
            {
                for (int i = 0; i < Name.Length; i++)
                {
                    Console.WriteLine($"{Name[i]} набрал(а) - {result[i]} очков.");
                }
            }
            goto menu;
        #endregion

        #region Блок записи жалоб и просьб
        backTo3:
            Console.WriteLine("Опишите Вашу жалобу");
            Array.Resize(ref request, numm);
            request[numm - 1] = Console.ReadLine();
            numm++;
            goto menu;
        #endregion

        #region Блок информации
        backTo4:
            Console.WriteLine("Расстояние стрельбы: 18, 30 или 50 метров. Мишени сделаны из бумаги с изображенными на ней концентрическими кругами разного цвета.\n"
                + "Два вида лука для стрельбы: блочного и классического. \n" +
                "Стрельба из классического лука - сила натяжения такого лука около 15-20 кг. Скорость полёта стрелы достигает 240 км/ч.\n  " +
                "Стрельба из блочного лука - в таких луках используется специальный механизм, который обеспечивает стреле более правильный разгон, а также облегчает процесс натяжения лука. Сила натяжения около 25-30 кг. Скорость полёта стрелы из такого лука достигает 320 км/ч. \n");
            goto menu;
        #endregion
        }
    }
}
