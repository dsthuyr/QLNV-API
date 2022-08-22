using QLNV.Core.Entities;
using QLNV.Core.Exceptions;
using QLNV.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV.Core.Services
{
    /// <summary>
    /// Lớp Nghiệp vụ phòng ban
    /// CreatedBy: dsthuyr(19/06/2022)
    /// </summary>
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {
        /// <summary>
        /// Khởi tạo IDepartmentRepository
        /// </summary>
        IDepartmentRepository _departmentRepository;

        /// <summary>
        /// Hàm khởi tạo DepartmentService
        /// </summary>
        /// <param name="departmentRepository"></param>
        public DepartmentService(IDepartmentRepository departmentRepository) : base(departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        //protected override bool Validate(Department department)
        //{
        //    var errorValidateMessage = new List<string>();
        //    // Xử lí nghiệp vụ
        //    // Validate dữ liệu
        //    // 1.Kiểm tra các thông tin bắt buộc nhập
        //    if (string.IsNullOrEmpty(department.DepartmentCode))
        //    {
        //        errorValidateMessage.Add("Mã phòng ban không được phép để trống.");
        //    }
        //    if (string.IsNullOrEmpty(department.DepartmentName))
        //    {
        //        errorValidateMessage.Add("Tên phòng ban không được phép để trống.");
        //    }

        //    // 4.Kiểm tra mã phòng ban đã tồn tại hay chưa và có độ dài lớn hơn 20 kí tự không
        //    if (department.DepartmentCode.Length > 20)
        //    {
        //        errorValidateMessage.Add("Mã phòng ban không được phép lớn hơn 20 kí tự.");
        //    }
        //    bool isEmployeeDuplicate = _departmentRepository.CheckEntityCodeDuplicate(department);
        //    if (isEmployeeDuplicate)
        //    {
        //        errorValidateMessage.Add("Mã phòng ban đã tồn tại trong hệ thống, vui lòng kiểm tra lại.");
        //    }

        //    // 5. Kiểm tra xem có lỗi không, nếu có thì throw exception
        //    if (errorValidateMessage.Count > 0)
        //    {
        //        throw new QLNVValidateException(Resources.ResourceVN.VN_ValidateError_InputNotValid, errorValidateMessage);
        //        return false;
        //    }
        //    return true;
        //}
    }
}
