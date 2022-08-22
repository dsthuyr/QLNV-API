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
using System.Data;

namespace QLNV.Infrastructure.Repository
{
    /// <summary>
    /// Lớp tương tác dữ liệu nhân viên
    /// CreatedBy: CreatedBy: dsthuyr(19/06/2022)
    /// </summary>
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration configuration):base(configuration)
        {
        }

        /// <summary>
        /// Ghi đè hàm kiểm tra mã trùng lặp
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public override bool CheckEntityCodeDuplicate(Employee employee)
        {
            // Lấy đối tượng có mã trùng với nó và khác chính nó.

            // Khởi tạo sql query
            var sqlEntityCodeDuplicate =
                $"SELECT * FROM Employee WHERE EmployeeCode = @EmployeeCode AND EmployeeId != @EmployeeId";
            // Lấy danh sách nhân viên có mã trùng lặp
            DynamicParameters paramCheck = new DynamicParameters();
            paramCheck.Add("@EmployeeCode", employee.EmployeeCode);
            paramCheck.Add("@EmployeeId", employee.EmployeeId);
            var employeeCodeDublicate = SqlConnection.QueryFirstOrDefault<Employee>(sqlEntityCodeDuplicate, param: paramCheck);
            // Nếu không có mã đối tượng trùng thì return true
            if (employeeCodeDublicate != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Lấy dữ liệu nhân viên theo số trang, kích thước trang và chuỗi tìm kiếm
        /// </summary>
        /// <param name="pageIndex">Số trang hiện tại</param>
        /// <param name="pageSize">Kích thước trang</param>
        /// <param name="employeeFilter">Chuỗi tìm kiếm</param>
        /// <returns>Danh sách đối tượng</returns>
        public object Filter(int pageIndex , int pageSize, string employeeFilter = "")
        {
            var sqlCommand = "Proc_GetEmployeesFilter";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@PageIndex", pageIndex);
            parameters.Add("@PageSize", pageSize);
            if(employeeFilter == null)
            {
                parameters.Add("@EmployeeFilter", "");
            }
            else
            {
                parameters.Add("@EmployeeFilter", employeeFilter);
            }
            parameters.Add("@Offset", pageSize*(pageIndex-1));
            parameters.Add("@TotalRecord", direction: ParameterDirection.Output, dbType: DbType.Int32);
            parameters.Add("@TotalPage", direction: ParameterDirection.Output, dbType: DbType.Int32);
            var entities = SqlConnection.Query<Employee>(sqlCommand, parameters, commandType:System.Data.CommandType.StoredProcedure);
            int totalRecords = parameters.Get<int>("@TotalRecord");
            int totalPages = parameters.Get<int>("@TotalPage");
            object dataFilter = new {
                TotalPage = totalPages,
                TotalRecord = totalRecords,
                DataReceived = entities,
            };
            return dataFilter;
        }

        /// <summary>
        /// Lấy danh sách nhân viên để xuất ra excel
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeExportExcel> GetEmployeeExportExcel()
        {
            var sqlCommand = $"Proc_GetEmployees";
            var entities = SqlConnection.Query<EmployeeExportExcel>(sqlCommand, commandType: System.Data.CommandType.StoredProcedure);
            return entities;
        }

        /// <summary>
        /// Xóa nhân viên theo id, và xóa hàng loạt
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public override int DeleteById(string id)
        //{
            //var sqlCommand = $"Proc_Delete{_className}ById";
            //DynamicParameters parameters = new DynamicParameters();
            //parameters.Add($"@m_{_className}Id", id);
            //var res = SqlConnection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            //return res;
        //}
    }
}
