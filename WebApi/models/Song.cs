using System.ComponentModel.DataAnnotations;

namespace WebApi.models
{
    public class Song
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "required")]
        public string Title { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public int Duration { get; set; }
    }
}
