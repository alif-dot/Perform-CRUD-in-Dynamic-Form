using CrudApi.Models;
using CrudApi.Models.ResponseModel;
using MediatR;

namespace CrudApi.Feature.Customer.Command
{
    public class DeleteAccountHolderDetailsCommand : IRequest<ResponseDto>
    {
        public int Id { get; set; }
        public class DeleteAccountHolderDetailsCommandHandler : IRequestHandler<DeleteAccountHolderDetailsCommand, ResponseDto>
        {
            private readonly projectstestdbContext _dbContext;
            public DeleteAccountHolderDetailsCommandHandler(projectstestdbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ResponseDto> Handle(DeleteAccountHolderDetailsCommand request, CancellationToken cancellationToken)
            {
                ResponseDto obj = new ResponseDto();

                var data = _dbContext.AccountHolderTables.FirstOrDefault(l => l.AccountholderId == request.Id);

                if (data != null)
                {
                    data.IsActive = false;
                    data.IsDeleted = true;

                    _dbContext.SaveChanges();

                    obj.StatusCode = 200;
                    obj.Message = "Delete Successfully.";
                    return obj;
                }
                else
                {
                    obj.StatusCode = 404;
                    obj.Message = "Id Does not Exist.";
                    return obj;
                }
            }
        }
    }
}
