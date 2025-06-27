using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AnswerDTO
    {
        public int AnswerId { get; set; }
        [Required]
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        [Required]
        public int QuestionId { get; set; }
    }

}
