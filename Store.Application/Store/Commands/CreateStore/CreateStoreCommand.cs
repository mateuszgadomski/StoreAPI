using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Store.Commands.CreateStore
{
    public class CreateStoreCommand : StoreDto, IRequest
    {
    }
}