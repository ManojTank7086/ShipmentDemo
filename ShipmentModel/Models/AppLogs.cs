using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShipmentModel.Models
{
    public partial class AppLogs
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(20)]
        public string UserAction { get; set; }
        [Required]
        public string EntityQuery { get; set; }
        public long CreateBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
    }
}
