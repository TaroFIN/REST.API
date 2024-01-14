# Game Store API

## Start SQL Server
``` powershell
$sa_password = ""
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -p 1433:1433 -v sqlvolumn:/var/opt/mssql -d --rm --name mssql mcr.microsoft.com/mssql/server:2022-latest
```