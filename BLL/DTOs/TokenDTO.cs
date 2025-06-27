using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TokenDTO
    {
        public int TokenId { get; set; }

        [Required]
        [StringLength(100)]
        public string TokenValue { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserType { get; set; } // "Teacher" or "Student"
    }
}
