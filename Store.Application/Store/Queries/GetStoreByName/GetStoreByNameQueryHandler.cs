using AutoMapper;
using MediatR;
using Store.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Store.Queries.GetStoreByName
{
    internal class GetStoreByNameQueryHandler : IRequestHandler<GetStoreByNameQuery, StoreDto>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public GetStoreByNameQueryHandler(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<StoreDto> Handle(GetStoreByNameQuery request, CancellationToken cancellationToken)
        {
            var store = await _storeRepository.GetByName(request.EncodedName);

            var dto = _mapper.Map<StoreDto>(store);

            return dto;
        }
    }
}