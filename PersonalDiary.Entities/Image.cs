using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PersonalDiary.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public int PersonalDairyId { get; set; }
        [StringLength(128)]
        public string ImageName { get; set; }
        [ForeignKey("PersonalDairyId")]
        public virtual PersonalDiary PersonalDiary { get; set; } 
    }
}
