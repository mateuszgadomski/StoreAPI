using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Store.Queries.GetAllStores
{
    public class GetAllStoresQuery : IRequest<IEnumerable<StoreDto>>
    {
    }
}