using PoliceManagement.Entities;
using PoliceManagement.ViewModels;

namespace PoliceManagement.Services
{
    public interface IPMService
    {


        List<PMViewModel> GetAll();

        PMViewModel GetById(Guid id);


        void Add(PMViewModel record);


        void Update(PMViewModel Newdata);

        void Delete(Guid id);

        void UpdateName(PatchNameViewModel NewName);
    }


}
