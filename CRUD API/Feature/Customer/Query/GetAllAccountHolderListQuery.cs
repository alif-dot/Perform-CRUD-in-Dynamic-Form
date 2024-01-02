﻿using CrudApi.Models;
using CrudApi.Models.RequestModel;
using MediatR;

namespace CrudApi.Feature.Customer.Query
{
    public class GetAllAccountHolderListQuery : IRequest<List<GetAllAccountHolderListDto>>
    {
        public class GetAllAccountHolderListQueryHandler : IRequestHandler<GetAllAccountHolderListQuery, List<GetAllAccountHolderListDto>>
        {
            private readonly projectstestdbContext _dbContext;
            public GetAllAccountHolderListQueryHandler(projectstestdbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<List<GetAllAccountHolderListDto>> Handle(GetAllAccountHolderListQuery request, CancellationToken cancellationToken)
            {
                var data = (from acc in _dbContext.AccountHolderTables
                            where acc.IsActive == true & acc.IsDeleted == false
                            orderby acc.AccountholderId descending
                            select new GetAllAccountHolderListDto()
                            {
                                AccountholderId = acc.AccountholderId,
                                AccountholderName = acc.AccountholderName,
                                AccountType = acc.AccountType,
                                AccountNumber = acc.AccountNumber,
                                Nominees = _dbContext.NomineeTables.Where(n => n.AccountHolderId == acc.AccountholderId & n.IsActive == true & n.IsDeleted == false).ToList()
                            }).ToList();

                return data;
            }
        }
    }
}
