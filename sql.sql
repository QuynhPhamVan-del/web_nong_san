USE [master]
GO
/****** Object:  Database [Web_Nong_San]    Script Date: 12/3/2024 8:43:36 PM ******/
CREATE DATABASE [Web_Nong_San]
go
USE [Web_Nong_San]
GO
/****** Object:  Table [dbo].[Banner]    Script Date: 12/3/2024 8:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banner](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenBanner] [nvarchar](max) NULL,
	[Link] [nvarchar](max) NULL,
	[ThuTu] [int] NULL,
	[IsDelete] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhGia]    Script Date: 12/3/2024 8:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhGia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DiemDanhGia] [int] NULL,
	[NoiDung] [nvarchar](500) NULL,
	[IsHienThi] [bit] NULL,
	[IdSP] [int] NULL,
 CONSTRAINT [PK_DanhGia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiaPhuong]    Script Date: 12/3/2024 8:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiaPhuong](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenDiaPhuong] [nvarchar](200) NULL,
	[HinhAnh] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 12/3/2024 8:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiSP] [nvarchar](200) NULL,
	[CapMenu] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 12/3/2024 8:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenSP] [nvarchar](200) NULL,
	[HinhAnh] [nvarchar](max) NULL,
	[GiaTien] [float] NULL,
	[MoTa] [nvarchar](max) NULL,
	[IdTK] [int] NULL,
	[IdDiaPhuong] [int] NULL,
	[TinhTrang] [bit] NULL,
	[NgayDang] [datetime] NULL,
	[HSD] [int] NULL,
	[GiamGia] [int] NULL,
	[SoLuongBan] [int] NULL,
	[IdLoai] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 12/3/2024 8:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](200) NULL,
	[PhanQuyen] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongTin]    Script Date: 12/3/2024 8:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](200) NULL,
	[SDT] [varchar](20) NULL,
	[Email] [nvarchar](200) NULL,
	[DiaChi] [nvarchar](500) NULL,
	[CMND] [varchar](20) NULL,
	[IdDiaPhuong] [int] NULL,
	[IdTK] [int] NULL,
	[Avatar] [nvarchar](max) NULL,
	[GioiThieu] [nvarchar](max) NULL,
	[NgaySinh] [datetime] NULL,
	[GioiTinh] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TinTuc]    Script Date: 12/3/2024 8:43:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TinTuc](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TieuDe] [nvarchar](200) NULL,
	[NoiDung] [nvarchar](max) NULL,
	[NgayDang] [datetime] NULL,
	[AnhDaiDien] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Banner] ON 

INSERT [dbo].[Banner] ([Id], [TenBanner], [Link], [ThuTu], [IsDelete]) VALUES (1, N'Banner 1', N'../Upload/Banner/bg_home_1.png', 1, 0)
INSERT [dbo].[Banner] ([Id], [TenBanner], [Link], [ThuTu], [IsDelete]) VALUES (2, N'Banner 2', N'../Upload/Banner/bg_home_2.png', 2, 0)
INSERT [dbo].[Banner] ([Id], [TenBanner], [Link], [ThuTu], [IsDelete]) VALUES (3, N'Banner 3', N'../Upload/Banner/bg_home_3.png', 3, 0)
INSERT [dbo].[Banner] ([Id], [TenBanner], [Link], [ThuTu], [IsDelete]) VALUES (4, N'Banner 4', N'../Upload/Banner/bg_home_4.png', 4, 0)
INSERT [dbo].[Banner] ([Id], [TenBanner], [Link], [ThuTu], [IsDelete]) VALUES (5, N'Banner 5', N'../Upload/Banner/bg_home_5.png', 5, 0)
SET IDENTITY_INSERT [dbo].[Banner] OFF
GO
SET IDENTITY_INSERT [dbo].[DiaPhuong] ON 

INSERT [dbo].[DiaPhuong] ([Id], [TenDiaPhuong], [HinhAnh]) VALUES (1, N'Thành phố Hạ Long', NULL)
INSERT [dbo].[DiaPhuong] ([Id], [TenDiaPhuong], [HinhAnh]) VALUES (2, N'Thành phố Cẩm Phả', NULL)
INSERT [dbo].[DiaPhuong] ([Id], [TenDiaPhuong], [HinhAnh]) VALUES (3, N'Huyện Bình Liêu', NULL)
INSERT [dbo].[DiaPhuong] ([Id], [TenDiaPhuong], [HinhAnh]) VALUES (4, N'Huyện Đầm Hà', NULL)
INSERT [dbo].[DiaPhuong] ([Id], [TenDiaPhuong], [HinhAnh]) VALUES (5, N'Huyện Ba Chẽ', NULL)
INSERT [dbo].[DiaPhuong] ([Id], [TenDiaPhuong], [HinhAnh]) VALUES (6, N'Thị xã Đông Triều', NULL)
INSERT [dbo].[DiaPhuong] ([Id], [TenDiaPhuong], [HinhAnh]) VALUES (7, N'Huyện Cô Tô', NULL)
INSERT [dbo].[DiaPhuong] ([Id], [TenDiaPhuong], [HinhAnh]) VALUES (8, N'Thành phố Móng Cái', NULL)
INSERT [dbo].[DiaPhuong] ([Id], [TenDiaPhuong], [HinhAnh]) VALUES (9, N'Thành phố Uông Bí', NULL)
INSERT [dbo].[DiaPhuong] ([Id], [TenDiaPhuong], [HinhAnh]) VALUES (10, N'Huyện Tiên Yên', NULL)
INSERT [dbo].[DiaPhuong] ([Id], [TenDiaPhuong], [HinhAnh]) VALUES (11, N'Huyện Hải Hà', NULL)
INSERT [dbo].[DiaPhuong] ([Id], [TenDiaPhuong], [HinhAnh]) VALUES (12, N'Huyện Vân Đồn', NULL)
INSERT [dbo].[DiaPhuong] ([Id], [TenDiaPhuong], [HinhAnh]) VALUES (13, N'Thị xã Quảng Yên', NULL)
SET IDENTITY_INSERT [dbo].[DiaPhuong] OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiSanPham] ON 

INSERT [dbo].[LoaiSanPham] ([Id], [TenLoaiSP], [CapMenu]) VALUES (1, N'Hoa quả', 2)
INSERT [dbo].[LoaiSanPham] ([Id], [TenLoaiSP], [CapMenu]) VALUES (2, N'Rau củ', 2)
INSERT [dbo].[LoaiSanPham] ([Id], [TenLoaiSP], [CapMenu]) VALUES (3, N'Đặc sản', 2)
INSERT [dbo].[LoaiSanPham] ([Id], [TenLoaiSP], [CapMenu]) VALUES (4, N'Hải sản', 2)
INSERT [dbo].[LoaiSanPham] ([Id], [TenLoaiSP], [CapMenu]) VALUES (5, N'Ngũ cốc và hạt', 2)
INSERT [dbo].[LoaiSanPham] ([Id], [TenLoaiSP], [CapMenu]) VALUES (6, N'Dược liệu', 2)
INSERT [dbo].[LoaiSanPham] ([Id], [TenLoaiSP], [CapMenu]) VALUES (7, N'Trà', 1)
INSERT [dbo].[LoaiSanPham] ([Id], [TenLoaiSP], [CapMenu]) VALUES (8, N'Thực phẩm hữu cơ', 1)
SET IDENTITY_INSERT [dbo].[LoaiSanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([Id], [TenSP], [HinhAnh], [GiaTien], [MoTa], [IdTK], [IdDiaPhuong], [TinhTrang], [NgayDang], [HSD], [GiamGia], [SoLuongBan], [IdLoai]) VALUES (1, N'Mật ong thiên nhiên', N'product_1.png', 20000, NULL, 2, 2, 1, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 180, 5, 2, 3)
INSERT [dbo].[SanPham] ([Id], [TenSP], [HinhAnh], [GiaTien], [MoTa], [IdTK], [IdDiaPhuong], [TinhTrang], [NgayDang], [HSD], [GiamGia], [SoLuongBan], [IdLoai]) VALUES (2, N'Mật ong thiên nhiên', N'product_1.png', 20000, NULL, 2, 3, 1, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 180, 7, 4, 3)
INSERT [dbo].[SanPham] ([Id], [TenSP], [HinhAnh], [GiaTien], [MoTa], [IdTK], [IdDiaPhuong], [TinhTrang], [NgayDang], [HSD], [GiamGia], [SoLuongBan], [IdLoai]) VALUES (3, N'Mật ong thiên nhiên', N'product_1.png', 20000, NULL, 2, 5, 1, CAST(N'2024-12-02T00:00:00.000' AS DateTime), 180, 9, 6, 3)
INSERT [dbo].[SanPham] ([Id], [TenSP], [HinhAnh], [GiaTien], [MoTa], [IdTK], [IdDiaPhuong], [TinhTrang], [NgayDang], [HSD], [GiamGia], [SoLuongBan], [IdLoai]) VALUES (7, N'Sữa Blackmores JNR Balance+ 1-10Y', N'tt6.png', 34000, N'test', 2, NULL, 1, CAST(N'2024-12-03T15:45:25.983' AS DateTime), 360, 5, 0, 5)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([Id], [TenDangNhap], [MatKhau], [PhanQuyen]) VALUES (1, N'phamthanhhuyen', N'123456', 2)
INSERT [dbo].[TaiKhoan] ([Id], [TenDangNhap], [MatKhau], [PhanQuyen]) VALUES (2, N'vanquynh98hy', N'Vanquynh98@', 2)
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
GO
SET IDENTITY_INSERT [dbo].[ThongTin] ON 

INSERT [dbo].[ThongTin] ([Id], [HoTen], [SDT], [Email], [DiaChi], [CMND], [IdDiaPhuong], [IdTK], [Avatar], [GioiThieu], [NgaySinh], [GioiTinh]) VALUES (1, N'Quỳnh', N'0866952668', N'vanquynh98@gmail.com', N'hạ long', N'033098008012', 3, 2, N'sogoku.png', N'test', CAST(N'1998-04-14T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[ThongTin] ([Id], [HoTen], [SDT], [Email], [DiaChi], [CMND], [IdDiaPhuong], [IdTK], [Avatar], [GioiThieu], [NgaySinh], [GioiTinh]) VALUES (2, N'Huyền', N'0866952668', N'huyen@gmail.com', N'hạ long', N'033098008019', 2, 1, N'sogoku.png', N'test', CAST(N'1998-04-14T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[ThongTin] OFF
GO
USE [master]
GO
ALTER DATABASE [Web_Nong_San] SET  READ_WRITE 
GO
