using System;
using System.Threading;

namespace Clock
{
    public class TimeInfoEventArgs : EventArgs//------------------------------
    {
        /*Lớp lưu giữ thông tin về sự kiện, trong trường hợp này nó chỉ
         lưu giữ những thông tin có giá trị lớp Clock*/
        public TimeInfoEventArgs(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }
        public readonly int hour;
        public readonly int minute;
        public readonly int second;
    }
    //khai báo lớp Clock - lớp này sẽ phát ra các sự kiện----------------------
    public class Clock
    {
        //khai báo delegate mà các subscriber phải thực thi
        public delegate void SecondChangeHandler(object clock,
            TimeInfoEventArgs timeInformation);

        //sự kiện mà ta đưa ra
        public event SecondChangeHandler OnSecondChange;
        //thiết lập đồng hồ thực hiện, sẽ phát ra mỗi sự kiện trong mỗi giây
        public void Run()
        {
            while(true)
            {
                Thread.Sleep(10);
                DateTime dt = DateTime.Now;
                //Nếu giay thay đổi thì báo cho subscriber
                if(dt.Second != second)
                {
                    /*Tạo TimeInfoEventArgs để truyên cho Subscriber*/
                    TimeInfoEventArgs timeInformation = new TimeInfoEventArgs(dt.Hour, dt.Minute, dt.Second);
                    /*Nếu có bất kì lớp nào đăng kí thì cảnh báo*/
                    if(OnSecondChange != null)
                    {
                        OnSecondChange(this, timeInformation);
                    }
                }
                //cập nhật trạng thái
                this.second = dt.Second;
                this.minute = dt.Minute;
                this.hour = dt.Hour;
            }
        }
        private int hour;
        private int minute;
        private int second;
    }
    //-------------------------------------------------------------------------
    public class DisplayClock
    {
        public void Subscrible(Clock theClock)
        {
            theClock.OnSecondChange +=
                new Clock.SecondChangeHandler(TimeHasChanged);
        }
        public void TimeHasChanged(object theClock, TimeInfoEventArgs ti)
        {
            Console.SetCursorPosition(5, 5);
            Console.WriteLine("Current Time: {0}:{1}:{2}",
                ti.hour.ToString(),
                ti.minute.ToString(),
                ti.second.ToString());
        }
    }
    class Program
    {
        static void Main()
        {
            //tao ra doi truong Clock
            Clock theClock = new Clock();
            //tao doi tuong DisplayClock dang ki su kien va xu li su kien
            DisplayClock dc = new DisplayClock();
            dc.Subscrible(theClock);
            //bat dau thuc hien vong lap va phat sinh su kien trong moi giay 
            theClock.Run();
        }
    }
}

