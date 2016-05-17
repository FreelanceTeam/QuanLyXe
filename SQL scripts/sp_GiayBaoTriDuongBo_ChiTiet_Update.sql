CREATE PROCEDURE [dbo].[sp_GiayBaoTriDuongBo_ChiTiet_Update]
	@ma_giay varchar(32)
	,@ngay_cap smalldatetime
	,@ngay_het_han smalldatetime
	,@chi_phi numeric(18,0)
	,@ghi_chu ntext
	,@ngay_cap_nhat smalldatetime
	,@nguoi_cap_nhat nchar(32)
	,@trang_thai char(1)
AS
BEGIN
	SET NOCOUNT OFF;
	UPDATE [dbo].[x_giay_bao_tri_duong_bo_ct]
	SET [ngay_het_han] = @ngay_het_han
		,[chi_phi] = @chi_phi
		,[ghi_chu] = @ghi_chu
		,[ngay_cap_nhat] = @ngay_cap_nhat
		,[nguoi_cap_nhat] = @nguoi_cap_nhat
		,[trang_thai] = @trang_thai
	WHERE  ma_giay = @ma_giay AND ngay_cap = @ngay_cap
END


