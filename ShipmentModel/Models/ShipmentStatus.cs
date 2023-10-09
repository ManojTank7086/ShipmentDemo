using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShipmentModel.Models
{
    public partial class ShipmentStatus
    {
        public ShipmentStatus()
        {
            ShipmentInfo = new HashSet<ShipmentInfo>();
            UpdateShipmentStatus = new HashSet<UpdateShipmentStatus>();
        }

        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string StatusName { get; set; }
        public bool IsActive { get; set; }
        public long CreateBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }

        [InverseProperty("Status")]
        public virtual ICollection<ShipmentInfo> ShipmentInfo { get; set; }
        [InverseProperty("Status")]
        public virtual ICollection<UpdateShipmentStatus> UpdateShipmentStatus { get; set; }
    }
}
