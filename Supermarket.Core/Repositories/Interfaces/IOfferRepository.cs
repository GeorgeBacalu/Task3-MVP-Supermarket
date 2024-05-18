using Supermarket.Core.Entities;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Repositories.Interfaces
{
    public interface IOfferRepository
    {
        IList<Offer> GetAll();

        Offer GetById(Guid id);

        Offer Add(Offer offer);

        Offer UpdateById(Offer offer, Guid id);

        Offer DeleteById(Guid id);
    }
}