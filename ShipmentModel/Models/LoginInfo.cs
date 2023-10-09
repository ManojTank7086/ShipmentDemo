using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShipmentModel.Models
{
    [Index(nameof(UserName), nameof(UserPass), Name = "LoginInfo_unique_user", IsUnique = true)]
    public partial class LoginInfo
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        public string UserPass { get; set; }
        public bool IsActive { get; set; }
        public long CreateBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
    }
}
