using CrudApi.Models;
using CrudApi.Models.RequestModel;
using CrudApi.Models.ResponseModel;
using MediatR;

namespace CrudApi.Feature.Customer.Query
{
    public class GetAccountHolderByIdQuery : IRequest<ResponseForGetAccounHolderById<GetAllAccountHolderListDto>>
    {
        public int Id { get; set; }
        public class GetAccountHolderByIdQueryHandler : IRequestHandler<GetAccountHolderByIdQuery, ResponseForGetAccounHolderById<GetAllAccountHolderListDto>>
        {
            private readonly projectstestdbContext _dbContext;
            public GetAccountHolderByIdQueryHandler(projectstestdbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ResponseForGetAccounHolderById<GetAllAccountHolderListDto>> Handle(GetAccountHolderByIdQuery request, CancellationToken cancellationToken)
            {
                ResponseForGetAccounHolderById<GetAllAccountHolderListDto> res = new ResponseForGetAccounHolderById<GetAllAccountHolderListDto>();
                var data = (from acc in _dbContext.AccountHolderTables
                            where acc.AccountholderId == request.Id
                            select new GetAllAccountHolderListDto()
                            {
                                AccountholderId = acc.AccountholderId,
                                AccountholderName = acc.AccountholderName,
                                AccountType = acc.AccountType,
                                AccountNumber = acc.AccountNumber,
                                Nominees = _dbContext.NomineeTables.Where(n => n.AccountHolderId == acc.AccountholderId & n.IsActive == true & n.IsDeleted == false).ToList()
                            }).FirstOrDefault();

                res.AccounHolderData = data;
                res.StatusCode = 200;
                res.Message = "Data Fetched Successfully.";

                return res;
            }
        }
    }
}
