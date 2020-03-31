using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace INSTTemp.Data.Models
{
    public class Upload
    {
        [Key]
        [Required]
        public Int64 Id { get; set; }

        [Required]
        [StringLength(100)]
        public String lectureName { get; set; }
        [Required]
        [StringLength(100)]
        public String lectureNumber { get; set; }

        [StringLength(100)]
        public String FilePath { get; set; }
        public Int64 FileSize { get; set; }
        [DataType(DataType.Upload)]
        public Byte[] DataDoc { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CreatedOn { get; set; }
    }
}
