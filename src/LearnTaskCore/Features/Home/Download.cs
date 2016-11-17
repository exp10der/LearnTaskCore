namespace LearnTaskCore.Features.Home
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Infrastructure;
    using Ionic.Zip;
    using MediatR;

    public class Download
    {
        public class Query : IAsyncRequest<Model>
        {
            public int Id { get; set; }
        }

        public class Model
        {
            public byte[] FileContents { get; set; }
            public IEnumerable<ItemDocument> ItemDocuments { get; set; }

            public class ItemDocument
            {
                public string DocumentPath { get; set; }
            }
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
                var documents = await _context.ItemDocuments
                    .Where(itemDocuments => itemDocuments.ItemId == message.Id)
                    .ProjectToListAsync<Model.ItemDocument>();

                var viewModel = new Model
                {
                    FileContents = CreateContentBytes(documents.Select(n => n.DocumentPath)),
                    ItemDocuments = documents
                };

                return viewModel;
            }

            private byte[] CreateContentBytes(IEnumerable<string> paths)
            {
                using (var outputStream = new MemoryStream())
                {
                    using (var zip = new ZipFile())
                    {
                        zip.AddFiles(paths, false, "");
                        zip.Save(outputStream);
                    }
                    return outputStream.ToArray();
                }
            }
        }
    }
}