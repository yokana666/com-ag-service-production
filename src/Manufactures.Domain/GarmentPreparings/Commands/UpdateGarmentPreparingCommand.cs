﻿using FluentValidation;
using Infrastructure.Domain.Commands;
using Manufactures.Domain.GarmentPreparings.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;


namespace Manufactures.Domain.GarmentPreparings.Commands
{
    public class UpdateGarmentPreparingCommand : ICommand<GarmentPreparing>
    {
        public void SetId(Guid id) { Id = id; }
        public Guid Id { get; private set; }
        public int UENId { get; set; }
        public string UENNo { get; set; }
        public UnitDepartment Unit { get; set; }
        public DateTimeOffset? ProcessDate { get; set; }
        public DateTimeOffset? ExpenditureDate { get; set; }
        public string RONo { get; set; }
        public string Article { get; set; }
        public bool IsCuttingIn { get; set; }
        public Shared.ValueObjects.Buyer Buyer { get; set; }
        public List<GarmentPreparingItemValueObject> Items { get; set; }
    }

    public class UpdateGarmentPreparingCommandValidator : AbstractValidator<UpdateGarmentPreparingCommand>
    {
        public UpdateGarmentPreparingCommandValidator()
        {
            RuleFor(r => r.UENId).NotEmpty().WithMessage("Nomor Bon Pengeluaran Unit Tidak Boleh Kosong");
            RuleFor(r => r.ProcessDate).NotNull().WithMessage("Tanggal Proses Tidak Boleh Kosong");
            RuleFor(r => r.Article).NotNull();
            RuleFor(r => r.ProcessDate).NotNull().LessThan(DateTimeOffset.Now).WithMessage("Tanggal Proses Tidak Boleh Lebih dari Hari Ini");
            RuleFor(r => r.ProcessDate).NotNull().GreaterThan(r => r.ExpenditureDate.GetValueOrDefault().Date).WithMessage("Tanggal Proses Tidak Boleh Kurang dari tanggal BUK");
            RuleFor(r => r.Items).NotEmpty().WithMessage("Item Tidak Boleh Kosong");
            RuleForEach(r => r.Items).SetValidator(new GarmentPreparingItemValueObjectValidator());
        }
    }
}