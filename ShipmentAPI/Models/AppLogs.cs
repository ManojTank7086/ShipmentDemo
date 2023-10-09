using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShipmentAPI.Models
{
    public partial class AppLogs
    {
        [Key]
        public long Id { get; set; }
        [StringLength(20)]
        public string UserAction { get; set; } = null!;
        public string EntityQuery { get; set; } = null!;
        public long CreateBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
    }
}
