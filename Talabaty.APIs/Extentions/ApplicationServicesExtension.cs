using Talabaty.APIs.Helpers;
using Talabaty.Core.Repository;
using Talabaty.Repository;
using Microsoft.EntityFrameworkCore;
using Talabaty.APIs.Helpers;
using Talabaty.Core.Repository;
using Talabaty.Repository;
using Talabaty.Repository.Data;


namespace Talabaty.APIs.Extentions
{
    public static class ApplicationServicesExtension
    {
        public static void AddApplicationServices(this IServiceCollection Services)
        {
            Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            Services.AddAutoMapper(typeof(MappingProfile));
        }

    }
}
