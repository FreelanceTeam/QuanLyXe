using System.Data;
using System.Data.SqlClient;
using VMS.DAL.Entity;
using VMS.Helper;

namespace VMS.DAL
{
    public class PhuTungData
    {
        public PhuTungData()
        {
            DataFactory.CreateConnection();
        }        

        public DataTable GetAllAsDataTable(string ma_xe)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT pt.*, ts.ten_tai_san FROM x_phu_tung_kem_theo pt INNER JOIN tai_san_may_moc_thiet_bi ts ON pt.ma_tai_san = ts.ma_tai_san WHERE ma_xe = '{0}'", ma_xe));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_phu_tung_kem_theo");
            da.Fill(dt);
            return dt;
        }

        public phu_tung Get(string ma_xe, string ma_tai_san)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT pt.*, ts.ten_tai_san FROM x_phu_tung_kem_theo pt INNER JOIN tai_san_may_moc_thiet_bi ts ON pt.ma_tai_san = ts.ma_tai_san WHERE ma_xe = '{0}' AND ma_tai_san ='{1}'", ma_xe, ma_tai_san));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_phu_tung_kem_theo");
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                return ConvertionHelper.ToEntity<phu_tung>(dt.Rows[0]);
            }
            return null;
        }

        public bool HasExisted(string ma_xe, string ma_tai_san)
        {
            SqlCommand cmd = DataFactory.CreateCommand(string.Format("SELECT * FROM x_phu_tung_kem_theo WHERE ma_xe = '{0}' AND ma_tai_san ='{1}'", ma_xe, ma_tai_san));
            SqlDataAdapter da = DataFactory.CreateAdapter(cmd);
            DataTable dt = new DataTable("x_phu_tung_kem_theo");
            da.Fill(dt);

            return dt.Rows.Count > 0;
        }

        public bool Save(phu_tung entity, bool isNew)
        {
            string sqlStr = "sp_PhuTung_Insert";
            if (!isNew)
                sqlStr = "sp_PhuTung_Update";

            SqlCommand cmd = DataFactory.CreateCommand(sqlStr);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma_xe", SqlDbType.VarChar).Value = entity.ma_xe;
            cmd.Parameters.Add("@ma_tai_san", SqlDbType.VarChar).Value = entity.ma_tai_san;
            cmd.Parameters.Add("@so_luong", SqlDbType.TinyInt).Value = entity.so_luong;
            cmd.Parameters.Add("@so_km_da_su_dung", SqlDbType.Decimal).Value = entity.so_km_da_su_dung;
            cmd.Parameters.Add("@trang_thai", SqlDbType.VarChar).Value = entity.trang_thai;

            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }

        public bool Delete(string ma_xe, string ma_tai_san)
        {
            SqlCommand cmd = DataFactory.CreateCommand("sp_PhuTung_Delete");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ma_xe", SqlDbType.VarChar).Value = ma_xe;
            cmd.Parameters.Add("@ma_tai_san", SqlDbType.VarChar).Value = ma_tai_san;
            bool result = DataFactory.ExecuteNonQuery(cmd);
            return result;
        }
    }
}
