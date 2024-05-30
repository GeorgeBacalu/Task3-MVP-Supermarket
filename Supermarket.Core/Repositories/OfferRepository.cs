using Supermarket.Core.Context;
using Supermarket.Core.Entities;
using Supermarket.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Supermarket.Core.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        private readonly SupermarketDbContext _context;

        public OfferRepository(SupermarketDbContext context) => _context = context;

        public IList<Offer> GetAll() => _context.Offers
            .Include(offer => offer.Product)
            .Where(offer => offer.DeletedAt == null)
            .OrderBy(offer => offer.CreatedAt)
            .ToList();

        public IList<Offer> GetByProductNameContains(string name) => _context.Offers
            .Include(offer => offer.Product)
            .Where(offer => offer.DeletedAt == null && offer.Product.Name.Contains(name))
            .OrderBy(offer => offer.CreatedAt)
            .ToList();

        public Offer GetById(Guid id) => _context.Offers
            .Include(offer => offer.Product)
            .Where(offer => offer.DeletedAt == null)
            .FirstOrDefault(offer => offer.Id == id)
            ?? throw new Exception($"Offer with id {id} not found");

        public Offer Add(Offer offer)
        {
            if (offer.Id == Guid.Empty) offer.Id = Guid.NewGuid();
            offer.CreatedAt = DateTime.Now;
            _context.Offers.Add(offer);
            _context.SaveChanges();
            return offer;
        }

        public Offer UpdateById(Offer offer, Guid id)
        {
            Offer offerToUpdate = GetById(id);
            offerToUpdate.Reason = offer.Reason;
            offerToUpdate.Discount = offer.Discount;
            offerToUpdate.StartsAt = offer.StartsAt;
            offerToUpdate.EndsAt = offer.EndsAt;
            if (_context.Entry(offerToUpdate).State == EntityState.Modified)
                offerToUpdate.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return offerToUpdate;
        }

        public Offer DeleteById(Guid id)
        {
            Offer offerToDelete = GetById(id);
            offerToDelete.DeletedAt = DateTime.Now;
            _context.SaveChanges();
            return offerToDelete;
        }
    }
}