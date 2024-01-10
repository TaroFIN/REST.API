# Game Store API

# Start SQL Server
```powershell
$sql_password="Pass@word123"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sql_password" -p 1433:1433 -v sqlvolumn:/var/opt/mssql -d --rm --name mssql mcr.microsoft.com/mssql/server:2022-latest
```

## Setting the connection string to secret manager
```powershell
$sql_password="Pass@word123"
dotnet user-secrets set "ConnectionString:GameStoreContext" "Server:localhost; Database:GameStore; User Id:sa; Password:$sql_password; TrustServerCertificate:True;"
```
