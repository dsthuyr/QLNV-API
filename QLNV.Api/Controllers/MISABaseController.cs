using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNV.Core.Interfaces;

namespace QLNV.Web04.Api.Controllers
{
    /// <summary>
    /// Lớp Base Controller
    /// </summary>
    /// <typeparam name="QLNVEntity"></typeparam>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class QLNVBaseController<QLNVEntity> : ControllerBase where QLNVEntity : class
    {
        IBaseRepository<QLNVEntity> _repository;
        IBaseService<QLNVEntity> _service;

        /// <summary>
        /// Hàm khởi tạo QLNVBaseController
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="service"></param>
        public QLNVBaseController(IBaseRepository<QLNVEntity> repository, IBaseService<QLNVEntity> service)
        {
            _repository = repository;
            _service = service;
        }

        /// <summary>
        /// Lấy toàn bộ bản ghi
        /// </summary>
        /// <returns>Danh sách đối tượng</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return StatusCode(200, _repository.GetAll());
        }

        /// <summary>
        /// Lấy bản ghi theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Đối tượng</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return StatusCode(200, _repository.GetById(id));
        }

        /// <summary>
        /// Thêm bản ghi mới
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        [HttpPost]
        public IActionResult InsertNew(QLNVEntity entity)
        {
            return StatusCode(201, _service.InsertService(entity));
        }

        /// <summary>
        /// Cập nhật bản ghi theo Id
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        [HttpPut]
        public IActionResult UpdateById(QLNVEntity entity)
        {
            return StatusCode(201, _service.UpdateService(entity));
        }

        /// <summary>
        /// Xóa bản ghi theo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            return StatusCode(200, _repository.DeleteById(id));
        }

        /// <summary>
        /// Lấy mã đối tượng mới
        /// </summary>
        /// <returns>Mã đối tượng</returns>
        [Route("GetNewCode")]
        [HttpGet]
        public IActionResult GetNewEntityCode()
        {
            return StatusCode(200, _repository.GetNewEntityCode());
        }
    }
}
