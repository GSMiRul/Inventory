using Application.Brands.Commands.DeleteBrand;
using Application.Common;
using Domain.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Brands.EventHandlers
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, RequestResponse<string>>
    {
        private readonly IWriteBaseRepository<Brand> _brandRepository;
        private readonly IReadBaseRepository<Brand> _brandReadRepository;
        public DeleteBrandCommandHandler(IWriteBaseRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        async Task<RequestResponse<string>> IRequestHandler<DeleteBrandCommand, RequestResponse<string>>.Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            int record = await _brandReadRepository.CountAsync(b => b.Id == request.Id, cancellationToken);

            if (record == 0)
            {
                throw new KeyNotFoundException($"Unable to delete the brand with the id {request.Id}, because it doesn't exists.");
            }
            else
            {
                await _brandRepository.DeleteAsync(request.Id, cancellationToken);

                return new RequestResponse<string>(request.Id.ToString());
            }
        }
    }
}
