create table ThuongHieu
(
	MaThuongHieu nchar(30) primary key,
	TenThuongHieu nvarchar(50) not null
)
create table SanPham
(
	MaSanPham nchar(30) primary key not null,
	TenSanPham nvarchar(50),
	MaThuongHieu nchar(30) not null,
	SoLuong int,
	DonGia int
	constraint FK_SP_TH foreign key (MaThuongHieu) references ThuongHieu(MaThuongHieu)
)

create table ThongTinQuanLy
(
	MaQuanLy nchar(30) primary key,
	TenQuanLy nvarchar(50),
	GioiTinh nchar(10),
	Sdt nchar(10),
)
create table TaiKhoanQuanLy
(
	TaiKhoanQL nchar(30) not null primary key,
	MatKhauQL nchar(30) not null,
	MaQuanLy nchar(30) not null,
	constraint FK_TKQL_TTQL foreign key (MaQuanLy) references ThongTinQuanLy(MaQuanLy)
)
create table ThongTinNhanVien
(
	MaNhanVien nchar(30) primary key,
	TenNhanVien nvarchar(50),
	MaQuanLy nchar(30) not null,
	DiaChi nvarchar(50),
	GioiTinh nvarchar(10),
	Sdt nchar(10),
	constraint FK_TTNV_TTQL foreign key (MaQuanLy) references ThongTinQuanLy(MaQuanLy)
)
create table TaiKhoanNhanVien
(
	TaiKhoanNv nchar(20) primary key not null,
	MatKhauNv nchar(20) not null,
	MaNhanVien nchar(30),
	constraint FK_TKNV_TTNV foreign key (MaNhanVien) references ThongTinNhanVien(MaNhanVien)
)
CREATE TABLE KhachHang (
    MaKhachHang nchar(30) primary key,
    HoTen NVARCHAR(100),
    DiaChi NVARCHAR(255),
    DienThoai nchar(10),
    Email nchar(30)
);

create table HoaDonBan
(
	MaHd nchar(30) primary key not null,
	MaNhanVien nchar(30) not null,
	MaKhachHang nchar(30) not null,
	MaSanPham nchar(30) not null,
	NgayLapHd date,
	SoLuongMua int,
	DonGia int,
	TongTien int,
	constraint FK_HD_TTNV foreign key (MaNhanVien) references ThongTinNhanVien(MaNhanVien),
	constraint FK_HD_KH foreign key (MaKhachHang) references KhachHang(MaKhachHang),
	constraint FK_HD_SP foreign key (MaSanPham) references SanPham(MaSanPham)
)
insert into ThongTinQuanLy
values
('TD',N'Lý Tiến Đạt','Nam','0336456341'),
('QA',N'Lê Quốc Anh','Nam','0352446495'),
('TT',N'Nguyễn Tiến Thành','Nam','0395807626')

insert into TaiKhoanQuanLy
values
('Lequocanh','naocavang','QA'),
('Nguyentienthanh','naocavang1','TT'),
('LyTienDat','hackerlor','TD')
insert into ThongTinNhanVien
values
('NV01',N'Nguyễn Đăng Khoa','TD',N'Thủ Dầu Một','Nam','0123456789'),
('NV02',N'Lưu Tuệ Thành','QA',N'Tân Phú','Nam','0123456788'),
('NV03',N'Vũ Phạm Hoàng Nhi','TT',N'Thủ Dầu Một',N'Nữ','0123456787'),
('NV04',N'Phạm Duy Sơn','QA',N'Thủ Dầu Một','Nam','0123456786'),
('NV05',N'Lâm Tuấn Đạt','TD',N'Tân Phú','Nam','0123456785')
insert into TaiKhoanNhanVien
values
('Nguyendangkhoa','matkhau1','NV01'),
('Luutuethanh','matkhau2','NV02'),
('Lamtuandat','matkhau3','NV03'),
('Phamduyson','matkhau4','NV04'),
('Vuphamhoangnhi','matkhau5','NV05')



insert into ThuongHieu
values
('Panasonic','Panasonic'),
('Sharp','Sharp'),
('LG','LG'),
('Daikin','Daikin'),
('Funiki','Funiki'),
('Toshiba','Toshiba'),
('AQUA','AQUA'),
('Midea','Midea'),
('Samsung','Samsung'),
('Hitachi','Hitachi')



insert into SanPham
values
('SP01',N'Sharp Inverter 1 HP AH-XP10YMW','Sharp',10,11900000),
('SP02',N'Panasonic Inverter 1 HP CU/CS-XU9ZKH-8','Panasonic',3,13900000),
('SP03',N'LG Inverter 1.5 HP V13WIN','LG',6,17290000),
('SP04',N'Daikin Inverter 2 HP FTKF50XVMV','Daikin',8,10190000),
('SP05',N'Funiki Inverter 2 HP HIC18TMU.ST3','Funiki',7,8900000),
('SP06',N'Toshiba Inverter 2 HP RAS-H18C4KCVG-V','Toshiba',10,18900000),
('SP07',N'Samsung Inverter 2 HP AR18TYHYCWKNSV','Samsung',10,9190000),
('SP08',N'AQUA Inverter 1 HP AQA-KCRV10NB','AQUA',3,8900000),
('SP09',N'Midea Inverter 2 HP MSAGA-18CRDN8','Midea',9,15000000),
('SP10',N'Hitachi Inverter 2 HP RAC/RAK-DJ13PCASVX','Hitachi',9,15900000)


insert into KhachHang
values
('KH01',N'Đặng Văn Của',N'Củ Chi','0352446423','cuadang@gmail.com'),
('KH02',N'Nguyễn Thúy Quỳnh',N'Củ Chi','0352446411','quynhnguyen@gmail.com'),
('KH03',N'Sơn Tùng MTP',N'Thái Bình','0123123123','sontungmtp@gmail.com'),
('KH04',N'Lê Anh Quốc',N'Củ Chi','0352446424','quocanhgaugau@gmail.com'),
('KH05',N'Lý Đạt Tiến',N'Bình Dương','0352446425','datdeptrai@gmail.com'),
('KH06',N'Lưu Thành Tuệ',N'Sài Gòn','052446428','tuethanhtue@gmail.com'),
('KH07',N'Nguyễn Khoa Đăng',N'Đồng Nai','0352446432','taodangkhoa@gmail.com'),
('KH08',N'Nguyễn Quốc Sử',N'Củ Chi','0352446423','taotenquocsu@gmail.com'),
('KH09',N'Đặng Duy Tân',N'Tân Phước Khánh','0321321321','tandang@gmail.com'),
('KH10',N'Đặng Duy Lợi',N'Tân Phước Khánh','0323446423','cuadang@gmail.com'),
('KH11',N'Lâm Đạt Tuấn',N'Sài Gòn','0352446423','cuadang@gmail.com'),
('KH12',N'Phạm Sơn Duy',N'Sài Gòn','0352446423','cuadang@gmail.com')




