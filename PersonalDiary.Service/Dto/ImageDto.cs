using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalDiary.Service.Dto
{
    public class ImageDto
    {
        public int Id { get; set; }
        public int PersonalDairyId { get; set; }
        public string ImageName { get; set; }
    }
}
