using CrudApi.Models;
using CrudApi.Models.ResponseModel;
using MediatR;

namespace CrudApi.Feature.Customer.Command
{
    public class DeleteNomineeDetailsCommand : IRequest<ResponseDto>
    {
        public int Id { get; set; }
        public class DeleteNomineeDetailsCommandHandler : IRequestHandler<DeleteNomineeDetailsCommand, ResponseDto>
        {
            private readonly projectstestdbContext _dbContext;
            public DeleteNomineeDetailsCommandHandler(projectstestdbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ResponseDto> Handle(DeleteNomineeDetailsCommand request, CancellationToken cancellationToken)
            {
                ResponseDto obj = new ResponseDto();

                var nomineeData = _dbContext.NomineeTables.FirstOrDefault(n => n.NomineeId == request.Id);

                if (nomineeData != null)
                {
                    nomineeData.IsActive = false;
                    nomineeData.IsDeleted = true;

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
