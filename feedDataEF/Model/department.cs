using System.ComponentModel.DataAnnotations;

namespace feedDataEF.Model
{
    public class department
    {
        [Key]
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }
}
