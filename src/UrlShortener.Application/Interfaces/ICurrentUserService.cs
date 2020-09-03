using System;
using System.Collections.Generic;
using System.Text;

namespace UrlShortener.Application.Interfaces
{
    public interface ICurrentUserService
    {
        string UserId { get; set; }
    }
}
