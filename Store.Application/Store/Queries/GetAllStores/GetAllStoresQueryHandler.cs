using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Interfaces;
using AutoMapper;

namespace Store.Application.Store.Queries.GetAllStores
{
    internal class GetAllStoresQueryHandler : IRequestHandler<GetAllStoresQuery, IEnumerable<StoreDto>>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public GetAllStoresQueryHandler(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StoreDto>> Handle(GetAllStoresQuery request, CancellationToken cancellationToken)
        {
            var stores = await _storeRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<StoreDto>>(stores);

            return dtos;
        }
    }
}