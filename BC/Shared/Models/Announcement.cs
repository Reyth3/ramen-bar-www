using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Shared.Models
{
    public class Announcement
    {
        public Announcement()
        {
            PostingDate = DateTimeOffset.UtcNow;
        }
        public int AnnouncementId { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(200)]
        public string Preview { get; set; }
        [MaxLength(5000)]
        public string Text { get; set; }
        [MaxLength(1048576)]
        public byte[] Thumbnail { get; set; }
        public DateTimeOffset PostingDate { get; set; }

        public UserProfile Author { get; set; }
    }
}
