using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommand : StoreProductDto, IRequest
    {
        public string StoreId { get; set; }

        public CreateProductCommand(string storeId)
        {
            StoreId = storeId;
        }
    }
}