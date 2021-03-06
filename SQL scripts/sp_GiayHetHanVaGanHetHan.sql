
CREATE PROCEDURE [dbo].[sp_GiayHetHanVaGanHetHan]
AS
BEGIN
	SELECT d.ten_bp, giay.*, DATEDIFF(day, GETDATE(), ngay_het_han) - nhac_nho_truoc_ngay AS ngay_con_lai FROM 
	(
		SELECT N'Giấy đăng ký' AS loai_giay, a.bien_so, b.don_vi, b.nhac_nho_truoc_ngay, MAX(c.ngay_het_han) AS ngay_het_han 
		FROM tai_san_xe a 
		INNER JOIN x_giay_dang_ky b on a.ma_xe = b.ma_xe
		INNER JOIN x_giay_dang_ky_ct c on b.ma_giay = c.ma_giay
		GROUP BY a.bien_so, b.don_vi, b.nhac_nho_truoc_ngay
		UNION
		SELECT N'Giấy đăng kiểm' AS loai_giay, a.bien_so, b.don_vi, b.nhac_nho_truoc_ngay, MAX(c.ngay_het_han) AS ngay_het_han 
		FROM tai_san_xe a 
		INNER JOIN x_giay_dang_kiem b on a.ma_xe = b.ma_xe
		INNER JOIN x_giay_dang_kiem_ct c on b.ma_giay = c.ma_giay
		GROUP BY a.bien_so, b.don_vi, b.nhac_nho_truoc_ngay
		UNION
		SELECT N'Giấy bảo trì đường bộ' AS loai_giay, a.bien_so, b.don_vi, b.nhac_nho_truoc_ngay, MAX(c.ngay_het_han) AS ngay_het_han 
		FROM tai_san_xe a 
		INNER JOIN x_giay_bao_tri_duong_bo b on a.ma_xe = b.ma_xe
		INNER JOIN x_giay_bao_tri_duong_bo_ct c on b.ma_giay = c.ma_giay
		GROUP BY a.bien_so, b.don_vi, b.nhac_nho_truoc_ngay
		UNION
		SELECT N'Giấy bảo hiểm nhân sự' AS loai_giay, a.bien_so, b.don_vi, b.nhac_nho_truoc_ngay, MAX(c.ngay_het_han) AS ngay_het_han 
		FROM tai_san_xe a 
		INNER JOIN x_giay_bao_hiem_nhan_su b on a.ma_xe = b.ma_xe
		INNER JOIN x_giay_bao_hiem_nhan_su_ct c on b.ma_giay = c.ma_giay
		GROUP BY a.bien_so, b.don_vi, b.nhac_nho_truoc_ngay
		UNION
		SELECT N'Giấy bảo hiểm thân xe' AS loai_giay, a.bien_so, b.don_vi, b.nhac_nho_truoc_ngay, MAX(c.ngay_het_han) AS ngay_het_han 
		FROM tai_san_xe a 
		INNER JOIN x_giay_bao_hiem_than_xe b on a.ma_xe = b.ma_xe
		INNER JOIN x_giay_bao_hiem_than_xe_ct c on b.ma_giay = c.ma_giay
		GROUP BY a.bien_so, b.don_vi, b.nhac_nho_truoc_ngay
	) AS giay
	INNER JOIN dm_bo_phan d ON giay.don_vi = d.ma_bp
	WHERE DATEDIFF(day, GETDATE(), ngay_het_han) <= nhac_nho_truoc_ngay
END