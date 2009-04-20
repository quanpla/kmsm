USE csdl_qlks
GO

-- Admin grant
GRANT EXECUTE ON dbo.admin_AddRoom TO q3_Admin 
GRANT EXECUTE ON dbo.admin_AddUser TO q3_Admin 
GRANT EXECUTE ON dbo.admin_DropLogin TO q3_Admin 
GRANT EXECUTE ON dbo.admin_DropRoom TO q3_Admin 
GRANT EXECUTE ON dbo.admin_DropUser TO q3_Admin 
GRANT EXECUTE ON dbo.calc_payment TO q3_Admin 
GRANT EXECUTE ON dbo.ChangeRoom TO q3_Admin 
GRANT EXECUTE ON dbo.CheckIn TO q3_Admin 
GRANT EXECUTE ON dbo.CheckOut TO q3_Admin 
GRANT EXECUTE ON dbo.get_AllImage TO q3_Admin 
GRANT EXECUTE ON dbo.get_AppPrintableBill TO q3_Admin 
GRANT EXECUTE ON dbo.get_AppStatus TO q3_Admin 
GRANT EXECUTE ON dbo.get_AppToolTip TO q3_Admin 
GRANT EXECUTE ON dbo.get_ErrDesc TO q3_Admin 
GRANT EXECUTE ON dbo.get_ListRoomFree TO q3_Admin 
GRANT EXECUTE ON dbo.get_ListRoomStatus TO q3_Admin 
GRANT EXECUTE ON dbo.get_ListUser TO q3_Admin 
GRANT EXECUTE ON dbo.get_RoomAction TO q3_Admin 
GRANT EXECUTE ON dbo.get_RoomStatus TO q3_Admin 
GRANT EXECUTE ON dbo.get_UserStatus TO q3_Admin 
GRANT EXECUTE ON dbo.ins_ThuNhap TO q3_Admin 
GRANT EXECUTE ON dbo.list_AllRooms TO q3_Admin 
GRANT EXECUTE ON dbo.report_Ngay TO q3_Admin 
GRANT EXECUTE ON dbo.upd_ResetPassword TO q3_Admin 
GRANT EXECUTE ON dbo.upd_UpdatePassword TO q3_Admin
GO

GRANT EXECUTE ON dbo.calc_payment TO q3_Employer 
GRANT EXECUTE ON dbo.ChangeRoom TO q3_Employer 
GRANT EXECUTE ON dbo.CheckIn TO q3_Employer 
GRANT EXECUTE ON dbo.CheckOut TO q3_Employer 
GRANT EXECUTE ON dbo.get_AllImage TO q3_Employer 
GRANT EXECUTE ON dbo.get_AppPrintableBill TO q3_Employer 
GRANT EXECUTE ON dbo.get_AppStatus TO q3_Employer 
GRANT EXECUTE ON dbo.get_AppToolTip TO q3_Employer 
GRANT EXECUTE ON dbo.get_ErrDesc TO q3_Employer 
GRANT EXECUTE ON dbo.get_ListRoomFree TO q3_Employer 
GRANT EXECUTE ON dbo.get_ListRoomStatus TO q3_Employer 
GRANT EXECUTE ON dbo.get_ListUser TO q3_Employer 
GRANT EXECUTE ON dbo.get_RoomAction TO q3_Employer 
GRANT EXECUTE ON dbo.get_RoomStatus TO q3_Employer 
GRANT EXECUTE ON dbo.get_UserStatus TO q3_Employer 
GRANT EXECUTE ON dbo.ins_ThuNhap TO q3_Employer 
GRANT EXECUTE ON dbo.list_AllRooms TO q3_Employer 
GRANT EXECUTE ON dbo.report_Ngay TO q3_Employer 
GRANT EXECUTE ON dbo.upd_ResetPassword TO q3_Employer 
GRANT EXECUTE ON dbo.upd_UpdatePassword TO q3_Employer 
GO