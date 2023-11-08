using APICore.Models;

namespace APIMVC.Models
{
    public class ModelsViewModel
    {
        public List<ModelsGetDto> Models { get; set; }

        public List<Marks> Marks { get; set; }

        public ModelsFilterDto Filter { get; set; }
    }
}
