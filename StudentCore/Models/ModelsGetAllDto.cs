using APICore.Models;

namespace APICore.Models
{
    public class ModelsGetAllDto
    {
        public List<ModelsGetDto> Models { get; set; }

        public List<Marks> Marks { get; set; }

        
    }
}
