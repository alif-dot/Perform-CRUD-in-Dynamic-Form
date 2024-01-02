using CrudApi.Models;
using CrudApi.Models.RequestModel;
using CrudApi.Models.ResponseModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CrudApi.Feature.Customer.Command
{
    public class AddAccountHolderDetailsCommand : AddAccountHolderDetailsDto, IRequest<ResponseDto>
    {
        public class AddAccountHolderDetailsCommandHandler : IRequestHandler<AddAccountHolderDetailsCommand, ResponseDto>
        {
            private readonly projectstestdbContext _dbContext;
            public AddAccountHolderDetailsCommandHandler(projectstestdbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ResponseDto> Handle(AddAccountHolderDetailsCommand request, CancellationToken cancellationToken)
            {
                ResponseDto res = new ResponseDto();

                try
                {
                    var data = _dbContext.AccountHolderTables.FirstOrDefault(x => x.AccountholderName == request.AccountholderName);
                    if (data != null)
                    {
                        res.StatusCode = 203;
                        res.Message = "Already Exits";
                        return res;
                    }
                    else
                    {
                        var AccountholderData = new AccountHolderTable()
                        {
                            AccountholderName = request.AccountholderName,
                            AccountType = request.AccountType,
                            AccountNumber = request.AccountNumber,
                            IsActive = true,
                            IsDeleted = false,
                        };

                        _dbContext.AccountHolderTables.Add(AccountholderData);
                        _dbContext.SaveChanges();


                        List<NomineeTable> obj = new List<NomineeTable>();
                        foreach (var n in request.Nominees)
                        {
                            var NomineeData = new NomineeTable()
                            {
                                NomineeName = n.NomineeName,
                                NomineeAge = n.NomineeAge,
                                AddressType = n.AddressType,
                                Address = n.Address,
                                AccountHolderId = AccountholderData.AccountholderId,
                                IsActive = true,
                                IsDeleted = false,
                            };

                            obj.Add(NomineeData);
                        }

                        _dbContext.NomineeTables.AddRange(obj);
                        _dbContext.SaveChanges();
                        res.Message = "Add Succcessfully";
                        res.StatusCode = 200;
                        return res;
                    }
                }
                catch (Exception ex)
                {
                    res.Message = ex.Message;
                    res.StatusCode = 500;
                    return res;
                }
            }
        }
    }
}
