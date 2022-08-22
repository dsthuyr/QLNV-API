using QLNV.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV.Core.Entities
{
    /// <summary>
    /// Nhân viên
    /// CreatedBy: dsthuyr (11/6/2022)
    /// </summary>
    public class Employee
    {

        /// <summary>
        /// Khóa chính
        /// </summary>
        /// 
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; } = string.Empty;

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string EmployeeName { get; set; } = string.Empty;

        /// <summary>
        /// Giới tính
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Tên giới tính
        /// </summary>
        public string GenderName
        {
            get
            {
                switch (Gender)
                {
                    case Enum.Gender.Female:
                        return "Nữ";
                        break;
                    case Enum.Gender.Male:
                        return "Nam";
                        break;
                    case Enum.Gender.Other:
                        return "Khác";
                        break;
                    default:
                        return "";
                        break;
                }
            }
        }

        /// <summary>
        /// Ngày tháng năm sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Địa chỉ
        /// /summary>
        public string? Address { get; set; }

        /// <summary>
        /// Số CMND
        /// </summary>
        public string? IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp
        /// </summary>
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp
        /// </summary>
        public string? IdentityPlace { get; set; }

        /// <summary>
        /// Khóa ngoại - Mã phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Khóa ngoại - Mã vị trí
        /// </summary>
        public Guid PositionId { get; set; }

        /// <summary>
        /// Trạng thái công việc
        /// </summary>
        public int? WorkStatus { get; set; }

        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string? PersonalTaxCode { get; set; }

        /// <summary>
        /// Lương
        /// </summary>
        public double? Salary { get; set; }

        /// <summary>
        /// Số di động
        /// </summary>
        public string? TelephoneNumber { get; set; }

        /// <summary>
        /// Số tài khoản ngân hàng
        /// </summary>
        public string? BankAccountNumber { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string? BankName { get; set; }

        /// <summary>
        /// Tên chi nhánh
        /// </summary>
        public string? BankBranchName { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Tạo bởi
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người chình sửa
        /// </summary>
        public string? ModifiedBy { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string? DepartmentName { get; set; }

        /// <summary>
        /// Tên vị trí
        /// </summary>
        public string? PositionName { get; set; }

        /// <summary>
        /// Chức danh
        /// </summary>
        public string? EmployeePosition { get; set; }

    }
}
