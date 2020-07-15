using FLA.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fla.Service.Orders
{
    public partial interface IOrderService
    {
        #region Order
        //Insert Order
        void CreateOrder(Order order);

        //delete Order
        void DeleteOrder(Order order);

        //update Order
        void UpdateOrder(Order order);

        //get order List
        IList<Order> GetAllOrder(long ClientId, long id = 0, long DeliveryID = 0, long UserLogId = 0, long OrderNumber = 0, string BookingNumber = null, long SalesRepID = 0, long BillToID = 0, long PickupID = 0);
        Order GetOrder(long id = 0, long PickupId = 0, long DeliveryId = 0, long ReturnLocationId = 0, long BilltoId = 0);
        long GetMaxOrderNo(long ClientId);
        #endregion

        #region Containers
        //Insert container
        void CreateContainer(Containers container);

        //delete container
        void DeleteContainer(Containers container);

        //update container
        void UpdateContainer(Containers container);

        Containers GetContainers(long Id = 0, long SizeId = 0, long ChassisId = 0);
        Containers GetContainerById(long Id);
        IList<Containers> GetContainersList(long ClientId, long Id = 0, long orderId = 0);
        #endregion
        #region Size
        //Insert Order
        void CreateSize(Size size);

        //delete Order
        void DeleteSize(Size size);

        //update Order
        void UpdateSize(Size size);

        Size GetSize(long Id = 0);
        Size GetSizeById(long Id);
        IList<Size> GetSizeList(long Id = 0, long ClientId = 0, bool Dropdown = false);
        #endregion
        #region Availability
        //Insert Order
        void CreateAvailability(Availability Availability);

        //delete Order
        void DeleteAvailability(Availability Availability);

        //update Order
        void UpdateAvailability(Availability Availability);

        Availability GetAvailability(long Id = 0, long ContainerId = 0);
        #endregion
        #region Chassis
        //Insert Chassis
        void CreateChassis(Chassis Chassis);

        //delete Chassis
        void DeleteChassis(Chassis Chassis);

        //update Chassis
        void UpdateChassis(Chassis Chassis);

        Chassis GetChassis(long Id = 0);
        IList<Chassis> GetChassisList(long ClientId, long Id = 0);
        #endregion
        #region RentalCompany
        //Insert RentalCompany
        void CreateRentalCompany(RentalCompany RentalCompany);

        //delete RentalCompany
        void DeleteRentalCompany(RentalCompany RentalCompany);

        //update RentalCompany
        void UpdateRentalCompany(RentalCompany RentalCompany);

        RentalCompany GetRentalCompany(long ClientId, long Id = 0);
        IList<RentalCompany> GetRentalCompanyList(long ClientId, long Id = 0);
        #endregion

        #region DeleteRole
        bool CheckRoleInUse(long ClientId, long UserId);

        #endregion

    }
}
