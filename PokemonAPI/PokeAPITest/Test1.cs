using Moq;
using Moq.Protected;


namespace PokemonAPI
{
    [TestClass]
    public class PokemonAPIClientTest
    {
        [TestMethod]
        public async Task GetPokemonAsync_ReturnsPokemonData()
        {
            // Arrange
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = new StringContent("{\"name\":\"pikachu\",\"height\":4,\"weight\":60}")
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var client = new PokeApiClient(httpClient);

            // Act
            var pokemon = await client.GetPokemonAsync("pikachu");

            // Assert
            Assert.IsNotNull(pokemon);
            Assert.AreEqual("pikachu", pokemon.Name);
            Assert.AreEqual(4, pokemon.Height);
            Assert.AreEqual(60, pokemon.Weight);
        }

        [TestMethod]
        public async Task GetPokemonAsync_InvalidNameOrId_ThrowsException()
        {
            // Arrange
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.NotFound
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object);
            var client = new PokeApiClient(httpClient);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<HttpRequestException>(() => client.GetPokemonAsync("invalidname"));
        }
    }
}
