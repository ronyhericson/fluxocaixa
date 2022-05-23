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
Processos de instalação de dependências e compilação dos projetos 
----------------------------------------------------------------------------------------------
Instalar Docker-Desktop (docker e docker-compose)
Instalar Framework .Net 5.0

clonar repositorio de: 
https://github.com/ronyhericson/fluxocaixa

Ir para pasta ../fluxocaixa/backend/FluxoCaixa.API 

Restore dos pacotes nuget 
dotnet restore --source https://api.nuget.org/v3/index.json

dotnet build

Voltar para pasta ../fluxocaixa/backend

Processos de inicialização dos container de banco postgres, execução de scripts de inicialização e serviço 

docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

