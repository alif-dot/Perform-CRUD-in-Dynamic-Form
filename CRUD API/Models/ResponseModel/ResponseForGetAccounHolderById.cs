namespace CrudApi.Models.ResponseModel
{
    public class ResponseForGetAccounHolderById<T> : ResponseDto
    {
        public T AccounHolderData { get; set; }
    }
}
