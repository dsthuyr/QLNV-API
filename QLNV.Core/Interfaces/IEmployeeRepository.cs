using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNV.Core.Entities;

namespace QLNV.Core.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        /// <summary>
        /// Tìm kiếm, phân trang danh sách nhân viên theo (Mã hoặc họ tên hoặc số điện thoại) và (phòng ban)
        /// </summary>
        /// <returns></returns>
        object Filter(int pageIndex, int pageSize, string employeeFilter);

        /// <summary>
        /// Lấy danh sách nhân viên để xuất ra file excel
        /// </summary>
        /// <returns>Danh sách nhân viên</returns>
        IEnumerable<EmployeeExportExcel> GetEmployeeExportExcel();
    }
}
