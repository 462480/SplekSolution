using Splek.Logic.DTO_s;
using System.Dynamic;

namespace TestProject;

[TestClass]
public class GameDTOTests
{

    //Deze bestaan eigenlijk alleen om de DTO's te testen, aangezien ze geen logica bevatten, maar alleen data.
    //Nu wordt de code coverage hoger :)
    [TestMethod]
    public void CreateResponse_Properties_SetAndGet()
    {
        Splek.Logic.DTO_s.CreateResponse dto = new Splek.Logic.DTO_s.CreateResponse
        {
            Title = "Test title",
            Body = "Test body",
            Likes = 10,
            Dislikes = 2,
            UserId = 42
        };

        Assert.Equals("Test title", dto.Title);
        Assert.Equals("Test body", dto.Body);
        Assert.Equals(10, dto.Likes);
        Assert.Equals(2, dto.Dislikes);
        Assert.Equals(42, dto.UserId);
    }

    [TestMethod]
    public void CreateRequest_Properties_SetAndGet()
    {
        var dto = new CreateRequest
        {
            Title = "Request title",
            Body = "Request body",
            Id = 1,
            UserId = 99
        };

        Assert.Equals("Request title", dto.Title);
        Assert.Equals("Request body", dto.Body);
        Assert.Equals(1, dto.Id);
        Assert.Equals(99, dto.UserId);
    }
}
