using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentModel.CModel
{
    public class UpdateShipmentStatusModel
    {
        [Key]
        public long Id { get; set; }
        [Column("Shipment_Id")]
        public long ShipmentId { get; set; }
        [Column("Status_Id")]
        public long StatusId { get; set; }
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
