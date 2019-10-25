# FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
# WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /sources
#COPY ./src .
#COPY . .
COPY . .
#RUN dotnet restore ./src
#RUN dotnet build -c Release -o /app/build ./src
#RUN dotnet publish -c Release -o /repository

# FROM build AS publish
# RUN dotnet publish -c Release -o /app/publish


# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "WorkerService1.dll"]

#
#docker build --tag xxx .
#docker run --rm -it xxx:latest --name xxx-container sh

#docker build --tag xxx . `
# --mount type=bind,source="$($pwd)",target=/source `
#







# FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
# WORKDIR /app

# FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
# WORKDIR /sources
# COPY ./src .
# RUN dotnet restore
# RUN dotnet build -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish -c Release -o /app/publish


# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "WorkerService1.dll"]