namespace Arkitektur.Business.DTOs.ProjectDtos;
public record CreateProjectDto(
                          string? Title,
                          string? ImageUrl,
                          string? Description,
                          string? Item1,
                          string? Item2,
                          string? Item3,
                          int? CategoryId);   