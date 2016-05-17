CREATE PROCEDURE [dbo].[sp_GiayBaoTriDuongBo_Insert]
	@ma_giay varchar(32)
	,@ma_xe varchar(32)
	,@don_vi nvarchar(50)
	,@ngay_cap_lan_dau smalldatetime
	,@nhac_nho_truoc_ngay numeric(4,0)
	,@hinh_anh image
	,@ghi_chu ntext
	,@ngay_cap_nhat datetime
	,@nguoi_cap_nhat nvarchar(50)
	,@ngay_tao datetime
	,@nguoi_tao nvarchar(50)
	,@status char(1)
AS
BEGIN
	SET NOCOUNT OFF;
	INSERT INTO [dbo].[x_giay_bao_tri_duong_bo]
           ([ma_giay]
           ,[ma_xe]
           ,[don_vi]
           ,[ngay_cap_lan_dau]
           ,[nhac_nho_truoc_ngay]
           ,[hinh_anh]
           ,[ghi_chu]
           ,[ngay_cap_nhat]
           ,[nguoi_cap_nhat]
           ,[ngay_tao]
           ,[nguoi_tao]
           ,[status])
     VALUES
           (@ma_giay
           ,@ma_xe
           ,@don_vi
           ,@ngay_cap_lan_dau
           ,@nhac_nho_truoc_ngay
           ,@hinh_anh
           ,@ghi_chu
           ,@ngay_cap_nhat
           ,@nguoi_cap_nhat
           ,@ngay_tao
           ,@nguoi_tao
           ,@status)
END


