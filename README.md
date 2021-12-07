# Instrucciones

## SQL:

1. Ejecutar script .\PagoEfectivo.PromoCode.Database\Script.PostDeployment.sql en servidor sql.

## NET 5:

2. Actualizar valor de cadena de conexión (ConnectionStrings.DbConnection) en .\PagoEfectivo.PromoCode.Api\appsettings.json
3. Ejecutar comando dotnet run en .\PagoEfectivo.PromoCode.Api para levantar el backend

## Angular:

4. Ejecutar npm i para instalar las dependencias en .\PagoEfectivo-PromoCode-Frontend
5. Actualizar el valor Urlapi de enviroment.ts con la ruta del backend
6. Ejecutar ng serve -o para levantar el cliente en .\PagoEfectivo-PromoCode-Frontend

## Docker:

7. Comando para construir docker build -f .\PagoEfectivo.PromoCode.Api\Dockerfile -t webapi .
8. Comando para ejecutar docker run -it -p 80:80 -d webapi
