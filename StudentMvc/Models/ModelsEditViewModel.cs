using APICore.Models;

namespace APIMVC.Models
{
    public class ModelsEditViewModel
    {
        public ModelsGetDto? Models { get; set; }

        public List<Marks>? Mark { get; set; }
    }
}
