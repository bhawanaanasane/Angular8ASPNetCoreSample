using FLA.Core.Domain.Drivers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fla.Service.Drivers
{
    public  interface iDriverService
    {
        #region driverMethod
        //Get Max DriverCode
        long GetMaxDriverCode(long ClientId);
        //Insert Driver
        void insertDriver(Driver Driver);
        void insertDriverLogin(DriverLogin DriverLogin);

        //Delete Driver
        void DeleteDriver(Driver Driver);
        void DeleteDriverLogin(DriverLogin driverLogin);
        //Update Driver
        void UpdateDriver(Driver Driver);
        void UpdateDriverLogin(DriverLogin Driver);

        //Get Driver
        Driver GetDriver(long ClientId, long Id);
        DriverLogin GetDriverLogin(long ClientId, long DriverId);
        DriverLogin GetDriverLoginByUserName(long ClientId, string UserName);
        DriverLogin VerifyDriverByUsernamePassword(string UserName, string Password, string ClientCode);

        //Get DriverList
        IList<Driver> GetAllDriver(long ClientId, long id = 0, string FirstName = null, string LastName = null, long Owner_Company_Driver = 0, DateTime? DriverLiabilityExpiry = null, long UserLogId = 0, string RfidNumber = null, long pageIndex = 0, long pageSize = 0);
        #endregion

        #region DrugScreenMethod
        //Insert DrugScreen
        void insertDrugScreen(DrugScreen drug);

        //Delete DrugScreen
        void DeleteDrugScreen(DrugScreen drug);

        //Update DrugScreen
        void UpdateDrugScreen(DrugScreen drug);

        //Get DrugScreen
        DrugScreen GetDrugScreen(long ClientId, long Id);

        //Get DrugScreenList
        IList<DrugScreen> GetAllDrugScreen(long ClientId, long id = 0, long driverId = 0, string InvoiceNumber = null);
        #endregion

        #region TruckInspectionMethod
        //Insert TruckInspection
        void insertTruckInspection(TruckInspection truck);

        //Delete TruckInspection
        void DeleteTruckInspection(TruckInspection truck);

        //Update TruckInspection
        void UpdateTruckInspection(TruckInspection truck);

        //Get TruckInspection
        TruckInspection GetTruckInspection(long ClientId, long Id);

        //Get TruckInspectionList
        IList<TruckInspection> GetAllTruckInspection(long ClientId, long id = 0, long driverId = 0, string InvoiceNumber = null);
        #endregion

        #region DeleteRole
        bool CheckRoleInUse(long ClientId, long UserId);

        #endregion

    }
}
