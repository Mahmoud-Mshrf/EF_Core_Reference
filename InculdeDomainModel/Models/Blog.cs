using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InculdeDomainModel.Models
{
    public class Blog
    {
        public int Id { get; set; }

        public string URL { get; set; }
        public List<Post> Posts { get; set; }

    }
}