using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArERP.Areas.HumanResource.Models;

public class EvaluationHeader
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    [DisplayName("单据编号")]
    public string DocumentNumber { get; set; }

    [Required]
    [DisplayName("考核日期")]
    public DateTime EvaluationDate { get; set; }

    [StringLength(500)]
    [DisplayName("备注")]
    public string Remarks { get; set; }

    [Required]
    [StringLength(50)]
    [DisplayName("考核人")]
    public string Operator { get; set; }

    public List<EvaluationDetail> Details { get; set; } = new List<EvaluationDetail>();
}


