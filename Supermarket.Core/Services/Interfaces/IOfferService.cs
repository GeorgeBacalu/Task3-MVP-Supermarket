using Supermarket.Core.Dtos;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Services.Interfaces
{
    public interface IOfferService
    {
        IList<OfferDto> GetAll();

        OfferDto GetById(Guid id);

        OfferDto Add(OfferDto offerDto);

        OfferDto UpdateById(OfferDto offerDto, Guid id);

        OfferDto DeleteById(Guid id);
    }
}