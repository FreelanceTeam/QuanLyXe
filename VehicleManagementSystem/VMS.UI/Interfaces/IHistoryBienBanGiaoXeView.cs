using System.Collections.Generic;
using System.Data;
using VMS.DAL.Entity;

namespace VMS.UI.Interfaces
{
    public interface IHistoryBienBanGiaoXeView
    {
        void LoadAllBienBanGiaoXe(List<bien_ban_giao_xe> list);
    }
}
