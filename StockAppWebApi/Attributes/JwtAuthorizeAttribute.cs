using Microsoft.AspNetCore.Mvc;
using StockAppWebApi.Filter;

namespace StockAppWebApi.Attributes;

public class JwtAuthorizeAttribute : TypeFilterAttribute
{
    public JwtAuthorizeAttribute() : base(typeof(JwtAuthorizeFilter))
    {

    }
}
