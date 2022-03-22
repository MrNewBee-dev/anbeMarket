using Anbe.Models;
using System.ComponentModel.DataAnnotations;

namespace Anbe.Areas.AnbeAdmin.Models
{
    public class Color
    {
        [Key]
        public int Id { get; set; }
        public string EsmeRang { get; set; }
        public string HexRag { get; set; }
        public Product Products { get; set; }
    }
}
