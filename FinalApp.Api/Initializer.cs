using FinalApp.ApiModels.DTOs.EntitiesDTOs.UsersDTOs;
using FinalApp.DAL.Repository.Implemintations;
using FinalApp.DAL.Repository.Interfaces;
using FinalApp.Domain.Models.Common;
using FinalApp.Domain.Models.Entities.Persons.Users;
using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;
using FinalApp.Services.Interfaces;
using FinalApp.Services.Implemintations;
using FinalApp.ApiModels.DTOs.EntitiesDTOs.RequestsDTO;

namespace FinalApp.Api
{
    public static class Initializer
    {
        public static void InitializeRepositories<T>(this IServiceCollection services)
        {
            services.AddScoped<IBaseAsyncRepository<Client>, BaseAsyncRepository<Client>>();
            services.AddScoped<IBaseAsyncRepository<Request>, BaseAsyncRepository<Request>>();
            services.AddScoped<IBaseAsyncRepository<TechnicalTeam>, BaseAsyncRepository<TechnicalTeam>>();
            services.AddScoped<IBaseAsyncRepository<SupportOperator>, BaseAsyncRepository<SupportOperator>>();
            services.AddScoped<IBaseAsyncRepository<Review>, BaseAsyncRepository<Review>>();
        }
        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IBaseService<Client, ClientDTO>, BaseService<Client, ClientDTO>>();
            services.AddScoped<IBaseService<Request, RequestDTO>, BaseService<Request, RequestDTO>>();
            services.AddScoped<IBaseService<TechnicalTeam, TechnicalTeamDTO>, BaseService<TechnicalTeam, TechnicalTeamDTO>>();
            services.AddScoped<IBaseService<SupportOperator, SupportOperatorDTO>, BaseService<SupportOperator, SupportOperatorDTO>>();
            services.AddScoped<IBaseService<Review, ReviewDTO>, BaseService<Review, ReviewDTO>>();

        }

    }
}
