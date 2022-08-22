using QLNV.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV.Core.Services
{
    /// <summary>
    /// Lớp BaseService 
    /// CreatedBy: dsthuyr(19/06/2022)
    /// </summary>
    /// <typeparam name="QLNVEntity"></typeparam>
    public class BaseService<QLNVEntity> : IBaseService<QLNVEntity> where QLNVEntity : class
    {
        /// <summary>
        /// Khởi tạo IBaseRepository
        /// </summary>
        IBaseRepository<QLNVEntity> _repository;

        /// <summary>
        /// Hàm khởi tạo BaseService
        /// </summary>
        /// <param name="repository"></param>
        public BaseService(IBaseRepository<QLNVEntity> repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Nghiệp vụ thêm dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int InsertService(QLNVEntity entity)
        {
            // Thực hiện validate
            bool isValid = Validate(entity);
            // Thực hiện thêm mới
            if (isValid)
            {
                return _repository.InsertNew(entity);
            }
            return 0;
        }

        /// <summary>
        /// Nghiệp vụ cập nhật
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int UpdateService(QLNVEntity entity)
        {
            // Thực hiện validate
            bool isValid = Validate(entity);
            // Thực hiện thêm mới
            if (isValid)
            {
                return _repository.UpdateById(entity);
            }
            return 0;
        }

        /// <summary>
        /// Validate dữ liệu trước khi thêm và cập nhật
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual bool Validate(QLNVEntity entity)
        {
            return true;
        }
    }
}
