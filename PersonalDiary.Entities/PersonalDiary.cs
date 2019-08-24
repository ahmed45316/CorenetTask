using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PersonalDiary.Entities
{
    public class PersonalDiary
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        [StringLength(500)]
        public string Note { get; set; }
        public bool IsNoteEnded { get; set; } = false;
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person User { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
