using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using n5challenge.Handlers.Commands;
using Nest;
using Xunit;

namespace n5challenge.Integration.Test
{
    public class N5ChallengeIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public N5ChallengeIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetPermissions_Test()
        {
            HttpResponseMessage response = await GetPermissionsAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        private async Task<HttpResponseMessage> GetPermissionsAsync()
        {
            var _client = _factory.CreateClient();
            var response = await _client.GetAsync($"/api/GetPermissions");
            response.EnsureSuccessStatusCode();

            return response;
        }


        [Fact]
        public async Task ModifyPermission_Test()
        {
            var modifyPermission = new ModifyPermissionsCommand() 
            {
                 Id = 1,
                 EmployeeForename = "Juan",
                 EmployeeSurname = "Perez",
                 PermissionType  = 1
            };

            HttpResponseMessage response = await ModifyPermissionAsync(modifyPermission);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        private async Task<HttpResponseMessage> ModifyPermissionAsync(ModifyPermissionsCommand modifyPermission)
        {
            var request = JsonSerializer.Serialize(modifyPermission);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var _client = _factory.CreateClient();
            var response = await _client.PutAsync($"/api/ModifyPermission", content);
            response.EnsureSuccessStatusCode();

            return response;
        }


        [Fact]
        public async Task RequestPermission_Test()
        {
            var requestPermission = new RequestPermissionsCommand()
            {                
                EmployeeForename = "Juan",
                EmployeeSurname = "Perez",
                PermissionType = 1
            };

            HttpResponseMessage response = await RequestPermissionAsync(requestPermission);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        private async Task<HttpResponseMessage> RequestPermissionAsync(RequestPermissionsCommand requestPermission)
        {
            var request = JsonSerializer.Serialize(requestPermission);
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            var _client = _factory.CreateClient();
            var response = await _client.PutAsync($"/api/RequestPermission", content);
            response.EnsureSuccessStatusCode();

            return response;
        }

    }
}