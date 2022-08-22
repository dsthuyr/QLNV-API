using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;
using Microsoft.Extensions.Configuration;
using QLNV.Core.Interfaces;

namespace QLNV.Infrastructure.Repository
{
    /// <summary>
    /// Lớp Base tương tác dữ liệu
    /// CreatedBy: CreatedBy: dsthuyr(19/06/2022)
    /// </summary>
    /// <typeparam name="QLNVEntity"></typeparam>
    public class BaseRepository<QLNVEntity> : IBaseRepository<QLNVEntity> where QLNVEntity : class
    {
        /// <summary>
        /// Khởi tạo ConnectionString
        /// </summary>
        protected string ConnectionString;

        /// <summary>
        /// Khởi tạo SqlConnection
        /// </summary>
        protected MySqlConnection SqlConnection;

        /// <summary>
        /// Gán tên Class vào _className
        /// </summary>
        string _className = typeof(QLNVEntity).Name;

        /// <summary>
        /// Hàm khởi tạo BaseRepository
        /// </summary>
        /// <param name="configuration"></param>
        public BaseRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("QLNV_Database");

            SqlConnection = new MySqlConnection(ConnectionString);
            //var a = 10;
        }

        /// <summary>
        /// Lấy toàn bộ bản ghi
        /// </summary>
        /// <returns>Danh sách đối tượng</returns>
        public IEnumerable<QLNVEntity> GetAll() 
        {
            var sqlCommand = $"Proc_Get{_className}s";
            var entities = SqlConnection.Query<QLNVEntity>(sqlCommand, commandType:System.Data.CommandType.StoredProcedure);
            return entities;
        }

        /// <summary>
        /// Lấy bản ghi theo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Đối tượng</returns>
        public QLNVEntity GetById(Guid id)
        {
            var sqlCommand = $"Proc_Get{_className}ById";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@{_className}Id", id);
            var entity = SqlConnection.QueryFirstOrDefault<QLNVEntity>(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            return entity;
        }
 
        /// <summary>
        /// Thêm bản ghi mới
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        public int InsertNew(QLNVEntity entity)
        {
            var sqlCommand = $"Proc_Insert{_className}";
            var res = SqlConnection.Execute(sqlCommand, param: entity, commandType: System.Data.CommandType.StoredProcedure);
            return res;
        }

        /// <summary>
        /// Cập nhật bản ghi theo Id
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        public int UpdateById(QLNVEntity entity)
        {
            var sqlCommand = $"Proc_Update{_className}ById";
            var res = SqlConnection.Execute(sqlCommand, param: entity, commandType: System.Data.CommandType.StoredProcedure);
            return res;
        }

        /// <summary>
        /// Xóa bản ghi theo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        public int DeleteById(Guid id)
        {
            var sqlCommand = $"Proc_Delete{_className}ById";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@m_{_className}Id", id);
            var res = SqlConnection.Execute(sqlCommand, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            return res;
        }

        /// <summary>
        /// Lấy danh sách theo phân trang
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns>Danh sách đối tượng</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<QLNVEntity> GetPaging(int pageSize, int pageIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Kiểm tra mã trùng lặp
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>true - mã bị trùng; false - mã không trùng</returns>
        public virtual bool CheckEntityCodeDuplicate(QLNVEntity entity)
        {
            return false;
        }

        /// <summary>
        /// Lấy mã đối tượng mới
        /// </summary>
        /// <returns>Mã đối tượng mới</returns>
        public string GetNewEntityCode()
        {
            var sqlQuery = $"SELECT MAX({_className}Code) FROM {_className}";

            var biggestEntityCode = SqlConnection.QueryFirstOrDefault<string>(sqlQuery);
            string entityCode = string.Join(" ", biggestEntityCode);
            for(int i = 0; i < entityCode.Length; i++)
            {
                if(entityCode[i] == '-')
                {
                    string text = entityCode.Substring(0, i+1) ;
                    int code = Int32.Parse(entityCode.Substring(i + 1)) + 1;
                    entityCode = text + code;
                }
            }
            return entityCode;
        }
    }
}
