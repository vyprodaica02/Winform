USE [dbVienHoa]
GO
SET IDENTITY_INSERT [dbo].[loaiLoNungs] ON 
GO
INSERT [dbo].[loaiLoNungs] ([Id], [TenLoaiLo]) VALUES (1, N'Lò Nung 1')
GO
INSERT [dbo].[loaiLoNungs] ([Id], [TenLoaiLo]) VALUES (2, N'Lò Nung 2')
GO
INSERT [dbo].[loaiLoNungs] ([Id], [TenLoaiLo]) VALUES (3, N'Lò Nung 3')
GO
INSERT [dbo].[loaiLoNungs] ([Id], [TenLoaiLo]) VALUES (4, N'Lò Nung 4')
GO
INSERT [dbo].[loaiLoNungs] ([Id], [TenLoaiLo]) VALUES (5, N'Lò Nung 5')
GO
INSERT [dbo].[loaiLoNungs] ([Id], [TenLoaiLo]) VALUES (6, N'Lò Nung 6')
GO
INSERT [dbo].[loaiLoNungs] ([Id], [TenLoaiLo]) VALUES (7, N'Lò Nung 7')
GO
SET IDENTITY_INSERT [dbo].[loaiLoNungs] OFF
GO
SET IDENTITY_INSERT [dbo].[doanhNghieps] ON 
GO
INSERT [dbo].[doanhNghieps] ([Id], [TenCongTy], [DiaChi], [DienThoai], [NguoiLienHe], [QuocGia]) VALUES (1, N'LTS', N'Cầu Giấy', N'12312341234', N'Uchiha ItaChi', N'Việt Nam')
GO
SET IDENTITY_INSERT [dbo].[doanhNghieps] OFF
GO
SET IDENTITY_INSERT [dbo].[duAns] ON 
GO
INSERT [dbo].[duAns] ([Id], [DoanhNghiepId], [TenDuAn], [NgayBatDau], [NgayKetThuc]) VALUES (1, 1, N'VienHoaPro', CAST(N'2023-01-08T00:00:00.0000000' AS DateTime2), CAST(N'2023-09-15T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[duAns] OFF
GO
SET IDENTITY_INSERT [dbo].[congSuatThietKes] ON 
GO
INSERT [dbo].[congSuatThietKes] ([Id], [CongSuatDinhMuc], [DonViCongSuat]) VALUES (1, 1, N'Đơn Vị 1')
GO
INSERT [dbo].[congSuatThietKes] ([Id], [CongSuatDinhMuc], [DonViCongSuat]) VALUES (2, 2, N'Đơn Vị 2')
GO
INSERT [dbo].[congSuatThietKes] ([Id], [CongSuatDinhMuc], [DonViCongSuat]) VALUES (3, 3, N'Đơn Vị 3')
GO
INSERT [dbo].[congSuatThietKes] ([Id], [CongSuatDinhMuc], [DonViCongSuat]) VALUES (4, 4, N'Đơn Vị 4')
GO
INSERT [dbo].[congSuatThietKes] ([Id], [CongSuatDinhMuc], [DonViCongSuat]) VALUES (5, 5, N'Đơn Vị 5')
GO
INSERT [dbo].[congSuatThietKes] ([Id], [CongSuatDinhMuc], [DonViCongSuat]) VALUES (6, 6, N'Đơn Vị 6')
GO
SET IDENTITY_INSERT [dbo].[congSuatThietKes] OFF
GO
SET IDENTITY_INSERT [dbo].[loaiNhaMays] ON 
GO
INSERT [dbo].[loaiNhaMays] ([Id], [TenLoai]) VALUES (1, N'Loại Nhà Máy 1')
GO
INSERT [dbo].[loaiNhaMays] ([Id], [TenLoai]) VALUES (2, N'Loại Nhà Máy 2')
GO
INSERT [dbo].[loaiNhaMays] ([Id], [TenLoai]) VALUES (3, N'Loại Nhà Máy 3')
GO
INSERT [dbo].[loaiNhaMays] ([Id], [TenLoai]) VALUES (4, N'Loại Nhà Máy 4')
GO
INSERT [dbo].[loaiNhaMays] ([Id], [TenLoai]) VALUES (5, N'Loại Nhà Máy 5')
GO
INSERT [dbo].[loaiNhaMays] ([Id], [TenLoai]) VALUES (6, N'Loại Nhà Máy 6')
GO
SET IDENTITY_INSERT [dbo].[loaiNhaMays] OFF
GO
SET IDENTITY_INSERT [dbo].[nhaMays] ON 
GO
INSERT [dbo].[nhaMays] ([Id], [DoanhNghiepId], [LoaiNhaMayId], [LoaiLoNungId], [CongSuatThietKeId], [TenNhaMay], [TiLeCoPhan], [ViTri]) VALUES (1, 1, 1, 1, 1, N'Nhà Máy 1', 1, N'Hà Nội')
GO
SET IDENTITY_INSERT [dbo].[nhaMays] OFF
GO
SET IDENTITY_INSERT [dbo].[sanPhams] ON 
GO
INSERT [dbo].[sanPhams] ([Id], [TenSanPham], [KyHieu], [MaCode], [CongNghe], [CongSuatThietKe], [NhaMayId], [DuAnId], [LoaiLoNungId]) VALUES (1, N'Dép Lê', N'DL', N'001', N'Ép Dẻo', N'CS1', 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[sanPhams] OFF
GO
SET IDENTITY_INSERT [dbo].[LCAs] ON 
GO
INSERT [dbo].[LCAs] ([Id], [KyHieu], [ThuTu], [TenLCA]) VALUES (1, N'A1', 1, N'Khai Thác Nguyên Liệu')
GO
INSERT [dbo].[LCAs] ([Id], [KyHieu], [ThuTu], [TenLCA]) VALUES (2, N'A2', 2, N'Vận Chuyển')
GO
INSERT [dbo].[LCAs] ([Id], [KyHieu], [ThuTu], [TenLCA]) VALUES (3, N'A3', 3, N'Sản Xuất')
GO
INSERT [dbo].[LCAs] ([Id], [KyHieu], [ThuTu], [TenLCA]) VALUES (4, N'A4', 4, N'Vận Chuyển')
GO
INSERT [dbo].[LCAs] ([Id], [KyHieu], [ThuTu], [TenLCA]) VALUES (5, N'A5', 5, N'Xây Dựng Lắp Đặt')
GO
INSERT [dbo].[LCAs] ([Id], [KyHieu], [ThuTu], [TenLCA]) VALUES (6, N'B1', 6, N'Sử Dụng')
GO
INSERT [dbo].[LCAs] ([Id], [KyHieu], [ThuTu], [TenLCA]) VALUES (8, N'B2', 7, N'Bảo Trì')
GO
INSERT [dbo].[LCAs] ([Id], [KyHieu], [ThuTu], [TenLCA]) VALUES (9, N'B3', 8, N'Sửa Chữa')
GO
INSERT [dbo].[LCAs] ([Id], [KyHieu], [ThuTu], [TenLCA]) VALUES (10, N'B4', 9, N'Thay Thế')
GO
INSERT [dbo].[LCAs] ([Id], [KyHieu], [ThuTu], [TenLCA]) VALUES (11, N'B5', 10, N'Cải Tạo')
GO
INSERT [dbo].[LCAs] ([Id], [KyHieu], [ThuTu], [TenLCA]) VALUES (12, N'B6', 11, N'Sử Dụng Năng Lương Vận Hành')
GO
INSERT [dbo].[LCAs] ([Id], [KyHieu], [ThuTu], [TenLCA]) VALUES (13, N'B7', 12, N'Sử Dụng Nước Cho Vận Hành')
GO
INSERT [dbo].[LCAs] ([Id], [KyHieu], [ThuTu], [TenLCA]) VALUES (14, N'C1', 13, N'Phá Dỡ')
GO
INSERT [dbo].[LCAs] ([Id], [KyHieu], [ThuTu], [TenLCA]) VALUES (16, N'C2', 14, N'Vận Chuyển')
GO
INSERT [dbo].[LCAs] ([Id], [KyHieu], [ThuTu], [TenLCA]) VALUES (17, N'C3', 15, N'Quá Trì Xử Lý Chất Thải')
GO
INSERT [dbo].[LCAs] ([Id], [KyHieu], [ThuTu], [TenLCA]) VALUES (18, N'C4', 16, N'Thải Bỏ')
GO
INSERT [dbo].[LCAs] ([Id], [KyHieu], [ThuTu], [TenLCA]) VALUES (19, N'D', 17, N'Tái Sử Dụng, Thu Hồi, Tái Chế')
GO
SET IDENTITY_INSERT [dbo].[LCAs] OFF
GO
SET IDENTITY_INSERT [dbo].[tacDongs] ON 
GO
INSERT [dbo].[tacDongs] ([Id], [TenTacDong]) VALUES (1, N'Tiềm Năng Hiệu Ứng Nhà Kính')
GO
INSERT [dbo].[tacDongs] ([Id], [TenTacDong]) VALUES (2, N'Phá Hủy Tầng Ozon')
GO
INSERT [dbo].[tacDongs] ([Id], [TenTacDong]) VALUES (3, N'Tiềm Năng Tạo Ozzon Quang Hóa')
GO
INSERT [dbo].[tacDongs] ([Id], [TenTacDong]) VALUES (4, N'Sự Axit Hóa')
GO
INSERT [dbo].[tacDongs] ([Id], [TenTacDong]) VALUES (5, N'Phú Dưỡng')
GO
INSERT [dbo].[tacDongs] ([Id], [TenTacDong]) VALUES (6, N'Sử Dụng Năng Lượng Tái Tạo')
GO
INSERT [dbo].[tacDongs] ([Id], [TenTacDong]) VALUES (7, N'Sử Dụng Năng Lượng Không Tái Tạo')
GO
INSERT [dbo].[tacDongs] ([Id], [TenTacDong]) VALUES (8, N'Sử Dụng Năng Lượng Từ Nhiên Liệu Thay Thế')
GO
INSERT [dbo].[tacDongs] ([Id], [TenTacDong]) VALUES (9, N'Phát sinh bụi')
GO
INSERT [dbo].[tacDongs] ([Id], [TenTacDong]) VALUES (10, N'Chất thải nguy hại')
GO
INSERT [dbo].[tacDongs] ([Id], [TenTacDong]) VALUES (11, N'Chất thải không nguy hại')
GO
INSERT [dbo].[tacDongs] ([Id], [TenTacDong]) VALUES (12, N'Sử dụng nước')
GO
INSERT [dbo].[tacDongs] ([Id], [TenTacDong]) VALUES (13, N'Tạo ra năng lượng')
GO
SET IDENTITY_INSERT [dbo].[tacDongs] OFF
GO
SET IDENTITY_INSERT [dbo].[donViSanPhams] ON 
GO
INSERT [dbo].[donViSanPhams] ([Id], [TenDonVi]) VALUES (1, N'Kg/Kg Sản Phẩm')
GO
INSERT [dbo].[donViSanPhams] ([Id], [TenDonVi]) VALUES (2, N'kWh/kg Sản Phẩm')
GO
INSERT [dbo].[donViSanPhams] ([Id], [TenDonVi]) VALUES (3, N'm3/kg Sản Phẩm')
GO
INSERT [dbo].[donViSanPhams] ([Id], [TenDonVi]) VALUES (4, N'Kg/TJ')
GO
INSERT [dbo].[donViSanPhams] ([Id], [TenDonVi]) VALUES (5, N'Tấn CO2/tấn nguyên liệu')
GO
SET IDENTITY_INSERT [dbo].[donViSanPhams] OFF
GO
SET IDENTITY_INSERT [dbo].[donViDoTheoNams] ON 
GO
INSERT [dbo].[donViDoTheoNams] ([Id], [TenDonVi]) VALUES (1, N'Kg/Kg Sản Phẩm')
GO
INSERT [dbo].[donViDoTheoNams] ([Id], [TenDonVi]) VALUES (2, N'kWh/kg Sản Phẩm')
GO
INSERT [dbo].[donViDoTheoNams] ([Id], [TenDonVi]) VALUES (3, N'm3/kg Sản Phẩm')
GO
SET IDENTITY_INSERT [dbo].[donViDoTheoNams] OFF
GO
SET IDENTITY_INSERT [dbo].[loaiNguyenLieus] ON 
GO
INSERT [dbo].[loaiNguyenLieus] ([Id], [TenLoai]) VALUES (1, N'Rắn')
GO
INSERT [dbo].[loaiNguyenLieus] ([Id], [TenLoai]) VALUES (2, N'Khí')
GO
INSERT [dbo].[loaiNguyenLieus] ([Id], [TenLoai]) VALUES (3, N'Lỏng')
GO
SET IDENTITY_INSERT [dbo].[loaiNguyenLieus] OFF
GO
SET IDENTITY_INSERT [dbo].[nguyenLieus] ON 
GO
INSERT [dbo].[nguyenLieus] ([Id], [LoaiNguyenLieuId], [DonViDoTheoNamId], [TenNguyenLieu], [TenHienThiTieuThu]) VALUES (1, 1, 1, N'Đôlômit', N'Đôlômit')
GO
INSERT [dbo].[nguyenLieus] ([Id], [LoaiNguyenLieuId], [DonViDoTheoNamId], [TenNguyenLieu], [TenHienThiTieuThu]) VALUES (2, 1, 1, N'Đá vôi', N'Đá vôi')
GO
INSERT [dbo].[nguyenLieus] ([Id], [LoaiNguyenLieuId], [DonViDoTheoNamId], [TenNguyenLieu], [TenHienThiTieuThu]) VALUES (3, 1, 1, N'Đất sét', N'Đất sét')
GO
INSERT [dbo].[nguyenLieus] ([Id], [LoaiNguyenLieuId], [DonViDoTheoNamId], [TenNguyenLieu], [TenHienThiTieuThu]) VALUES (4, 1, 1, N'Thạch Cao', N'Thạch Cao')
GO
INSERT [dbo].[nguyenLieus] ([Id], [LoaiNguyenLieuId], [DonViDoTheoNamId], [TenNguyenLieu], [TenHienThiTieuThu]) VALUES (5, 1, 1, N'Hợp Chất Cacbonat', N'Hợp Chất Cacbonat')
GO
INSERT [dbo].[nguyenLieus] ([Id], [LoaiNguyenLieuId], [DonViDoTheoNamId], [TenNguyenLieu], [TenHienThiTieuThu]) VALUES (6, 1, 1, N'Kính', N'Kính')
GO
INSERT [dbo].[nguyenLieus] ([Id], [LoaiNguyenLieuId], [DonViDoTheoNamId], [TenNguyenLieu], [TenHienThiTieuThu]) VALUES (7, 1, 1, N'Clinker', N'Clinker')
GO
SET IDENTITY_INSERT [dbo].[nguyenLieus] OFF
GO
SET IDENTITY_INSERT [dbo].[loaiNhienLieus] ON 
GO
INSERT [dbo].[loaiNhienLieus] ([Id], [TenLoai]) VALUES (1, N'Rắn')
GO
INSERT [dbo].[loaiNhienLieus] ([Id], [TenLoai]) VALUES (2, N'Khí')
GO
INSERT [dbo].[loaiNhienLieus] ([Id], [TenLoai]) VALUES (3, N'Lỏng')
GO
INSERT [dbo].[loaiNhienLieus] ([Id], [TenLoai]) VALUES (4, N'Khác')
GO
SET IDENTITY_INSERT [dbo].[loaiNhienLieus] OFF
GO
SET IDENTITY_INSERT [dbo].[nhienLieus] ON 
GO
INSERT [dbo].[nhienLieus] ([Id], [LoaiNhienLieuId], [DonViDoTheoNamId], [TenNhienLieu], [TenHienThiTieuThu], [NhietTriRieng]) VALUES (2, 1, 1, N'Than', N'Tổng lượng than tiêu thụ', 25.122)
GO
INSERT [dbo].[nhienLieus] ([Id], [LoaiNhienLieuId], [DonViDoTheoNamId], [TenNhienLieu], [TenHienThiTieuThu], [NhietTriRieng]) VALUES (3, 3, 1, N'Dầu FO', N'Tổng lượng dầu FO tiêu thụ', 41.4513)
GO
INSERT [dbo].[nhienLieus] ([Id], [LoaiNhienLieuId], [DonViDoTheoNamId], [TenNhienLieu], [TenHienThiTieuThu], [NhietTriRieng]) VALUES (4, 3, 1, N'Dầu DO', N'Tổng lượng dầu DO tiêu thụ', 42.7074)
GO
INSERT [dbo].[nhienLieus] ([Id], [LoaiNhienLieuId], [DonViDoTheoNamId], [TenNhienLieu], [TenHienThiTieuThu], [NhietTriRieng]) VALUES (6, 3, 1, N'LPG', N'Tổng lượng LPG tiêu thụ', 45.6383)
GO
INSERT [dbo].[nhienLieus] ([Id], [LoaiNhienLieuId], [DonViDoTheoNamId], [TenNhienLieu], [TenHienThiTieuThu], [NhietTriRieng]) VALUES (7, 2, 1, N'CNG', N'Tổng lượng CNG tiêu thụ', 46.85)
GO
INSERT [dbo].[nhienLieus] ([Id], [LoaiNhienLieuId], [DonViDoTheoNamId], [TenNhienLieu], [TenHienThiTieuThu], [NhietTriRieng]) VALUES (8, 4, 1, N'Sinh Khối', N'Tổng lượng sinh khối tiêu thụ', 15)
GO
INSERT [dbo].[nhienLieus] ([Id], [LoaiNhienLieuId], [DonViDoTheoNamId], [TenNhienLieu], [TenHienThiTieuThu], [NhietTriRieng]) VALUES (9, 4, 1, N'Chất Thải Công Nghiệp', N'Tổng lượng chất thải công nghiệp tiêu thụ', 11.25)
GO
INSERT [dbo].[nhienLieus] ([Id], [LoaiNhienLieuId], [DonViDoTheoNamId], [TenNhienLieu], [TenHienThiTieuThu], [NhietTriRieng]) VALUES (10, 4, 2, N'Điện năng', N'Tổng lượng điện năng mua từ lưới điện', 0)
GO
INSERT [dbo].[nhienLieus] ([Id], [LoaiNhienLieuId], [DonViDoTheoNamId], [TenNhienLieu], [TenHienThiTieuThu], [NhietTriRieng]) VALUES (11, 4, 2, N'Điện năng', N'Lượng điện năng tiêu thụ cho sản xuất', 0)
GO
INSERT [dbo].[nhienLieus] ([Id], [LoaiNhienLieuId], [DonViDoTheoNamId], [TenNhienLieu], [TenHienThiTieuThu], [NhietTriRieng]) VALUES (12, 4, 2, N'Điện năng', N'Lượng điện tiêu thụ cho sinh hoạt', 0)
GO
INSERT [dbo].[nhienLieus] ([Id], [LoaiNhienLieuId], [DonViDoTheoNamId], [TenNhienLieu], [TenHienThiTieuThu], [NhietTriRieng]) VALUES (13, 4, 2, N'Điện', N'Lượng điện tự sản xuất', 0)
GO
INSERT [dbo].[nhienLieus] ([Id], [LoaiNhienLieuId], [DonViDoTheoNamId], [TenNhienLieu], [TenHienThiTieuThu], [NhietTriRieng]) VALUES (14, 3, 3, N'Nước sạch', N'Tổng lượng nước sạch tiêu thụ', 0)
GO
INSERT [dbo].[nhienLieus] ([Id], [LoaiNhienLieuId], [DonViDoTheoNamId], [TenNhienLieu], [TenHienThiTieuThu], [NhietTriRieng]) VALUES (16, 3, 3, N'Nước sạch', N'Lượng nước sạch tiêu thụ cho sản xuất', 0)
GO
INSERT [dbo].[nhienLieus] ([Id], [LoaiNhienLieuId], [DonViDoTheoNamId], [TenNhienLieu], [TenHienThiTieuThu], [NhietTriRieng]) VALUES (17, 3, 3, N'Nước sạch', N'Lượng nước sạch tiêu thụ cho sinh hoạt', 0)
GO
SET IDENTITY_INSERT [dbo].[nhienLieus] OFF
GO
SET IDENTITY_INSERT [dbo].[loaiChatThais] ON 
GO
INSERT [dbo].[loaiChatThais] ([Id], [TenLoaiChatThai]) VALUES (1, N'Rắn')
GO
INSERT [dbo].[loaiChatThais] ([Id], [TenLoaiChatThai]) VALUES (2, N'Lỏng')
GO
INSERT [dbo].[loaiChatThais] ([Id], [TenLoaiChatThai]) VALUES (3, N'Khí')
GO
INSERT [dbo].[loaiChatThais] ([Id], [TenLoaiChatThai]) VALUES (4, N'Khác')
GO
SET IDENTITY_INSERT [dbo].[loaiChatThais] OFF
GO
SET IDENTITY_INSERT [dbo].[chatThais] ON 
GO
INSERT [dbo].[chatThais] ([Id], [LoaiChatThaiId], [TenChatThai]) VALUES (1, 1, N'Chất thải rắn thông thường')
GO
INSERT [dbo].[chatThais] ([Id], [LoaiChatThaiId], [TenChatThai]) VALUES (2, 1, N'Chất thải rắn nguy hại')
GO
INSERT [dbo].[chatThais] ([Id], [LoaiChatThaiId], [TenChatThai]) VALUES (3, 2, N'COD')
GO
INSERT [dbo].[chatThais] ([Id], [LoaiChatThaiId], [TenChatThai]) VALUES (4, 2, N'N')
GO
INSERT [dbo].[chatThais] ([Id], [LoaiChatThaiId], [TenChatThai]) VALUES (5, 2, N'P')
GO
INSERT [dbo].[chatThais] ([Id], [LoaiChatThaiId], [TenChatThai]) VALUES (6, 2, N'PO4')
GO
INSERT [dbo].[chatThais] ([Id], [LoaiChatThaiId], [TenChatThai]) VALUES (7, 2, N'NH4')
GO
INSERT [dbo].[chatThais] ([Id], [LoaiChatThaiId], [TenChatThai]) VALUES (8, 2, N'NO')
GO
INSERT [dbo].[chatThais] ([Id], [LoaiChatThaiId], [TenChatThai]) VALUES (9, 2, N'NO2')
GO
INSERT [dbo].[chatThais] ([Id], [LoaiChatThaiId], [TenChatThai]) VALUES (10, 2, N'NOx')
GO
INSERT [dbo].[chatThais] ([Id], [LoaiChatThaiId], [TenChatThai]) VALUES (11, 3, N'SO2')
GO
INSERT [dbo].[chatThais] ([Id], [LoaiChatThaiId], [TenChatThai]) VALUES (12, 3, N'NOx')
GO
INSERT [dbo].[chatThais] ([Id], [LoaiChatThaiId], [TenChatThai]) VALUES (13, 3, N'NH3')
GO
INSERT [dbo].[chatThais] ([Id], [LoaiChatThaiId], [TenChatThai]) VALUES (14, 3, N'NO')
GO
INSERT [dbo].[chatThais] ([Id], [LoaiChatThaiId], [TenChatThai]) VALUES (15, 3, N'NO2')
GO
INSERT [dbo].[chatThais] ([Id], [LoaiChatThaiId], [TenChatThai]) VALUES (16, 3, N'Bụi')
GO
INSERT [dbo].[chatThais] ([Id], [LoaiChatThaiId], [TenChatThai]) VALUES (17, 3, N'CF2CL2')
GO
INSERT [dbo].[chatThais] ([Id], [LoaiChatThaiId], [TenChatThai]) VALUES (18, 3, N'C2F3Cl3')
GO
INSERT [dbo].[chatThais] ([Id], [LoaiChatThaiId], [TenChatThai]) VALUES (19, 3, N'C2F4Cl2')
GO
INSERT [dbo].[chatThais] ([Id], [LoaiChatThaiId], [TenChatThai]) VALUES (20, 3, N'CH4')
GO
INSERT [dbo].[chatThais] ([Id], [LoaiChatThaiId], [TenChatThai]) VALUES (21, 3, N'CFCl3')
GO
INSERT [dbo].[chatThais] ([Id], [LoaiChatThaiId], [TenChatThai]) VALUES (22, 3, N'C2F5Cl')
GO
INSERT [dbo].[chatThais] ([Id], [LoaiChatThaiId], [TenChatThai]) VALUES (23, 3, N'CCL4')
GO
SET IDENTITY_INSERT [dbo].[chatThais] OFF
GO
SET IDENTITY_INSERT [dbo].[khiPhatThais] ON 
GO
INSERT [dbo].[khiPhatThais] ([Id], [TenKhi]) VALUES (1, N'CO2')
GO
INSERT [dbo].[khiPhatThais] ([Id], [TenKhi]) VALUES (2, N'CH4')
GO
INSERT [dbo].[khiPhatThais] ([Id], [TenKhi]) VALUES (3, N'N2O')
GO
SET IDENTITY_INSERT [dbo].[khiPhatThais] OFF
GO
SET IDENTITY_INSERT [dbo].[gayNongLenToanCaus] ON 
GO
INSERT [dbo].[gayNongLenToanCaus] ([Id], [KhiPhatThaiId], [GiaTri]) VALUES (1, 1, 1)
GO
INSERT [dbo].[gayNongLenToanCaus] ([Id], [KhiPhatThaiId], [GiaTri]) VALUES (2, 2, 25)
GO
INSERT [dbo].[gayNongLenToanCaus] ([Id], [KhiPhatThaiId], [GiaTri]) VALUES (3, 3, 298)
GO
SET IDENTITY_INSERT [dbo].[gayNongLenToanCaus] OFF
GO
SET IDENTITY_INSERT [dbo].[heSoPhatThaiDiens] ON 
GO
INSERT [dbo].[heSoPhatThaiDiens] ([Id], [KhiPhatThaiId], [Nam], [GiaTri]) VALUES (1, 1, 2016, 0.8154)
GO
INSERT [dbo].[heSoPhatThaiDiens] ([Id], [KhiPhatThaiId], [Nam], [GiaTri]) VALUES (2, 1, 2017, 0.8469)
GO
SET IDENTITY_INSERT [dbo].[heSoPhatThaiDiens] OFF
GO
SET IDENTITY_INSERT [dbo].[loNungTrongNhaMays] ON 
GO
INSERT [dbo].[loNungTrongNhaMays] ([Id], [LoaiLoNungId], [NhaMayId]) VALUES (2, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[loNungTrongNhaMays] OFF
GO


SET IDENTITY_INSERT dbo.heSoPhatThaiTuNguyenLieus ON
GO
INSERT [dbo].[heSoPhatThaiTuNguyenLieus] ([Id],[KhiPhatThaiId],[NguyenLieuId],[DonViTinhId],[GiaTri]) VALUES (1, 1, 1,1,0.4773)
GO
INSERT [dbo].[heSoPhatThaiTuNguyenLieus] ([Id],[KhiPhatThaiId],[NguyenLieuId],[DonViTinhId],[GiaTri]) VALUES (2, 1, 2,1,0.76)
GO
INSERT [dbo].[heSoPhatThaiTuNguyenLieus] ([Id],[KhiPhatThaiId],[NguyenLieuId],[DonViTinhId],[GiaTri]) VALUES (3, 1, 3,1,0.028)
GO
INSERT [dbo].[heSoPhatThaiTuNguyenLieus] ([Id],[KhiPhatThaiId],[NguyenLieuId],[DonViTinhId],[GiaTri]) VALUES (4, 1, 6,1,0.21)
GO
INSERT [dbo].[heSoPhatThaiTuNguyenLieus] ([Id],[KhiPhatThaiId],[NguyenLieuId],[DonViTinhId],[GiaTri]) VALUES (5, 1, 7,1,0.525)
GO
SET IDENTITY_INSERT dbo.heSoPhatThaiTuNguyenLieus OFF

SET IDENTITY_INSERT[dbo].[heSoPhatThaiTuNhienLieus] ON
GO
INSERT dbo.heSoPhatThaiTuNhienLieus (Id,KhiPhatThaiId,NhienLieuId,DonViTinhId,GiaTri) VALUES (1,1,2,1,98300)
GO
INSERT dbo.heSoPhatThaiTuNhienLieus (Id,KhiPhatThaiId,NhienLieuId,DonViTinhId,GiaTri) VALUES (2,2,2,1,10)
GO
INSERT dbo.heSoPhatThaiTuNhienLieus (Id,KhiPhatThaiId,NhienLieuId,DonViTinhId,GiaTri) VALUES (3,3,2,1,1.5)
GO
INSERT dbo.heSoPhatThaiTuNhienLieus (Id,KhiPhatThaiId,NhienLieuId,DonViTinhId,GiaTri) VALUES (4,1,3,1,98300)
GO
INSERT dbo.heSoPhatThaiTuNhienLieus (Id,KhiPhatThaiId,NhienLieuId,DonViTinhId,GiaTri) VALUES (5,2,3,1,10)
GO
INSERT dbo.heSoPhatThaiTuNhienLieus (Id,KhiPhatThaiId,NhienLieuId,DonViTinhId,GiaTri) VALUES (6,3,3,1,1.5)
GO
INSERT dbo.heSoPhatThaiTuNhienLieus (Id,KhiPhatThaiId,NhienLieuId,DonViTinhId,GiaTri) VALUES (7,1,4,1,98300)
GO
INSERT dbo.heSoPhatThaiTuNhienLieus (Id,KhiPhatThaiId,NhienLieuId,DonViTinhId,GiaTri) VALUES (8,2,4,1,10)
GO
INSERT dbo.heSoPhatThaiTuNhienLieus (Id,KhiPhatThaiId,NhienLieuId,DonViTinhId,GiaTri) VALUES (9,3,4,1,1.5)
GO
INSERT dbo.heSoPhatThaiTuNhienLieus (Id,KhiPhatThaiId,NhienLieuId,DonViTinhId,GiaTri) VALUES (10,1,6,1,98300)
GO
INSERT dbo.heSoPhatThaiTuNhienLieus (Id,KhiPhatThaiId,NhienLieuId,DonViTinhId,GiaTri) VALUES (11,2,6,1,10)
GO
INSERT dbo.heSoPhatThaiTuNhienLieus (Id,KhiPhatThaiId,NhienLieuId,DonViTinhId,GiaTri) VALUES (12,3,6,1,1.5)
GO
INSERT dbo.heSoPhatThaiTuNhienLieus (Id,KhiPhatThaiId,NhienLieuId,DonViTinhId,GiaTri) VALUES (13,1,7,1,98300)
GO
INSERT dbo.heSoPhatThaiTuNhienLieus (Id,KhiPhatThaiId,NhienLieuId,DonViTinhId,GiaTri) VALUES (14,2,7,1,10)
GO
INSERT dbo.heSoPhatThaiTuNhienLieus (Id,KhiPhatThaiId,NhienLieuId,DonViTinhId,GiaTri) VALUES (15,3,7,1,1.5)
GO
INSERT dbo.heSoPhatThaiTuNhienLieus (Id,KhiPhatThaiId,NhienLieuId,DonViTinhId,GiaTri) VALUES (16,1,8,1,98300)
GO
INSERT dbo.heSoPhatThaiTuNhienLieus (Id,KhiPhatThaiId,NhienLieuId,DonViTinhId,GiaTri) VALUES (17,2,8,1,10)
GO
INSERT dbo.heSoPhatThaiTuNhienLieus (Id,KhiPhatThaiId,NhienLieuId,DonViTinhId,GiaTri) VALUES (18,3,8,1,1.5)
GO
INSERT dbo.heSoPhatThaiTuNhienLieus (Id,KhiPhatThaiId,NhienLieuId,DonViTinhId,GiaTri) VALUES (19,1,9,1,98300)
GO
INSERT dbo.heSoPhatThaiTuNhienLieus (Id,KhiPhatThaiId,NhienLieuId,DonViTinhId,GiaTri) VALUES (20,2,9,1,10)
GO
INSERT dbo.heSoPhatThaiTuNhienLieus (Id,KhiPhatThaiId,NhienLieuId,DonViTinhId,GiaTri) VALUES (21,3,9,1,1.5)
GO

SET IDENTITY_INSERT[dbo].[heSoPhatThaiTuNhienLieus] OFF
GO

INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230824043756_initv.1', N'6.0.21')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230828030257_updateentity', N'6.0.21')
GO
