using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.FeatureDtos;
using Arkitektur.DataAccess.Repositories.FeatureRepositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Arkitektur.Business.Services.FeatureServices
{
    public class FeatureService(IFeatureRepository _featureRepository,
                                IUnitOfWork _unitOfWork,
                                IValidator<CreateFeatureDto> _createValidator,
                                IValidator<UpdateFeatureDto> _updateValidator ) : IFeatureService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateFeatureDto createDto)
        {

            var feature =createDto.Adapt<Feature>();

            var validationResult = await _createValidator.ValidateAsync(createDto);

            if(!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            await _featureRepository.CreateAsync(feature);

            bool result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success(feature) : BaseResult<object>.Fail("Created Failed");

        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {

            var feature = await _featureRepository.GetByIdAsync(id);

            if(feature is null)
            {
                return BaseResult<object>.Fail("Feature Not Found");
            }

            _featureRepository.Delete(feature);

            bool result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success(feature) : BaseResult<object>.Fail("Deleted Failed");




        }

        public async Task<BaseResult<List<ResultFeatureDto>>> GetAllAsync()
        {
            
            var features = await _featureRepository.GetAllAsync();

            var mappedFeatures = features.Adapt<List<ResultFeatureDto>>();

            return BaseResult<List<ResultFeatureDto>>.Success(mappedFeatures);


        }

        public async Task<BaseResult<ResultFeatureDto>> GetByIdAsync(int id)
        {
            var feature = await _featureRepository.GetByIdAsync(id);

            if(feature is null)
            {
                return BaseResult<ResultFeatureDto>.Fail("Feature Not Found");
            }
            var mappedFeature  = feature.Adapt<ResultFeatureDto>();

            return BaseResult<ResultFeatureDto>.Success(mappedFeature);



        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateFeatureDto updateDto)
        {

            var feature = updateDto.Adapt<Feature>();

            var validationResult = await _updateValidator.ValidateAsync(updateDto);

            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

             _featureRepository.Update(feature);

            bool result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success(feature) : BaseResult<object>.Fail("Updated Failed");



        }
    }
}
