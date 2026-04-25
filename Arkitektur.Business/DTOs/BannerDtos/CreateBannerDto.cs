namespace Arkitektur.Business.DTOs.BannerDtos;

    public record CreateBannerDto(
                                    string? ImageUrl
                                   , string? Title
                                   , string? Description);
  