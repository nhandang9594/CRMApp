using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Antra.CRMApp.Core.Model
{
    public class VendorRequestModel
    {
        public int Id { get; set; }
        [Required, Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required, Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string City { get; set; }
        [Required, Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Country { get; set; }
        [Required, Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Mobile { get; set; }
        [Required, Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string EmailId { get; set; }
        public bool IsActive { get; set; }
    }
}
