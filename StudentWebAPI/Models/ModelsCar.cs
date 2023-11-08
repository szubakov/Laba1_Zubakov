using APICore.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class ModelsCar
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Marks))]
        public int markID { get; set; }

        public Marks? Mark { get; set; }

        public string Name { get; set; }

        public string privod { get; set; }
        public string kuzov { get; set; }

        public string DVS { get; set; }

        public double ls  { get; set; }

        public double engine_capacity { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
