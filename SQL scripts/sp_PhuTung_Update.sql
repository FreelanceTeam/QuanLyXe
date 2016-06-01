CREATE PROCEDURE [dbo].[sp_PhuTung_Update]
	@ma_xe nchar(32)
	,@ma_tai_san nchar(32)
	,@so_luong tinyint
	,@so_km_da_su_dung numeric(18,0)
	,@trang_thai tinyint
AS
	SET NOCOUNT OFF;
	UPDATE [dbo].[x_phu_tung_kem_theo]
	   SET [so_luong] = @so_luong
		  ,[so_km_da_su_dung] = @so_km_da_su_dung
		  ,[trang_thai] = @trang_thai
	 WHERE [ma_xe] = @ma_xe AND ma_tai_san = @ma_tai_san
GO


