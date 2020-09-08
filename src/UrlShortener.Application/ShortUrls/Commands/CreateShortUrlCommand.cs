using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace UrlShortener.Application.ShortUrls.Commands
{
    public class CreateShortUrlCommand : IRequest<int>
    {
        public CreateShortUrlCommand()
        {
           
        }

        public int iShortUrlID { get; set; }
        public string sOriginalUrl { get; set; }
        public string sShortUrl { get; set; }
        public DateTime? dtDeleted { get; set; }
    }
}
