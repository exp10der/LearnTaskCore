namespace LearnTaskCore.Features.Home
{
    using System.Threading.Tasks;
    using Infrastructure;
    using MediatR;

    public class Details
    {
        public class Query : IAsyncRequest<Model>
        {
            public int Id { get; set; }
        }

        public class Model
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string ImagePath { get; set; }
            public bool HasRelatedLinks { get; set; }
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
                var query = @"
SELECT  I.* ,
        CASE WHEN EXISTS ( SELECT   1
                           FROM     dbo.ItemDocuments AS ID
                           WHERE    ID.ItemId = I.Id ) THEN CAST(1 AS BIT)
             ELSE CAST(0 AS BIT)
        END AS HasRelatedLinks
FROM    dbo.Items AS I
WHERE   Id = @p0;
";

                var model = await _context.Database.SqlQuery<Model>(query, message.Id).SingleOrDefaultAsync();

                return model;
            }
        }
    }
}