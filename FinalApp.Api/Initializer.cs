using FinalApp.ApiModels.DTOs.EntitiesDTOs.RequestsDTO;
using FinalApp.ApiModels.DTOs.EntitiesDTOs.UsersDTOs;
using FinalApp.DAL.Repository.Implemintations;
using FinalApp.DAL.Repository.Interfaces;
using FinalApp.Domain.Models.Entities.Persons.Users;
using FinalApp.Domain.Models.Entities.Requests.EcoBoxInfo;
using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;
using FinalApp.Services.Implemintations;
using FinalApp.Services.Interfaces;

namespace FinalApp.Api
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            #region Base_Repositories 
            services.AddScoped<IBaseAsyncRepository<Client>, BaseAsyncRepository<Client>>();
            services.AddScoped<IBaseAsyncRepository<Request>, BaseAsyncRepository<Request>>();
            services.AddScoped<IBaseAsyncRepository<TechnicalTeam>, BaseAsyncRepository<TechnicalTeam>>();
            services.AddScoped<IBaseAsyncRepository<SupportOperator>, BaseAsyncRepository<SupportOperator>>();
            services.AddScoped<IBaseAsyncRepository<Review>, BaseAsyncRepository<Review>>();
            services.AddScoped<IBaseAsyncRepository<Location>, BaseAsyncRepository<Location>>();
            services.AddScoped<IBaseAsyncRepository<EcoBoxTemplate>, BaseAsyncRepository<EcoBoxTemplate>>();


            #endregion
        }
        public static void InitializeServices(this IServiceCollection services)
        {
            #region Base_Services
            services.AddScoped<IBaseService<Client, ClientDTO>, BaseService<Client, ClientDTO>>();
            services.AddScoped<IBaseService<Request, RequestDTO>, BaseService<Request, RequestDTO>>();
            services.AddScoped<IBaseService<TechnicalTeam, TechnicalTeamDTO>, BaseService<TechnicalTeam, TechnicalTeamDTO>>();
            services.AddScoped<IBaseService<SupportOperator, SupportOperatorDTO>, BaseService<SupportOperator, SupportOperatorDTO>>();
            services.AddScoped<IBaseService<Review, ReviewDTO>, BaseService<Review, ReviewDTO>>();
            #endregion

            #region User_Services
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IUserService<TechnicalTeam>, UserService<TechnicalTeam>>();
            services.AddScoped<IUserService<SupportOperator>, UserService<SupportOperator>>();
            #endregion

            #region Request_Services
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IRequestHistoryService, RequestHistoryService>();
            services.AddScoped<IReviewService, ReviewService>();
            #endregion
        }

    }
}
