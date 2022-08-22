using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNV.Core.Entities;
using QLNV.Core.Interfaces;
using QLNV.Infrastructure.Repository;

namespace QLNV.Web04.Api.Controllers
{
    /// <summary>
    /// Lớp controller phòng ban
    /// CreatedBy: dsthuyr(26/6/2022)
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentsController : QLNVBaseController<Department>
    {
        /// <summary>
        /// Khởi tạo IDepartmentService
        /// </summary>
        IDepartmentService _service;
        /// <summary>
        /// Khởi tạo IDepartmentRepository
        /// </summary>
        IDepartmentRepository _repository;

        /// <summary>
        /// Hàm khởi tạo DepartmentsController
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="repository"></param>
        /// <param name="service"></param>
        public DepartmentsController(
            IConfiguration configuration, 
            IDepartmentRepository repository, 
            IDepartmentService service):base(repository:repository, service:service)
        {
            _service = service;
            _repository = repository;
        }
    }
}
