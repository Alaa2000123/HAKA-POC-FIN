using AutoMapper;

namespace API.Helper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Entity.FleetManagement, DTO.FleetManagement>();
            CreateMap<DTO.FleetManagement, Entity.FleetManagement>();

            CreateMap<Entity.GeneralAction, DTO.GeneralAction>();
            CreateMap<DTO.GeneralAction, Entity.GeneralAction>();
           
            CreateMap<Entity.GeneralActionsHistory, DTO.GeneralActionsHistory>();
            CreateMap<DTO.GeneralActionsHistory, Entity.GeneralActionsHistory>();
              
            CreateMap<Entity.GeneralEmployee, DTO.GeneralEmployee>();
            CreateMap<DTO.GeneralEmployee, Entity.GeneralEmployee>();
              
            CreateMap<Entity.GeneralLookup, DTO.GeneralLookup>();
            CreateMap<DTO.GeneralLookup, Entity.GeneralLookup>();
               
            CreateMap<Entity.GeneralLookupsGroup, DTO.GeneralLookupsGroup>();
            CreateMap<DTO.GeneralLookupsGroup, Entity.GeneralLookupsGroup>();
             
            CreateMap<Entity.GeneralRequestsService, DTO.GeneralRequestsService>();
            CreateMap<DTO.GeneralRequestsService, Entity.GeneralRequestsService>();
               
            CreateMap<Entity.GeneralServiceType, DTO.GeneralServiceType>();
            CreateMap<DTO.GeneralServiceType, Entity.GeneralServiceType>();
             
            CreateMap<Entity.GeneralStep, DTO.GeneralStep>();
            CreateMap<DTO.GeneralStep, Entity.GeneralStep>();
               
            CreateMap<Entity.GenralService, DTO.GenralService>();
            CreateMap<DTO.GenralService, Entity.GenralService>();
               
            CreateMap<Entity.GenralStatus, DTO.GenralStatus>();
            CreateMap<DTO.GenralStatus, Entity.GenralStatus>();
              
            CreateMap<Entity.InsuranceCompanyType, DTO.InsuranceCompanyType>();
            CreateMap<DTO.InsuranceCompanyType, Entity.InsuranceCompanyType>();
              
            CreateMap<Entity.InsuranceInfo, DTO.InsuranceInfo>();
            CreateMap<DTO.InsuranceInfo, Entity.InsuranceInfo>();
              
        }
    }
}
