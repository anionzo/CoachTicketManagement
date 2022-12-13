using CoachTicketManagement.Core;
using CoachTicketManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoachTicketManagement.Utility
{
    public class ControlHelper
    {
        #region Singleton
        private static ControlHelper instance;
        public static ControlHelper Instance
        {
            get { if (instance == null) instance = new ControlHelper(); return instance; }
            private set { instance = value; }
        }
        private ControlHelper() { }
        #endregion

        public void loadGender(ComboBox combo)
        {
            combo.DataSource = new string[] { "Nam", "Nữ" };
        }
        public void loadCity(ComboBox combo)
        {
            combo.DisplayMember = "NameCity";
            combo.ValueMember = "IDCity";
            combo.DataSource = ADOHelper.Instance.ExecuteReader("select * from tbl_City");
        }
        public void loadDistrict(ComboBox combo)
        {
            combo.DisplayMember = "NameDistrict";
            combo.ValueMember = "IDDistrict";
            combo.DataSource = ADOHelper.Instance.ExecuteReader("select * from tbl_District");
        }
        public void loadDistrict(ComboBox combo, int idCity)
        {
            combo.DisplayMember = "NameDistrict";
            combo.ValueMember = "IDDistrict";
            combo.DataSource = DataService.Instance.GetDistricts(idCity);
        }

        public void loadWard(ComboBox combo)
        {
            combo.DisplayMember = "NameWard";
            combo.ValueMember = "IDWard";
            combo.DataSource = ADOHelper.Instance.ExecuteReader("select * from tbl_Ward");
        }
        public void loadWard(ComboBox combo, int idDistrict)
        {
            combo.DisplayMember = "NameWard";
            combo.ValueMember = "IDWard";
            combo.DataSource = DataService.Instance.GetWards(idDistrict);
        }
        public void loadCboCoach(ComboBox combo)
        {
            combo.DisplayMember = "LICENSEPLATE";
            combo.ValueMember = "IDCOACH";
            combo.DataSource = ADOHelper.Instance.ExecuteReader("select IDCOACH, LICENSEPLATE from TBL_COACH");
        }
        public void loadCboTime(ComboBox combo)
        {
            combo.DisplayMember = "Time";
            combo.ValueMember = "IDTIME";
            combo.DataSource = ADOHelper.Instance.ExecuteReader("select IDTIME, cast(STARTTIME as nvarchar(max)) + ' - ' + cast(FINISHTIME as nvarchar(max)) as 'Time' from TBL_TIMEBUSLINE");
        }
        public void loadCboDriver(ComboBox combo)
        {
            combo.DisplayMember = "NAMEDRIVER";
            combo.ValueMember = "IDDRIVER";
            combo.DataSource = ADOHelper.Instance.ExecuteReader("select IDDRIVER, NAMEDRIVER from TBL_DRIVER");
        }
        public void loadCboBusLine(ComboBox combo)
        {
            combo.DisplayMember = "BusLine";
            combo.ValueMember = "IDBUSLINE";
            combo.DataSource = ADOHelper.Instance.ExecuteReader("select IDBUSLINE, DEPARTURESTATION + ' - ' + DESTINATIONSTATION as 'BusLine' from TBL_BUSLINE");
            
        }

        public void loadTypeAccount(ComboBox combo)
        {
            combo.DisplayMember = "NameGroup";
            combo.ValueMember = "IDPERMISSIONGROUP";
            combo.DataSource = ADOHelper.Instance.ExecuteReader("select * from TBL_PERMISSIONGROUP");
        }
        public void loadTypeEmployee(ComboBox combo)
        {
            combo.DisplayMember = "NameType";
            combo.ValueMember = "IDType";
            combo.DataSource = ADOHelper.Instance.ExecuteReader("select * from TBL_TYPEOFEMPLOYEE");
        }
        public void loadCboEmployee(ComboBox combo, string sam)
        {
            combo.DisplayMember = "NAMEEMPLOYEE";
            combo.ValueMember = "IDEMPLOYEE";
            combo.DataSource = ADOHelper.Instance.ExecuteReader("select IDEMPLOYEE, NAMEEMPLOYEE from TBL_EMPLOYEE e, TBL_TYPEOFEMPLOYEE te where e.IDTYPE = te.IDTYPE and te.NAMETYPE like N'%'+@para_0+'%'", new object[] { sam });
            
        }

        public void loadCboPickUpPoint(ComboBox combo, int idTrip)
        {
            combo.DisplayMember = "NameStation";
            combo.ValueMember = "IDSTATION";
            combo.DataSource = ADOHelper.Instance.ExecuteReader("select s.IDSTATION, s.NAMESTATION from TBL_PICKUP p, TBL_STATION s where @para_0 = p.IDBUSLINE and p.IDSTATION = s.IDSTATION", new object[] { idTrip });
            
        }
        public void loadCboDropOffPoint(ComboBox combo, int idTrip)
        {
            combo.DisplayMember = "NameStation";
            combo.ValueMember = "IDSTATION";
            combo.DataSource = ADOHelper.Instance.ExecuteReader("select s.IDSTATION, s.NAMESTATION from TBL_DROPOFF d, TBL_STATION s where @para_0 = d.IDBUSLINE and d.IDSTATION = s.IDSTATION", new object[] { idTrip });
            
        }
    }
}
