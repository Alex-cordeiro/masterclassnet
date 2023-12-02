using AulaIOC.DTOs;
using AulaIOC.HttpClients;
using AulaIOC.Services.Interfaces;

namespace AulaIOC.Services.Services;

public class CepService : ICepService
{
    private readonly IViaCepRefit _viaCepRefit;


    public CepService(IViaCepRefit viaCepRefit)
    {
        _viaCepRefit = viaCepRefit;
    }


    public ViaCepResponseDto BuscaCep(string cep)
    {
        ViaCepResponseDto? resultCep = _viaCepRefit.BuscaInformacoesCep(cep).Result;

        return resultCep;
    }
}
