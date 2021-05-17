using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Service
{
    /// <summary>
    /// Interface Employee Service implement IBaseService
    /// </summary>
    /// CreatedBy: NNNANG (12/05/21)
    public interface IEmployeeService : IBaseService<Employee>
    {
        /// <summary>
        /// Service tìm kiếm nhân viên theo mã nhân viên hoặc tên nhân viên hoặc số điện 
        /// </summary>
        /// <param name="search">Mã nhân viên, tên nhân viên, số điện thoại</param>
        /// <returns>Nhân viên tương ứng</returns>
        IEnumerable<Employee> Search(string search);

        /// <summary>
        /// Server lấy danh sách nhân viên kèm tên phòng ban
        /// </summary>
        /// <returns>Danh sách nhân viên kèm tên phòng ban</returns>
        IEnumerable<Employee> GetEmployeesWithDepartmentName();

        /// <summary>
        /// Service lấy mã nhân viên của nhân viên mới nhất được thêm vào hệ thống
        /// </summary>
        /// <returns>Mã nhân viên tương ứng</returns>
        string GetNewEmployeeCode();

    }
}
