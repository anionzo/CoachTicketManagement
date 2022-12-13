using CoachTicketManagement.Data;
using CoachTicketManagement.Models;
using CoachTicketManagement.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoachTicketManagement.Core
{
    public class AccountService
    {
        #region Singleton
        private static AccountService instance;
        public static AccountService Instance
        {
            get { if (instance == null) instance = new AccountService(); return instance; }
            private set { instance = value; }
        }
        private AccountService() { }
        #endregion
        public List<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();
            using(var session = NHibernateHelper.OpenSession())
            {
                accounts = session.Query<Account>().ToList();
            }
            return accounts;
        }
        public int LoginGetIDAccount(string username, string password)
        {
            return ADOHelper.Instance.ExecuteScalar(@"declare @id int
                                                        exec @id = sp_GetIDAccount @para_0, @para_1
                                                        select @id", new object[] { username, password });
        }
    }
}
