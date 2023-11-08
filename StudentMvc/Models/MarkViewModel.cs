using APICore.Models;

namespace APIMVC.Models
{
    public class MarkViewModel
    {
        public List<Marks> Marks { get; set; }

        public MarksFilterDto Filter { get; set; }


    }
}
