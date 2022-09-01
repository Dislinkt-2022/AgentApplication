namespace AgentApplication.WebAPI.Util
{
    public static class HerokuPostgresConfiguration
    {
        public static string ParseConnectionString(string databaseUrl)
        {
            databaseUrl = databaseUrl.Trim().Replace("postgres://", "");

            //user3123 : passkja83kd8 @ ec2-117-21-174-214.compute-1.amazonaws.com : 6212 / db982398
            //user : pass @ host : port / db_name

            var username = databaseUrl.Split('@')[0].Split(':')[0].Trim();
            var password = databaseUrl.Split('@')[0].Split(':')[1].Trim();
            var host = databaseUrl.Split('@')[1].Split(':')[0].Trim();
            var port = databaseUrl.Split('@')[1].Split(':')[1].Split('/')[0].Trim();
            var databaseName = databaseUrl.Split('@')[1].Split(':')[1].Split('/')[1].Trim();

            var connectionString = $"Server={host};Port={port};Database={databaseName};User ID={username};Password={password};";
            return connectionString;
        }
    }
}
