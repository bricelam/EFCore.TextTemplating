namespace EFCore.TextTemplating
{
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.EntityFrameworkCore.Scaffolding;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    /// <summary>
    /// Specifies our design-time services. Reference this class from your startup project using
    /// <see cref="DesignTimeServicesReferenceAttribute" />.
    /// </summary>
    internal class DesignTimeServices : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection services)
            => services.Replace(ServiceDescriptor.Singleton<IModelCodeGenerator, ModelGenerator>());
    }
}