namespace Arkitektur.Business.DTOs.BannerDtos;

    public record UpdateBannerDto(
        int Id,
        string ImageUrl,
        string Title,
        string Description
    );
   