USE CSDL_QLKS
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
go





ALTER PROCEDURE[dbo].[list_AllRooms](@order_by INT = 1)
AS BEGIN
-- =============================================
-- Author:		Quan Phan
-- Create date: 2009-03-01
-- Description:	List All Room + Detail
-- order	= 1: room name
--			= 2: Mo Ta, Room Name
--			= 3: TrangThai_D, Room Name
--			= 4: Gia, Room Name
-- =============================================
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF @order_by = 1
		SELECT	phong.phong_id, phong.phong_cd [TenPhong],
				ISNULL(phong.mota, '') [MoTa],
				CASE Phong_TrangThai.is_hoatdong WHEN 1 THEN 0 ELSE 1 END [Trong],
				--ISNULL(TrangThai.trangthai,'') [TrangThai],
				TrangThai.TrangThai_ID
		FROM dbo.Phong LEFT JOIN dbo.Phong_TrangThai
			ON Phong.phong_id = Phong_TrangThai.phong_id
				JOIN dbo.TrangThai
			ON TrangThai.trangthai_id = ISNULL(Phong_TrangThai.trangthai_id, 1)
		ORDER BY phong.phong_cd;

	IF @order_by = 2
		SELECT	phong.phong_id, phong.phong_cd [TenPhong],
				ISNULL(phong.mota, '') [MoTa],
				CASE Phong_TrangThai.is_hoatdong WHEN 1 THEN 0 ELSE 1 END [Trong],
				--ISNULL(TrangThai.trangthai,'') [TrangThai],
				TrangThai.TrangThai_ID
		FROM dbo.Phong LEFT JOIN dbo.Phong_TrangThai
			ON Phong.phong_id = Phong_TrangThai.phong_id
				JOIN dbo.TrangThai
			ON TrangThai.trangthai_id = ISNULL(Phong_TrangThai.trangthai_id, 1)
		ORDER BY ISNULL(phong.mota, ''), phong.phong_cd;

	IF @order_by = 3
		SELECT	phong.phong_id, phong.phong_cd [TenPhong],
				ISNULL(phong.mota, '') [MoTa],
				CASE Phong_TrangThai.is_hoatdong WHEN 1 THEN 0 ELSE 1 END [Trong],
				--ISNULL(TrangThai.trangthai,'') [TrangThai],
				TrangThai.TrangThai_ID
		FROM dbo.Phong LEFT JOIN dbo.Phong_TrangThai
			ON Phong.phong_id = Phong_TrangThai.phong_id
				JOIN dbo.TrangThai
			ON TrangThai.trangthai_id = ISNULL(Phong_TrangThai.trangthai_id, 1)
		ORDER BY TrangThai.TrangThai_ID, phong.phong_cd;

	SET NOCOUNT OFF;
END



