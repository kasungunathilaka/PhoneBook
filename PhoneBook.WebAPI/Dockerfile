FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY PhoneBook.WebAPI/PhoneBook.WebAPI.csproj PhoneBook.WebAPI/
COPY PhoneBook.Business/PhoneBook.Business.csproj PhoneBook.Business/
COPY PhoneBook.Contract/PhoneBook.Contract.csproj PhoneBook.Contract/
COPY PhoneBook.Persistence/PhoneBook.Persistence.csproj PhoneBook.Persistence/
RUN dotnet restore
COPY . .
WORKDIR /src/PhoneBook.WebAPI
RUN chmod +x entrypoint.sh
CMD /bin/bash entrypoint.sh
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PhoneBook.WebAPI.dll"]


