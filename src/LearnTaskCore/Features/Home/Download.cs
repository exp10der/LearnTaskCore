namespace LearnTaskCore.Features.Home
{
    using System;
    using System.Threading.Tasks;
    using Infrastructure;
    using MediatR;

    public class Download
    {
        public class Query : IAsyncRequest<Model>
        {
            public int Id { get; set; }
        }

        public class Model
        {
        }

        public class QueryHandler : IAsyncRequestHandler<Query, Model>
        {
            private readonly ApplicationDbContext _context;

            public QueryHandler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Model> Handle(Query message)
            {
                throw new NotImplementedException();
            }
        }
    }
}