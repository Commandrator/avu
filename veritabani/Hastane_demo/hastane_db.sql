create database if not exists Hastane_DB;
use Hastane_DB;
create table if not exists t.c(
    ad nvarchar(25),
    soyad nvarchar(25),
    kimlik_no int,
    seri_no varchar(255),
    aile_sıra_no tinyint,
    anne_adi nvarchar(25),
    baba_adi nvarchar(25)
);
create table if not exists iletisim(
    kimlik_no int,
    telefon int,
    eposta nvarchar(60),
    adres_id int
);
create table if not exists adres(
	adres_id int primary key,
    ulke nvarchar(25),
    sheir nvarchar(25),
	ilce nvarchar(25),
    acik_adres text,
    posta_kodu tinyint
);
create table if not exists hasta_durumu(
    kimlik_no int,
	tehsis text,
    hastalik_nedeni text,
    saglik_durumu_id int
);
create table if not exists saglik(
    saglik_durumu_id int,
    durum text
);
create table if not exists genel(
    kan_gurubu_id int,
    devamli_hastalik_durumu nvarchar(255)
);
create table if not exists kan_gurubu(
    kan_gurubu_id int,
    kan_gurubu nchar(4)
);
create table if not exists personel(
    kimlik_no int,
    sertifika image,
    resim image,
    alani nvarchar(30),
    meslek_id int
    baslangic_tarihi datetime,
);
create table if not exists meslek(
    meslek_id int,
    meslek nvarchar(75)
);
create table if not exists malzeme_stogu(
    id int,
    kodu int,
    adi nvarchar(50),
    fiyati Decimal(19,4),
    kdv tinyint,
    stok_tarihi datetime,
    ürün_tarihi datetime,
    son_kullanim_tarihi datetime
    teslim_alan nvarchar(30),
    teslim_eden nvarchar(30),
);
ALTER TABLE iletisim
ADD FOREIGN KEY (`adres_id`) REFERENCES `adres` (`adres_id`),
ADD FOREIGN KEY (`kimlik_no`) REFERENCES `t.c.` (`kimlik_no`);
ALTER TABLE hasta_durumu
ADD FOREIGN KEY (`saglik`) REFERENCES `saglik` (`saglik_durumu_id`);
ALTER TABLE genel
ADD FOREIGN KEY (`kan_gurubu_id`) REFERENCES `kan_gurubu` (`kan_gurubu_id`);
ALTER TABLE personel
ADD FOREIGN KEY (`kimlik_no`) REFERENCES `t.c.` (`kimlik_no`),
ADD FOREIGN KEY (`meslek_id`) REFERENCES `meslek` (`meslek_id`);