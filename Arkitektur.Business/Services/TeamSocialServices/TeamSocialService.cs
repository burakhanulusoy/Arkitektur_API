using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.TeamDtos;
using Arkitektur.Business.DTOs.TeamSocialDtos;
using Arkitektur.Business.Validators.TeamSocialValidators;
using Arkitektur.DataAccess.Repositories.TeamSocialRepositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitektur.Business.Services.TeamSocialServices
{
    public class TeamSocialService(ITeamSocialRepository _teamSocialRepository
                                  ,IUnitOfWork _unitOfWork
                                  ,IValidator<UpdateTeamSocialDto> _updateValidator
                                  ,IValidator<CreateTeamSocialDto> _createValidator) : ITeamSocialService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateTeamSocialDto createDto)
        {
            var team = createDto.Adapt<TeamSocial>();

            var validationResult = await _createValidator.ValidateAsync(createDto);

            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            await _teamSocialRepository.CreateAsync(team);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success(team) : BaseResult<object>.Fail("Create failed.");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var team = await _teamSocialRepository.GetByIdAsync(id);

            if (team is null)
            {
                return BaseResult<object>.Fail("Team Not Found");
            }

            _teamSocialRepository.Delete(team);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success(team) : BaseResult<object>.Fail("Deleted failed.");
        }

        public async Task<BaseResult<List<ResultTeamSocialDto>>> GetAllAsync()
        {
            var teams = await _teamSocialRepository.GetAllAsync();

            var mappedTeams = teams.Adapt<List<ResultTeamSocialDto>>();

            return BaseResult<List<ResultTeamSocialDto>>.Success(mappedTeams);
        }

        public async Task<BaseResult<ResultTeamSocialDto>> GetByIdAsync(int id)
        {
            var team = await _teamSocialRepository.GetByIdAsync(id);

            if (team is null)
            {
                return BaseResult<ResultTeamSocialDto>.Fail("User Not Found");
            }

            var mappedTeam = team.Adapt<ResultTeamSocialDto>();

            return BaseResult<ResultTeamSocialDto>.Success(mappedTeam);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateTeamSocialDto updateDto)
        {

            var team = updateDto.Adapt<TeamSocial>();

            var validationResult = await _updateValidator.ValidateAsync(updateDto);

            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            _teamSocialRepository.Update(team);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success(team) : BaseResult<object>.Fail("Updated failed.");
        
        }
    }
}
