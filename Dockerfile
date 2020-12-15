FROM mcr.microsoft.com/dotnet/core/sdk:3.1

WORKDIR /app
COPY /app /app

EXPOSE 5000/tcp
ENV ASPNETCORE_URLS=http://*:$PORT

CMD dotnet DataLuna.Back.dll

