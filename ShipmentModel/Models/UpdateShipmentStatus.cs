using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShipmentModel.Models
{
    public partial class UpdateShipmentStatus
    {
        [Key]
        public long Id { get; set; }
        [Column("Shipment_Id")]
        public long ShipmentId { get; set; }
        [StringLength(20)]
        public string VechicalNo { get; set; }
        [StringLength(50)]
        public string DriverName { get; set; }
        public long ContactNo1 { get; set; }
        public long? ContactNo2 { get; set; }
        public long CreateBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
    }
}
