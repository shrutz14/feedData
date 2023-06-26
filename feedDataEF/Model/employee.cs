using System.ComponentModel.DataAnnotations;

namespace feedDataEF.Model
{
    public class employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string departmentName { get; set; }
    }
}
