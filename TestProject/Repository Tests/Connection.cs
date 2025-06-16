using MySql.Data.MySqlClient;

namespace TestProject;

[TestClass]
public class Connection
{
    private readonly string c = "Server=localhost;Database=splek_db;Uid=root;Pwd=;";

    [TestMethod()]
    public void DatabaseConnectionAvailableTest()
    {
        try
        {
            using (var connection = new MySqlConnection(c))
            {
                connection.Open();
                Assert.AreEqual(System.Data.ConnectionState.Open, connection.State, "Database connection is not open.");
            }
        }
        catch (Exception ex)
        {
            Assert.Fail($"Database connection failed: {ex.Message}");
        }
    }
}
