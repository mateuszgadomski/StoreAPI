using AutoMapper;
using MediatR;
using Store.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Store.Commands.CreateStore
{
    public class CreateStoreCommandHandler : IRequestHandler<CreateStoreCommand>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public CreateStoreCommandHandler(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            var store = _mapper.Map<Domain.Entities.Store>(request);
            store.EncodeName();

            await _storeRepository.Create(store);
            return Unit.Value;
        }
    }
}