using Supermarket.Core.Dtos;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Services.Interfaces
{
    public interface IReceiptService
    {
        IList<ReceiptDto> GetAll();

        ReceiptDto GetById(Guid id);

        ReceiptDto Add(ReceiptDto receiptDto);

        ReceiptDto UpdateById(ReceiptDto receiptDto, Guid id);

        ReceiptDto DeleteById(Guid id);
    }
}