using FinalApp.Api.Authentication;
using FinalApp.ApiModels.DTOs.EntitiesDTOs.RequestsDTO;
using FinalApp.ApiModels.DTOs.EntitiesDTOs.UsersDTOs;
using FinalApp.DAL.Repository.Implemintations;
using FinalApp.DAL.Repository.Interfaces;
using FinalApp.Domain.Models.Abstractions.BaseUsers;
using FinalApp.Domain.Models.Entities.Persons.Users;
using FinalApp.Domain.Models.Entities.Requests.EcoBoxInfo;
using FinalApp.Domain.Models.Entities.Requests.RequestsInfo;
using FinalApp.Services.Implemintations;
using FinalApp.Services.Interfaces;
using FinalApp.Services.Mapping;

namespace FinalApp.Api
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            #region Base_Repositories 
            services.AddScoped(typeof(IBaseAsyncRepository<>), typeof(BaseAsyncRepository<>));
            #endregion
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            #region Base_Services
            services.AddScoped<IBaseService<Client, ClientDTO>, BaseService<Client, ClientDTO>>();
            services.AddScoped<IBaseService<Request, RequestDTO>, BaseService<Request, RequestDTO>>();
            services.AddScoped<IBaseService<TechTeam, TechTeamDTO>, BaseService<TechTeam, TechTeamDTO>>();
            services.AddScoped<IBaseService<SupportOperator, SupportOperatorDTO>, BaseService<SupportOperator, SupportOperatorDTO>>();
            services.AddScoped<IBaseService<Review, ReviewDTO>, BaseService<Review, ReviewDTO>>();
            #endregion

            #region User_Services
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IUserService<TechTeam>, UserService<TechTeam>>();
            services.AddScoped<IUserService<SupportOperator>, UserService<SupportOperator>>();
            #endregion

            #region Request_Services
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IRequestHistoryService, RequestHistoryService>();
            services.AddScoped<IReviewService, ReviewService>();
            #endregion

            #region Authorization_And_Authentication_Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped(typeof(IAuthManager<>), typeof(AuthManager<>));

            #endregion

            #region AutoMapper
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new MappingProfile());
            });
            #endregion
        }

    }
}
