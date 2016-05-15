CREATE PROCEDURE [dbo].[sp_PhuTung_Insert]
	@ma_xe nchar(32)
	,@ma_tai_san nchar(32)
	,@so_luong tinyint
	,@so_km_da_su_dung numeric(18,0)
	,@tinh_trang tinyint
AS
BEGIN
	SET NOCOUNT OFF;
	INSERT INTO [dbo].[x_phu_tung_kem_theo]
           ([ma_xe]
           ,[ma_tai_san]
           ,[so_luong]
           ,[so_km_da_su_dung]
           ,[tinh_trang])
     VALUES
           (@ma_xe
           ,@ma_tai_san
           ,@so_luong
           ,@so_km_da_su_dung
           ,@tinh_trang)
END


