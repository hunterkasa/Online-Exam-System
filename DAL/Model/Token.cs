using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Token
    {
        public int TokenId { get; set; }
        [Required]
        [StringLength(100)]
        public string TokenValue { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int UserId { get; set; } 
    }
}

