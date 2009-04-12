USE CSDL_QLKS
GO

/*User grant*/
GRANT EXECUTE ON dbo.report_Ngay TO q3_Employer
GO

GRANT EXECUTE ON dbo.ins_Phong TO q3_Employer
GO

GRANT EXECUTE ON dbo.get_RoomStatus TO q3_Employer
GO

GRANT EXECUTE ON dbo.get_ListRoomStatus TO q3_Employer
GO

GRANT EXECUTE ON dbo.get_RoomAction TO q3_Employer
GO

GRANT EXECUTE ON dbo.list_AllRooms TO q3_Employer
GO

GRANT EXECUTE ON dbo.CheckIn TO q3_Employer
GO

GRANT EXECUTE ON dbo.ins_ThuNhap TO q3_Employer
GO

GRANT EXECUTE ON dbo.calc_payment TO q3_Employer
GO

GRANT EXECUTE ON dbo.CheckOut TO q3_Employer
GO

/*Admin GRANT*/
GRANT EXECUTE ON dbo.admin_AddUser TO q3_Admin
GO

GRANT EXECUTE ON dbo.admin_DropLogin TO q3_Admin
GO

GRANT EXECUTE ON dbo.admin_DropUser TO q3_Admin
GO

GRANT EXECUTE ON dbo.calc_payment TO q3_Admin
GO

GRANT EXECUTE ON dbo.CheckIn TO q3_Admin
GO

GRANT EXECUTE ON dbo.CheckOut TO q3_Admin
GO

GRANT EXECUTE ON dbo.get_ListRoomStatus TO q3_Admin
GO

GRANT EXECUTE ON dbo.get_RoomAction TO q3_Admin
GO

GRANT EXECUTE ON dbo.get_RoomStatus TO q3_Admin
GO

GRANT EXECUTE ON dbo.ins_Phong TO q3_Admin
GO

GRANT EXECUTE ON dbo.ins_ThuNhap TO q3_Admin
GO

GRANT EXECUTE ON dbo.list_AllRooms TO q3_Admin
GO

GRANT EXECUTE ON dbo.report_Ngay TO q3_Admin
GO
