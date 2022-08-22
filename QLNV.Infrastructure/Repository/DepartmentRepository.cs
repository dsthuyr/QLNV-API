using QLNV.Core.Entities;
using QLNV.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;
using Microsoft.Extensions.Configuration;

namespace QLNV.Infrastructure.Repository
{
    /// <summary>
    /// Lớp tương tác dữ liệu phòng ban
    /// CreatedBy: CreatedBy: dsthuyr(19/06/2022)
    /// </summary>
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        /// <summary>
        /// Hàm khởi tạo DepartmentRepository
        /// </summary>
        /// <param name="configuration"></param>
        public DepartmentRepository(IConfiguration configuration):base(configuration)
        {
        }

        /// <summary>
        /// Ghi đè hàm kiểm tra mã trùng lặp
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public override bool CheckEntityCodeDuplicate(Department department)
        {
            // Lấy đối tượng có mã trùng với nó và khác chính nó.

            // Khởi tạo sql query
            var sqlEntityCodeDuplicate = 
                $"SELECT * FROM Department WHERE DepartmentCode = @DepartmentCode AND DepartmentId != @DepartmentId";
            // Lấy danh sách phòng ban có mã trùng lặp
            DynamicParameters paramCheck = new DynamicParameters();
            paramCheck.Add("@DepartmentCode", department.DepartmentCode);
            paramCheck.Add("@DepartmentId", department.DepartmentId);
            var departmentCodeDublicate = SqlConnection.QueryFirstOrDefault<Department>(sqlEntityCodeDuplicate, param: paramCheck);
            // Nếu không có mã đối tượng trùng thì return true
            if (departmentCodeDublicate != null)
            {
                return true;
            }
            return false;
        }
    }
}
