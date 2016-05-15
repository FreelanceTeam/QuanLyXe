IF EXISTS (SELECT * FROM sys.key_constraints WHERE type = 'PK' AND parent_object_id = OBJECT_ID('dbo.x_giay_dang_kiem_ct') AND Name = 'PK_x_giay_dang_kiem_ct')
   ALTER TABLE dbo.x_giay_dang_kiem_ct
   DROP CONSTRAINT PK_x_giay_dang_kiem_ct
GO

ALTER TABLE x_giay_dang_kiem_ct
ADD CONSTRAINT PK_x_giay_dang_kiem_ct PRIMARY KEY (ma_giay,ngay_cap)