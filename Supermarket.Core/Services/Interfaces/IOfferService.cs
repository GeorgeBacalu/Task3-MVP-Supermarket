using Supermarket.Core.Dtos.Common;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Services.Interfaces
{
    public interface IOfferService
    {
        IList<OfferDto> GetAll();

        IList<OfferDto> GetByKey(string key);

        OfferDto GetById(Guid id);

        OfferDto Add(OfferDto offerDto);

        OfferDto UpdateById(OfferDto offerDto, Guid id);

        OfferDto DeleteById(Guid id);
    }
}