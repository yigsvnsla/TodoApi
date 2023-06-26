namespace TodoApi.Models
{
    public class Connection
    {
        public string ConnectionString { get; } = String.Empty;

        public Connection()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            ConnectionString = configurationBuilder.GetSection("ConnectionStrings:DefaultConnection").Value;
        }
    }
}