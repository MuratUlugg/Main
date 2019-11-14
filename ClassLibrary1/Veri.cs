using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary1
{

    public  class Veri
    {
        static string dBAdi;
        static string tabelaAdi;
        static int lisansNo;

        public string TabelaAdi
        {
            get
            {
                return tabelaAdi;
            }
        }


        public void mordorOlustur()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=.\\" + IniIslemleri.VeriOku("Sunucu Bilgileri", "SunucuAdi") + ";Database=master;User ID=" + IniIslemleri.VeriOku("Kullanıcı Bilgileri", "KullaniciAdi") + ";Password=" + IniIslemleri.VeriOku("Şifre Bilgileri", "sifre") + ";MultipleActiveResultSets=True";

            SqlCommand cmd = new SqlCommand("Use master Create Database MORDOR1");
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public void mordorTabloOlustur()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=.\\" + IniIslemleri.VeriOku("Sunucu Bilgileri", "SunucuAdi") + ";Database=MORDOR1;User ID=" + IniIslemleri.VeriOku("Kullanıcı Bilgileri", "KullaniciAdi") + ";Password=" + IniIslemleri.VeriOku("Şifre Bilgileri", "sifre") + ";MultipleActiveResultSets=True";
            SqlCommand cmd1 = new SqlCommand("USE [MORDOR1] CREATE TABLE[dbo].[TBLFIRMA]([lisans_no][int] NOT NULL,[tabela_adi][nvarchar](50) NOT NULL,[varsayilan][bit] NOT NULL,[veritabani_adi][nvarchar](50) NOT NULL,CONSTRAINT[PK_TBLFIRMA] PRIMARY KEY CLUSTERED([lisans_no] ASC)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]) ON[PRIMARY]");
            cmd1.Connection = conn;
            conn.Open();
            cmd1.ExecuteNonQuery();
            conn.Close();
        }

        public void kontrolDurumu()
        {
            SqlConnection kontrol = new SqlConnection();
            kontrol.ConnectionString = "Server=.\\" + IniIslemleri.VeriOku("Sunucu Bilgileri", "SunucuAdi") + ";Database=MORDOR1;User ID=" + IniIslemleri.VeriOku("Kullanıcı Bilgileri", "KullaniciAdi") + ";Password=" + IniIslemleri.VeriOku("Şifre Bilgileri", "sifre") + ";MultipleActiveResultSets=True";

            try
            {
                kontrol.Open();
                SqlCommand kontrolKomut = new SqlCommand("SELECT * FROM TBLFIRMA", kontrol);
                SqlDataReader okukontrol = kontrolKomut.ExecuteReader();
                while (okukontrol.Read())
                {
                    lisansNo = Convert.ToInt32(okukontrol[0]);
                    tabelaAdi = okukontrol[1].ToString();
                    dBAdi = okukontrol[3].ToString();
                }
                kontrol.Close();
            }
            catch (Exception)
            {
                IniIslemleri.veriSil();
                throw;
            }
        }


        public SqlConnection getMordor(string db)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=.\\" + IniIslemleri.VeriOku("Sunucu Bilgileri", "SunucuAdi") + ";Database=" + db + ";User ID=" + IniIslemleri.VeriOku("Kullanıcı Bilgileri", "KullaniciAdi") + ";Password=" + IniIslemleri.VeriOku("Şifre Bilgileri", "sifre") + ";MultipleActiveResultSets=True";

            con.Open();
            return con;
        }

        public void firmaDbOlustur(string firmaAdi)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=.\\" + IniIslemleri.VeriOku("Sunucu Bilgileri", "SunucuAdi") + ";Database=master;User ID=" + IniIslemleri.VeriOku("Kullanıcı Bilgileri", "KullaniciAdi") + ";Password=" + IniIslemleri.VeriOku("Şifre Bilgileri", "sifre") + ";MultipleActiveResultSets=True";

            SqlCommand cmd = new SqlCommand("Use master Create Database " + firmaAdi);
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void firmaTabloOlustur(string firmaAdi)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=.\\" + IniIslemleri.VeriOku("Sunucu Bilgileri", "SunucuAdi") + ";Database=" + firmaAdi + ";User ID=" + IniIslemleri.VeriOku("Kullanıcı Bilgileri", "KullaniciAdi") + ";Password=" + IniIslemleri.VeriOku("Şifre Bilgileri", "sifre") + ";MultipleActiveResultSets=True";

            SqlCommand tblAdisyon = new SqlCommand("USE[" + firmaAdi + "]SET ANSI_NULLS ON   SET QUOTED_IDENTIFIER ON   CREATE TABLE[dbo].[TBLADISYON]([tarih][nvarchar](50) NULL,[masa][nvarchar](50) NULL,[garson][nvarchar](50) NULL,[adisyonno][nvarchar](15) NULL,[urunadi][nvarchar](100) NULL,[birim][nvarchar](50) NULL,[miktari][float] NULL,[birimfiyati][money] NULL,[iskonto_orani][float] NULL,[baski][int] NULL,[grup][nvarchar](50) NULL,[silinme][int] NULL,[sebep][int] NULL,[silen][nvarchar](50) NULL,[Paket][bit] NULL,[Anahtar][int] IDENTITY(1, 1) NOT NULL,[VARY][nvarchar](max) NULL,[SIP_KISI][nvarchar](50) NULL,[DEPO][int] NULL,[DEPARTMAN][nvarchar](50) NULL,[DURUM][nvarchar](50) NULL,[SIRA_NO][int] NULL,[IKRAM][bit] NULL,[MENU][bit] NULL,[MENU_ID][nvarchar](255) NULL,[STOK_KODU][nvarchar](50) NULL,[CHID][datetime] NULL,[GUID][uniqueidentifier] ROWGUIDCOL  NULL,[LastEditDate][datetime] NULL,[CreationDate][datetime] NULL,[NEDEN][nvarchar](100) NULL,[V_FIYAT][money] NULL,[KAMPANYA][bit] NULL,[KAMP_KODU][nvarchar](50) NULL,[KAMP_SATIR][nvarchar](50) NULL,[URUN_KDV][money] NULL,[VARY_KDV][money] NULL,[KDV_ORANI][float] NULL,[T_ZAMAN][datetime] NULL,[SANDALYE][int] NULL,[CINSIYET][nvarchar](1) NULL,[IKRAM_NEDEN][nvarchar](200) NULL,[ISKONTO_TUTARI]  AS(CONVERT([money], CONVERT([money],[miktari] *[birimfiyati], (0)) - CONVERT([money], CONVERT([money],[miktari] * ([birimfiyati] * ((1) - isnull([iskonto_orani], (0)))),(0)),(0)),(0))),[toplam] AS(round(CONVERT([money], CONVERT([money],[miktari]*([birimfiyati]*((1)-isnull([iskonto_orani], (0)))),(0)),(0)),(2))),CONSTRAINT[PK_TBL_ADISYON] PRIMARY KEY CLUSTERED([Anahtar] ASC)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]   ALTER TABLE[dbo].[TBLADISYON] ADD CONSTRAINT[DF_TBL_ADISYON_GUID]  DEFAULT(newid()) FOR[GUID]   ALTER TABLE[dbo].[TBLADISYON] ADD CONSTRAINT[DF_TBL_ADISYON_LastEditDate]  DEFAULT(getutcdate()) FOR[LastEditDate]   ALTER TABLE[dbo].[TBLADISYON] ADD CONSTRAINT[DF_TBL_ADISYON_CreationDate]  DEFAULT(getutcdate()) FOR[CreationDate] ", conn);
            SqlCommand tblAdisyonUst = new SqlCommand("USE[" + firmaAdi + "]   SET ANSI_NULLS ON   SET QUOTED_IDENTIFIER ON   CREATE TABLE[dbo].[TBLADISYONUST]([tarih][nvarchar](50) NULL,[adisyonno][nvarchar](15) NULL,[masano][nvarchar](50) NULL,[garson][nvarchar](50) NULL,[tutar][money] NULL,[kdv][money] NULL,[yekun][money] NULL,[durum][int] NULL,[kredikarti][nvarchar](50) NULL,[iptal][bit] NULL,[saat][datetime] NULL,[musteri][nvarchar](500) NULL,[dovizcinsi][nvarchar](50) NULL,[hesap][bit] NULL,[indirim][money] NULL,[ilave][money] NULL,[garsoniye][money] NULL,[baski][bit] NULL,[cari][bit] NULL,[kisi][int] NULL,[Odeme][int] NULL,[grup][nvarchar](50) NULL,[a][int] IDENTITY(1, 1) NOT NULL,[GUID][uniqueidentifier] ROWGUIDCOL  NOT NULL,[CHID][datetime] NULL,[TERMINAL][nvarchar](150) NULL,[OSEBEP][nvarchar](50) NULL,[NETSIS_OK][int] NULL,[KURYE][nvarchar](50) NULL,[SIP_KISI][nvarchar](100) NULL,[MASA_ACAN][nvarchar](50) NULL,[DEPARTMAN][nvarchar](50) NULL,[KASA_KODU][nvarchar](50) NULL,[M_KUL][nvarchar](50) NULL,[SUBE_KODU][int] NULL,[ADS_NOT][nvarchar](500) NULL,[ADRES][nvarchar](500) NULL,[ NDERIM][int] NULL,[SUBE_Anahtar][int] NULL,[GARSONIYE_DURUM][int] NULL,[MERKEZ][bit] NULL,[MERKEZ_DIGER][bit] NULL,[MERKEZ_ADISYON][nvarchar](15) NULL,[KASIYER][nvarchar](50) NULL,[A_ZAMAN][datetime] NULL,[K_ZAMAN][datetime] NULL,[Y_KORDINAT][money] NULL,[KURYE_SAATI][datetime] NULL,[KURYE_ZAMAN][datetime] NULL,[LastEditDate][datetime] NULL,[CreationDate][datetime] NULL,[T_ZAMAN][datetime] NULL,[ISLETME_KODU][int] NULL,[UYE_NO][nvarchar](50) NULL,[Y_SATIR][money] NULL,[Y_SAYFA][money] NULL,[SYNC][int] NULL,[SATIR_ISKONTO_TOPLAM][money] NULL,[TOPLAM_KDV][money] NULL,[FAT_CARI_KODU][nvarchar](50) NULL,[SIRA_NO][int] NULL,[ISKONTO_NEDEN][nvarchar](250) NULL,[IADE][bit] NULL,[MUSTERI_IADE][int] NULL,[HANUTCU][nvarchar](100) NULL,[FATURA_FIS][nvarchar](50) NULL,[ISK_ORANI][float] NULL,[ISKONTO_YAPAN][nvarchar](50) NULL,[YUVARLAMA][float] NULL,[REFERANS_NO][nvarchar](50) NULL,[EFT_POS][bit] NULL,CONSTRAINT[PK_TBL_ADISYONUST] PRIMARY KEY CLUSTERED([a] ASC)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]) ON [PRIMARY]   ALTER TABLE[dbo].[TBLADISYONUST] ADD CONSTRAINT[DF_TBL_ADISYONUST_GUID]  DEFAULT(newsequentialid()) FOR[GUID]   ALTER TABLE[dbo].[TBLADISYONUST] ADD CONSTRAINT[DF_TBL_ADISYONUST_LastEditDate]  DEFAULT(getutcdate()) FOR[LastEditDate]   ALTER TABLE[dbo].[TBLADISYONUST] ADD CONSTRAINT[DF_TBL_ADISYONUST_CreationDate]  DEFAULT(getutcdate()) FOR[CreationDate] ", conn);
            SqlCommand tblKullanici = new SqlCommand("USE [" + firmaAdi + "]   SET ANSI_NULLS ON   SET QUOTED_IDENTIFIER ON   CREATE TABLE[dbo].[TBLKULLANICI]([kul_id][int] IDENTITY(1, 1) NOT NULL,[kulAdi][nvarchar](50) NULL,[yetki][nvarchar](50) NULL,[sifre][nvarchar](50) NULL,CONSTRAINT[PK_TBLKULLANICI] PRIMARY KEY CLUSTERED([kul_id] ASC)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]) ON[PRIMARY] ", conn);
            SqlCommand tblMasaGrup = new SqlCommand("USE [" + firmaAdi + "]   SET ANSI_NULLS ON   SET QUOTED_IDENTIFIER ON   CREATE TABLE[dbo].[TBLMASAGRUP]([grup_id][int] IDENTITY(1, 1) NOT NULL,[grup_adi][nvarchar](50) NULL,[grup_sira][nvarchar](50) NULL,CONSTRAINT[PK_TBLMASAGRUP] PRIMARY KEY CLUSTERED([grup_id] ASC)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]) ON[PRIMARY] ", conn);
            SqlCommand tblMasaListe = new SqlCommand("USE [" + firmaAdi + "]   SET ANSI_NULLS ON   SET QUOTED_IDENTIFIER ON   CREATE TABLE[dbo].[TBLMASALISTE]([masa_id][int] IDENTITY(1, 1) NOT NULL,[masa_adi][nvarchar](50) NULL,[masa_sira][nvarchar](50) NULL,[grup_id][int] NULL,CONSTRAINT[PK_TBLMASALISTE] PRIMARY KEY CLUSTERED([masa_id] ASC)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]) ON[PRIMARY] ", conn);
            SqlCommand tblOdeme = new SqlCommand("USE [" + firmaAdi + "]   SET ANSI_NULLS ON   SET QUOTED_IDENTIFIER ON   CREATE TABLE[dbo].[TBLODEME]([Kimlik][int] IDENTITY(1, 1) NOT NULL,[adisyonno][nvarchar](15) NULL,[odeme][int] NULL,[miktar][money] NULL,[tarih][nvarchar](50) NULL,[CariBaglanti][int] NULL,[Cari][nvarchar](50) NULL,[Terminal][nvarchar](50) NULL,[Kullanıcı][nvarchar](50) NULL,[SelfServis][bit] NULL,[GUID][uniqueidentifier] ROWGUIDCOL  NULL,[CHID][datetime] NULL,[ACIKLAMA][nvarchar](250) NULL,[LastEditDate][datetime] NULL,[CreationDate][datetime] NULL,[KK_BILGISI][nvarchar](250) NULL,CONSTRAINT[PK_Odeme] PRIMARY KEY CLUSTERED([Kimlik] ASC)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]) ON[PRIMARY]   ALTER TABLE[dbo].[TBLODEME] ADD CONSTRAINT[DF_TBL_ODEME_GUID]  DEFAULT(newsequentialid()) FOR[GUID]   ALTER TABLE[dbo].[TBLODEME] ADD CONSTRAINT[DF_TBL_ODEME_LastEditDate]  DEFAULT(getutcdate()) FOR[LastEditDate]   ALTER TABLE[dbo].[TBLODEME] ADD CONSTRAINT[DF_TBL_ODEME_CreationDate]  DEFAULT(getutcdate()) FOR[CreationDate] ", conn);
            SqlCommand tblOdemeTipleri = new SqlCommand("USE [" + firmaAdi + "]   SET ANSI_NULLS ON   SET QUOTED_IDENTIFIER ON   CREATE TABLE[dbo].[TBLODEMETIPLERI]([odeme_kodu][int] IDENTITY(1, 1) NOT NULL,[odeme_adi][nvarchar](50) NULL,[odeme_tipi][nvarchar](50) NULL,[odeme_kasa][nvarchar](50) NULL,[odeme_sira][nchar](10) NULL,CONSTRAINT[PK_TBLODEMETIPLERI] PRIMARY KEY CLUSTERED([odeme_kodu] ASC)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]) ON[PRIMARY]  ", conn);
            SqlCommand tblUrun = new SqlCommand("USE [" + firmaAdi + "]   SET ANSI_NULLS ON   SET QUOTED_IDENTIFIER ON   CREATE TABLE[dbo].[TBLURUN]([STOK_KODU][nvarchar](50) NOT NULL,[GRUP_ID][int] NULL,[ISIM][nvarchar](50) NULL,[BRM1][nvarchar](50) NULL,[BRM2][nvarchar](50) NULL,[BRM2CVR][nvarchar](50) NULL,[FIYAT][money] NULL,[OZEL_FIYAT][nvarchar](50) NULL,[ISKONTO_ORAN][nvarchar](50) NULL,[YAZICI][nvarchar](50) NULL,[P_TYPE][nvarchar](50) NULL,[DEPO][nvarchar](50) NULL,[ALIS_KDV][float] NULL,[SATIS_KDV][float] NULL,CONSTRAINT[PK_TBLURUN] PRIMARY KEY CLUSTERED([STOK_KODU] ASC)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]) ON[PRIMARY] ", conn);
            SqlCommand tblUrunGrup = new SqlCommand("USE [" + firmaAdi + "]   SET ANSI_NULLS ON   SET QUOTED_IDENTIFIER ON   CREATE TABLE[dbo].[TBLURUNGRUP]([grup_id][int] IDENTITY(1, 1) NOT NULL,[grup_adi][nvarchar](50) NULL,[grup_sira][nvarchar](50) NULL,CONSTRAINT[PK_TBLURUNGRUP] PRIMARY KEY CLUSTERED([grup_id] ASC)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]) ON[PRIMARY] ", conn);
            SqlCommand tblYazici = new SqlCommand("USE ["+firmaAdi+"] SET ANSI_NULLS ON SET QUOTED_IDENTIFIER ON CREATE TABLE[dbo].[TBLYAZICI]([id][int] IDENTITY(1, 1) NOT NULL,[yazici_yolu][nvarchar](60) NULL,CONSTRAINT[PK_TBLYAZICI] PRIMARY KEY CLUSTERED([id] ASC)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]) ON[PRIMARY]",conn);
            SqlCommand tblKullaniciEkle = new SqlCommand("USE [" + firmaAdi + "] INSERT INTO TBLKULLANICI (kulAdi , yetki , sifre) Values ('ULUPOS' ,'SISTEM' , '1995') ", conn); 
            conn.Open();

            tblAdisyon.ExecuteNonQuery();
            tblAdisyonUst.ExecuteNonQuery();
            tblKullanici.ExecuteNonQuery();
            tblMasaGrup.ExecuteNonQuery();
            tblMasaListe.ExecuteNonQuery();
            tblOdeme.ExecuteNonQuery();
            tblOdemeTipleri.ExecuteNonQuery();
            tblUrun.ExecuteNonQuery();
            tblUrunGrup.ExecuteNonQuery();
            tblYazici.ExecuteNonQuery();
            tblKullaniciEkle.ExecuteNonQuery();
            conn.Close();

        }



        public SqlConnection getBaglanti()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=.\\" + IniIslemleri.VeriOku("Sunucu Bilgileri", "SunucuAdi") + ";Database=" + dBAdi + ";User ID=" + IniIslemleri.VeriOku("Kullanıcı Bilgileri", "KullaniciAdi") + ";Password=" + IniIslemleri.VeriOku("Şifre Bilgileri", "sifre") + ";MultipleActiveResultSets=True";

            try
            {
                con.Open();
                return (con);
            }
            catch (Exception)
            {
                IniIslemleri.veriSil();
                throw;
            }
        }

        public Boolean baglantiDurumu()
        {
            if (getBaglanti().State == ConnectionState.Open) return true;
            else return false;
        }

        public DataTable GetDataTable(string sql)
        {
            SqlConnection baglanti = this.getBaglanti();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, baglanti);
            DataTable dt = new DataTable();
            try
            {
                adapter.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message + " (" + sql + ")");
            }
            adapter.Dispose();
            baglanti.Close();
            baglanti.Dispose();
            return dt;
        }
        

    }
}
