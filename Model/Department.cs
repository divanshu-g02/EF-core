using System.ComponentModel.DataAnnotations;

namespace EF_core.Model
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

    }
}
