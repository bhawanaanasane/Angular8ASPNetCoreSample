using FLA.Core.Domain.Clients;
using FLA.Core.Domain.Drivers;
using FLA.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fla.Service.Drivers
{
   public class DriverService:iDriverService
    {
        #region Fields

        private readonly IRepository<Driver> _DriversRepository;
        private readonly IRepository<DriverLogin> _DriversLoginRepository;
        private readonly IRepository<Client> _ClientRepository;
        private readonly IRepository<DrugScreen> _DrugScreenRepository;
        private readonly IRepository<TruckInspection> _TruckInspectionRepository;

        #endregion

        #region Ctor
        public DriverService(IRepository<Driver> DriversRepository, IRepository<DriverLogin> DriversLoginRepository, IRepository<DrugScreen> DrugScreenRepository, IRepository<TruckInspection> TruckInspectionRepository, IRepository<Client> ClientRepository)
        {
            this._DriversRepository = DriversRepository;
            this._DrugScreenRepository = DrugScreenRepository;
            this._TruckInspectionRepository = TruckInspectionRepository;
            this._ClientRepository = ClientRepository;
            this._DriversLoginRepository = DriversLoginRepository;
        }


        #endregion
        #region Driver Method
        //Get Max DriverCode
        public long GetMaxDriverCode(long ClientId)
        {
            var Driver = _DriversRepository.Table.Where(a => a.ClientId == ClientId).ToList();
            if (Driver.Count != 0)
            {
                var Code = Driver.Max(a => Convert.ToInt64(a.DriverCode));
                return Code + 1;
            }
            else
            {
                var quary = _ClientRepository.Table.Where(a => a.Id == ClientId).FirstOrDefault();
                if (quary != null)
                {
                    if (quary.StartingDriverCodeNumber != null && quary.StartingDriverCodeNumber != "")
                    {
                        return Convert.ToInt32(quary.StartingDriverCodeNumber) + 1;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return 1;
                }
            }

        }
        //Insert Driver
        public virtual void insertDriver(Driver driver)
        {
            if (driver == null)
                throw new ArgumentNullException(nameof(Driver));
            _DriversRepository.Insert(driver);
        }
        public void insertDriverLogin(DriverLogin DriverLogin)
        {
            if (DriverLogin == null)
                throw new ArgumentNullException(nameof(DriverLogin));
            _DriversLoginRepository.Insert(DriverLogin);
        }

        //Delete Driver
        public virtual void DeleteDriver(Driver driver)
        {
            if (driver == null)
                throw new AccessViolationException(nameof(Driver));
            _DriversRepository.Delete(driver);
        }
        public virtual void DeleteDriverLogin(DriverLogin driverLogin)
        {
            if (driverLogin == null)
                throw new AccessViolationException(nameof(DriverLogin));
            _DriversLoginRepository.Delete(driverLogin);
        }

        //Update Driver
        public virtual void UpdateDriver(Driver driver)
        {
            if (driver == null)
                throw new AccessViolationException(nameof(Driver));
            _DriversRepository.Update(driver);
        }
        public virtual void UpdateDriverLogin(DriverLogin DriverLogin)
        {
            if (DriverLogin == null)
                throw new AccessViolationException(nameof(DriverLogin));
            _DriversLoginRepository.Update(DriverLogin);
        }

        //Get Driver
        public virtual Driver GetDriver(long ClientId, long id)
        {
            if (id == 0)
                throw new AccessViolationException(nameof(Driver));
            var DriverDetail = _DriversRepository.Table.Where(a => a.Id == id && a.ClientId == ClientId).FirstOrDefault();
            return DriverDetail;

        }
        public virtual DriverLogin GetDriverLogin(long ClientId, long DriverId)
        {
            if (DriverId == 0)
                throw new AccessViolationException(nameof(DriverLogin));
            var DriverDetail = _DriversLoginRepository.Table.Where(a => a.DriverId == DriverId && a.ClientId == ClientId).FirstOrDefault();
            return DriverDetail;
        }

        public DriverLogin GetDriverLoginByUserName(long ClientId, string UserName)
        {
            if (UserName == "")
                throw new AccessViolationException(nameof(DriverLogin));
            var DriverDetail = _DriversLoginRepository.Table.Where(a => a.UserName == UserName && a.ClientId == ClientId).FirstOrDefault();

            return DriverDetail;
        }

        public DriverLogin VerifyDriverByUsernamePassword(string UserName, string Password, string ClientCode)
        {
            var DriverDetail = _DriversLoginRepository.Table.Where(a => a.UserName == UserName && a.Password == Password && a.ClientCode == ClientCode).FirstOrDefault();
            return DriverDetail;
        }

        //Get DriverList
        public virtual IList<Driver> GetAllDriver(long ClientId, long id, string FirstName, string LastName, long Owner_Company_Driver, DateTime? DriverLiabilityExpiry, long UserLogId, string RfidNumber, long pageIndex, long pageSize)
        {
            var query = _DriversRepository.Table;
            if (id > 0)
            {
                query = query.Where(a => a.Id == id);
            }
            if (FirstName != null)
            {
                query = query.Where(a => a.FirstName.Contains(FirstName));
            }
            if (LastName != null)
            {
                query = query.Where(a => a.LastName.Contains(LastName));
            }
            if (Owner_Company_Driver > 0)
            {
                query = query.Where(a => a.Owner_Company_Driver == Owner_Company_Driver);
            }
            if (DriverLiabilityExpiry != null)
            {
                query = query.Where(a => a.DriverLiabilityExpiry == DriverLiabilityExpiry);
            }
            if (UserLogId > 0)
            {
                query = query.Where(a => a.UserLogID == UserLogId);
            }
            if (RfidNumber != null)
            {
                query = query.Where(a => a.RFIDNumber == RfidNumber);
            }
            query = query.Where(a => a.ClientId == ClientId);
            return query.OrderByDescending(a => a.Id).ToList();
        }
        #endregion


        #region DrugScreen Method
        //Insert Driver
        public virtual void insertDrugScreen(DrugScreen driver)
        {
            if (driver == null)
                throw new ArgumentNullException(nameof(DrugScreen));
            _DrugScreenRepository.Insert(driver);
        }

        //Delete Driver
        public virtual void DeleteDrugScreen(DrugScreen driver)
        {
            if (driver == null)
                throw new AccessViolationException(nameof(DrugScreen));
            _DrugScreenRepository.Delete(driver);
        }

        //Update Driver
        public virtual void UpdateDrugScreen(DrugScreen driver)
        {
            if (driver == null)
                throw new AccessViolationException(nameof(DrugScreen));
            _DrugScreenRepository.Update(driver);
        }

        //Get Driver
        public virtual DrugScreen GetDrugScreen(long ClientId, long id)
        {
            if (id == 0)
                throw new AccessViolationException(nameof(DrugScreen));
            var DriverDetail = _DrugScreenRepository.Table.Where(a => a.Id == id && a.ClientId == ClientId).FirstOrDefault();
            return DriverDetail;

        }

        //Get DriverList
        public virtual IList<DrugScreen> GetAllDrugScreen(long ClientId, long id, long driverId, string InvoiceNumber)
        {
            var query = _DrugScreenRepository.Table;
            if (id > 0)
            {
                query = query.Where(a => a.Id == id);
            }
            if (driverId > 0)
            {
                query = query.Where(a => a.DriverId == driverId);
            }
            if (InvoiceNumber != null)
            {
                query = query.Where(a => a.InvoiceNumber == InvoiceNumber);
            }
            query = query.Where(a => a.ClientId == ClientId);
            return query.ToList();
        }
        #endregion

        #region TruckInspection Method
        //Insert TruckInspection
        public virtual void insertTruckInspection(TruckInspection Truck)
        {
            if (Truck == null)
                throw new ArgumentNullException(nameof(TruckInspection));
            _TruckInspectionRepository.Insert(Truck);
        }

        //Delete TruckInspection
        public virtual void DeleteTruckInspection(TruckInspection Truck)
        {
            if (Truck == null)
                throw new AccessViolationException(nameof(TruckInspection));
            _TruckInspectionRepository.Delete(Truck);
        }

        //Update TruckInspection
        public virtual void UpdateTruckInspection(TruckInspection Truck)
        {
            if (Truck == null)
                throw new AccessViolationException(nameof(TruckInspection));
            _TruckInspectionRepository.Update(Truck);
        }

        //Get TruckInspection
        public virtual TruckInspection GetTruckInspection(long ClientId, long id)
        {
            if (id == 0)
                throw new AccessViolationException(nameof(TruckInspection));
            var TruckInspectionDetail = _TruckInspectionRepository.Table.Where(a => a.Id == id && a.ClientId == ClientId).FirstOrDefault();
            return TruckInspectionDetail;

        }

        //Get DriverList
        public virtual IList<TruckInspection> GetAllTruckInspection(long ClientId, long id, long driverId, string InvoiceNumber)
        {
            var query = _TruckInspectionRepository.Table;
            if (id > 0)
            {
                query = query.Where(a => a.Id == id);
            }
            if (driverId > 0)
            {
                query = query.Where(a => a.DriverId == driverId);
            }
            if (InvoiceNumber != null)
            {
                query = query.Where(a => a.InvoiceNumber == InvoiceNumber);
            }
            query = query.Where(a => a.ClientId == ClientId);
            return query.ToList();
        }
        #endregion
        #region Utilites


        #endregion

        #region CheckRoles
        public bool CheckRoleInUse(long ClientId, long UserId)
        {
            if (_DriversRepository.Table.Where(a => a.ClientId == ClientId && a.UserLogID == UserId).ToList().Count() != 0)
            {
                return true;
            }
            else if (_ClientRepository.Table.Where(a => a.Id == ClientId && a.UserId == UserId).ToList().Count() != 0)
            {
                return true;
            }
            else if (_DrugScreenRepository.Table.Where(a => a.ClientId == ClientId && a.UserId == UserId).ToList().Count() != 0)
            {
                return true;
            }
            else if (_TruckInspectionRepository.Table.Where(a => a.ClientId == ClientId && a.UserId == UserId).ToList().Count() != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
