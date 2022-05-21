# <h1>Controle de fluxo de caixa</h1>

Modelo de arquitetura <br />
![Onion Architecture ](https://user-images.githubusercontent.com/55793137/169664598-b1de8ce0-ef7d-4dff-b9e1-8b67581e3aa3.png)

Fluxo da arquitetura <br />
![Onion Architecture  (1)](https://user-images.githubusercontent.com/55793137/169664925-d5b13349-3268-4d2d-8bd5-8eb452d64d53.png)

<br />    
<u>Padrões e práticas utilizados</u>
<br /> 

 - SOLID 
 - CQRS 
 - Testes Unitarios com XUnit 
 
<br />    
<u>Blibliotecas e frameworks utilizados</u>
<br /> 
    
  - .Net Framework 5.0 
  - Dapper
  - NPGSQL  
  - PostgreSQL 9
  - PGADMIN 4.0
  - Docker Compose
  - Docker
  - Swashbuckle (Swagger)
  
  <h3>Processos de instalação de dependencias</h3>
  <br />
  <code>dotnet build</code>
    
  Processos de inicialização
  <br />
  <code>docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d</code>
  <br />
  <br />
  <u><h2>Links uteis</h2></u>
  <br />
  SWAGGER: <hyperlink>http://host.docker.internal:8001/swagger/index.html</hyperlink>
  <br />
  PGADMIN: <hyperlink>http://host.docker.internal:16543/</hyperlink> User: admin@fluxocaixa.com.br | pwr: admin123
  <br />
  FRAMEWORK .NET CORE 5.0: <hyperlink>https://dotnet.microsoft.com/en-us/download/dotnet/5.0</hyperlink>
  
  
 <u>Desenvolvimento Frontend</u>

- ReactJS (18.0)
- axios (0.26.1)
- material-ui (5.6.1)

<u>Processos de instalação de dependencias</u>
  <br />
  <code>npm install</code>

Processos de inicialização
<br />
  <code>npm start</code>  
  
