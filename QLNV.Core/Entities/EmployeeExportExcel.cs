using QLNV.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNV.Core.Entities
{
    /// <summary>
    /// Nhân viên xuất ra file excel
    /// CreatedBy: dsthuyr (11/6/2022)
    /// </summary>
    public class EmployeeExportExcel
    {

        /// <summary>
        /// Giới tính
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; } = string.Empty;

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string EmployeeName { get; set; } = string.Empty;

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
        /// Chức danh
        /// </summary>
        public string? EmployeePosition { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string? DepartmentName { get; set; }


        /// <summary>
        /// Số tài khoản ngân hàng
        /// </summary>
        public string? BankAccountNumber { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string? BankName { get; set; }

    }
}
