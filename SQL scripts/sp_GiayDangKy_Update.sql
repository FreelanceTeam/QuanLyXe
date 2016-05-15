CREATE PROCEDURE [dbo].[sp_GiayDangKy_Update]
	@ma_giay varchar(32)
	,@ma_xe varchar(32)
	,@don_vi nvarchar(50)
	,@ngay_cap_lan_dau smalldatetime
	,@nhac_nho_truoc_ngay numeric(4,0)
	,@hinh_anh image
	,@ghi_chu ntext
	,@ngay_cap_nhat datetime
	,@nguoi_cap_nhat nvarchar(50)
	,@status char(1)
AS
BEGIN
	SET NOCOUNT OFF;
	UPDATE [dbo].[x_giay_dang_ky]
	   SET [don_vi] = @don_vi		  
		  ,[nhac_nho_truoc_ngay] = @nhac_nho_truoc_ngay
		  ,[hinh_anh] = @hinh_anh
		  ,[ghi_chu] = @ghi_chu
		  ,[ngay_cap_nhat] = @ngay_cap_nhat
		  ,[nguoi_cap_nhat] = @nguoi_cap_nhat
		  ,[status] = @status
	 WHERE ma_giay = @ma_giay
END


