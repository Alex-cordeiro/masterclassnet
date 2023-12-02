using AulaIOC;
using AulaIOC.DTOs;
using AulaIOC.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Iniciando o APP");

//adicionando o json para leitura das configurações
IConfigurationBuilder configbuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);

IConfiguration config = configbuilder.Build();


//Fazendo o application builder que controla as injeções de dependências para o aplicativo
HostApplicationBuilder hostBuilder = Host.CreateApplicationBuilder(args);


//Consumindo a camada de IOC e configurando nossos serviços no container de dependências
hostBuilder.Services.ConfiguracaoRefitClient(config);
hostBuilder.Services.ConfiguracaoServicos();

//Instância do provedor dos nossos serviços
var serviceProvider = hostBuilder.Services.BuildServiceProvider();

//Retornando uma instância já injetada do serviço de cep para realizar a busca
var cepService = serviceProvider.GetService<ICepService>();

Console.WriteLine("Insira o seu cep:");
var cep = Console.ReadLine().Trim().Replace('-', ' ');


ViaCepResponseDto cepDto = cepService.BuscaCep(cep);

Console.WriteLine("   Seu endereço é:   ");
Console.WriteLine("----------------------");


Console.WriteLine($"  Rua: {cepDto.Logradouro}");
Console.WriteLine($"  Bairro: {cepDto.Bairro}");
Console.WriteLine($"  Municipio: {cepDto.Localidade}");



