using DB_Islemleri.App_Code;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace DB_Islemleri
{
    public partial class Index : System.Web.UI.Page
    {
        //App_Code Veritabani islemlerini gerceklesirmek icin bu sinifi kullanilir.
        Veri_islemleri vi = new Veri_islemleri();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Ornek cmd kullanimi 
            vi.cmd("Update Ogrenci set cinsiyet='1' where id='2' ");

            //DataTable kullanimi
            DataTable dt = vi.GetDataTable("Select * from ogrenci");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                Response.Write(dr["adı"].ToString() + "</br>");
            }

            //DataRow kullanimi (Tek satirlik islemler icin kullanilir)
            DataRow dr1 = vi.GetDataRow("Select * from Ogrenci Where id = 2");
            Response.Write(dr1["adı"].ToString());

            //GETDATACELL kullanimi
            string telefon_no = "";
            //sorgudaki ilk sutunu yani telefon_no yi cek
            telefon_no = vi.GetDataCell("Select telefon_no From ogrenci");
            Response.Write(telefon_no);


        }
    }
}