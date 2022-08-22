using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV.Core.Interfaces
{
    public interface IBaseRepository<QLNVEntity> where QLNVEntity : class
    {
        /// <summary>
        /// Lấy danh sách đối tượng
        /// </summary>
        /// <returns>Danh sách đối tượng</returns>
        /// CreatedBy: dsthuyr (14/6/2022)
        IEnumerable<QLNVEntity> GetAll();

        /// <summary>
        /// Lấy đối tượng theo Id
        /// </summary>
        /// <param name="id">Khóa chính của đối tượng</param>
        /// <returns>Đối tượng</returns>
        /// CreatedBy: dsthuyr (14/6/2022)
        QLNVEntity GetById(Guid id);

        /// <summary>
        /// Thêm đối tượng mới
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: dsthuyr (14/6/2022)
        int InsertNew(QLNVEntity entity);

        /// <summary>
        /// Cập nhật đối tượng theo Id
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: dsthuyr (14/6/2022)
        int UpdateById(QLNVEntity entity);

        /// <summary>
        /// Xóa đối tượng theo Id
        /// </summary>
        /// <param name="id">Khóa chính của đối tượng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: dsthuyr (14/6/2022)
        int DeleteById(Guid id);

        /// <summary>
        /// Lấy danh sách theo phân trang
        /// </summary>
        /// <param int="pageSize"">Số lượng bản ghi trên mỗi trang </param>
        /// <param int="pageIndex">Vị trí trang (trang số bao nhiêu)</param>
        /// <returns>Danh sách đối tượng</returns>
        /// CreatedBy: dsthuyr (14/6/2022)
        IEnumerable<QLNVEntity> GetPaging(int pageSize, int pageIndex);

        /// <summary>
        /// Kiểm tra mã đối tượng đã có hay chưa, trừ chính nó trong trường hợp sửa
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>true - Có; false - Không</returns>
        /// CreatedBy: dsthuyr (14/6/2022)
        bool CheckEntityCodeDuplicate(QLNVEntity entity);

        /// <summary>
        /// Lấy mã đối tượng mới
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Mã đối tượng mới</returns>
        /// CreatedBy: dsthuyr (23/6/2022)
        string GetNewEntityCode();

    }
}
