USE CSDL_QLKS
GO

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE[dbo].[CheckOut](
	@phong_id INT,
	@qua_dem INT = 0,
	@phu_thu NUMERIC(28, 12) = NULL,
	@NguyenNhan VARCHAR(256) = NULL)
AS BEGIN -- SP Body
/***********************************************
** Author:		Quan Phan
** Create date: 2009-03-01
**
**	Description:	Check out a room
**
**	Example:
		DECLARE @er_code INT
		EXECUTE @er_code = dbo.CheckOut 1
		SELECT @er_code
**
************************************************
**	Plan
**
************************************************
**	Params
**	________________________________
**	@phong_id int
**	 
***********************************************/

	SET NOCOUNT ON;
	DECLARE	@gio_batdau datetime, @gio_ketthuc datetime, @thanhtien Numeric(28,12)

--	1.	Standardize input
	IF NOT EXISTS(SELECT 1 FROM dbo.Phong WHERE phong_id = @phong_id)
	BEGIN
		EXEC dbo.Raise_UDF_Error 'MissingRoom', @phong_id;
		RETURN;
	END

	-- If the room is not check out (is currently available)
	IF dbo.is_AvailableRoom(@phong_id) = 1 OR NOT EXISTS(	SELECT 1 FROM dbo.Phong_TrangThai
															WHERE phong_id = @phong_id)
	BEGIN
		EXEC dbo.Raise_UDF_Error 'NotCheckIn', @phong_id;
		RETURN;
	END


--	2.	Prepare values
	-- Get the id of the status
	DECLARE @trangthai_id INT;
	SET @trangthai_id = dbo.get_trangthaiid('trong');

	-- Get the check in time;
	SELECT @gio_batdau = gio_batdau, @gio_ketthuc = GETDATE()
	FROM dbo.Phong_TrangThai
	WHERE phong_id = @phong_id;

--	3.	Another check, check in time > check out time
	IF (@gio_batdau > GETDATE())
	RETURN dbo.get_errid('invalidCheckInTime');

--	4.	Update status
	UPDATE dbo.Phong_TrangThai
	SET trangthai_id = @trangthai_id,
		is_hoatdong = 0,
		is_conguoi = 0,
		gio_ketthuc = GETDATE(),
		last_update = GETDATE(),
		update_by = SYSTEM_USER
	WHERE phong_id = @phong_id;

--	5.	Calculate money spend
	SET @thanhtien = dbo.calc_payment(@gio_batdau, @gio_ketthuc, @qua_dem);
	SET @thanhtien = @thanhtien + ISNULL(@phu_thu, 0);
 
	DECLARE @mota VARCHAR(512)
	SET @mota = 'Tien Muon Phong' + ISNULL('+ Phu thu: ' + CAST(@phu_thu AS VARCHAR) + ' == Ly do: ' + @nguyennhan, '');

--	6.	Trace to ThuNhap table
	EXEC dbo.ins_ThuNhap @phong_id , @thanhtien, @mota;
 

	INSERT INTO TacVu_Hist(TacVu_ID, Description)
	SELECT dbo.get_TacVuID('chkOut'), 'Tra phong: ' + CAST(@phong_id AS VARCHAR);

	SELECT @gio_batdau [Gio Bat Dau], @gio_ketthuc [Gio Ket Thuc],	@thanhtien [Thanh Tien]
	RETURN 0;
END -- SP Body
GO





