using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Service
{
    /// <summary>
    /// Interface Department Service implement IBaseService
    /// </summary>
    /// CreatedBy: NNNANG (12/05/21)
    public interface IDepartmentService : IBaseService<Department>
    {
        /// <summary>
        /// Service lấy một bản ghi phòng ban theo id
        /// </summary>
        /// <param name="departmentId">ID phòng ban</param>
        /// <returns>Phòng ban tương ứng</returns>
        Department GetDepartmentById(Guid departmentId);
    }
}
