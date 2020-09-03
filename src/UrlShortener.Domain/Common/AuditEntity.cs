using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortener.Domain.Common
{
    public class AuditEntity
    {
        public string sCreatedBy { get; set; }
        public DateTime dtCreated { get; set; }
        public string sLastModifiedBy { get; set; }
        public DateTime? dtLastModified { get; set; }
    }
}
