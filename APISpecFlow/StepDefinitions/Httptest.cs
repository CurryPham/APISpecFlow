using NUnit.Framework;
using System;
using System.Security.Policy;
using TechTalk.SpecFlow.Infrastructure;

namespace APISpecFlow.StepDefinitions
{
    [Binding]
    public class Httptest
    {
        HttpClient httpClient;
        HttpResponseMessage response;
        string responsebody;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public Httptest(ISpecFlowOutputHelper _specFlowOutputHelper) 
        {
            httpClient = new HttpClient();
            this._specFlowOutputHelper = _specFlowOutputHelper;
        }

        [Given(@"User send a request with url as ""([^""]*)""")]
        public async Task GivenUserSendARequestWithUrlAs(string url)
        {
            response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            responsebody = await response.Content.ReadAsStringAsync();
            _specFlowOutputHelper.WriteLine(responsebody);
        }

        [Then(@"Request should be a success with (.*) codes")]
        public void ThenRequestShouldBeASuccessWithCodes(int p0)
        {
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
