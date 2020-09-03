using System;
using System.Collections.Generic;
using System.Text;
using UrlShortener.Domain.Common;

namespace UrlShortener.Domain.Entities
{
    public class ShortUrl : AuditEntity
    {
        public ShortUrl()
        {
        }

        public int iShortUrlID { get; set; }
        public string sOriginalUrl { get; set; }
        public string sShortUrl { get; set; }
        public DateTime? dtDeleted { get; set; }
    }
}
