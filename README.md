# SQL:

1. Ejecutar script .\PagoEfectivo.PromoCode.Database\Script.PostDeployment.sql en servidor sql.

# NET 5:

2. Actualizar valor de cadena de conexión (ConnectionStrings.DbConnection) en .\PagoEfectivo.PromoCode.Api\appsettings.json
3. Ejecutar comando dotnet run en .\PagoEfectivo.PromoCode.Api para levantar el backend

# Angular:

4. Ejecutar npm i para instalar las dependencias en .\PagoEfectivo-PromoCode-Frontend
5. Ejecutar ng serve -o para levantar el cliente en .\PagoEfectivo-PromoCode-Frontend

# Docker:

6. Comando para construir docker build -f .\PagoEfectivo.PromoCode.Api\Dockerfile -t webapi .
7. Comando para ejecutar docker run -it -p 80:0 -d webapi
