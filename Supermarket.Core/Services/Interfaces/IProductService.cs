using Supermarket.Core.Dtos.Common;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Services.Interfaces
{
    public interface IProductService
    {
        IList<ProductDto> GetAll();

        ProductDto GetById(Guid id);

        ProductDto Add(ProductDto productDto);

        ProductDto UpdateById(ProductDto productDto, Guid id);

        ProductDto DeleteById(Guid id);
    }
}