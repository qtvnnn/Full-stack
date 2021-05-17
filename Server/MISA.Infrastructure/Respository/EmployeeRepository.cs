using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Respository
{
    /// <summary>
    /// Employee Reposiotry implement BaseReposiotry, IEmployeeRepository
    /// </summary>
    /// CreatedBy: NNNANG (12/05/21)
    public class EmployeeRepository : BaseReposiotry<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {

        }

        /// <summary>
        /// Lấy bản ghi nhân viên theo mã nhân viên
        /// </summary>
        /// <param name="code">Mã nhân viên</param>
        /// <returns>Dữ liệu đối tượng nhân viên tương ứng</returns>
        public Employee GetEmployeeByCode(string code)
        {
            var res = _dbConnection.Query<Employee>("Proc_GetEmployeeByCode", new { EmployeeCode = code }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return res;
        }

        /// <summary>
        /// Join bảng Employee và Department để lấy Department Name tương ứng với nhân viên
        /// </summary>
        /// <returns>Danh sách nhân viên kèm tên phòng ban</returns>
        public IEnumerable<Employee> GetEmployeesWithDepartmentName()
        {
            var res = _dbConnection.Query<Employee>("Proc_GetEmployeesWithDepartmentName", commandType: CommandType.StoredProcedure);
            return res;
        }

        /// <summary>
        /// Lấy một bản ghi nhân viên theo mã nhân viên hoặc tên hoặc số điện thoại
        /// </summary>
        /// <param name="search">Mã nhân viên, tên nhân viên, số điện thoại</param>
        /// <returns>Nhân viên tương ứng</returns>
        public IEnumerable<Employee> GetEmployeeByCodeNamePhone(string search)
        {

            var sql = "  SELECT * FROM Employee e WHERE e.EmployeeCode LIKE '%" + search + "%' OR e.EmployeeName LIKE '%" + search + "%' OR e.PhoneNumber LIKE '%" + search + "%' ORDER BY e.CreatedDate DESC";
            var res = _dbConnection.Query<Employee>(sql, commandType: CommandType.Text);

            return res;
        }

        /// <summary>
        /// Lấy mã nhân viên của nhân viên gần nhất được thêm vào hệ thống
        /// </summary>
        /// <returns>Mã nhân viên tương ứng</returns>
        public string GetNewEmployeeCode()
        {
            var sql = "SELECT e.EmployeeCode FROM Employee e ORDER BY e.EmployeeCode DESC LIMIT 1;";
            var res = _dbConnection.QueryFirstOrDefault<string>(sql);

            return res;
        }
    }
}
