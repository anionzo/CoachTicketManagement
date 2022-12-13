using CoachTicketManagement.Data;
using CoachTicketManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachTicketManagement.Core
{
    public class ClientService
    {
        #region Singleton
        private static ClientService instance;
        public static ClientService Instance
        {
            get { if (instance == null) instance = new ClientService(); return instance; }
            private set { instance = value; }
        }
        private ClientService() { }
        #endregion

        public List<Client> GetClients()
        {
            using(var session = NHibernateHelper.OpenSession())
            {
                return session.Query<Client>().ToList();
            }    
        }
    }
}
