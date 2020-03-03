using Newtonsoft.Json;

namespace CRMALL.Teste.Domain.ViewModels.Base
{
    public class BaseUpdateViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
    }
}
