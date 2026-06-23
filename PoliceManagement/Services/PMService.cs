using PoliceManagement.DBContext;
using PoliceManagement.Entities;
using PoliceManagement.ViewModels;

namespace PoliceManagement.Services
{
    public class PMService : IPMService
    {
        private readonly PMContext _pmContext;

        public PMService(PMContext pmContext)
        {
            _pmContext = pmContext;
        }

        public List<PMViewModel> GetAll()
        {
            try
            {
                var data = _pmContext.PoliceRecords
                    .Select(x => new PMViewModel
                    {
                        Officerid = x.Officerid,
                        BadgeNumber = x.BadgeNumber,
                        OfficerName = x.OfficerName,
                        Department = x.Department,
                        Location = x.Location,
                        Salary = x.Salary,
                        JoiningDate = x.JoiningDate,
                        Rank = x.Rank
                    }).OrderByDescending(y=>y.JoiningDate).ToList();


                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public PMViewModel GetById(Guid id)
        {
            try
            {
                var data = _pmContext.PoliceRecords.Where(x => x.Officerid == id)
                    .Select(x => new PMViewModel
                    {
                        Officerid = x.Officerid,
                        BadgeNumber = x.BadgeNumber,
                        OfficerName = x.OfficerName,
                        Department = x.Department,
                        Location = x.Location,
                        Salary = x.Salary,
                        JoiningDate = x.JoiningDate,
                        Rank = x.Rank
                    }).FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    

        public void Add(PMViewModel record)
        {
            try
            {
                PMEntity entity = new PMEntity();

                entity.Officerid = Guid.NewGuid();
                entity.BadgeNumber = record.BadgeNumber;
                entity.OfficerName = record.OfficerName;
                entity.Department = record.Department;
                entity.Location = record.Location;
                entity.Salary = record.Salary;
                entity.JoiningDate = record.JoiningDate;
                entity.Rank = record.Rank;

                _pmContext.PoliceRecords.Add(entity);
                _pmContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(PMViewModel Newdata)
        {
            try
            {
                var entity = _pmContext.PoliceRecords.FirstOrDefault(x => x.Officerid == Newdata.Officerid);

                if (entity == null)
                {
                    throw new Exception("Record not found");
                }

                entity.BadgeNumber = Newdata.BadgeNumber;
                entity.OfficerName = Newdata.OfficerName;
                entity.Department = Newdata.Department;
                entity.Location = Newdata.Location;
                entity.Salary = Newdata.Salary;
                entity.JoiningDate = Newdata.JoiningDate;
                entity.Rank = Newdata.Rank;

                _pmContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public void Delete(Guid id)
        {

            try
            {
                var entity = _pmContext.PoliceRecords.FirstOrDefault(x => x.Officerid == id);

                if (entity == null)
                {
                    throw new Exception("Record not found");
                }

                _pmContext.PoliceRecords.Remove(entity);
                _pmContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void UpdateName(PatchNameViewModel NewName)
        {
            try
            {
                var entity = _pmContext.PoliceRecords.FirstOrDefault(x => x.Officerid == NewName.Officerid);

                if (entity == null)
                {
                    throw new Exception("Record not found");
                }

                entity.OfficerName = NewName.OfficerName;

                _pmContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
