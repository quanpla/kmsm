USE CSDL_QLKS
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
go

ALTER PROCEDURE[dbo].[CheckIn](@phong_id INT)
AS BEGIN -- SP Body
/***********************************************
** Author:		Quan Phan
** Create date: 2009-03-01
**
**	Description:	Check in a room
**
**	Example:
		DECLARE @er_code INT
		EXECUTE @er_code = dbo.checkIn 3
		SELECT @er_code
**
**	Returns error in Error_Lookup table
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

--	1.	Standardize input
	IF NOT EXISTS(SELECT 1 FROM dbo.Phong WHERE phong_id = @phong_id)
	BEGIN
		EXEC dbo.Raise_UDF_Error 'MissingRoom', @phong_id;
		RETURN;
	END

	-- If the room not available
	IF dbo.is_AvailableRoom(@phong_id) = 0
	BEGIN
		EXEC dbo.Raise_UDF_Error 'NotAvailRoom', @phong_id;
		RETURN;
	END

--	2.	Prepare values
	-- Get the id of the status
	DECLARE @trangthai_id INT;
	SET @trangthai_id = dbo.get_trangthaiid('muon');

--	3.	If the status record not exists, insert new one, else update status
	IF NOT EXISTS(	SELECT 1 FROM dbo.Phong_TrangThai
					WHERE phong_id = @phong_id)
	BEGIN
		INSERT INTO dbo.Phong_TrangThai(phong_id, trangthai_id, is_hoatdong, is_conguoi, gio_batdau, gio_ketthuc)
		VALUES (@phong_id, @trangthai_id, 1/*is active*/, 1/*is occupied*/, GETDATE(), NULL /*No end date*/);
	END
	ELSE
	BEGIN
		UPDATE dbo.Phong_TrangThai
		SET trangthai_id = @trangthai_id,
			is_hoatdong = 1,
			is_conguoi = 1,
			gio_batdau = GETDATE(),
			gio_ketthuc = NULL,
			last_update = GETDATE(),
			update_by = SYSTEM_USER
		WHERE phong_id = @phong_id;
	END

		-- log it
		INSERT INTO TacVu_Hist(TacVu_ID, Description)
		SELECT dbo.get_TacVuid('chkIn'), 'Dang ky phong: ' + CAST(@phong_id AS VARCHAR);

	RETURN 0;
END -- SP Body



