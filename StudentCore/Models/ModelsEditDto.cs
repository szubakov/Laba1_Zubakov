using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APICore.Models
{
    public class ModelsEditDto
    {
        public int Id { get; set; }

        public int markid { get; set; }

        

        public string Name { get; set; }

        public string privod { get; set; }

        public string kuzov { get; set; }

        public string DVS { get; set; }
        public double ls { get; set; }
        public double engine_capacity { get; set; }

    }
}
