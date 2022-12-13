using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CoachTicketManagement.Utility
{
    public class Utilities
    {
        #region Singleton Pattern
        private static Utilities instance;
        public static Utilities Instance
        {
            get { if (instance == null) instance = new Utilities(); return instance; }
            private set { instance = value; }
        }
        private Utilities() { }
        #endregion

        #region Cons
        public int _DangChon = 2, _Trong = 0, _KhongBan = 1;
        public int _WidthSeat = 40, _HeightSeat = 40;
        public int _Downstairs_RowOfSeats = 8;
        public int _Upstairs_RowOfSeats = 7;
        #endregion

        public void AutoResizeListView(ListView lsv)
        {
            int nCol = lsv.Columns.Count;
            for (int i = 0; i < nCol; i++)
            {
                lsv.Columns[i].Width = (int)(lsv.Width * (100.0 / nCol) / 100.0);
            }
        }
        public DateTime MinusTime(DateTime start, DateTime finish)
        {
            TimeSpan diff = new DateTime(new TimeSpan(start.Hour, start.Minute, start.Second).Ticks) - new DateTime(new TimeSpan((finish.Hour == 0) ? 24 : finish.Hour, finish.Minute, finish.Second).Ticks);
            long i = Math.Abs(diff.Ticks);
            DateTime newDate = new DateTime(i);
            return newDate;
        }
        public bool CheckPhone(string phone)
        {
            if (new Regex(@"^(0[0-9]{9,10})$").IsMatch(phone))
                return true;
            return false;
        }
        public bool CheckIdentityCard(string identityCard)
        {
            if (new Regex(@"^[0-9]{9,12}$").IsMatch(identityCard))
                return true;
            return false;
        }
        public bool CheckUsername(string username)
        {
            if (new Regex(@"^([\d\w]{5,100})$").IsMatch(username))
                return true;
            return false;
        }
        public bool CheckInputPassword(string password)
        {
            if (new Regex(@"^([\x00-\x7F]+[^.])+$").IsMatch(password))
                return true;
            return false;
        }
        public bool CheckGmail(string email)
        {
            if (new Regex(@"^[\w\d.]+@gmail.[\w]{2,3}$").IsMatch(email))
                return true;
            return false;
        }
    }
}
