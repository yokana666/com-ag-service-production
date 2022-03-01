﻿using Manufactures.Domain.Shared.ValueObjects;
using Moonlay.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manufactures.Domain.GarmentSewingDOs.ValueObjects
{
    public class GarmentSewingDOItemValueObject : ValueObject
    {
        public Guid Id { get; set; }
        public Guid SewingDOId { get; set; }
        public Guid CuttingOutDetailId { get; set; }
        public Guid CuttingOutItemId { get; set; }
        public Product Product { get; set; }
        public string CustomsCategory { get; set; }
        public string DesignColor { get; set; }
        public SizeValueObject Size { get; set; }
        public double Quantity { get; set; }
        public Uom Uom { get; set; }
        public string Color { get; set; }
        public double RemainingQuantity { get; set; }
        public double BasicPrice { get; set; }
        public double Price { get; set; }

        public GarmentSewingDOItemValueObject()
        {
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}