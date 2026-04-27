using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.TeamDtos;
using Arkitektur.DataAccess.Repositories.TeamRepositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Arkitektur.Business.Services.TeamServices
{
    public class TeamService(ITeamRepository _teamRepository,
                             IUnitOfWork _unitOfWork
                             ,IValidator<CreateTeamDto> _createValidator,
                              IValidator<UpdateTeamDto> _updateValidator) : ITeamService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateTeamDto createDto)
        {

            var team = createDto.Adapt<Team>();

            var validationResult = await _createValidator.ValidateAsync(createDto);

            if(!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

            await _teamRepository.CreateAsync(team);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success(team) : BaseResult<object>.Fail("Create failed.");



        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var team = await _teamRepository.GetByIdAsync(id);

            if(team is null)
            {
                return BaseResult<object>.Fail("Team Not Found");
            }

             _teamRepository.Delete(team);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success(team) : BaseResult<object>.Fail("Deleted failed.");
        }

        public async Task<BaseResult<List<ResultTeamDto>>> GetAllAsync()
        {
            var teams = await _teamRepository.GetQueryable().Include(x=>x.TeamSocials).AsNoTracking().ToListAsync();

            var mappedTeams = teams.Adapt<List<ResultTeamDto>>();

            return BaseResult<List<ResultTeamDto>>.Success(mappedTeams);

        }

        public async Task<BaseResult<ResultTeamDto>> GetByIdAsync(int id)
        {

            var team = await _teamRepository.GetQueryable().Include(x=>x.TeamSocials).AsNoTracking().Where(x=>x.Id==id).FirstOrDefaultAsync();

            if(team is null)
            {
                return BaseResult<ResultTeamDto>.Fail("User Not Found");
            }

            var mappedTeam = team.Adapt<ResultTeamDto>();

            return BaseResult<ResultTeamDto>.Success(mappedTeam);



        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateTeamDto updateDto)
        {
            var team = updateDto.Adapt<Team>();

            var validationResult = await _updateValidator.ValidateAsync(updateDto);

            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }

             _teamRepository.Update(team);

            var result = await _unitOfWork.SaveChangesAsync();

            return result ? BaseResult<object>.Success(team) : BaseResult<object>.Fail("Updated failed.");
        }
    }
}
