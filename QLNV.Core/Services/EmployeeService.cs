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
    /// Lớp nghiệp vụ nhân viên
    /// CreatedBy: dsthuyr(19/06/2022)
    /// </summary>
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        /// <summary>
        /// Khởi tạo IEmployeeRepository
        /// </summary>
        IEmployeeRepository _employeeRepository;

        /// <summary>
        /// Hàm khởi tạo EmployeeService
        /// </summary>
        /// <param name="employeeRepository"></param>
        public EmployeeService(IEmployeeRepository employeeRepository):base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        /// <summary>
        /// Validate cho thêm mới và cập nhật
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// <exception cref="QLNVValidateException"></exception>
        protected override bool Validate(Employee employee)
        {
            //employee.EmployeeId = new Guid();

            var errorValidateMessage = new List<string>();
            // Xử lí nghiệp vụ
            // Validate dữ liệu
            // 1.Kiểm tra các thông tin bắt buộc nhập
            if (string.IsNullOrEmpty(employee.EmployeeCode))
            {
                errorValidateMessage.Add(Resources.ResourceVN.VN_ValidateError_EmployeeCodeNotEmpty);
                throw new ValidateException(Resources.ResourceVN.VN_ValidateError_InputNotValid, errorValidateMessage);
                return false;
            }
            if (string.IsNullOrEmpty(employee.EmployeeName))
            {
                errorValidateMessage.Add(Resources.ResourceVN.VN_ValidateError_EmployeeNameNotEmpty);
                throw new ValidateException(Resources.ResourceVN.VN_ValidateError_InputNotValid, errorValidateMessage);
                return false;
            }
            string departmentIdString = employee.DepartmentId.ToString("D");
            if (string.IsNullOrEmpty(departmentIdString) || departmentIdString == "00000000-0000-0000-0000-000000000000")
            {
                errorValidateMessage.Add(Resources.ResourceVN.VN_ValidateError_DepartmentNotEmpty);
                throw new ValidateException(Resources.ResourceVN.VN_ValidateError_InputNotValid, errorValidateMessage);
                return false;
            }

            // 2.Kiểm tra định dạng dữ liệu: Định dạng email đã hợp lệ hay chưa
            if (!IsValidEmail(employee.Email))
            {
                errorValidateMessage.Add(Resources.ResourceVN.VN_ValidateError_EmailNotValid);
                throw new ValidateException(Resources.ResourceVN.VN_ValidateError_InputNotValid, errorValidateMessage);
                return false;
            }

            // 3.Kiểm tra ngày sinh có lớn hơn ngày hiện tại ?
            var currentDate = DateTime.Now;
            var dateOfBirth = employee.DateOfBirth;
            if (dateOfBirth > currentDate)
            {
                errorValidateMessage.Add(Resources.ResourceVN.VN_ValidateError_DOBNotValid);
                throw new ValidateException(Resources.ResourceVN.VN_ValidateError_InputNotValid, errorValidateMessage);
                return false;
            }

            // 4.Kiểm tra mã nhân viên đã tồn tại hay chưa và có độ dài lớn hơn 20 kí tự không
            if (employee.EmployeeCode.Length > 20)
            {
                errorValidateMessage.Add(Resources.ResourceVN.VN_ValidateError_EmployeeCodeToLong);
                throw new ValidateException(Resources.ResourceVN.VN_ValidateError_InputNotValid, errorValidateMessage);
                return false;
            }
            bool isEmployeeDuplicate = _employeeRepository.CheckEntityCodeDuplicate(employee);
            if (isEmployeeDuplicate)
            {
                errorValidateMessage.Add(Resources.ResourceVN.VN_ValidateError_EmployeeCodeDuplilcate);
                throw new ValidateException(Resources.ResourceVN.VN_ValidateError_InputNotValid, errorValidateMessage);
                return false;
            }

            // 5. Kiểm tra xem có lỗi không, nếu có thì throw exception
            //if (errorValidateMessage.Count > 0)
            //{
            //    throw new QLNVValidateException(Resources.ResourceVN.VN_ValidateError_InputNotValid, errorValidateMessage);
            //    return false;
            //}
            return true;
        }

        /// <summary>
        /// Hàm kiểm tra định dạng email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true - Hợp lệ; false - Không hợp lệ</returns>
        private bool IsValidEmail(string? email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}
