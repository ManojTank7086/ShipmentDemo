using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShipmentModel.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            ShipmentInfoConsignee = new HashSet<ShipmentInfo>();
            ShipmentInfoConsignor = new HashSet<ShipmentInfo>();
        }

        [Key]
        public long Id { get; set; }
        [StringLength(50)]
        public string VendorName { get; set; }
        [StringLength(20)]
        public string VendorType { get; set; }
        public long? CreateBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }

        [InverseProperty(nameof(ShipmentInfo.Consignee))]
        public virtual ICollection<ShipmentInfo> ShipmentInfoConsignee { get; set; }
        [InverseProperty(nameof(ShipmentInfo.Consignor))]
        public virtual ICollection<ShipmentInfo> ShipmentInfoConsignor { get; set; }
    }
}
