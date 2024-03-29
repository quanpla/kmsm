USE CSDL_QLKS
GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
go

ALTER FUNCTION dbo.calc_payment(
	@gio_batdau datetime,
	@gio_ketthuc datetime,
	@qua_dem INT = 0) -- ngu qua dem
RETURNS NUMERIC(28,12)
AS BEGIN -- FN Body
/***********************************************
** Author:		Quan Phan
** Create date: 2009-03-01
**
**	Description:	calculate and record the payment
**
**	Example:

SELECT dbo.calc_payment('2009-01-01 23:00:00', '2009-01-02 1:00:00', 1)

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
	IF(DATEDIFF(d, @gio_batdau, @gio_ketthuc) = 0)
		SET @qua_dem = 0;
	DECLARE @thanhtien NUMERIC(28,12);

	DECLARE @GioQuaDem_batdau INT, @GioQuaDem_ketthuc INT;
	SELECT @GioQuaDem_batdau = 22, @GioQuaDem_ketthuc = 12;

	DECLARE @phutToiThieu INT;
	SET @phutToiThieu = 13;

--	1.	Get the price level
	DECLARE @px_1h NUMERIC(28,12),
			@px_2h NUMERIC(28,12),
			@px_3h NUMERIC(28,12),
			@px_quadem NUMERIC(28,12),
			@px_ngay NUMERIC(28,12),
			@px_them NUMERIC(28,12),
			@gia_trave NUMERIC(28,12);
	SELECT @px_1h = gia FROM dbo.BangGia WHERE banggia_cd = '1gio';
	SELECT @px_2h = gia FROM dbo.BangGia WHERE banggia_cd = '2gio';
	SELECT @px_3h = gia FROM dbo.BangGia WHERE banggia_cd = '3gio';
	SELECT @px_quadem = gia FROM dbo.BangGia WHERE banggia_cd = 'quadem';
	SELECT @px_them = gia FROM dbo.BangGia WHERE banggia_cd = 'them';

	DECLARE @soGioQuaDem INT;
	SET @soGioQuaDem = @gioQuaDem_ketthuc + (24 - @gioQuaDem_batdau);

	SELECT @px_ngay = @px_quadem + (24 - @soGioQuaDem)*@px_them;

--	2.	Tinh Gio, Phut
	DECLARE @dd INT, @hh INT, @mi INT;
	SET @mi = DATEDIFF(mi, @gio_batdau, @gio_ketthuc);

	SET @dd = ROUND(@mi/24/60, 0, 1);
	SET @mi = @mi - @dd*24*60;
	SET @hh = ROUND(@mi/60,0,1);
	SET @mi = @mi - @hh*60;
	IF @mi > @phutToiThieu
		SET @hh = @hh + 1;
--	3.	Gia qua dem
	DECLARE @startH INT;
	SET @startH = DATEPART(hh, @gio_batdau);

	IF ISNULL(@qua_dem, 0) = 1
	BEGIN
		SET @gia_trave = @px_quadem + ((@GioQuaDem_batdau - @startH) + (@startH + @hh - 24 - @GioQuaDem_ketthuc))*@px_them;
	END -- tinh gia qua dem
	ELSE
	BEGIN
		IF(@hh>=3)
			SET @gia_trave = @px_3h + (@hh-3)*@px_them;
		ELSE IF(@hh=2)
			SET @gia_trave = @px_2h;
		ELSE IF(@hh=1)
			SET @gia_trave = @px_1h;
		ELSE
			SET @gia_trave = 0;
	END

	SET @thanhtien = @dd*@px_ngay + @gia_trave;

	RETURN @thanhtien;
END -- FN Body
GO





