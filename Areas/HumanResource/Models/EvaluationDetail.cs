using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArERP.Models.Entity;

namespace ArERP.Areas.HumanResource.Models;
public class EvaluationDetail
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int EvaluationHeaderId { get; set; }
    [ForeignKey("EvaluationHeaderId")]
    public EvaluationHeader EvaluationHeader { get; set; }

    [Required]
    public int EmployeeId { get; set; }
    [ForeignKey("EmployeeId")]
    public Employee Employee { get; set; }

    [Required] [Range(0, 100)] [Column(TypeName = "decimal(18,2)")]
    public decimal PerformanceScore { get; set; }

    [Required] [Range(0, 100)] [Column(TypeName = "decimal(18,2)")]
    public decimal QualityScore { get; set; }

    [NotMapped] [Column(TypeName = "decimal(18,2)")]
    public decimal TotalScore => PerformanceScore + QualityScore;

    [StringLength(200)]
    public string DetailRemarks { get; set; }
}
    