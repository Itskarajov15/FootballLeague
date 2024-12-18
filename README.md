# FootballLeague

The project is designed following Clean Architecture and Domain-Driven Design principles. The API communicates with the application layer using MediatR to handle commands and queries, and features global error handling with structured logging implemented using Serilog. Logs will be saved in a logs folder that is automatically created in the application's directory.

To start the project, navigate to the FootballLeague folder where the docker-compose.yml file is located and run docker compose up -d --build.

Note that the API does not currently wait for the database to be ready, so you must ensure the database container is fully initialized before starting the API container.

The address of the API is https://localhost:8081/swagger/index.html
