using FLA.Core.Domain.BaseTable;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fla.Service.BaseTable
{
    public interface iBaseTableService
    {
        #region BillTo
        IList<BillTo> GetAllBillTo(long UserLoginId = 0, long TermsId = 0, string PhoneNumber = null, string CompanyName = null, bool? Active = null, long ClientId = 0);
        BillTo GetBillTo(long Id, long ClientId);
        BillTo GetBillToById(long Id, long ClientId = 0);
        void InsertBillTo(BillTo _billto);
        void updateBillTo(BillTo _billto);
        void DeleteBillTo(BillTo _billto);
        #endregion
        #region Port
        void InsertPort(Ports ports);
        void UpdatePort(Ports ports);
        Ports GetPortById(long Id);
        IList<Ports> GetAllPortById(long ClientId);
        #endregion
        #region BillToContacts
        IList<BillToContacts> GetAllBillToContacts(long BillToId = 0, string EmailAddress = null, string PhoneNumber = null);
        BillToContacts GetBillToContacts(long Id = 0);
        void InsertBillToContacts(BillToContacts _billtoContacts);
        void updateBillToContacts(BillToContacts _billtoContacts);
        void DeleteBillToContacts(BillToContacts _billtoContacts);
        #endregion

        #region ConsigneeContacts
        IList<PickupDeliveryContacts> GetAllPickupDeliveryContacts(long ClientId, long PickupDeliveryId = 0, string Email = null, string PhoneNumber = null);
        PickupDeliveryContacts GetPickupDeliveryContacts(long ClientId, long Id = 0);
        void InsertPickupDeliveryContacts(PickupDeliveryContacts _PickupDeliveryContacts);
        void updatePickupDeliveryContacts(PickupDeliveryContacts _PickupDeliveryContacts);
        void DeletePickupDeliveryContacts(PickupDeliveryContacts _PickupDeliveryContacts);
        #endregion
        #region Pickup
        IList<PickupDelivery> GetAllPickup(long ClientId,string FaxNumber = null, string City = null, string PhoneNumber = null, string CompanyName = null, bool? Active = null, bool? Port = null);
        PickupDelivery GetPickup(long Id, long ClientId);
        PickupDelivery GetPickupById(long Id, long ClientId = 0);
        void InsertPickup(PickupDelivery _Pickup);
        void updatePickup(PickupDelivery _Pickup);
        void DeletePickup(PickupDelivery _Pickup);

        #endregion
        #region SalesPerson
        void CreateSalePerson(SalesPerson salesPerson);
        IList<SalesPerson> GetAllSalesPersons(long Id = 0, bool? Active = null, long ClientId = 0);
        SalesPerson GetPersonById(long Id, long ClientId = 0);
        void UpdateSalePerson(SalesPerson salesPerson);
        void DeleteSalePerson(SalesPerson salesPerson);
        #endregion
    }
}
