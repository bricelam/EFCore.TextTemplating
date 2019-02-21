using System;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.TextTemplating.Design
{
    class DesignTimeServices : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection services)
            => services.AddSingleton<IModelCodeGenerator, MyModelGenerator>();
    }
}
