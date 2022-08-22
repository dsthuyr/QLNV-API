using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNV.Core.Entities;
using QLNV.Core.Exceptions;
using QLNV.Core.Interfaces;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace QLNV.Web04.Api.Controllers
{
    /// <summary>
    /// Lớp controller nhân viên
    /// CreatedBy: dsthuyr(26/6/2022)
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : QLNVBaseController<Employee>
    {
        IEmployeeService _service;
        IEmployeeRepository _repository;

        /// <summary>
        /// Hàm khởi tạo EmployeesController
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="service"></param>
        /// <param name="repository"></param>
        public EmployeesController(
            IConfiguration configuration,
            IEmployeeService service, 
            IEmployeeRepository repository):base(service:service, repository:repository)
        {
            _service = service;
            _repository = repository;
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo số trang, kích thước trang và chuỗi tìm kiếm
        /// </summary>
        /// <param name="pageIndex">Vị trí trang hiện tại</param>
        /// <param name="pageSize">Kích thước trang</param>
        /// <param name="employeeFilter">Chuỗi tìm kiếm</param>
        /// <returns>Danh sách đối tượng</returns>
        [Route("filter")]
        [HttpGet]
        public IActionResult Filter([FromQuery]int pageIndex, [FromQuery]int pageSize, [FromQuery]string? employeeFilter)
        {
            return StatusCode(200, _repository.Filter(pageIndex, pageSize, employeeFilter));
        }

        /// <summary>
        /// Xuất danh sách nhân viên ra file excel
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("export")]
        public async Task<IActionResult> ExportEmployeeList()
        {
            // Truy vấn dữ liệu từ DB
            await Task.Yield();
            var list = _repository.GetEmployeeExportExcel();
            var numberRecord = list.Count();
            var stream = new MemoryStream();
            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Danh sách nhân viên");
                
                // Load dữ liệu lên worksheet
                workSheet.Cells.LoadFromCollection(list, false);


                // Chèn 3 hàng : 1 hàng tiêu đề, 1 hàng trống, 1 hàng header bảng
                workSheet.InsertRow(1, 3);


                // Xóa cột đầu (Không dùng đến) và chèn 1 cột làm index, sau đó gán giá trị cho cột index
                workSheet.DeleteColumn(1);
                workSheet.InsertColumn(1, 1);
                for(int i = 0; i < numberRecord; i++)
                {
                    workSheet.Cells[i+4, 1].Value = i+1;
                }

                // Merge các ô hàng 1 và 2 từ A đến I
                workSheet.Cells["A1:I1"].Merge = true;
                workSheet.Cells["A2:I2"].Merge = true;

                // Định dạng cột ngày tháng
                workSheet.Columns[5].Style.Numberformat.Format = "dd/mm/yyyy";

                // Gán text, Style ô tiêu đề
                workSheet.Cells["A1"].LoadFromText("Danh sách nhân viên");
                workSheet.Cells["A1"].Style.Font.Size = 18;
                workSheet.Cells["A1"].Style.Font.Bold = true;

                // Gán header table, style font, style background
                workSheet.Cells[3, 1].LoadFromText("STT,Mã nhân viên,Tên nhân viên,Giới tính,Ngày sinh,Chức danh,Tên đơn vị,Số tài khoản,Tên ngân hàng");
                workSheet.Cells["A3:I3"].Style.Font.Bold = true;
                workSheet.Cells["A3:I3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["A3:I3"].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#D8D8D8"));

                // Gán border cho các ô trong bảng
                workSheet.Cells[$"A3:I{numberRecord + 3}"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A3:I{numberRecord + 3}"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A3:I{numberRecord + 3}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A3:I{numberRecord + 3}"].Style.Border.Left.Style = ExcelBorderStyle.Thin;

                workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();

                // Căn lề một số cột và ô
                workSheet.Columns[5].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                workSheet.Columns[1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                workSheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                package.Save();
            }
            stream.Position = 0;
            string excelName = $"EmployeeData_{DateTime.Now.ToString("dd-MM-yyyy")}.xlsx";

            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }
    }
}
