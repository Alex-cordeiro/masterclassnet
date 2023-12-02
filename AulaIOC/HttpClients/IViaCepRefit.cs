using AulaIOC.DTOs;
using Refit;

namespace AulaIOC.HttpClients
{
    public interface IViaCepRefit
    {
        [Get("/{cep}/json/")]
        public Task<ViaCepResponseDto> BuscaInformacoesCep([AliasAs("cep")] string cep);
    }
}
