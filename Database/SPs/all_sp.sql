SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE[dbo].[report_Ngay](@nam INT, @thang INT = 0, @ngay INT = 0)
AS BEGIN -- SP Body
/***********************************************
** Author:		Quan Phan
** Create date: 2009-03-01
**
**	Description:	Get the report for thang
**
**	Example:
		exec dbo.report_Thang 2008, 3
**
************************************************
**	Plan
**
************************************************
**	Params
**	________________________________
**	@nam int: should not be null, and should be > 1900
**	@thang: if input 0/NULL, return year report
**  @ngay: if input 0/NULL, return month report, unless @thang = 0/NULL
**	 
***********************************************/

	SET NOCOUNT ON;
/*
SELECT DATEPART(yyyy,ss.gio) nam, DATEPART(mm, ss.gio) thang, DATEPART(dd,ss.gio) ngay
	,dt.phong_id, SUM(dt.thunhap) thunhap
	FROM dbo.TongThuNhap ss, dbo.ThuNhap dt
	WHERE ss.tongthunhap_id = dt.tongthunhap_id
	GROUP BY ss.gio, dt.phong_id
	WITH ROLLUP

	DECLARE @chuoi_thongbao_toanthoigian VARCHAR(255),
			@chuoi_thongbao_motthoigian VARCHAR(255);

	SET @chuoi_thongbao_toanthoigian = 'Tong trong ngay @ngay, thang @thang, nam @nam:';
	SET @chuoi_thongbao_motthoigian = '';
--	1.	Standardize intput
	IF @thang > 12 OR @thang < 1 OR @thang IS NULL
	BEGIN
		SET @thang = 0;
		SET @ngay = 0;
		SET @chuoi_thongbao_toanthoigian = 'Tong trong nam @nam:';
	END
	IF @ngay < 1 OR @ngay > 31 OR @ngay IS NULL
	BEGIN
		SET @ngay = 0;
		SET @chuoi_thongbao_toanthoigian = 'Tong trong thang @thang, nam @nam:';
	END
--	1.	The main select
	WITH ROLL_UP_REPORT AS (SELECT DATEPART(yyyy, ss.gio, dt.phong_id, SUM(dt.thunhap) thunhap
							FROM dbo.TongThuNhap ss JOIN dbo.ThuNhap dt
								ON ss.tongthunhap_id = dt.tongthunhap_id
							WHERE DATEPART(yyyy, ss.gio) = @nam
								AND (DATEPART(mm, ss.gio) = @thang OR @thang = 0)
								AND (DATEPART(dd, ss.gio) = @ngay OR @ngay = 0)
							GROUP BY ss.gio, dt.phong_id
							WITH ROLLUP )
	SELECT CASE WHEN ss.gio IS NULL 'Tong toan thoi gian '
*/
	RETURN 0;
END -- SP Body



GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE[dbo].[admin_DropLogin]
       @name sysname = null
As
 
/***5***10***15***20***25***30***35***40***45***50***55***60***65***70***75**/
--Name        : sp_RemoveLogin        for SQL 7.0 & 2K
--
--Description : Attempts to remove a login from a SQL Server whether STD or NT.
--
--Parameters  : @name - the login to be removed, ie.e, <login> or
--                      <domain>\<login>
--
--Comments    : Removing login from a SQL server can be a tedious, manual
--              process checking for database access in each database, object
--              ownership in each database, granted permissions (the login is
--              the grantor), jobs & packages owned by the login. This procedure
--              automates the process as much as possible. The following rules
--              are applied when issues are encountered:
--              1) If the login owns databases (as will occur when a restore
--                 is done manually) the ownership is changed to sa.
--              2) If the login is a user in a particlar db and owns objects,
--                 then the proc attempts to reassign ownership to dbo. If an
--                 object by the same name is already owned by dbo a message is
--                 displayed and manual intervention is required.
--              3) If this login as a user in a db has granted permissions then
--                 those permissions are removed.
--              4) Once object ownership is taken care and grants are dropped
--                 then the user can be removed from the db.
--              5) If the user is aliased it is dropped.
--              6) This process continues for each db. Once all dbs are
--                 processed if there were any objects that could not be handle
--                 without manual intervention a message is displayed to that
--                 effect.
--              7) If the login owns jobs or packages in msdb those are changed
--                 to sa.
--              8) Any open connections the login has are killed and finally the
--                 login is removed from the SQL Server.
--              9) If a session could not be killed a message is displayed to that
--                 effect.
--
--Date        : 07/02/2001
--Author      : Clinton Herring
--
--History     : 07/10/2002 Added code to change the db owner to sa if the
--                         login owns databases.
--
/***5***10***15***20***25***30***35***40***45***50***55***60***65***70***75**/

-- Create a temp holding tables
If (Select object_id('tempdb.dbo.#Parm')) > 0
   Exec ('Drop table #Parm')
Create table #Parm(value int null)

-- Declare variables  
Declare @sid varbinary(85),
        @dbname sysname,
        @cmd varchar(4096),
        @spid int

---- Check for master db
--If db_name() <> 'master'
--   Begin
--      Print 'This stored procedure must be run from the master database.'
--      Return
--   End

-- Check for a null parameter
IF @name is null
   Begin
      Print 'This stored procedure requires a valid login as a parameter.'
      Return
   End

-- Check for logins not allowed to be dropped using this procedure
IF @name in ('BUILTIN\Administrators', 'distributor_admin', 'sa', 'repl_publisher', 'repl_subscriber')
   Begin
      Print 'You may not drop the following logins using this stored procedure:'
      Print '   BUILTIN\Administrators, distributor_admin, sa, repl_publisher, repl_subscriber'
      Return
   End

-- Check to see if the login exists.
If exists (select * from master.dbo.syslogins where loginname = @name)
   Begin

      -- Display a message
      Print 'Attempting to find and drop ''' + @name + ''' from each database...'

      -- retrieve the sid of the login
      Set @sid = suser_sid(@name)

      -- Does this login own any databases
      If exists(select * from sys.databases where owner_sid = @sid)
         Begin
            Select @cmd = 'use master declare @cmd varchar(512) Exec sp_configure ''allow updates'',1 ' +
                          'Reconfigure with override Waitfor delay ''00:00:01'' ' +
                          'Print ''   Fixing db owner issues in master...'' ' +
                          'Select @cmd = ''Update sysdatabases set sid = 0x01 where sid = suser_sid(''''' + @name + ''''')'' ' +
                          'Exec (@cmd) Exec sp_configure ''allow updates'',0 Reconfigure with override '
            Exec (@cmd)
         End          

      -- If the login exists begin checking each database for this login as a users in
      -- that database.
      Select @dbname = min(name) from master.dbo.sysdatabases

      -- Loop through each database.
      While @dbname is not null
         Begin

            -- Here dynamic sql is required to use the 'Use command'.
            -- This loop checks for db and msdb ownership issues & granted permissions.
            -- Build a command.
            Select @cmd  = 'use ' + @dbname + ' declare @uid int, @cmd varchar(512), @name sysname ' +
                           'If exists (select * from sysusers where sid = suser_sid(''' + @name + ''') and isaliased = 0) ' +
                           'Begin Print ''   Processing db ' + @dbname + '...'' Select @uid = uid, @name = name from ' +
                           'sysusers where sid = suser_sid(''' + @name + ''') If exists (select * from sysobjects ' +
                           'where uid = 1 and name in (select name from sysobjects where uid = @uid)) ' +
                           'Begin Print ''   The following objects are owned by the user in database ' + @dbname + '.'' ' +
                           'Print ''   Objects with the same name owned by dbo already exist. Please decide '' ' +
                           'Print ''   what to do with these objects before attempting to drop this user.'' Print '''' ' +
                           'Select convert(varchar(50), name) ''name'', type from sysobjects where uid = @uid ' +
                           'Insert into #parm values(1) End ' +
                           'Else Begin Exec sp_configure ''allow updates'', 1 Reconfigure with override ' +
                           'waitfor delay ''00:00:01'' select @cmd = ''update sysobjects set uid = 1 where uid = '' ' +
                           '+ convert(varchar(5),@uid) + ' +
                           ''' Delete from syspermissions where grantor = '' + convert(varchar(5),@uid) ' +
                           'Print ''   Fixing object ownership issues in '' + db_name() + ''...'' Exec (@cmd) ' +
                           'Exec sp_configure ''allow updates'', 0 Reconfigure with override ' +
                           'Exec sp_revokedbaccess @name End Print '''' End ' +
                           'If exists(select * from sysusers where sid = suser_sid(''' + @name + ''') and isaliased = 1) ' +
                           'Begin Exec sp_dropalias ''' + @name + ''' Print '''' End'                    
            -- Execute the command
            Exec (@cmd)

            -- If the database is msdb then fix any job or package onwership issues.
            If @dbname = 'msdb' and
               (exists(select * from msdb.dbo.sysjobs where owner_sid = @sid) or
                exists(select * from msdb.dbo.sysdtspackages where owner_sid = @sid))
               Begin
                  Select @cmd = 'use msdb declare @cmd varchar(512) ' +
                                'Exec sp_configure ''allow updates'', 1 Reconfigure with override ' +
                                'waitfor delay ''00:00:01'' select @cmd = ' +
                                '''update sysdtspackages set owner = ''''sa'''', owner_sid = ' +
                                '0x01 where owner_sid = suser_sid(''''' + @name + ''''') ' +
                                'update sysjobs set owner_sid = 0x01 where owner_sid = suser_sid(''''' + @name+ ''''')'' ' +
                                'Print ''   Fixing job &/or package ownership issues in msdb.'' ' +
                                'Exec (@cmd) Exec sp_configure ''allow updates'', 0 Reconfigure with override '
                  Exec (@cmd)
               End

            Select @dbname = min(name) from master.dbo.sysdatabases where name > @dbname
         End
    
      -- Did we have any issues that could not be resolved?
      If exists(select * from #parm where value = 1)
         Print 'Cannot drop the login at this time.'
      Else
         Begin
            Truncate table #parm

            -- Check for any connection by this login and attempt to kill them.
            If exists (Select * from master.dbo.sysprocesses where loginame = @name and sid <> 0x01 and sid is not null)
               Begin
                  Insert into #parm Select spid from master.dbo.sysprocesses where loginame = @name and sid <> 0x01 and sid is not null
                  Select @spid = min(value) from #parm
                  While @spid is not null
                     Begin
                        Select @cmd = 'Kill ' + convert(varchar(5),@spid)
                        Exec (@cmd)
                        Select @spid = min(value) from #parm where value > @spid
                     End
               End

            -- Not all kill commands succeed; check again
            If exists (Select * from master.dbo.sysprocesses where loginame = @name and sid <> 0x01 and sid is not null)
               Begin
                  Print 'Could not kill all active sessions for this login.'
                  Print 'Cannot drop the login at this time.'
               End
            Else
               Begin
                  If charindex('\', @name) > 0
                     Exec sp_revokelogin @name
                  Else
                     Exec sp_droplogin @name
               End
         End

   End
Else
   Begin
      Print 'The login ''' + @name + ''' does not exist on SQL Server ''' + @@servername + '''.'
   End



GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[upd_UpdatePassword](@oldPassword VARCHAR(128), @newPassword VARCHAR(128))
AS BEGIN
/***************************************************************
**	update user password
***************************************************************/
	EXEC sp_password @oldPassword, @newPassword;
END


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[upd_ResetPassword](@userName VARCHAR(128))
AS BEGIN
/***************************************************************
**	update user password
***************************************************************/
	EXEC sp_password NULL, '1234', @userName;
END


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE[dbo].[get_RoomAction](@phong_id INT = NULL)
AS BEGIN -- SP Body
/***********************************************
** Author:		Quan Phan
** Create date: 2009-03-01
**
**	Description:	Get the all room status
**
**	Example:
		DECLARE @er_code INT
		EXECUTE @er_code = dbo.get_RoomAction  NULL
		SELECT @er_code

select * from tACvU

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

	--	Get Group, then get permission for the group
	DECLARE @User_Name VARCHAR(50), @Group_ID INT;

	SET @User_Name = suser_sname();
	SELECT @Group_ID = GROUP_ID
	FROM [User]
	WHERE User_CD = @User_Name;

	IF @phong_id IS NULL -- if it is null, return the null action (add room, etc., that does not affect the room)
		SELECT DISTINCT TacVu.TacVu_ID, TacVu_CD, TacVu
		FROM TacVu JOIN User_Group_Permission
			ON TacVu.TacVu_ID = User_Group_Permission.TacVu_ID
		WHERE TacVu.TrangThai_1 IS NULL AND TacVu.TrangThai_2 IS NULL
			AND Loai NOT IN(1)
		UNION SELECT DISTINCT TacVu.TacVu_ID, TacVu_CD, TacVu
		FROM TacVu JOIN User_Permission
			ON TacVu.TacVu_ID = User_Permission.TacVu_ID
		WHERE TacVu.TrangThai_1 IS NULL AND TacVu.TrangThai_2 IS NULL
			AND Loai NOT IN (1);
	ELSE
		--	Tac Vu is all available tac vu for the user,
		--	that will not make the same trangthai of the room
		SELECT DISTINCT TacVu.TacVu_ID, TacVu_CD, TacVu
		FROM TacVu JOIN User_Group_Permission
			ON TacVu.TacVu_ID = User_Group_Permission.TacVu_ID
		WHERE NOT EXISTS(
			SELECT 1 FROM Phong_TrangThai
			WHERE Phong_ID = @phong_id
				AND ISNULL(TrangThai_ID, 0) = ISNULL(TrangThai_2, 0)
		)	AND TrangThai_2 IS NOT NULL
			AND Loai NOT IN (1)
		UNION SELECT DISTINCT TacVu.TacVu_ID, TacVu_CD, TacVu
		FROM TacVu JOIN User_Permission
			ON TacVu.TacVu_ID = User_Permission.TacVu_ID
		WHERE NOT EXISTS(
			SELECT 1 FROM Phong_TrangThai
			WHERE Phong_ID = @phong_ID
				AND ISNULL(TrangThai_ID, 0) = ISNULL(TrangThai_2, 0)
		)	AND TrangThai_2 IS NOT NULL
			AND Loai NOT IN (1);
	RETURN 0;
END -- SP Body







GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE[dbo].[get_ListRoomFree]
AS BEGIN -- SP Body
/***********************************************
** Author:		Quan Phan
** Create date: 2009-03-01
**
**	Description:	Get the all room status
**
**	Example:
		DECLARE @er_code INT
		EXECUTE @er_code = dbo.get_RoomStatus 3
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

	SELECT DISTINCT Phong_ID, Phong_CD
	FROM Phong
	WHERE dbo.is_AvailableRoom(Phong_ID) = 1;

	RETURN 0;

	SET NOCOUNT OFF;
END -- SP Body






GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE[dbo].[list_AllRooms](@order_by INT = 1)
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
				TrangThai.TrangThai_ID,
				BangGia.gia [Gia]
		FROM dbo.Phong JOIN dbo.Phong_Default
			ON Phong.phong_id = Phong_Default.phong_id
				JOIN dbo.BangGia
			ON BangGia.banggia_id = Phong_Default.banggia_id
				LEFT JOIN dbo.Phong_TrangThai
			ON Phong.phong_id = Phong_TrangThai.phong_id
				JOIN dbo.TrangThai
			ON TrangThai.trangthai_id = ISNULL(Phong_TrangThai.trangthai_id, 1)
		ORDER BY phong.phong_cd;

	IF @order_by = 2
		SELECT	phong.phong_id, phong.phong_cd [TenPhong],
				ISNULL(phong.mota, '') [MoTa],
				CASE Phong_TrangThai.is_hoatdong WHEN 1 THEN 0 ELSE 1 END [Trong],
				--ISNULL(TrangThai.trangthai,'') [TrangThai],
				TrangThai.TrangThai_ID,
				BangGia.gia [Gia]
		FROM dbo.Phong JOIN dbo.Phong_Default
			ON Phong.phong_id = Phong_Default.phong_id
				JOIN dbo.BangGia
			ON BangGia.banggia_id = Phong_Default.banggia_id
				LEFT JOIN dbo.Phong_TrangThai
			ON Phong.phong_id = Phong_TrangThai.phong_id
				JOIN dbo.TrangThai
			ON TrangThai.trangthai_id = ISNULL(Phong_TrangThai.trangthai_id, 1)
		ORDER BY ISNULL(phong.mota, ''), phong.phong_cd;

	IF @order_by = 3
		SELECT	phong.phong_id, phong.phong_cd [TenPhong],
				ISNULL(phong.mota, '') [MoTa],
				CASE Phong_TrangThai.is_hoatdong WHEN 1 THEN 0 ELSE 1 END [Trong],
				--ISNULL(TrangThai.trangthai,'') [TrangThai],
				TrangThai.TrangThai_ID,
				BangGia.gia [Gia]
		FROM dbo.Phong JOIN dbo.Phong_Default
			ON Phong.phong_id = Phong_Default.phong_id
				JOIN dbo.BangGia
			ON BangGia.banggia_id = Phong_Default.banggia_id
				LEFT JOIN dbo.Phong_TrangThai
			ON Phong.phong_id = Phong_TrangThai.phong_id
				JOIN dbo.TrangThai
			ON TrangThai.trangthai_id = ISNULL(Phong_TrangThai.trangthai_id, 1)
		ORDER BY TrangThai.TrangThai_ID, phong.phong_cd;

	IF @order_by = 4
		SELECT	phong.phong_id, phong.phong_cd [TenPhong],
				ISNULL(phong.mota, '') [MoTa],
				CASE Phong_TrangThai.is_hoatdong WHEN 1 THEN 0 ELSE 1 END [Trong],
				--ISNULL(TrangThai.trangthai,'') [TrangThai],
				TrangThai.TrangThai_ID,
				BangGia.gia [Gia]
		FROM dbo.Phong JOIN dbo.Phong_Default
			ON Phong.phong_id = Phong_Default.phong_id
				JOIN dbo.BangGia
			ON BangGia.banggia_id = Phong_Default.banggia_id
				LEFT JOIN dbo.Phong_TrangThai
			ON Phong.phong_id = Phong_TrangThai.phong_id
				JOIN dbo.TrangThai
			ON TrangThai.trangthai_id = ISNULL(Phong_TrangThai.trangthai_id, 1)
		ORDER BY BangGia.gia, phong.phong_cd;

	SET NOCOUNT OFF;
END



GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE[dbo].[ins_ThuNhap](
	@phong_id int,
	@thunhap numeric(28,12),
	@mota varchar(512))
AS BEGIN -- SP Body
/***********************************************
** Author:		Quan Phan
** Create date: 2009-03-01
**
**	Description:	record payment
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
--	1.	Get sum_id
	DECLARE @tongthunhap_id INT;
	SELECT @tongthunhap_id = tongthunhap_id
	FROM dbo.TongThuNhap
	WHERE DATEDIFF(d, gio, GETDATE()) = 0;

--	2.	If not exists tongthunhap, insert one
	IF @tongthunhap_id IS NULL
	BEGIN
		INSERT INTO dbo.TongThuNhap(gio, tongthunhap)
		VALUES (CONVERT(VARCHAR, GETDATE(), 112), 0);
		SET @tongthunhap_id = @@IDENTITY;
	END

--	3.	Insert it:
	INSERT INTO dbo.ThuNhap(tongthunhap_id, phong_id, gio, thunhap, mota)
	VALUES(@tongthunhap_id, @phong_id, GETDATE(), @thunhap, @mota);

	IF (@@ROWCOUNT>0)
	UPDATE dbo.TongThuNhap
	SET tongthunhap = COALESCE(tongthunhap, 0) + @thunhap
	WHERE tongthunhap_id = @tongthunhap_id;
END -- SP Body




GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE[dbo].[get_RoomStatus]( @phong_id int)
AS BEGIN -- SP Body
/***********************************************
** Author:		Quan Phan
** Create date: 2009-03-01
**
**	Description:	Get the room status
**
**	Example:
		DECLARE @er_code INT
		EXECUTE @er_code = dbo.get_RoomStatus 3
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

	SELECT DISTINCT TrangThai_CD
	FROM Phong_TrangThai JOIN TrangThai
	ON Phong_TrangThai.TrangThai_ID = TrangThai.TrangThai_ID
	WHERE Phong_TrangThai.Phong_ID = @phong_id;

	RETURN 0;
END -- SP Body




GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE[dbo].[get_ListRoomStatus]
AS BEGIN -- SP Body
/***********************************************
** Author:		Quan Phan
** Create date: 2009-03-01
**
**	Description:	Get the all room status
**
**	Example:
		DECLARE @er_code INT
		EXECUTE @er_code = dbo.get_RoomStatus 3
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

	SELECT DISTINCT Phong_TrangThai.Phong_ID, TrangThai_CD
	FROM Phong_TrangThai JOIN TrangThai
	ON Phong_TrangThai.TrangThai_ID = TrangThai.TrangThai_ID;

	RETURN 0;
END -- SP Body




GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE[dbo].[get_AllImage]
AS BEGIN
	SELECT HinhAnh_ID, Image_Link, Image
	FROM HinhAnh;
END


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE[dbo].[get_ErrDesc](@err_id int)
AS BEGIN -- SP Body
/***********************************************
** Author:		Quan Phan
** Create date: 2009-03-01
**
**	Description:	Get the error Description
**
**	Example:
		DECLARE @er_code INT
		EXECUTE @er_code = dbo.get_ErrDesc 1
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
	SELECT Err_Code
	FROM dbo.Error_Lookup
	WHERE Err_ID = @err_id;
	SET NOCOUNT OFF;
END -- SP Body



GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE[dbo].[admin_DropRoom](
	@phong_cd VARCHAR(50))
AS BEGIN -- SP Body
/***********************************************
** Author:		Quan Phan
** Create date: 2009-03-08
**
**	Description:	delete existed room
**
exec dbo.admin_DropRoom 101
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
	DECLARE @phong_id INT;
--	1.	Check Exists
	SELECT @phong_id = phong_id
	FROM dbo.Phong
	WHERE ISNULL(UPPER(RTRIM(LTRIM(phong_cd))),'Z') = ISNULL(UPPER(RTRIM(LTRIM(@phong_cd))),'Z');

--	2.	If not exists
	IF @phong_id IS NOT NULL
	BEGIN
		DELETE Phong_Default
		WHERE Phong_ID = @Phong_ID;

		DELETE Phong_TrangThai
		WHERE Phong_ID = @Phong_ID;

		DELETE Phong_NhomPhong_Xref
		WHERE Phong_ID = @Phong_ID;

		DELETE Phong
		WHERE Phong_ID = @Phong_ID;

		-- log it
		INSERT INTO TacVu_Hist(TacVu_ID, Description)
		SELECT dbo.get_TacVuid('delRoom'), 'Xoa phong: ' + @phong_cd;

	END
END -- SP Body





GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE[dbo].[ChangeRoom]( @phong1_id int, @phong2_id int )
AS BEGIN -- SP Body
/***********************************************
** Author:		Quan Phan
** Create date: 2009-03-01
**
**	Description:	Change the room
**
**	Example:
		EXEC dbo.CheckIn 5
		SELECT * FROM Phong_trangThai
		EXEC dbo.changeRoom 5, 6
		SELECT * FROM Phong_trangThai
		EXEC dbo.CheckOut 5
		SELECT * FROM Phong_trangThai
		
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
	IF NOT EXISTS(SELECT 1 FROM dbo.Phong WHERE phong_id = @phong1_id OR phong_id = @phong2_id)
	RETURN dbo.get_errid('MissingRoom');

	-- If the room not available
	IF dbo.is_AvailableRoom(@phong2_id) = 0
	RETURN dbo.get_errid('NotAvailRoom');

--	2.	Prepare values
	-- Get the id of the status
	DECLARE @muon_id INT, @trong_id INT;
	SET @muon_id = dbo.get_trangthaiid('muon');
	SET @trong_id = dbo.get_trangthaiid('trong');

--	3.	If the status record not exists, insert new one, else update status
	IF NOT EXISTS(	SELECT 1 FROM dbo.Phong_TrangThai
					WHERE phong_id = @phong2_id)
	BEGIN
		INSERT INTO dbo.Phong_TrangThai(phong_id, trangthai_id, is_hoatdong, is_conguoi, gio_batdau, gio_ketthuc)
		SELECT @phong2_id, @muon_id, 1/*is active*/, 1/*is occupied*/, gio_batdau, NULL /*No end date*/
		FROM dbo.Phong_TrangThai
		WHERE phong_id = @phong1_id
			AND trangthai_id = @muon_id;
	END
	ELSE
	BEGIN
		UPDATE phongmoi
		SET trangthai_id = @muon_id,
			is_hoatdong = 1,
			is_conguoi = 1,
			gio_batdau = phongcu.gio_batdau,
			gio_ketthuc = NULL,
			last_update = GETDATE(),
			update_by = SYSTEM_USER
		FROM Phong_TrangThai phongcu, Phong_TrangThai phongmoi
		WHERE phongcu.phong_id = @phong1_id
			AND phongmoi.phong_id = @phong2_id;
	END

	-- Update trang thai of phong 1
	UPDATE dbo.Phong_TrangThai
	SET trangthai_id = @trong_id,
		is_hoatdong = 0,
		is_conguoi = 0,
		gio_ketthuc = GETDATE(),
		last_update = GETDATE(),
		update_by = SYSTEM_USER
	WHERE phong_id = @phong1_id;

		-- log it
		INSERT INTO TacVu_Hist(TacVu_ID, Description)
		SELECT dbo.get_TacVuid('chgRoom'), 'Doi phong ' + CAST(@phong1_id AS VARCHAR) + ' to ' + CAST(@phong2_id AS VARCHAR);
	RETURN 0;
END -- SP Body





GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE[dbo].[admin_AddRoom](
	@phong_cd VARCHAR(50),
	@mota VARCHAR(512) = NULL)
AS BEGIN -- SP Body
/***********************************************
** Author:		Quan Phan
** Create date: 2009-03-08
**
**	Description:	insert new room
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
	DECLARE @phong_id INT;
--	1.	Check Exists
	SELECT @phong_id = phong_id
	FROM dbo.Phong
	WHERE ISNULL(UPPER(RTRIM(LTRIM(phong_cd))),'Z') = ISNULL(UPPER(RTRIM(LTRIM(@phong_cd))),'Z');

--	2.	If not exists
	IF @phong_id IS NULL
	BEGIN
		INSERT INTO dbo.Phong(phong_cd, mota)
		VALUES (@phong_cd, @mota);
		SET @phong_id = @@IDENTITY;

		-- log it
		INSERT INTO TacVu_Hist(TacVu_ID, Description)
		SELECT dbo.get_TacVuid('addRoom'), 'Them phong ' + @Phong_CD;
	END

	INSERT INTO dbo.Phong_Default(phong_id, banggia_id)
	SELECT @phong_id, dbo.get_banggiaid(NULL)
	WHERE NOT EXISTS (SELECT 1 FROM Phong_Default WHERE Phong_ID = @phong_ID);

	SELECT @Phong_id AS Phong_ID
END -- SP Body







GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE[dbo].[CheckIn]( @phong_id int)
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
	RETURN dbo.get_errid('MissingRoom');

	-- If the room not available
	IF dbo.is_AvailableRoom(@phong_id) = 0
	RETURN dbo.get_errid('NotAvailRoom');

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



GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE[dbo].[admin_AddUser](@UserName VARCHAR(30), @IsAdmin INT = 0) AS
/************************************************************************
**	create a user, admin or not,
**	the default password is of newUser login
exec admin_AddUser 'AGK', 1
************************************************************************/
BEGIN
	SET NOCOUNT ON

	IF NOT EXISTS(	SELECT 1 FROM sysusers
					WHERE name = @UserName)
	BEGIN
		DECLARE @sql VARCHAR(2000);
		IF NOT EXISTS(select * from master.dbo.syslogins where loginname = @UserName)
		SET @sql = '	CREATE LOGIN @newUser
						WITH PASSWORD = ''1234''
		'
		SET @sql = ISNULL(@sql,'') + '		
						CREATE USER @newUser FOR LOGIN @newUser
		';
		SET @sql = REPLACE(@sql, '@newUser', @UserName);
		EXEC(@sql);

		IF @isAdmin = 1
		BEGIN
			EXEC sp_addrolemember 'q3_admin', @UserName
		END
		ELSE
		BEGIN
			EXEC sp_addrolemember 'q3_employer', @UserName
		END -- admin or not

		-- log it
		INSERT INTO TacVu_Hist(TacVu_ID, Description)
		SELECT dbo.get_TacVuid('addUser'), 'Them user: ' + @UserName;
	END -- add new?

	--	OK, now if the user existed, we add new into User table:
	INSERT INTO [User](User_CD, Group_ID)
	SELECT @UserName, CASE @isAdmin WHEN 1 THEN dbo.get_adminGroupID() ELSE dbo.get_employerGroupID() END
	WHERE NOT EXISTS (SELECT 1 FROM [User] WHERE User_CD = @UserName)
	SET NOCOUNT OFF
END

/*
DECLARE @result INT, @OLEResult INT, @UserID INT, @ServerID INT, @UsersID INT
SET @result = 0

--Create UserManager object
EXECUTE @OLEResult = sp_OACreate 'UserManager.Server', @ServerID OUT
IF @OLEResult <> 0 SELECT @result = @OLEResult
IF @OLEResult <> 0 RAISERROR 50000 'CreateObject'

--Create Select domain controler to add user
EXEC @OLEResult = sp_OAMethod @ServerID, 'Select', Null, 'DomainControler'
IF @OLEResult <> 0 SELECT @result = @OLEResult 
IF @OLEResult <> 0 RAISERROR 50001 'SelectDC'

--Get Users collection
EXEC @OLEResult = sp_OAGetProperty @ServerID, 'Users', @UsersID OUT
IF @OLEResult <> 0 SELECT @result = @OLEResult
IF @OLEResult <> 0 RAISERROR 50002 'Users'

--Add the user to Users collection
EXEC @OLEResult = sp_OAMethod @UsersID, 'Add', @UserID OUT, @UserName, @Password

IF @OLEResult <> 0 SELECT @result = @OLEResult
IF @OLEResult <> 0 RAISERROR 50003 'UserAdd'

IF ''+@FullName<>''
 BEGIN--Set user full name
  EXEC @OLEResult = sp_OASetProperty @UserID, 'FullName', @FullName
  IF @OLEResult <> 0 SELECT @result = @OLEResult
  IF @OLEResult <> 0 RAISERROR 50004 'FullName'
 END

IF ''+@GroupName<>''

 BEGIN--Add the user to defined group
  EXEC @OLEResult = sp_OAMethod @UserID, 'AddToLocalGroup', NULL, @GroupName
  IF @OLEResult <> 0 SELECT @result = @OLEResult
  IF @OLEResult <> 0 RAISERROR 50005 'Group'
 END

EXEC @OLEResult = sp_OADestroy @UserID
EXEC @OLEResult = sp_OADestroy @UsersID
EXEC @OLEResult = sp_OADestroy @ServerID

RETURN @result


GO
exec admin_AddUser 'AGK', '1234', 'Quan Phan', 'q3_admin'

*/







GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE[dbo].[calc_payment](
	@phong_id int,
	@gio_batdau datetime,
	@gio_ketthuc datetime,
	@thanhtien Numeric(28,12) OUTPUT)
AS BEGIN -- SP Body
/***********************************************
** Author:		Quan Phan
** Create date: 2009-03-01
**
**	Description:	calculate and record the payment
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

--	1.	Get price per hour
	DECLARE @unitPx NUMERIC(28,12);
	SELECT @unitPx = BangGia.gia
	FROM dbo.Phong_Default
		INNER JOIN dbo.BangGia
			ON Phong_Default.banggia_id = BangGia.banggia_id
	WHERE Phong_Default.phong_id = @phong_id;

--	2.	If no default price apply, use the default one:
	SET @unitPx = (SELECT TOP 1 gia FROM dbo.BangGia ORDER BY banggia_id);

--	3.	Convert Actual Time range (this is to be review)
	DECLARE @hh INT, @mi INT;
	SET @mi = DATEDIFF(mi, @gio_batdau, @gio_ketthuc);

	SET @hh = ROUND(@mi/60,0,1);
	SET @mi = @mi - @hh*60;

	-- review from here:
	IF(ISNULL(@mi,0) > 15) -- if the time > 15 mins, increase hour by 1
		SET @hh = ISNULL(@hh,0) + 1;
	IF(ISNULL(@hh,0) = 0) -- if less than 1 hour, round up to 1 hour
		SET @hh = 1;

	SET @thanhtien = @hh*@unitPx;

--	4.	Trace to ThuNhap table
	EXEC dbo.ins_ThuNhap @phong_id , @thanhtien, 'Tien Muon Phong';

END -- SP Body




GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE[dbo].[admin_DropUser](@UserName VARCHAR(30)) AS
/************************************************************************
**	create a user, admin or not,
**	the default password is of newUser login
DROP USER AGK
exec admin_DropUser 'AGK'
************************************************************************/
BEGIN
	SET NOCOUNT ON

	IF EXISTS(	SELECT 1 FROM sysusers
				WHERE name = @UserName)
	BEGIN
		DECLARE @sql VARCHAR(2000);
		SET @sql = 'DROP USER ' + @UserName;
		EXEC(@sql);
		EXEC admin_DropLogin @UserName

		INSERT INTO Tacvu_Hist(TacVu_ID, Description)
		SELECT dbo.get_TacVuid('delUser'), 'Xoa user: ' + @UserName;
	END -- existed?

	SET NOCOUNT OFF
END


GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE[dbo].[CheckOut](	@phong_id int)
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
	DECLARE	@gio_batdau datetime, @gio_ketthuc datetime,	@thanhtien Numeric(28,12)

--	1.	Standardize input
	IF NOT EXISTS(SELECT 1 FROM dbo.Phong WHERE phong_id = @phong_id)
	RETURN dbo.get_errid('MissingRoom');

	-- If the room is not check out (is currently available)
	IF dbo.is_AvailableRoom(@phong_id) = 1 OR NOT EXISTS(	SELECT 1 FROM dbo.Phong_TrangThai
															WHERE phong_id = @phong_id)
	RETURN dbo.get_errid('NotCheckIn');

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

--	Calculate money spend
	exec dbo.calc_payment @phong_id, @gio_batdau, @gio_ketthuc, @thanhtien OUTPUT;

	INSERT INTO TacVu_Hist(TacVu_ID, Description)
	SELECT dbo.get_TacVuID('chkOut'), 'Tra phong: ' + CAST(@phong_id AS VARCHAR);

	SELECT @gio_batdau [Gio Bat Dau], @gio_ketthuc [Gio Ket Thuc],	@thanhtien [Thanh Tien]
	RETURN 0;
END -- SP Body




