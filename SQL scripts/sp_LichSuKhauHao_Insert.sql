CREATE PROCEDURE [dbo].[sp_LichSuKhauHao_Insert]
	@ma_xe nchar(32)
   ,@ngay_hieu_luc smalldatetime
   ,@gia_tri_khau_hao numeric(18,0)
   ,@ti_le_khau_hao numeric(16,2)
   ,@gia_tri_con_lai numeric(18,0)
   ,@gia_tri_trich_kh_nam numeric(18,0)
   ,@gia_tri_trich_kh_thang numeric(18,0)
   ,@so_thang_da_trich_kh smallint
   ,@ghi_chu nvarchar(100)
   ,@ngay_cap_nhat datetime
   ,@nguoi_cap_nhat nvarchar(50)
   ,@ngay_tao datetime
   ,@nguoi_tao nvarchar(50)
   ,@status char(1)
AS
BEGIN
	SET NOCOUNT OFF;
	INSERT INTO [dbo].[x_lich_su_khau_hao]
           ([ma_xe]
           ,[ngay_hieu_luc]
           ,[gia_tri_khau_hao]
           ,[ti_le_khau_hao]
           ,[gia_tri_con_lai]
           ,[gia_tri_trich_kh_nam]
           ,[gia_tri_trich_kh_thang]
           ,[so_thang_da_trich_kh]
           ,[ghi_chu]
           ,[ngay_cap_nhat]
           ,[nguoi_cap_nhat]
           ,[ngay_tao]
           ,[nguoi_tao]
           ,[status])
     VALUES
           (@ma_xe
           ,@ngay_hieu_luc
           ,@gia_tri_khau_hao
           ,@ti_le_khau_hao
           ,@gia_tri_con_lai
           ,@gia_tri_trich_kh_nam
           ,@gia_tri_trich_kh_thang
           ,@so_thang_da_trich_kh
           ,@ghi_chu
           ,@ngay_cap_nhat
           ,@nguoi_cap_nhat
           ,@ngay_tao
           ,@nguoi_tao
           ,@status)
END


