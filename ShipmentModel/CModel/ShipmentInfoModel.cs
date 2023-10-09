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
    public class ShipmentInfoModel
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
    }
}
