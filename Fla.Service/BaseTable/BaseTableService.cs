using FLA.Core.Domain.BaseTable;
using FLA.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fla.Service.BaseTable
{

    public class BaseTableService: iBaseTableService
    {
        #region Fields
        private readonly IRepository<PickupDelivery> _PickupRepository;
        private readonly IRepository<BillTo> _BillToRepository;
        private readonly IRepository<BillToContacts> _BillToContactsRepository;

        private readonly IRepository<PickupDeliveryContacts> _PickupDeliveryContactsRepository;
        private readonly IRepository<SalesPerson> _SalesPersonRepository;
        private readonly IRepository<Ports> _PortsRepository;
        private readonly IRepository<PortLogin> _PortLoginRepository;
        #endregion
        #region Ctor
        public BaseTableService(IRepository<BillTo> BillToRepository, IRepository<BillToContacts> BillToContactsRepository, IRepository<PickupDeliveryContacts> PickupDeliveryContactsRepository, IRepository<PickupDelivery> PickupRepository, IRepository<Ports> PortsRepository, IRepository<PortLogin> PortLoginRepository, IRepository<SalesPerson> SalesPersonRepository)
        {
            this._BillToRepository = BillToRepository;
            this._BillToContactsRepository = BillToContactsRepository;
            this._PickupDeliveryContactsRepository = PickupDeliveryContactsRepository;
            this._PickupRepository = PickupRepository;
            this._PortsRepository = PortsRepository;
            this._PortLoginRepository = PortLoginRepository;
            this._SalesPersonRepository = SalesPersonRepository;
        }
        #endregion

        #region BillTo method
        public IList<BillTo> GetAllBillTo(long UserLogId, long TermsId, string PhoneNumber, string CompanyName, bool? Active, long ClientId)
        {
            var quary = _BillToRepository.Table;
            if (UserLogId != 0)
            {
                quary = quary.Where(a => a.UserLoginId == UserLogId);
            }
            if (TermsId != 0)
            {
                quary = quary.Where(a => a.TermsId == TermsId);
            }
            if (CompanyName != null)
            {
                quary = quary.Where(a => a.CompanyName.Contains(CompanyName));
            }
            if (Active != null)
            {
                quary = quary.Where(a => a.Active == Active);
            }
            if (PhoneNumber != null)
            {
                quary = quary.Where(a => a.PhoneNumber == PhoneNumber);
            }
            if (ClientId != 0)
            {
                quary = quary.Where(a => a.ClientId == ClientId);
            }
            return quary.ToList();
        }
        public BillTo GetBillTo(long Id, long ClientId)
        {
            var quary = _BillToRepository.Table;


            quary = quary.Where(a => a.Id == Id && a.ClientId == ClientId);



            return quary.FirstOrDefault();
        }
        public BillTo GetBillToById(long Id, long ClientId)
        {
            var quary = _BillToRepository.Table.Where(a => a.Id == Id);
            if (ClientId != 0)
            {
                quary = quary.Where(a => a.ClientId == ClientId);
            }

            return quary.FirstOrDefault();
        }

        public void InsertBillTo(BillTo _billto)
        {
            if (_billto == null)
                throw new ArgumentNullException(nameof(_billto));
            _BillToRepository.Insert(_billto);
        }
        public void updateBillTo(BillTo _billto)
        {
            if (_billto == null)
                throw new ArgumentNullException(nameof(_billto));
            _BillToRepository.Update(_billto);
        }
        public void DeleteBillTo(BillTo _billto)
        {
            if (_billto == null)
                throw new ArgumentNullException(nameof(_billto));
            _BillToRepository.Delete(_billto);
        }
        #endregion
        #region Port
        public void InsertPort(Ports ports)
        {
            if (ports == null)
                throw new ArgumentNullException(nameof(ports));
            _PortsRepository.Insert(ports);
        }
        public void UpdatePort(Ports ports)
        {
            if (ports == null)
                throw new ArgumentNullException(nameof(ports));
            _PortsRepository.Update(ports);
        }
        public Ports GetPortById(long Id)
        {
            if (Id == 0)
            {
                throw new ArgumentNullException(nameof(Id));
            }
          var Query=  _PortsRepository.Table.Where(a=>a.Id==Id).FirstOrDefault();
            return Query;
        }
        public IList<Ports> GetAllPortById(long ClientId)
        {
            return _PortsRepository.Table.Where(a => a.ClientId == 0 && a.ClientId == ClientId).ToList();
        }
        #endregion

        #region BillToContacts method
        public IList<BillToContacts> GetAllBillToContacts(long BillToId, string EmailAddress, string PhoneNumber)
        {
            var quary = _BillToContactsRepository.Table;
            if (BillToId != 0)
            {
                quary = quary.Where(a => a.BillToId == BillToId);
            }
            if (EmailAddress != null)
            {
                quary = quary.Where(a => a.EmailAddress == EmailAddress);
            }
            if (PhoneNumber != null)
            {
                quary = quary.Where(a => a.PhoneNumber == PhoneNumber);
            }
            return quary.ToList();
        }
        public BillToContacts GetBillToContacts(long Id)
        {
            var quary = _BillToContactsRepository.Table;
            if (Id != 0)
            {
                quary = quary.Where(a => a.Id == Id);
            }

            return quary.FirstOrDefault();
        }
        public void InsertBillToContacts(BillToContacts _billtoContacts)
        {
            if (_billtoContacts == null)
                throw new ArgumentNullException(nameof(_billtoContacts));
            _BillToContactsRepository.Insert(_billtoContacts);
        }
        public void updateBillToContacts(BillToContacts _billtoContacts)
        {
            if (_billtoContacts == null)
                throw new ArgumentNullException(nameof(_billtoContacts));
            _BillToContactsRepository.Update(_billtoContacts);
        }
        public void DeleteBillToContacts(BillToContacts _billtoContacts)
        {
            if (_billtoContacts == null)
                throw new ArgumentNullException(nameof(_billtoContacts));
            _BillToContactsRepository.Delete(_billtoContacts);
        }
        #endregion



        #region PickupDelContacts method
        public IList<PickupDeliveryContacts> GetAllPickupDeliveryContacts(long ClientId, long PickupDeliveryId, string Email, string PhoneNumber)
        {
            var quary = _PickupDeliveryContactsRepository.Table.Where(a => a.ClientId == ClientId);
            if (PickupDeliveryId != 0)
            {
                quary = quary.Where(a => a.PickupDeliveryId == PickupDeliveryId);
            }

            if (PhoneNumber != null)
            {
                quary = quary.Where(a => a.PhoneNumber == PhoneNumber);
            }
            if (Email != null)
            {
                quary = quary.Where(a => a.EmailAddress == Email);
            }
            return quary.ToList();
        }
        public PickupDeliveryContacts GetPickupDeliveryContacts(long ClientId, long Id)
        {
            var quary = _PickupDeliveryContactsRepository.Table.Where(a => a.ClientId == ClientId);
            if (Id != 0)
            {
                quary = quary.Where(a => a.Id == Id);
            }
            return quary.FirstOrDefault();
        }
        public void InsertPickupDeliveryContacts(PickupDeliveryContacts _PckupContacts)
        {
            if (_PckupContacts == null)
                throw new ArgumentNullException(nameof(_PckupContacts));
            _PickupDeliveryContactsRepository.Insert(_PckupContacts);
        }
        public void updatePickupDeliveryContacts(PickupDeliveryContacts _PckupContacts)
        {
            if (_PckupContacts == null)
                throw new ArgumentNullException(nameof(_PckupContacts));
            _PickupDeliveryContactsRepository.Update(_PckupContacts);
        }
        public void DeletePickupDeliveryContacts(PickupDeliveryContacts _PckupContacts)
        {
            if (_PckupContacts == null)
                throw new ArgumentNullException(nameof(_PckupContacts));
            _PickupDeliveryContactsRepository.Delete(_PckupContacts);
        }
        #endregion

        #region Pickup
        public IList<PickupDelivery> GetAllPickup(long ClientId,string FaxNumber, string City, string PhoneNumber, string CompanyName, bool? Active, bool? Port = null)
        {
            var quary = _PickupRepository.Table.Where(a => a.ClientId == ClientId);
            if (FaxNumber != null)
            {
                quary = quary.Where(a => a.FaxNumber == FaxNumber);
            }
            if (CompanyName != null)
            {
                quary = quary.Where(a => a.CompanyName.Contains(CompanyName));
            }

            if (PhoneNumber != null)
            {
                quary = quary.Where(a => a.PhoneNumber == PhoneNumber);
            }
            if (City != null)
            {
                quary = quary.Where(a => a.City == City);
            }
            if (Active != null)
            {
                quary = quary.Where(a => a.Active == Active);
            }
            if (Port != null)
            {
                quary = quary.Where(a => a.Port == Port);
            }


            return quary.ToList();
        }
        public PickupDelivery GetPickup(long Id, long ClientId)
        {
            var quary = _PickupRepository.Table;

            quary = quary.Where(a => a.Id == Id && a.ClientId == ClientId);

            return quary.FirstOrDefault();
        }
        public PickupDelivery GetPickupById(long Id, long ClientId)
        {
            var quary = _PickupRepository.Table.Where(a => a.Id == Id);
            if (ClientId != 0)
            {
                quary = quary.Where(a => a.ClientId == ClientId);
            }
            return quary.FirstOrDefault();
        }

        public void InsertPickup(PickupDelivery _Pickup)
        {
            if (_Pickup == null)
                throw new ArgumentNullException(nameof(_Pickup));
            _PickupRepository.Insert(_Pickup);
        }
        public void updatePickup(PickupDelivery _Pickup)
        {
            if (_Pickup == null)
                throw new ArgumentNullException(nameof(_Pickup));
            _PickupRepository.Update(_Pickup);
        }
        public void DeletePickup(PickupDelivery _Pickup)
        {
            if (_Pickup == null)
                throw new ArgumentNullException(nameof(_Pickup));
            _PickupRepository.Delete(_Pickup);
        }
        #endregion
        #region SalesPerson
        public void CreateSalePerson(SalesPerson salesPerson)
        {
            if (salesPerson == null)
                throw new ArgumentNullException(nameof(salesPerson));
            _SalesPersonRepository.Insert(salesPerson);
        }
        public void UpdateSalePerson(SalesPerson salesPerson)
        {
            if (salesPerson == null)
                throw new ArgumentNullException(nameof(salesPerson));
            _SalesPersonRepository.Update(salesPerson);
        }
        public void DeleteSalePerson(SalesPerson salesPerson)
        {
            if (salesPerson == null)
                throw new ArgumentNullException(nameof(salesPerson));
            _SalesPersonRepository.Delete(salesPerson);
        }

        public IList<SalesPerson> GetAllSalesPersons(long Id, bool? Active, long ClientId)
        {
            var quary = _SalesPersonRepository.Table;
            if (Id != 0)
            {
                quary = quary.Where(a => a.Id == Id);
            }
            if (ClientId != 0)
            {
                quary = quary.Where(a => a.ClientId == ClientId);
            }
            if (Active != null)
            {
                quary = quary.Where(a => a.Active == Active);
            }
            return quary.ToList();
        }
        public SalesPerson GetPersonById(long Id, long ClientId = 0)
        {
            var quary = _SalesPersonRepository.Table.Where(a => a.Id == Id);
            if (ClientId != 0)
            {
                quary = quary.Where(a => a.ClientId == ClientId);
            }
            return quary.FirstOrDefault();
        }

        #endregion
    }
}
