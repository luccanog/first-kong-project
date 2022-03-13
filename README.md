# My very first kong gateway project
<b>API Gateway and Microservices using Kong and dotnet core in docker</b>
🦍🐳


### Start microservices

<code>docker-compose build</code>

<code>docker-compose up</code>

### Setup Postgres database

<code>docker run -d --name kong-database --network=kong-net -p 5432:5432 -e "POSTGRES_USER=kong" -e "POSTGRES_DB=kong"  -e "POSTGRES_PASSWORD=kong" postgres:9.6</code>

<code>docker run --rm --network=kong-net  -e "KONG_DATABASE=postgres" -e "KONG_PG_HOST=kong-database" -e "KONG_PG_USER=kong" -e "KONG_PG_PASSWORD=kong"  kong:latest kong migrations bootstrap</code>

### Run Kong

<code>docker run -d --name kong --network=kong-net -e "KONG_DATABASE=postgres" -e "KONG_PG_HOST=kong-database" -e "KONG_PG_USER=kong" -e "KONG_PG_PASSWORD=kong" -e "KONG_PROXY_ACCESS_LOG=/dev/stdout"  -e "KONG_ADMIN_ACCESS_LOG=/dev/stdout"      -e "KONG_PROXY_ERROR_LOG=/dev/stderr"      -e "KONG_ADMIN_ERROR_LOG=/dev/stderr"      -e "KONG_ADMIN_LISTEN=0.0.0.0:8001, 0.0.0.0:8444 ssl"      -p 8000:8000      -p 8443:8443     -p 127.0.0.1:8001:8001     -p 127.0.0.1:8444:8444      kong:latest
</code>


### Add microservices routes
<code>curl -i -X POST http://localhost:8001/services --data name=numbers --data url="http://numbers:7001/"
curl -i -X POST http://localhost:8001/services/numbers/routes --data "paths[]=/numbers" --data name=numbers</code>

<code>curl -i -X POST http://localhost:8001/services --data name=words --data url="http://words:7002/"
curl -i -X POST http://localhost:8001/services/numbers/routes --data "paths[]=/words" --data name=words</code>
