using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ExamDTO
    {
        public int ExamId { get; set; } /////////
        [Required]
        [StringLength(200)]
        public string Title { get; set; }///////////////
        public string Description { get; set; }////////////
        [Required]
        public DateTime StartTime { get; set; }////////////
        [Required]
        public DateTime EndTime { get; set; }/////////////
        [Required]
        [Range(1, int.MaxValue)]
        public int DurationInMinutes { get; set; }////////////////
        [Required]
        public int TeacherId { get; set; }/////////////////////
    }

}
