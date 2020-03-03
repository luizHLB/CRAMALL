namespace CRMALL.Teste.Domain.ViewModels
{
    public class InternalServerErrorResponseModel
    {
        public InternalServerErrorResponseModel()
        {
            Message = "An error has occurred, try again later or contact technical support.";
        }

        public InternalServerErrorResponseModel(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
