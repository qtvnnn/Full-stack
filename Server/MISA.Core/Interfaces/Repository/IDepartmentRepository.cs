using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Repository
{
    /// <summary>
    /// Interface Department Repository implement IBaseRepository
    /// </summary>
    /// CreatedBy: NNNANG (12/05/21)
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        /// <summary>
        /// Lấy một bản ghi phòng ban theo Id phòng ban
        /// </summary>
        /// <param name="departmentId">Id phòng ban</param>
        /// <returns>Phòng ban tương ứng</returns>
        Department GetDepartmentById(Guid departmentId);
    }
}
