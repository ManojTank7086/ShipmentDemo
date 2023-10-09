using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShipmentModel.Models
{
    public partial class ShipmentInfo
    {
        [Key]
        public long Id { get; set; }
        [Column("OriginPoint_Id")]
        public long OriginPointId { get; set; }
        [Column("DestinationPoint_Id")]
        public long DestinationPointId { get; set; }
        [Column("Consignor_Id")]
        public long ConsignorId { get; set; }
        [Column("Consignee_Id")]
        public long ConsigneeId { get; set; }
        [Column("Status_Id")]
        public long StatusId { get; set; }
        [StringLength(100)]
        public string OriginAddress { get; set; }
        [StringLength(100)]
        public string DestinationAddress { get; set; }
        [StringLength(20)]
        public string AwbNo { get; set; }
        [Required]
        [StringLength(100)]
        public string Item { get; set; }
        public int PktQty { get; set; }
        public long CreateBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }

        [ForeignKey(nameof(ConsigneeId))]
        [InverseProperty(nameof(Vendor.ShipmentInfoConsignee))]
        public virtual Vendor Consignee { get; set; }
        [ForeignKey(nameof(ConsignorId))]
        [InverseProperty(nameof(Vendor.ShipmentInfoConsignor))]
        public virtual Vendor Consignor { get; set; }
        [ForeignKey(nameof(DestinationPointId))]
        [InverseProperty(nameof(ShipmentPoint.ShipmentInfoDestinationPoint))]
        public virtual ShipmentPoint DestinationPoint { get; set; }
        [ForeignKey(nameof(OriginPointId))]
        [InverseProperty(nameof(ShipmentPoint.ShipmentInfoOriginPoint))]
        public virtual ShipmentPoint OriginPoint { get; set; }
        [ForeignKey(nameof(StatusId))]
        [InverseProperty(nameof(ShipmentStatus.ShipmentInfo))]
        public virtual ShipmentStatus Status { get; set; }
    }
}
