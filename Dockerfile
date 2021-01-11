FROM mcr.microsoft.com/dotnet/core/sdk:3.1

WORKDIR /app
COPY /app /app
COPY ./mycerts.pfx /app

EXPOSE 5000/tcp
ENV ASPNETCORE_URLS=https://*:$PORT
ENV ASPNETCORE_HTTPS_PORT=$PORT
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=./mycerts.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="dotnetpass"

CMD dotnet DataLuna.Back.dll

