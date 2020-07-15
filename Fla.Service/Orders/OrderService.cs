using FLA.Core.Domain.BaseTable;
using FLA.Core.Domain.Clients;
using FLA.Core.Domain.Orders;
using FLA.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fla.Service.Orders
{
    public partial class OrderService : IOrderService
    {
        #region Fields
        private readonly IRepository<PickupDelivery> _PickupRepository;
        private readonly IRepository<Client> _ClientRepository;
        private readonly IRepository<BillTo> _BillToRepository;
        private readonly IRepository<Order> _OrderRepository;
        private readonly IRepository<Size> _SizeRepository;
        private readonly IRepository<Containers> _ContainerRepository;
        private readonly IRepository<Availability> _AvailabilityRepository;
        private readonly IRepository<RentalCompany> _RentalCompanyRepository;
        private readonly IRepository<Chassis> _chassisRepository;

        #endregion


        #region Ctor
        public OrderService(IRepository<Order> OrderRepository, IRepository<Size> SizeRepository, IRepository<Containers> ContainerRepository, IRepository<Availability> AvailabilityRepository, IRepository<RentalCompany> RentalCompanyRepository, IRepository<Chassis> ChassisRepository, IRepository<PickupDelivery> PickupRepository, IRepository<BillTo> BillToRepository, IRepository<Client> ClientRepository)
        {
            this._OrderRepository = OrderRepository;
            this._SizeRepository = SizeRepository;
            this._ContainerRepository = ContainerRepository;
            this._AvailabilityRepository = AvailabilityRepository;
            this._RentalCompanyRepository = RentalCompanyRepository;
            this._chassisRepository = ChassisRepository;
            this._PickupRepository = PickupRepository;
            this._BillToRepository = BillToRepository;
            this._ClientRepository = ClientRepository;
        }

        #endregion
        #region Order Method
        //Insert Driver
        public virtual void CreateOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(Order));
            _OrderRepository.Insert(order);
        }

        //Insert Driver
        public long GetMaxOrderNo(long ClientId)
        {
            if (ClientId != 0)
            {
                var Order = _OrderRepository.Table.Where(a => a.ClientId == ClientId).ToList();
                if (Order.Count != 0)
                {
                    var Code = Order.Max(a => Convert.ToInt64(a.OrderNumber));
                    return Code + 1;
                }
                else
                {
                    var ClientOrder = _ClientRepository.Table.Where(a => a.Id == ClientId).FirstOrDefault();
                    if (ClientOrder != null)
                    {
                        return (ClientOrder.StartingOrderNumber != null && ClientOrder.StartingOrderNumber != "" ? Convert.ToInt64(ClientOrder.StartingOrderNumber) + 1 : 1);
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            else
            {
                return 1;
            }

        }

        //Delete Driver
        public virtual void DeleteOrder(Order order)
        {
            if (order == null)
                throw new AccessViolationException(nameof(Order));
            _OrderRepository.Delete(order);
        }

        //Update Driver
        public virtual void UpdateOrder(Order order)
        {
            if (order == null)
                throw new AccessViolationException(nameof(Order));
            _OrderRepository.Update(order);
        }

        public virtual Order GetOrder(long id, long PickupId, long DeliveryId, long ReturnLocationId, long BilltoId)
        {
            var query = _OrderRepository.Table;
            if (id > 0)
            {
                query = query.Where(a => a.Id == id);
            }
            if (PickupId != 0)
            {
                query = query.Where(a => a.PickupID == PickupId);
            }
            if (DeliveryId != 0)
            {
                query = query.Where(a => a.DeliveryID == DeliveryId);
            }
            if (ReturnLocationId != 0)
            {
                query = query.Where(a => a.ReturnLocationID == ReturnLocationId);
            }
            if (BilltoId != 0)
            {
                query = query.Where(a => a.BillToID == BilltoId);
            }
            return query.FirstOrDefault();
        }
        //Get DriverList
        public virtual IList<Order> GetAllOrder(long ClientId, long id, long DeliveryID, long UserLogId, long OrderNumber, string BookingNumber, long SalesRepID, long BillToID, long PickupID)
        {
            var query = _OrderRepository.Table;
            if (id > 0)
            {
                query = query.Where(a => a.Id == id);
            }
            if (DeliveryID > 0)
            {
                query = query.Where(a => a.DeliveryID == DeliveryID);
            }
            if (UserLogId > 0)
            {
                query = query.Where(a => a.UserId == UserLogId);
            }
            if (OrderNumber > 0)
            {
                query = query.Where(a => a.OrderNumber == OrderNumber);
            }
            if (BookingNumber != null)
            {
                query = query.Where(a => a.BookingNumber == BookingNumber);
            }
            if (SalesRepID > 0)
            {
                query = query.Where(a => a.SalesRepID == SalesRepID);
            }
            if (BillToID > 0)
            {
                query = query.Where(a => a.BillToID == BillToID);
            }
            if (PickupID > 0)
            {
                query = query.Where(a => a.PickupID == PickupID);
            }
            query = query.Where(a => a.ClientId == ClientId);
            return query.ToList();
        }
        #endregion

        #region Cointainer Method
        public virtual void CreateContainer(Containers container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(Containers));
            _ContainerRepository.Insert(container);
        }

        //Delete Driver
        public virtual void DeleteContainer(Containers container)
        {
            if (container == null)
                throw new AccessViolationException(nameof(Containers));
            _ContainerRepository.Delete(container);
        }

        //Update Driver
        public virtual void UpdateContainer(Containers container)
        {
            if (container == null)
                throw new AccessViolationException(nameof(Containers));
            _ContainerRepository.Update(container);
        }
        public Containers GetContainers(long Id, long SizeId, long ChassisId)
        {
            var query = _ContainerRepository.Table;
            if (Id != 0)
            {
                query = query.Where(a => a.Id == Id);
            }
            if (SizeId != 0)
            {
                query = query.Where(a => a.SizeId == SizeId);
            }
            if (ChassisId != 0)
            {
                query = query.Where(a => a.ChassisId == ChassisId);
            }
            return query.FirstOrDefault();
        }
        public Containers GetContainerById(long Id)
        {
            var Query = _ContainerRepository.Table.Where(a => a.Id == Id).FirstOrDefault();
            return Query;
        }
        public IList<Containers> GetContainersList(long ClientId, long Id, long orderId)
        {
            var query = _ContainerRepository.Table;
            if (Id != 0)
            {
                query = query.Where(a => a.Id == Id);
            }
            if (orderId != 0)
            {
                query = query.Where(a => a.OrderId == orderId);
            }
            query = query.Where(a => a.ClientId == ClientId);
            return query.ToList();

        }
        #endregion
        #region Size Method
        public virtual void CreateSize(Size size)
        {
            if (size == null)
                throw new ArgumentNullException(nameof(Size));
            _SizeRepository.Insert(size);
        }

        //Delete Driver
        public virtual void DeleteSize(Size size)
        {
            if (size == null)
                throw new AccessViolationException(nameof(Size));
            _SizeRepository.Delete(size);
        }

        //Update Driver
        public virtual void UpdateSize(Size size)
        {
            if (size == null)
                throw new AccessViolationException(nameof(Size));
            _SizeRepository.Update(size);
        }
        public Size GetSize(long Id)
        {
            var query = _SizeRepository.Table;
            if (Id != 0)
            {
                query = query.Where(a => a.Id == Id);
            }
            return query.FirstOrDefault();
        }
        public Size GetSizeById(long Id)
        {
            var query = _SizeRepository.Table.Where(a => a.Id == Id); ;

            return query.FirstOrDefault();
        }

        public IList<Size> GetSizeList(long Id, long ClientId, bool Dropdown = false)
        {
            var query = _SizeRepository.Table;
            if (ClientId != 0)
            {
                long count = query.Where(a => a.ClientId == ClientId || a.ClientId == 0).Count();
                if (count > 0)
                {
                    query = query.Where(a => a.ClientId == ClientId || a.ClientId == 0);
                }
            }
            if (Id != 0)
            {
                query = query.Where(a => a.Id == Id);
            }
            if (Dropdown != false)
            {
                query = query.Where(a => a.DropdownUse == Dropdown);
            }

            return query.ToList();

        }
        #endregion

        #region Availability Method
        public virtual void CreateAvailability(Availability availability)
        {
            if (availability == null)
                throw new ArgumentNullException(nameof(Availability));
            _AvailabilityRepository.Insert(availability);
        }

        //Delete Driver
        public virtual void DeleteAvailability(Availability availability)
        {
            if (availability == null)
                throw new AccessViolationException(nameof(Availability));
            _AvailabilityRepository.Delete(availability);
        }

        //Update Driver
        public virtual void UpdateAvailability(Availability availability)
        {
            if (availability == null)
                throw new AccessViolationException(nameof(Availability));
            _AvailabilityRepository.Update(availability);
        }
        public Availability GetAvailability(long Id, long ContainerId)
        {
            var query = _AvailabilityRepository.Table;
            if (Id != 0)
            {
                query = query.Where(a => a.Id == Id);
            }
            if (ContainerId != 0)
            {
                query = query.Where(a => a.ContainersId == ContainerId);
            }
            return query.FirstOrDefault();
        }
        #endregion

        #region RentalCompany Method
        public virtual void CreateRentalCompany(RentalCompany rentalCompany)
        {
            if (rentalCompany == null)
                throw new ArgumentNullException(nameof(RentalCompany));
            _RentalCompanyRepository.Insert(rentalCompany);
        }

        //Delete Driver
        public virtual void DeleteRentalCompany(RentalCompany rentalCompany)
        {
            if (rentalCompany == null)
                throw new AccessViolationException(nameof(RentalCompany));
            _RentalCompanyRepository.Delete(rentalCompany);
        }

        //Update Driver
        public virtual void UpdateRentalCompany(RentalCompany rentalCompany)
        {
            if (rentalCompany == null)
                throw new AccessViolationException(nameof(RentalCompany));
            _RentalCompanyRepository.Update(rentalCompany);
        }

        public RentalCompany GetRentalCompany(long ClientId, long Id)
        {
            var query = _RentalCompanyRepository.Table;

            query = query.Where(a => a.Id == Id);

            if (ClientId != 0)
            {
                query = query.Where(a => a.ClientId == ClientId);
            }

            return query.FirstOrDefault();
        }
        public IList<RentalCompany> GetRentalCompanyList(long ClientId, long Id)
        {
            var query = _RentalCompanyRepository.Table;
            if (Id != 0)
            {
                query = query.Where(a => a.Id == Id);
            }
            query = query.Where(a => a.ClientId == ClientId);
            return query.ToList();

        }
        #endregion

        #region Chassis Method
        public virtual void CreateChassis(Chassis chassis)
        {
            if (chassis == null)
                throw new ArgumentNullException(nameof(Chassis));
            _chassisRepository.Insert(chassis);
        }

        //Delete Driver
        public virtual void DeleteChassis(Chassis chassis)
        {
            if (chassis == null)
                throw new AccessViolationException(nameof(Chassis));
            _chassisRepository.Delete(chassis);
        }

        //Update Driver
        public virtual void UpdateChassis(Chassis chassis)
        {
            if (chassis == null)
                throw new AccessViolationException(nameof(Chassis));
            _chassisRepository.Update(chassis);
        }

        public Chassis GetChassis(long Id)
        {
            var query = _chassisRepository.Table;
            if (Id != 0)
            {
                query = query.Where(a => a.Id == Id);
            }
            return query.FirstOrDefault();
        }
        public IList<Chassis> GetChassisList(long ClientId, long Id)
        {
            var query = _chassisRepository.Table;
            if (Id != 0)
            {
                query = query.Where(a => a.Id == Id);
            }
            query = query.Where(a => a.ClientId == ClientId);
            return query.ToList();

        }
        #endregion

        #region CheckRoles
        public bool CheckRoleInUse(long ClientId, long UserId)
        {
            if (_PickupRepository.Table.Where(a => a.ClientId == ClientId && a.UserId == UserId).ToList().Count() != 0)
            {
                return true;
            }
            else if (_ClientRepository.Table.Where(a => a.Id == ClientId && a.UserId == UserId).ToList().Count() != 0)
            {
                return true;
            }
            else if (_BillToRepository.Table.Where(a => a.ClientId == ClientId && a.UserLoginId == UserId).ToList().Count() != 0)
            {
                return true;
            }
            else if (_OrderRepository.Table.Where(a => a.ClientId == ClientId && a.UserId == UserId).ToList().Count() != 0)
            {
                return true;
            }
            else if (_SizeRepository.Table.Where(a => a.ClientId == ClientId && a.UserId == UserId).ToList().Count() != 0)
            {
                return true;
            }
            else if (_ContainerRepository.Table.Where(a => a.ClientId == ClientId && a.UserId == UserId).ToList().Count() != 0)
            {
                return true;
            }
            else if (_RentalCompanyRepository.Table.Where(a => a.ClientId == ClientId && a.UserId == UserId).ToList().Count() != 0)
            {
                return true;
            }
            else if (_chassisRepository.Table.Where(a => a.ClientId == ClientId && a.UserId == UserId).ToList().Count() != 0)
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
