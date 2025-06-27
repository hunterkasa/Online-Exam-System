using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class StudentExamResultDTO
    {
        public int StudentExamResultId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int ExamId { get; set; }
        [Required]
        [Range(0, 100)]
        public decimal Score { get; set; }
        [Required]
        public DateTime ExamTakenTime { get; set; }
    }

}
