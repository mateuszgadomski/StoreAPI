using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Store.Queries.GetStoreByName
{
    public class GetStoreByNameQuery : IRequest<StoreDto>
    {
        public string EncodedName { get; set; }

        public GetStoreByNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}