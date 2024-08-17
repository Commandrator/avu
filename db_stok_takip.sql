CREATE database if not exists db_stok_takip;
use db_stok_takip;
create table if not exists `urun`(
	id int not null primary key auto_increment,
    name nvarchar(50) null,
    content nvarchar(255) null
);