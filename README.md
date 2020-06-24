# aspnet-async-communication
Undoubtedly the most popular design pattern when writing distributed application
is Pub/Sub. Turns out that there's another important design pattern used in
distributed applications not as frequently mentioned, that can also be
implemented with queues: async resquests/responses. Async resquests/responses
are very useful and widely used to exchange data between microservices in
non-blocking calls, allowing the resqueted service to throttle incoming requests
via a queue preventing its own exhaustion.

This repo implements async resquest/response exchange between two ASP.NET Core
websites via RabbitMQ queues using MassTransit. We'll also wire everything up
using Docker and Docker Compose. 

## License
This project is licensed under
[the MIT License](https://opensource.org/licenses/MIT).

## Final Thoughts
To learn more about this app, ASP.NET Core, Docker, Azure, Linux and
microservices, check my blog at: [blog.hildenco.com](https://blog.hildenco.com)

