namespace IfoodSocial.Core.Dto;

public record BairroRequest(string? Dcr_Bairro, ICollection<Localidade>? Localidades);