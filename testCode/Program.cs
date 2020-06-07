using System;
using System.Threading;
using System.Text;

namespace testCode
{
    public class DrawFrame
    {
        public DrawFrame()
        {
            ngang = 80;
            doc = 24;
        }
        public void DrawFrameMethod()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.White;
            for (int i = 0; i < ngang; i++)
            {
                Console.SetCursorPosition(1 + i, 2);
                Console.Write((char)171);
            }
            for (int i = 0; i < doc + 1; i++)
            {
                Console.SetCursorPosition(1, 2 + i);
                Console.Write((char)171);
            }
            for (int i = 0; i < ngang; i++)
            {
                Console.SetCursorPosition(1 + i, 2 + doc);
                Console.Write((char)187);
            }
            for (int i = 0; i < doc + 1; i++)
            {
                Console.SetCursorPosition(1 + ngang, 2 + i);
                Console.Write((char)187);
            }
            Console.ResetColor();
        }
        public void DrawPlayer()
        {
            
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            for(int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(ngang + 4, 8 + i);
                for (int j = 0; j < 30; j++)
                {
                    Console.Write(" ");
                }
            }
            Console.SetCursorPosition(ngang + 4, 10);
            Console.Write("   Player:  {0}", PlayerName);
            Console.SetCursorPosition(ngang + 4, 5);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("press ENTER to start game");
            Console.ResetColor();
            Console.ReadLine();
            Console.SetCursorPosition(ngang + 4, 5);
            Console.Write("                         ");
        }
        public void Score()
        {
            Console.SetCursorPosition(ngang + 4, doc - 6);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("                              ");
            Console.SetCursorPosition(ngang + 4, doc - 5);
            Console.Write("                              ");
            Console.SetCursorPosition(ngang + 4, doc - 4);
            Console.Write("   SCORE:     {0}               ", score);
            Console.SetCursorPosition(ngang + 4, doc - 3);
            Console.Write("                              ");
            Console.SetCursorPosition(ngang + 4, doc - 2);
            Console.Write("                              ");
            Console.ResetColor();
        }
        public DotRan ToaDo_Food()      //tọa độ mồi
        {
            Random ran = new Random();
            //Console.SetCursorPosition(ran.Next(2, 1 + ngang - 1), ran.Next(3, 1 + doc));
            return new DotRan(ran.Next(2, ngang), ran.Next(3, 1 + doc));
        }

        public string Name
        {
            get
            {
                return PlayerName;
            }
            set { PlayerName = value; }
        }
        public int Ngang
        {
            get { return ngang; }
            set { ngang = value; }
        }
        public int Doc
        {
            get { return doc; }
            set { doc = value; }
        }
        protected int ngang;
        protected int doc;
        protected string PlayerName;
        private int score = 0;
        //----------------------------------
        public DotRan VeMoi()
        {
            toadoX = r.Next(2, ngang);
            toadoY = r.Next(3, 1 + doc);
            DotRan Moi = new DotRan(toadoX, toadoY);
            Console.SetCursorPosition(Moi.X, Moi.Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("$");
            Console.ResetColor();
            return Moi;
        }
        Random r = new Random();
        private int toadoX, toadoY;
        //--------------------------------------
    }
    public class DotRan
    {
        public DotRan(int x, int y)
        {
            x_Coor = x;
            y_Coor = y;
        }
        public DotRan (DotRan arg)
        {
            x_Coor = arg.X;
            y_Coor = arg.Y;
        }
        public int X
        {
            get { return x_Coor; }
            set { x_Coor = value; }
        }
        public int Y
        {
            get { return y_Coor; }
            set { y_Coor = value; }
        }
        private int x_Coor, y_Coor;
    }
    public class MangToaDo
    {
        public MangToaDo() //khoi tao ran
        {
            arr = new DotRan[100];
            arr[0] = new DotRan(14, 10);
            arr[1] = new DotRan(15, 10);
            arr[2] = new DotRan(16, 10);
        }
        public void Move(int direction)
        {
            Console.SetCursorPosition(arr[0].X, arr[0].Y);
            Console.Write(" ");
            for (int i = 0; i < soDot - 1; i++) // 0 1 2
            {
                arr[i].X = arr[i + 1].X;
                arr[i].Y = arr[i + 1].Y;
            }
            switch (direction)
            {
                case UP:
                    arr[soDot - 1].Y--;
                    break;
                case DOWN:
                    arr[soDot - 1].Y++;
                    break;
                case LEFT:
                    arr[soDot - 1].X--;
                    break;
                case RIGHT:
                    arr[soDot - 1].X++;
                    break;
            }
        }
        public void Draw_Snake()
        {
            for (int i = 0; i < soDot; i++)
            {
                Console.SetCursorPosition(arr[i].X, arr[i].Y);
                Console.Write(dot);
            }
        }

        public bool IsLose()
        {
            DrawFrame drw = new DrawFrame();
            if (arr[soDot - 1].X < drw.Ngang + 1 && arr[soDot - 1].Y < drw.Doc + 2 && arr[soDot - 1].X > 1 && arr[soDot - 1].Y > 2)
            {
                return false;
            }
            //for(int i = 0; i < soDot; i++)
            //{
            //    if (arr[soDot - 1].X == arr[i].X && arr[soDot - 1].Y == arr[i].Y)
            //        return true;
            //}
            return true;
        }

        public bool HasScored(DotRan obj)
        {
            if (obj.X == arr[soDot - 1].X && obj.Y == arr[soDot - 1].Y)
            {
                return true;
            }
            else
                return false;
        }
        public void IncreaseLength(DotRan moi, int direction)
        {
            switch (direction)
            {
                case UP:
                    arr[soDot] = new DotRan(arr[soDot - 1]);
                    arr[soDot].Y--;
                    break;
                case DOWN:
                    arr[soDot] = new DotRan(arr[soDot - 1]);
                    arr[soDot].Y++;
                    break;
                case LEFT:
                    arr[soDot] = new DotRan(arr[soDot - 1]);
                    arr[soDot].X--;
                    break;
                case RIGHT:
                    arr[soDot] = new DotRan(arr[soDot - 1]);
                    arr[soDot].X++;
                    break;
            }
            soDot++;
        }
        public int SoDot
        {
            get { return soDot; }
            set { soDot = value; }
        }
        const char dot = 'O';
        public static int soDot = 3;
        public DotRan[] arr;

        //direction
        public const int UP = 1;
        public const int DOWN = 2;
        public const int LEFT = 3;
        public const int RIGHT = 4;
    }

    public class Game
    {
        static void Main()
        {
            time = 500;
            DrawFrame drf = new DrawFrame();
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            #region NHAP TEN
            Console.SetCursorPosition(10, 10);
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Nhập tên của bạn:(không dấu) ");
            drf.Name = Console.ReadLine();
            string str = "";
            foreach (char ch in drf.Name)
            {
                str += char.ToUpper(ch).ToString();
            }
            drf.Name = str;
            Console.CursorVisible = false;
            #endregion
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.SetCursorPosition(8, 10);
            Console.Write("CHỌN ĐỘ KHÓ CHO GAME");
            Console.SetCursorPosition(10, 11);
            Console.Write("1. Easy (Dễ)");
            Console.SetCursorPosition(10, 12);
            Console.Write("2. Medium (Trung Bình)");
            Console.SetCursorPosition(10, 13);
            Console.Write("3. Hard (Khó)");
            Console.SetCursorPosition(10, 14);
            Console.Write("Bạn chọn: \t");

            int choice = 0;
            while (!(choice == 1 || choice == 2 || choice == 3))
                choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    time = 500;       // easy mode
                    break;
                case 2:
                    time = 250;        // medium mode
                    break;
                case 3:
                    time = 150;        // hard mode
                    break;
            }
            #region INTRO
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(1000);
            Console.WriteLine("\n\n\n\n\n\n\n\t\t _   _                     _   _       _     ");
            Console.WriteLine("\t\t| | | |                   | | | |     (_)    ");
            Console.WriteLine("\t\t| |_| |_   _ _ __   __ _  | |_| | ___  _ ___ ");
            Console.WriteLine("\t\t|  _  | | | | '_ \\ / _` | |  _  |/ _ \\| / __|");
            Console.WriteLine("\t\t| | | | |_| | | | | (_| |_| | | | (_) | \\__ \\");
            Console.WriteLine("\t\t\\_| |_/\\__,_|_| |_|\\__, (_)_| |_/\\___/|_|___/");
            Console.WriteLine("\t\t                    __/ |                    ");
            Console.WriteLine("\t\t                   |___ /     ");
            Thread.Sleep(3000);
            Console.ResetColor();
            Console.Clear();

            #endregion

            Console.Clear();
            MangToaDo ran = new MangToaDo();
            drf.DrawFrameMethod();
            drf.Score();
            drf.DrawPlayer();
            
            status = true;
            Thread thr2 = new Thread(Thread2.Console_Input);
            thr2.Start();
            DotRan check = new DotRan(0, 0);
            int first = 0;

            while (true)
            {
                ran.Move(Direction);
                ran.Draw_Snake();

                Thread.Sleep(time);
                
                if (first == 0)
                {
                    check = drf.VeMoi();
                    first++;
                }

                if (ran.HasScored(check))
                {
                    check = drf.VeMoi();
                    ran.IncreaseLength(check, Direction);
                    Console.SetCursorPosition(drf.Ngang + 5, drf.Doc - 4);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("   SCORE:     {0}  ", ran.SoDot - 3);
                    Console.ResetColor();
                }

                if (ran.IsLose())
                {
                    status = false;
                    Thread.Sleep(2000);
                    break;
                }
            }
            #region GAME_OVER
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.SetCursorPosition(50, 15);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("ĐIỂM CỦA BẠN:\t {0}      ", ran.SoDot - 3);
            Console.ResetColor();
            for(int i = 10; i >= 1; i--)
            {
                Console.SetCursorPosition(47, 17);
                Console.Write("THOÁT SAU {0} GIÂY NỮA !", i);
                Thread.Sleep(1000);
            }
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Thread.Sleep(1000);
            Console.SetCursorPosition(0, 3);
            Console.WriteLine("              ___           ___           ___           ___");
            Console.WriteLine("             /  /\\         /  /\\         /__/\\         /  /\\");
            Console.WriteLine("            /  /:/_       /  /::\\       |  |::\\       /  /:/_");
            Console.WriteLine("           /  /:/ /\\     /  /:/\\:\\      |  |:|:\\     /  /:/ /\\");
            Console.WriteLine("          /  /:/_/::\\   /  /:/~/::\\   __|__|:|\\:\\   /  /:/ /:/_");
            Console.WriteLine("         /__/:/__\\/\\:\\ /__/:/ /:/\\:\\ /__/::::| \\:\\ /__/:/ /:/ /\\");
            Console.WriteLine("         \\  \\:\\ /~~/:/ \\  \\:\\/:/__\\/ \\  \\:\\~~\\__\\/ \\  \\:\\/:/ /:/");
            Console.WriteLine("          \\  \\:\\  /:/   \\  \\::/       \\  \\:\\        \\  \\::/ /:/");
            Console.WriteLine("           \\  \\:\\/:/     \\  \\:\\        \\  \\:\\        \\  \\:\\/:/");
            Console.WriteLine("            \\  \\::/       \\  \\:\\        \\  \\:\\        \\  \\::/");
            Console.WriteLine("             \\__\\/         \\__\\/         \\__\\/         \\__\\/");
            Console.WriteLine("              ___                        ___           ___");
            Console.WriteLine("             /  /\\          ___         /  /\\         /  /\\");
            Console.WriteLine("            /  /::\\        /__/\\       /  /:/_       /  /::\\");
            Console.WriteLine("           /  /:/\\:\\       \\  \\:\\     /  /:/ /\\     /  /:/\\:\\");
            Console.WriteLine("          /  /:/  \\:\\       \\  \\:\\   /  /:/ /:/_   /  /:/~/:/");
            Console.WriteLine("         /__/:/ \\__\\:\\  ___  \\__\\:\\ /__/:/ /:/ /\\ /__/:/ /:/___");
            Console.WriteLine("         \\  \\:\\ /  /:/ /__/\\ |  |:| \\  \\:\\/:/ /:/ \\  \\:\\/:::::/");
            Console.WriteLine("          \\  \\:\\  /:/  \\  \\:\\|  |:|  \\  \\::/ /:/   \\  \\::/~~~~");
            Console.WriteLine("           \\  \\:\\/:/    \\  \\:\\__|:|   \\  \\:\\/:/     \\  \\:\\");
            Console.WriteLine("            \\  \\::/      \\__\\::::/     \\  \\::/       \\  \\:\\");
            Console.WriteLine("             \\__\\/           ~~~~       \\__\\/         \\__\\/");
            Thread.Sleep(1000);
            #endregion
            //Console.WriteLine("\t\t\tENTER!");

            //Console.Write("\n\t\t\tPLAY AGAIN ???! (Y/N)");
            //Console.ResetColor();

            ////while (true)
            //{
            //    choice = Convert.ToChar(Console.Read());
            //    if (choice == 'Y' || choice == 'y')
            //    {
            //        //break;
            //        goto Start;
            //    }
            //    else if (choice == 'N' || choice == 'n')
            //    {
            //        Console.WriteLine("\t\t\tSEE YOU NEXT TIME ^^ !");
            //        //break;
            //        goto END;
            //    }
            //}
            //}
            //END:

            //    Console.Clear();
            //    Console.ReadKey();
        }

        public static bool status;
        protected const int UP = 1;
        protected const int DOWN = 2;
        protected const int LEFT = 3;
        protected const int RIGHT = 4;  //Huong chuyen dong ban dau cua ran
        protected static int Direction = RIGHT;
        protected static int time;
    }
    public class Thread2 : Game
    {
        public static void Console_Input() //thread chay song song
        {
            while (status)
            {
                ConsoleKeyInfo ConsKey = Console.ReadKey();
                Thread.Sleep(100);

                if (ConsKey.Key == ConsoleKey.UpArrow)
                {
                    Direction = UP;
                }
                else if (ConsKey.Key == ConsoleKey.DownArrow)
                {
                    Direction = DOWN;
                }
                else if (ConsKey.Key == ConsoleKey.LeftArrow)
                {
                    Direction = LEFT;
                }
                else if (ConsKey.Key == ConsoleKey.RightArrow)
                {
                    Direction = RIGHT;
                }
                else { break; }

            }
        }
    }
}
