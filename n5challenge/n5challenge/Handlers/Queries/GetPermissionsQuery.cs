using AutoMapper;
using ErrorOr;
using MediatR;
using n5challenge.Application.Model;
using n5challenge.Core.Entity;
using n5challenge.Infraestructure.UnitOfWork.Interface;
using Nest;
using System;

namespace n5challenge.Handlers.Queries
{
    public class GetPermissionsQuery : MediatR.IRequest<List<Permission>>
    {
        public GetPermissionsQuery() { }
    }

    public class GetPermissionsQueryHandler : IRequestHandler<GetPermissionsQuery, List<Permission>>
    {
        private readonly IUnitOfWork _uow;

        public GetPermissionsQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<Permission>> Handle(GetPermissionsQuery request,
            CancellationToken cancellationToken)
        {
            var permissions = await _uow.Repository().FindAllAsync<Permission>();  
            return permissions;
        }
    }
}
