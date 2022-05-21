:::::::: README :::::::::

Modelo de Arquitetura: Onion Architecture

Padrões e práticas utilizadas
SOLID
CQRS
MediatR
Testes Unitarios com XUnit

Blibliotecas e frameworks utilizadas
.Net Framework 5.0
MediatR
XUnit
Dapper 
NPGSQL
PostgreSQL 9
PGADMIN 4.0
Docker Compose
Docker
Swashbuckle (Swagger)

----------------------------------------------------------------------------------------------
Processos de instalação de dependencias e compilçação dos projetos 
----------------------------------------------------------------------------------------------

Restore dos pacotes nuget 
dotnet restore --source https://api.nuget.org/v3/index.json

dotnet build

Processos de inicialização do banco postgres q execução de scripts de inicialização

docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

