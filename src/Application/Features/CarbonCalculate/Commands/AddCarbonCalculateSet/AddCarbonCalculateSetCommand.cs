
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using BlazorHero.CleanArchitecture.Application.Interfaces.Repositories;
using BlazorHero.CleanArchitecture.Domain.Entities.Catalog;
using BlazorHero.CleanArchitecture.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using BlazorHero.CleanArchitecture.Shared.Constants.Application;
using BlazorHero.CleanArchitecture.Domain.Entities.CarbonCalculator;
using System;

namespace BlazorHero.CleanArchitecture.Application.Features.CarbonCalculate.Commands.AddCarbonCalculateSet

{
    public partial class AddCarbonCalculateSetCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public int CountryId { get; set; }
        public int NumberEmployee  { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }

    internal class AddCarbonCalculateSetCommandHandler : IRequestHandler<AddCarbonCalculateSetCommand, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddCarbonCalculateSetCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public AddCarbonCalculateSetCommandHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IStringLocalizer<AddCarbonCalculateSetCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(AddCarbonCalculateSetCommand command, CancellationToken cancellationToken)
        {
            //var test = _mapper.Map<CarbonCalculateSet>(command);
            if (command.Id==0)
            {

            var test = new CarbonCalculateSet
            {
                UserId = command.UserId,
                NumberEmployee = command.NumberEmployee,

            };
                try
                {
            await _unitOfWork.Repository<CarbonCalculateSet>().AddAsync(test);
            await _unitOfWork.Commit(cancellationToken);

                }
                catch (Exception e)
                {

                    throw;
                }
            return await Result<int>.SuccessAsync(test.Id, _localizer["Brand Updated"]);
            }
            else
            {
                var data = await _unitOfWork.Repository<CarbonCalculateSet>().GetByIdAsync(command.Id);
                if (data != null)
                {
                    data.NumberEmployee = command.NumberEmployee;
                    data.CountryId = command.CountryId;
                    data.From = DateTime.Parse( command?.From);
                    data.To = DateTime.Parse(command?.To);
                    await _unitOfWork.Repository<CarbonCalculateSet>().UpdateAsync(data);
                    await _unitOfWork.Commit(cancellationToken);
                    return await Result<int>.SuccessAsync("Update success");
                }
                else
                {
                    return await Result<int>.FailAsync("Update error");
                }
            }
            //if (command.Id == 0)
            //{
            //    var brand = _mapper.Map<Brand>(command);
            //    await _unitOfWork.Repository<Brand>().AddAsync(brand);
            //    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllBrandsCacheKey);
            //    return await Result<int>.SuccessAsync(brand.Id, _localizer["Brand Saved"]);
            //}
            //else
            //{
            //    var brand = await _unitOfWork.Repository<Brand>().GetByIdAsync(command.Id);
            //    if (brand != null)
            //    {
            //        brand.Name = command.Name ?? brand.Name;
            //        brand.Tax = (command.Tax == 0) ? brand.Tax : command.Tax;
            //        brand.Description = command.Description ?? brand.Description;
            //        await _unitOfWork.Repository<Brand>().UpdateAsync(brand);
            //        await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllBrandsCacheKey);
            //        return await Result<int>.SuccessAsync(brand.Id, _localizer["Brand Updated"]);
            //    }
            //    else
            //    {
            //        return await Result<int>.FailAsync(_localizer["Brand Not Found!"]);
            //    }
            //}
        }
    }
}