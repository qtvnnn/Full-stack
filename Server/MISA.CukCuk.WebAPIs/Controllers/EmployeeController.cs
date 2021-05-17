using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.WebAPIs.Controllers
{
    /// <summary>
    /// Employee Controller implement BaseEntityController
    /// </summary>
    /// CreatedBy: NNNANG (12/05/21)
    public class EmployeeController : BaseEntityController<Employee>
    {   
        IEmployeeService _employeeService;

        // Constuctor
        public EmployeeController(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Lấy danh sach tất cả nhân viên kèm tên phòng ban
        /// </summary>
        /// <returns>Danh sách nhân viên kèm tên phòng ban</returns>
        [HttpGet("EmployeesWithDepartment")]
        public IActionResult GetEmployeesWithDepartmentName()
        {
            var entities = _employeeService.GetEmployeesWithDepartmentName();
            return Ok(entities);
        }

        /// <summary>
        /// Http Get: Tìm kiếm nhân viên theo mã nhân viên hoặc tên nhân viên hoặc số điện thoại
        /// </summary>
        /// <param name="search">Mã nhân viên, tên nhân viên hoặc số điện thoại</param>
        /// <returns>Nhân viên tương ứng</returns>
        [HttpGet("employeeFilter")]
        public IActionResult Search(string search)
        {
            var entities = _employeeService.Search(search);
            return Ok(entities);
        }

        /// <summary>
        /// Http Get: Lấy mã nhân viên của nhân viên mới nhất được thêm vào hệ thống
        /// </summary>
        /// <returns>Mã nhân viên mới tăng thêm một đơn vị ở phần số</returns>
        [HttpGet("newEmployeeCode")]
        public IActionResult GetNewEmployeeCode()
        {
            try
            {
                var entities = _employeeService.GetNewEmployeeCode();
                string numberEmployeeCode = entities.Substring(3);//Cắt chuỗi lấy các số của mã nhân viên
                string newEmployeeCode = "NV-" + (Int32.Parse(numberEmployeeCode) + 1);//tăng thêm 1 và ghép trở lại thành mã nhân viên hoàn chỉnh
                return Ok(newEmployeeCode);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
