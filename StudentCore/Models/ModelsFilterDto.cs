using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APICore.Models
{
    public class ModelsFilterDto
    {

        public int? markid { get; set; }
        public string? Name { get; set; }

        public string? privod { get; set; }
        public string? kuzov { get; set; }



    }
}
