create database if not exist HASTANE_DB
use Hastane_DB
	create table if not exist [T.C.](
		[Kimlik No]						int					NOT NULL,
		[İsim]							nvarchar(25)		NOT NULL,
		[Soyad]							nvarchar(25)		NOT NULL,
		[Seri No]						varchar(200)		NOT NULL,
		[Aile Sıra No]					smallint			NOT NULL,
		[Anne Adı]						nvarchar(25)		NOT NULL,
		[Baba Adı]						nvarchar(25)		NOT NULL,
		PRIMARY KEY ("Kimlik No")
	)
		create table if not exist  [ADRES] (
			[ID]						int				NOT NULL,
			[Ülke KODU]					int				NOT NULL,
			[İl]						nvarchar(50)		NULL,
			[İlçe]						nvarchar(30)		NULL,
			[Mahalle]					nvarchar(30)		NULL,
			[Cadde]						nvarchar(30)		NULL,
			[Sokak]						nvarchar(20)		NULL,
			[No]						smallint			NULL,
			[Kat]						smallint			NULL,
			PRIMARY KEY ("ID")
	)
	create table if not exist  [İletişim](
		[ID]							int					NOT NULL,
		[TELEFON]						int						NULL,
		[MAIL]							nvarchar(35)			Null,
		[ADRES]							int					NOT NULL,
		FOREIGN KEY ("ADRES") 		REFERENCES [dbo].[ADRES]("ID"),	-- Adres Tablosu Forıng Key Olarak Bağlancak.
		PRIMARY KEY ("ID")
	)
	create table if not exist [HASTA DURUMU](
		[ID]						int				NOT NULL,
		[Tehşis]					TEXT				NULL,
		[Hastalık Nedeni]			TEXT				NULL,
		[Sağlık Durumu]				TEXT				NULL,
		PRIMARY KEY ("ID")
	)
	create table if not exist [Genel](
			[ID]						int				NOT NULL,
			[Kan Gurubu]				char(5)			NOT NULL,
			[Devamlı Hastalık Durumu]	nvarchar(150)		NULL,
			[Not]						text				NULL,
			PRIMARY KEY ("ID")
)

	create table if not exist [Doktor](
		[ID]						int				NOT NULL,
		[Ad]						nchar(15)		NOT NULL,
		[Soyad]						nchar(20)		NOT NULL,
		[Sertifika]					nvarchar(50)		NULL,
		[Uzmanlık Alanı]			TEXT			NOT NULL,
		[Başladığı Tarih]			datetime			NULL,
		PRIMARY KEY (ID)
	)
	create table if not exist [Hemşir](
		[ID]						int				NOT NULL,
		[Ad]						nchar(15)		NOT NULL,
		[Soyad]						nchar(20)		NOT NULL,
		[Alanı]						nchar			NOT NULL,
		[Başladığı Tarih]			datetime			NULL,
		PRIMARY	KEY ("ID")
	)
	create table if not exist [Güvenlik](
		[ID]						int				NOT NULL,
		[Ad]						nchar(15)		NOT NULL,
		[Soyad]						nchar(20)		NOT NULL,
		[Sertifika]					nvarchar(50)		NULL,
		[Başladığı Tarih]			datetime			NULL,
		PRIMARY KEY ("ID")
	)
	create table if not exist [Hizmetli](
		[ID]						int				NOT NULL,
		[Ad]						nchar(15)		NOT NULL,
		[Soyad]						nchar(20)		NOT NULL,
		[Başladığı Tarih]			datetime			NULL,
		PRIMARY KEY ("ID")
	)	
create table if not exist [Personel](
	[Doktor]					int				NOT NULL,
	[Hemşir]					int				NOT NULL,
	[Güvenlik]					int				NOT NULL,
	[Hizmetli]					int				NOT NULL,
	FOREIGN KEY ("Doktor")			REFERENCES [dbo].[Doktor]("ID"), -- Doktor Tablosu Forıng Key Oarak Bağlanacak.
	FOREIGN KEY ("Hemşir") 			REFERENCES [dbo].[Hemşir]("ID"), -- Hemşir Tablosu Forıng Key Oarak Bağlanacak.
	FOREIGN KEY ("Güvenlik") 		REFERENCES [dbo].[Güvenlik]("ID"), -- Güvenlik Tablosu Forıng Key Oarak Bağlanacak.
	FOREIGN KEY ("Hizmetli")	 	REFERENCES [dbo].[İletişim]("ID")	-- Hizmetli Tablosu Forıng Key Oarak Bağlanacak.
)
	create table if not exist [Temizlik Malzemesi](
			[ID]						int 			NOT NULL, --Farklı ürünlerin aynı ürün kodları olavbileceği için iç ID tanımlaması ihtayacı duydum
			[Ürün Kodu]					int					NULL,
			[Ürün Adı]					nvarchar		NOT NULL,
			[Ürün Fiyatı]				money 			NOT NULL,
			[Ürün KDV oranı]			tinyint 			NULL, --Muhasebe programlarına veri tabanı dahil edilebileceğini düşündüğüm için KDV oranın istettim.
			[Stok Tarihi]				datetime 		NOT NULL,
			[Ürün Tarihi]				datetime 			NULL,
			[Ürünü Teslim Alan]			int 			NOT NULL, -- [Ürünü Teslim Alan] sütunu Personel>Hizmetli tablosuna Foring Key olarak bağlanacak.
			[Ürünü Teslim Eden]			nvarchar(50) 	NOT NULL,
			[Ürün Son Kullanım Tarihi]	datetime 		NOT NULL,
			PRIMARY KEY ("ID"),
			FOREIGN KEY ("Ürünü Teslim Alan")	 	REFERENCES [dbo].[Hizmetli]("ID")
	)

create table if not exist [Malzeme Stoğu](
	[Temizlik Malzemesi]			int				NOT NULL,
	FOREIGN KEY ("Temizlik Malzemesi")	 		REFERENCES [dbo].[Temizlik Malzemesi]("ID")	-- Temizlik MAZEMELESİ FORİNG KEY OLARAK BAĞLANACAK
)

	create table if not exist [Hasta](
	[T.C.] 								int 				NOT NULL,
	[İletişim] 							int 				NOT NULL,
	[Hasta Durumu] 						int 				NOT NULL,
	[Genel] 							int 				NOT NULL,
	[Personel] 							int 				NOT NULL,
	FOREIGN KEY ("T.C.")			REFERENCES [dbo].[T.C.]("Kimlik No"),	-- T.C. Tablosu Forıng Key Olarak Bağlanacak.
	FOREIGN KEY ("İletişim")		REFERENCES [dbo].[İletişim]("ID"), 		-- İletişim Tablosu Forıng Key Olarak Bağlanılacka.
	FOREIGN KEY ("Hasta Durumu")	REFERENCES [dbo].[İletişim]("ID"), 		-- Hasta Durumu Tablosu Foring Key Olarak Bağlanacak.
	FOREIGN KEY ("Genel") 			REFERENCES [dbo].[İletişim]("ID"), 		-- Genel Tablosu Forıng Key Olarak Bağlanacak.
	FOREIGN KEY ("Personel") 		REFERENCES [dbo].[İletişim]("ID") 		-- Personel Tablosu Forıng Key Oarak Bağlanacak.
)