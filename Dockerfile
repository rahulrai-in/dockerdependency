ARG waitForContainer

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

COPY /DockerDependencyTest/DockerDependencyTest.csproj ./
RUN dotnet restore

ENV WAIT_HOSTS=$waitForContainer

RUN echo $waitForContainer 

COPY . ./
ADD https://github.com/ufoscout/docker-compose-wait/releases/download/2.5.0/wait /wait
RUN chmod +x /wait

CMD /wait && dotnet test