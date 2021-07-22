using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnMon.Models
{
    public class Giode
    {
        WEBTNDataContext db = new WEBTNDataContext();
        public int iMaDe { set; get; }
        public string sTenDe { set; get; }
        public string sAnhbia { set; get; }
        public double dDongia { set; get; }
        public int iSoLuong { set; get; }
        public double dthanhtien
        {
            get { return iSoLuong * dDongia; }
        }

        public Giode(int MaDe)
        {
            iMaDe = MaDe;
            De de = db.Des.Single(n => n.MaDe == iMaDe);
            sTenDe = de.TenDe;
            sAnhbia = de.Anhbia;
            dDongia = double.Parse(de.Giaban.ToString());
            iSoLuong = 1;
        }
    }
       
}