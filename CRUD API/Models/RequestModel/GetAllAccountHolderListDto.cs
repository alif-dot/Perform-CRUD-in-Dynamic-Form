namespace CrudApi.Models.RequestModel
{
    public class GetAllAccountHolderListDto
    {
        public int AccountholderId { get; set; }
        public string? AccountholderName { get; set; }
        public string? AccountType { get; set; }
        public string? AccountNumber { get; set; }
        public List<NomineeTable> Nominees { get; set; }
    }
}
