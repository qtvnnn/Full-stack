using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Repository
{
    /// <summary>
    /// Interface Employee Repository implement IBaseRepository
    /// </summary>
    /// CreatedBy: NNNANG (12/05/21)
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        /// <summary>
        /// Lấy dữ liệu của một nhân viên theo mã nhân viên
        /// </summary>
        /// <param name="code">Mã nhân viên</param>
        /// <returns>Dữ liệu đối tượng nhân viên</returns>
        Employee GetEmployeeByCode(string code);

        /// <summary>
        /// Lấy danh sách nhân viên kèm tên phòng ban
        /// </summary>
        /// <returns>Danh sách nhân viên kèm tên phòng ban</returns>
        IEnumerable<Employee> GetEmployeesWithDepartmentName();

        /// <summary>
        /// Lấy nhân viên theo tên nhân viên, mã nhân viên hoặc số điện thoại
        /// </summary>
        /// <param name="search">Tên nhân viên, mã nhân viên, số điện thoại</param>
        /// <returns>Nhân viên tương ứng</returns>
        IEnumerable<Employee> GetEmployeeByCodeNamePhone(string search);

        /// <summary>
        /// Lấy mã nhân viên của nhân viên mới nhất được thêm vào hệ thống
        /// </summary>
        /// <returns>Mã nhân viên tương ứng</returns>
        string GetNewEmployeeCode();
    }
}
