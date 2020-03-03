using CRMALL.Teste.Business.Service;
using CRMALL.Teste.Domain.Interfaces.Repository;
using CRMALL.Teste.Domain.Interfaces.Service;
using CRMALL.Teste.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CRMALL.Api.Injection
{
    public static class Factory
    {
        public static void Build(IServiceCollection services)
        {
            services.AddTransient<IPessoaService, PessoaService>();
            services.AddTransient<IPessoaRepository, PessoaRepository>();

            //services.AddTransient<IUserService, UserService>();
            //services.AddTransient<IUserRepository, UserRepository>();

            Teste.Business.Injection.Factory.SetServices(services.BuildServiceProvider());
        }

        public static TS GetInstance<T, TS>()
        {
            return Teste.Business.Injection.Factory.GetInstance<T, TS>();
        }
    }
}
