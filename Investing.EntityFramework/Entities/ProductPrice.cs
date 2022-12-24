﻿using Investing.Core.Domain;
using Investing.Core.Specification;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Investing.EntityFramework.Entities
{
    [Index(nameof(ProductId))]
    [Index(nameof(ClosedAt))]
    public class ProductPrice : EntityBase, IAggregateRoot, IUniqueSpecification<ProductPrice>
    {
        public Guid ProductId { get; set; }

        public decimal Open { get; set; }

        public decimal High { get; set; }

        public decimal Low { get; set; }

        public decimal Close { get; set; }

        public decimal Volume { get; set; }

        public DateTime ClosedAt { get; set; }

        public Expression<Func<ProductPrice, bool>> Unique => (item) => item.ProductId == ProductId && 
            item.ClosedAt == ClosedAt;

        public virtual Product? Product { get; set; }
    }
}
