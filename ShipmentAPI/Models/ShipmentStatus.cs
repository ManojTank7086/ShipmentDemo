using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShipmentAPI.Models
{
    public partial class ShipmentStatus
    {
        public ShipmentStatus()
        {
            ShipmentInfo = new HashSet<ShipmentInfo>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string StatusName { get; set; } = null!;
        public bool IsActive { get; set; }
        public long CreateBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }

        [InverseProperty("Status")]
        public virtual ICollection<ShipmentInfo> ShipmentInfo { get; set; }
    }
}
