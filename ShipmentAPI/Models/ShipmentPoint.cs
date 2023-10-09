using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShipmentAPI.Models
{
    public partial class ShipmentPoint
    {
        public ShipmentPoint()
        {
            ShipmentInfoDestinationPoint = new HashSet<ShipmentInfo>();
            ShipmentInfoOriginPoint = new HashSet<ShipmentInfo>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string AreaName { get; set; } = null!;
        public bool IsActive { get; set; }
        public long CreateBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }

        [InverseProperty(nameof(ShipmentInfo.DestinationPoint))]
        public virtual ICollection<ShipmentInfo> ShipmentInfoDestinationPoint { get; set; }
        [InverseProperty(nameof(ShipmentInfo.OriginPoint))]
        public virtual ICollection<ShipmentInfo> ShipmentInfoOriginPoint { get; set; }
    }
}
