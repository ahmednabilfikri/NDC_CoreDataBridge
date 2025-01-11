namespace NDC_Core_DataBridge.Helpers
{
    internal static class ConnectionStringBuilder
    {
        internal static string BuildConnectionString(Models.CredentialsDto credentialsDto)
        {
            return $"Server={credentialsDto.Id};User={credentialsDto.Username};Password={credentialsDto.Password};Database={credentialsDto.DatabaseName};";
        }
    }
}
