using CoachTicketManagement.Models;
using CoachTicketManagement.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachTicketManagement.Core
{
    public class DataService
    {
        #region Singleton
        private static DataService instance;
        public static DataService Instance
        {
            get { if (instance == null) instance = new DataService(); return instance; }
            private set { instance = value; }
        }
        private DataService() { }
        #endregion

        static List<City> cities = ADOHelper.Instance.ExecuteReader<City>("select * from tbl_City");
        static List<District> districts = ADOHelper.Instance.ExecuteReader<District>("select * from tbl_District");
        static List<Ward> wards = ADOHelper.Instance.ExecuteReader<Ward>("select * from tbl_Ward");

        public DataTable GetDistricts(int idCity)
        {
            return ADOHelper.Instance.ExecuteReader("select * from tbl_District where IDCity = @para_0", new object[] { idCity });
        }
        public DataTable GetWards(int idDistrict)
        {
            return ADOHelper.Instance.ExecuteReader("select * from tbl_Ward where IDDistrict = @para_0", new object[] { idDistrict });
        }

        public int GetIDBusLine(int idTrip)
        {
            List<Trip> trips = ADOHelper.Instance.ExecuteReader<Trip>("select * from tbl_Trip");
            Trip trip = trips.SingleOrDefault(x => x.IDTRIP == idTrip);
            if (trip != null)
                return trip.IDBUSLINE;
            return 0;
        }
        public int GetIDDistrict(int idWard)
        {
            Ward ward = wards.SingleOrDefault(x => x.IDWARD == idWard);
            if (ward != null)
                return ward.IDDISTRICT;
            return 0;
        }

        public int GetIDCity(int idDistrict)
        {
            District district = districts.SingleOrDefault(x => x.IDDISTRICT == idDistrict);
            if (district != null)
                return district.IDCITY;
            return 0;
        }
    }
}
