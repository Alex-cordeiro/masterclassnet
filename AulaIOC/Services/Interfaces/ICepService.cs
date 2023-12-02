using AulaIOC.DTOs;

namespace AulaIOC.Services.Interfaces;

public interface ICepService
{
    public ViaCepResponseDto BuscaCep(string cep);
}
