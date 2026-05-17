using System.ComponentModel.DataAnnotations;

namespace EF_Core8.Models
{
    public class Blog
    {
        public int Id { get; set; }
        
        public string URL { get; set; }
    }
}