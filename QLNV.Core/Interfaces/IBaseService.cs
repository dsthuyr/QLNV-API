using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV.Core.Interfaces
{
    public interface IBaseService<QLNVEntity> where QLNVEntity : class
    {
        /// <summary>
        /// Thêm mới đối tượng - có validate
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        int InsertService(QLNVEntity entity);
        /// <summary>
        /// Cập nhật đối tượng - có validate
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        int UpdateService(QLNVEntity entity);
    }
}
