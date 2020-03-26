using ExemploDojo.IntegrationTests.Fixture;
using ExemploDojo.WebApi.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ExemploDojo.IntegrationTests.Scenario
{
    public class TarefaControllerIntegrationTests : IClassFixture<BaseTestFixture>
    {
        private readonly HttpClient _client;

        private readonly string _baseUrl = "http://localhost:56788/api/";

        public TarefaControllerIntegrationTests(BaseTestFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task TarefaController_ConsultarComSucesso()
        {
            //Arrange
            var endpoint = $"{_baseUrl}tarefa";

            //Act
            var response = await _client.GetAsync(endpoint);

            //Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task TarefaController_GravarComSucesso()
        {
            //Arrange
            var endpoint = $"{_baseUrl}tarefa";
            var tarefa = new Tarefa()
            {
                Chave = 5,
                Nome = "Apresentar teste de integração no Dojo",
                EstaCompleta = false
            };

            var json = JsonConvert.SerializeObject(tarefa);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            //Act
            var response = await _client.PostAsync(endpoint, content);

            //Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public void TarefaController_TesteBancoInMemory()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<TarefaContext>()
                .UseInMemoryDatabase(databaseName: "TarefaIntegrationTestDatabase")
                .Options;

            var tarefa = new Tarefa()
            {
                Chave = 7,
                Nome = "Apresentar teste de integração no Dojo",
                EstaCompleta = false
            };

            TarefaRepository repository = null;
            //Act
            using (var context = new TarefaContext(options))
            {
                repository = new TarefaRepository(context);
                repository.Add(tarefa);
            }

            //Assert
            repository.Should().NotBeNull();
        }
    }
}
