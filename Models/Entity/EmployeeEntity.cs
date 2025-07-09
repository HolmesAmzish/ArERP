using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Models.Entity
{
    public class EmployeeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "员工姓名不能为空")]
        [StringLength(100, ErrorMessage = "员工姓名长度不能超过100个字符")]
        public string EmployeeName { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        [EmailAddress(ErrorMessage = "邮箱格式不正确")]
        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; } = DateTime.Now;

        [StringLength(100)]
        public string Department { get; set; }

        [StringLength(100)]
        public string Position { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }

        public bool IsActive { get; set; } = true;

        public EmployeeEntity() { }
    }
}
