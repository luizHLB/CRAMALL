using System.Collections.Generic;

namespace CRMALL.Teste.Domain.ViewModels.Base
{
    public class ItemErrorResponseViewModel
    {
        public ItemErrorResponseViewModel()
        {
        }

        public ItemErrorResponseViewModel(string field)
        {
            Field = field;
        }

        public ItemErrorResponseViewModel(string field, List<string> messages)
        {
            Field = field;
            Messages = messages;
        }

        public string Field { get; set; }
        public List<string> Messages { get; set; }
    }
}
