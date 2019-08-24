using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalDiary.Service.Dto
{
    public class PersonalDiaryDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Note { get; set; }
        public bool IsNoteEnded { get; set; }
        public int PersonId { get; set; } = 1;
    }
}
