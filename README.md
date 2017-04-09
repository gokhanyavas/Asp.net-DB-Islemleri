# Asp.net-DB-Islemleri

Asp.net'te veritabanı işlemlerini kısayoldan yapmaya olanak sağlayan sınıf.
' public class Veri_islemleri
    {
        /* Bu sinifindaki tum metodlar SQL sorgusu dondurur.
         * Bu sinif yardimiyla veritabani islemleri yapilmaktadir. 
        */

        // Baglanti burada saglanir.
        public SqlConnection baglan()
        {
            SqlConnection sqlbaglanti = new SqlConnection("Data Source=localhost; Initial Catalog=dilokulu; Integrated Security=True;");
            sqlbaglanti.Open();
            return (sqlbaglanti);
        }

        //sql sorgularini calistirmak icin (update,delete,insert)
        public int cmd(string sqlcumle)
        {
            SqlConnection baglan = this.baglan();
            SqlCommand sorgu = new SqlCommand(sqlcumle, baglan);
            int sonuc = 0;
            //hata meydana geldiginde sonucu bildir.
            try
            {
                sonuc = sorgu.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //hatayi ve sorguyu goster.
                throw new Exception(ex.Message + "(" + sqlcumle + ")");
            }
            sorgu.Dispose();
            baglan.Close();
            baglan.Dispose();
            return (sonuc);
        }

        //SQL sorgusunu kullanarak Datatable veri aktarma islemi.
        public DataTable GetDataTable(string sql)
        {
            SqlConnection baglanti = this.baglan();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, baglanti);
            DataTable dt = new DataTable();
            try
            {
                //yazilan sql sorgusunu datatable doldur.
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + "(" + sql + ")");
            }
            adapter.Dispose();
            baglanti.Close();
            baglanti.Dispose();
            return dt;
        }

        //Geriye Dataset degeri dondurur.
        public DataSet GetDataSet(string sql)
        {
            SqlConnection baglanti = this.baglan();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, baglanti);
            DataSet ds = new DataSet();
            try
            {
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + "(" + sql + ")");
            }
            adapter.Dispose();
            baglanti.Close();
            baglanti.Dispose();
            return ds;
        }

        //DataRow cekmek icin kullanilir.
        //Tek satirlik islemler icin kullanilir
        public DataRow GetDataRow(string sql)
        {
            DataTable table = GetDataTable(sql);
            //Tablodaki kayit sayisi 0 ise 
            if (table.Rows.Count == 0) return null;
            // 0 degilse ilk satiri geriye dondur.
            return table.Rows[0];
        }

        //Datatable icerisindeki hucrelere erismek icin kullanilir.
        public string GetDataCell(string sql)
        {
            DataTable table = GetDataTable(sql);
            if (table.Rows.Count == 0) return null;
            //kayit varsa ilk satirin ilk hucresini geriye dondur.
            return table.Rows[0][0].ToString();
        }
    }'
