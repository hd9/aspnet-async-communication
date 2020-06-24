using HildenCo.Core;
using HildenCo.Core.Contracts;
using MassTransit;
using ResponseSvc.Core.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ResponseSvc.Core.Consumers
{
    /// <summary>
    /// ProductInfoRequestConsumer consumes ProductInfoRequest events
    /// and responds asynchronously with account information.
    /// </summary>
    public class ProductInfoRequestConsumer
        : IConsumer<ProductInfoRequest>
    {

        readonly ICatalogSvc _svc;

        public ProductInfoRequestConsumer(ICatalogSvc svc)
        {
            _svc = svc;
        }

        public async Task Consume(ConsumeContext<ProductInfoRequest> context)
        {
            var msg = context.Message;
            var slug = msg.Slug;

            // a fake delay
            var delay = 1000 * (msg.Delay > 0 ? msg.Delay : 1);
            await Task.Delay(delay);

            // get the product from ProductService
            var p = _svc.GetProductBySlug(slug);

            // this responds via the queue to our client
            await context.RespondAsync(new ProductInfoResponse
            {
                Product = p
            });
        }
    }
}
