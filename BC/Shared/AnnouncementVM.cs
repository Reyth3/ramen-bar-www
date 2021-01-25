using BC.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Shared
{
    public class AnnouncementVM
    {
        public int AnnouncementId { get; set; }
        [Required, StringLength(100, ErrorMessage = "Tytuł artykułu jest zbyt długi.")]
        public string Title { get; set; }
        public string Preview { get; set; }
        [Required, StringLength(5000, ErrorMessage = "Tekst jest zbyt długi.")]
        public string Text { get; set; }
        public byte[] Thumbnail { get; set; }
        public DateTimeOffset PostingDate { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        
        public string ImageSource { get { return Encoding.UTF8.GetString(Thumbnail ?? new byte[0]); } }

        public static implicit operator AnnouncementVM(Announcement a)
        {
            if (a == null)
                return null;
            return new AnnouncementVM()
            {
                AnnouncementId = a.AnnouncementId,
                AuthorFirstName = a.Author.FirstName,
                AuthorLastName = a.Author.LastName,
                PostingDate = a.PostingDate,
                Preview = a.Preview,
                Text = a.Text,
                Thumbnail = a.Thumbnail,
                Title = a.Title
            };
        }

        public static implicit operator Announcement(AnnouncementVM vm)
        {
            if (vm == null)
                return null;
            return new Announcement()
            {
                AnnouncementId = vm.AnnouncementId,
                PostingDate = vm.PostingDate == default ? DateTimeOffset.UtcNow : vm.PostingDate,
                Preview = vm.Preview,
                Text = vm.Text,
                Thumbnail = vm.Thumbnail,
                Title = vm.Title
            };
        }
    }
}
