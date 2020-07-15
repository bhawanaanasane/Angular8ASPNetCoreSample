using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using ApiService.Model;
using Fla.Service.BaseTable;
using Fla.Service.Clients;
using Fla.Service.Common;
using Fla.Service.Drivers;
using Fla.Service.Helper;
using Fla.Service.Orders;
using Fla.Service.Permissions;
using Fla.Service.Users;
using FLA.Core.Domain.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        #region Field
        private readonly IPermissionService _permissionService;
        private readonly IWorkContext _workContext;
        private readonly iUserService _UserService;
        private readonly iClientService _ClientService;
        private readonly iBaseTableService _BaseTableService;
        private readonly IOrderService _IOrderService;
        private readonly ICommonService _commonService;
        #endregion
        #region Ctor
        public OrderController(iDriverService DriverService,   iBaseTableService BaseTableService, IOrderService IOrderService, IPermissionService permissionService, IWorkContext workContext, iUserService UserService, iClientService ClientService, ICommonService commonService)
        {
            
            this._BaseTableService = BaseTableService;
            this._IOrderService = IOrderService;
            this._permissionService = permissionService;
            this._workContext = workContext;
            this._ClientService = ClientService;
            this._UserService = UserService;
            this._commonService = commonService;
        }
        #endregion

        #region Order
        [HttpGet("GetAllSalePersonByClientId/{clientId}")]
        public IActionResult GetAllSalePersonByClientId(long clientId)
        {
            ResponseModel _resp = new ResponseModel();
            var SalesPerson = _BaseTableService.GetAllSalesPersons(ClientId: clientId, Active: true);
            _resp.Message = "Success";
            _resp.Status = 1;
            _resp.Response = SalesPerson;
            return Ok(_resp);
        }
        [HttpGet("GetMaxOrderNoByClientId/{clientId}")]
        public IActionResult GetMaxOrderNoByClientId(long clientId)
        {
            ResponseModel _resp = new ResponseModel();
            var OrderNumber = _IOrderService.GetMaxOrderNo(clientId);
            _resp.Message = "Success";
            _resp.Status = 1;
            _resp.Response = OrderNumber;
            return Ok(_resp);
        }
       
        [HttpPost("CreateOrder")]
        public IActionResult CreateOrder(Order _model)
        {
            ResponseModel _resp = new ResponseModel();
            if (_model != null)
            {


                try
                {

                    _model.UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserLoginId"));
                    _model.CreateDate = DateTime.UtcNow;
                    _model.LastUpdateDate = DateTime.UtcNow;

                    _IOrderService.CreateOrder(_model);

                    //SendEmailToCustomer(_model.BillToID, _model.ClientId, _model.OrderNumber);
                    _resp.Message = "Success";
                    _resp.Status = 1;
                    _resp.Response = null;
                    return Ok(_resp);
                }
                catch (Exception ex)
                {
                    _resp.Message = ex.ToString();
                    _resp.Status = 0;
                    _resp.Response = null;
                    return Ok(_resp);
                }
            }
            else
            {
                _resp.Message = "Model Is Null..";
                _resp.Status = 0;
                _resp.Response = null;
                return Ok(_resp);
            }
        }



        //private void SendEmailToCustomer(long billToID, long ClientId, long OrderNo)
        //{
        //    var Billto = _BaseTableService.GetBillToById(Id: billToID, ClientId: ClientId);
        //    var EmailCredential = _permissionService.GetEmailCredential();
        //    try
        //    {
        //        MailMessage mail = new MailMessage();
        //        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

        //        mail.From = new MailAddress(EmailCredential.Email);
        //        mail.To.Add(Billto.InvoiceEmailAddress);
        //        mail.Subject = "Your Order Is Successfully Palced.";
        //        mail.Body = "Your order NO :-" + OrderNo + " \n Your Address Is :- " + Billto.Address1 + "\n" + Billto.Address2 + " ";

        //        SmtpServer.Port = 587;
        //        SmtpServer.Credentials = new System.Net.NetworkCredential(EmailCredential.Email, EmailCredential.Password);
        //        SmtpServer.EnableSsl = true;

        //        SmtpServer.Send(mail);

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}



        //public IActionResult DeleteOrder(long OrderId,long clientId)
        //{
        //    ResponseModel _model = new ResponseModel();
        //    try
        //    {

        //        var Order = _IOrderService.GetOrder(id: OrderId);

        //        var Container = _IOrderService.GetContainersList(ClientId: clientId, orderId: OrderId);
        //        foreach (var Item in Container)
        //        {
        //            var DispatchList = _DispatchService.GetDispatchListbyContainerId(ContainerId: Item.Id, clientId: clientId);
        //            if (DispatchList != null)
        //            {
        //                foreach (var iten in DispatchList)
        //                {
        //                    var dispatchDriver = _DispatchService.GetDispatchDriverByID(DispatchId: iten.Id);
        //                    _DispatchService.DeleteDispatchDriverDetail(dispatchDriver);
        //                    _DispatchService.DeleteDispatch(iten);
        //                }
        //            }

        //            if (Item.Id != 0)
        //            {
        //                var Availibility = _IOrderService.GetAvailability(ContainerId: Item.Id);
        //                if (Availibility != null)
        //                {
        //                    _IOrderService.DeleteAvailability(Availibility);
        //                }
        //            }
        //            _IOrderService.DeleteContainer(Item);
        //        }
        //        _IOrderService.DeleteOrder(Order);

        //        _model.Success = true;
        //        _model.Message = "Delete Successful";
        //    }
        //    catch (Exception ex)
        //    {
        //        _model.Success = false;
        //        _model.Message = "Deletion Fail";
        //    }
        //    return Json(_model);
        //}

        //public IActionResult UpdateOrder(int OrderId)
        //{
        //    CheckSession();
        //    var order = new OrderFormModel();
        //    order.OrderModel = _IOrderService.GetOrder(id: OrderId).ToModelOrder();
        //    ViewBag.FormName = "Order #" + order.OrderModel.OrderNumber;
        //    var SalesPerson = _BaseTableService.GetAllSalesPersons(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId")), Active: true);
        //    order.AvailableSalesPerson.Add(new SelectListItem { Text = "Select", Value = "0" });
        //    if (SalesPerson != null)
        //    {
        //        foreach (var item in SalesPerson)
        //        {
        //            order.AvailableSalesPerson.Add(new SelectListItem { Text = item.FirstName + " " + item.LastName, Value = item.Id.ToString(), Selected = (item.Id == 0) });
        //        }
        //    }
        //    else
        //    {
        //        order.AvailableSalesPerson.Add(new SelectListItem { Text = "Select", Value = "0" });
        //    }

        //    var BillTo = _BaseTableService.GetAllBillTo(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId")));
        //    if (BillTo.Any())
        //    {
        //        order.AvailableBillToAddress.Add(new SelectListItem { Text = "Select", Value = null });

        //        foreach (var s in BillTo)
        //        {
        //            order.AvailableBillToAddress.Add(new SelectListItem { Text = s.CompanyName, Value = s.Id.ToString(), Selected = (s.Id == order.OrderModel.BillToID) });
        //        }
        //    }
        //    else
        //    {
        //        order.AvailableBillToAddress.Add(new SelectListItem { Text = "Select", Value = null });
        //    }

        //    ViewBag.TypesEnumList = from Types e in Enum.GetValues(typeof(Types))
        //                            select new
        //                            {
        //                                ID = (int)e,
        //                                Name = e.ToString()
        //                            };
        //    var Pickup = _BaseTableService.GetAllPickup(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId")));
        //    if (Pickup.Any())
        //    {
        //        order.AvailablePickupAddress.Add(new SelectListItem { Text = "Select", Value = "0" });

        //        foreach (var s in Pickup)
        //        {
        //            order.AvailablePickupAddress.Add(new SelectListItem { Text = s.CompanyName, Value = s.Id.ToString(), Selected = (s.Id == order.OrderModel.PickupID) });
        //        }
        //    }
        //    else
        //    {
        //        order.AvailablePickupAddress.Add(new SelectListItem { Text = "Select", Value = "0" });
        //    }

        //    if (Pickup.Any())
        //    {
        //        order.AvailablePickupDeliveryAddress.Add(new SelectListItem { Text = "Select", Value = null });

        //        foreach (var s in Pickup)
        //        {
        //            order.AvailablePickupDeliveryAddress.Add(new SelectListItem { Text = s.CompanyName, Value = s.Id.ToString(), Selected = (s.Id == order.OrderModel.DeliveryID) });
        //        }
        //    }
        //    else
        //    {
        //        order.AvailablePickupDeliveryAddress.Add(new SelectListItem { Text = "Select", Value = null });
        //    }

        //    if (Pickup.Any())
        //    {
        //        order.AvailablePickupReturnAddress.Add(new SelectListItem { Text = "Select", Value = null });

        //        foreach (var s in Pickup)
        //        {
        //            order.AvailablePickupReturnAddress.Add(new SelectListItem { Text = s.CompanyName, Value = s.Id.ToString(), Selected = (s.Id == order.OrderModel.ReturnLocationID) });
        //        }
        //    }
        //    else
        //    {
        //        order.AvailablePickupReturnAddress.Add(new SelectListItem { Text = "Select", Value = null });
        //    }


        //    var State = _stateProvinceService.GetStateProvincesByCountryId(countryId: 1);
        //    if (State.Any())
        //    {
        //        order.AvailableState.Add(new SelectListItem { Text = "Select State", Value = "0" });

        //        foreach (var s in State)
        //        {
        //            order.AvailableState.Add(new SelectListItem { Text = s.Abbreviation, Value = s.Id.ToString(), Selected = (s.Id == 0) });
        //        }
        //    }
        //    else
        //    {
        //        order.AvailableState.Add(new SelectListItem { Text = "Select State", Value = "0" });
        //    }
        //    order.ChassisModel = _IOrderService.GetChassisList(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId"))).ToModelChassisMappingList();
        //    var Chassis = _IOrderService.GetChassisList(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId")));
        //    if (Chassis.Any())
        //    {
        //        order.AvailableChassis.Add(new SelectListItem { Text = "Select", Value = "0" });

        //        foreach (var s in Chassis)
        //        {
        //            order.AvailableChassis.Add(new SelectListItem { Text = s.ChassisNumber, Value = s.Id.ToString(), Selected = (s.Id == 0) });
        //        }
        //    }
        //    else
        //    {
        //        order.AvailableChassis.Add(new SelectListItem { Text = "Select", Value = "0" });
        //    }

        //    var Size = _IOrderService.GetSizeList(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId")), Dropdown: true);
        //    if (Size.Any())
        //    {
        //        order.AvailableSize.Add(new SelectListItem { Text = "Select", Value = null });

        //        foreach (var s in Size)
        //        {
        //            order.AvailableSize.Add(new SelectListItem { Text = s.Description, Value = s.Id.ToString(), Selected = (s.Id == 0) });
        //        }
        //    }
        //    else
        //    {
        //        order.AvailableSize.Add(new SelectListItem { Text = "Select", Value = null });
        //    }

        //    order.PickupModel = _BaseTableService.GetPickupById(Id: order.OrderModel.PickupID, ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId"))).ToModelPickup();
        //    if (order.PickupModel != null)
        //    {
        //        order.PickupModel.StateProvince = _stateProvinceService.GetStateProvinceById(order.PickupModel.StateProvinceId);

        //        order.PickupModel.Address1 = ((!string.IsNullOrEmpty(order.PickupModel.Address1)) ? order.PickupModel.Address1 : "") +
        //            ((!string.IsNullOrEmpty(order.PickupModel.Address2)) ? "\n" + order.PickupModel.Address2 : "") +
        //             ((!string.IsNullOrEmpty(order.PickupModel.City)) ? "\n" + order.PickupModel.City : "") +
        //            ((order.PickupModel.StateProvinceId != null && order.PickupModel.StateProvinceId != 0) ? (((order.PickupModel.StateProvinceId != null && order.PickupModel.StateProvinceId != 0) ? "," + _stateProvinceService.GetStateProvinceById(order.PickupModel.StateProvinceId).Abbreviation : "")) : "") +
        //             ((!string.IsNullOrEmpty(order.PickupModel.ZipCode)) ? "   " + order.PickupModel.ZipCode : "") +
        //                 ((!string.IsNullOrEmpty(order.PickupModel.PhoneNumber)) ? "\n" + order.PickupModel.PhoneNumber : "");

        //    }

        //    order.BillToModel = _BaseTableService.GetBillTo(Id: order.OrderModel.BillToID, ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId"))).ToModelBillTo();
        //    if (order.BillToModel != null)
        //    {
        //        order.BillToModel.StateProvince = _stateProvinceService.GetStateProvinceById(order.BillToModel.StateProvinceId);

        //        order.BillToModel.Address1 = ((!string.IsNullOrEmpty(order.BillToModel.Address1)) ? order.BillToModel.Address1 : "") +
        //                ((!string.IsNullOrEmpty(order.BillToModel.Address2)) ? "\n" + order.BillToModel.Address2 : "") +
        //                 ((!string.IsNullOrEmpty(order.BillToModel.City)) ? "\n" + order.BillToModel.City : "") +
        //            ((order.BillToModel.StateProvinceId != null && order.BillToModel.StateProvinceId != 0) ? (((order.BillToModel.StateProvinceId != null && order.BillToModel.StateProvinceId != 0) ? "," + _stateProvinceService.GetStateProvinceById(order.BillToModel.StateProvinceId).Abbreviation : "")) : "") +
        //                 ((!string.IsNullOrEmpty(order.BillToModel.ZipCode)) ? "   " + order.BillToModel.ZipCode : "") +
        //                 ((!string.IsNullOrEmpty(order.BillToModel.PhoneNumber)) ? "\n" + order.BillToModel.PhoneNumber : "");

        //    }

        //    order.PickupDeliveryModel = _BaseTableService.GetPickupById(Id: order.OrderModel.DeliveryID, ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId"))).ToModelPickup();
        //    if (order.PickupDeliveryModel != null)
        //    {
        //        order.PickupDeliveryModel.StateProvince = _stateProvinceService.GetStateProvinceById(order.PickupDeliveryModel.StateProvinceId);

        //        order.PickupDeliveryModel.Address1 = ((!string.IsNullOrEmpty(order.PickupDeliveryModel.Address1)) ? order.PickupDeliveryModel.Address1 : "") +
        //            ((!string.IsNullOrEmpty(order.PickupDeliveryModel.Address2)) ? "\n" + order.PickupDeliveryModel.Address2 : "") +
        //             ((!string.IsNullOrEmpty(order.PickupDeliveryModel.City)) ? "\n" + order.PickupDeliveryModel.City : "") +
        //            ((order.PickupDeliveryModel.StateProvinceId != null && order.PickupDeliveryModel.StateProvinceId != 0) ? (((order.PickupDeliveryModel.StateProvinceId != null && order.PickupDeliveryModel.StateProvinceId != 0) ? "," + _stateProvinceService.GetStateProvinceById(order.PickupDeliveryModel.StateProvinceId).Abbreviation : "")) : "") +
        //             ((!string.IsNullOrEmpty(order.PickupDeliveryModel.ZipCode)) ? "   " + order.PickupDeliveryModel.ZipCode : "") +
        //                 ((!string.IsNullOrEmpty(order.PickupDeliveryModel.PhoneNumber)) ? "\n" + order.PickupDeliveryModel.PhoneNumber : "");
        //    }

        //    order.PickupReturnModel = _BaseTableService.GetPickupById(Id: order.OrderModel.ReturnLocationID, ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId"))).ToModelPickup();
        //    if (order.PickupReturnModel != null)
        //    {
        //        order.PickupReturnModel.StateProvince = _stateProvinceService.GetStateProvinceById(order.PickupReturnModel.StateProvinceId);

        //        order.PickupReturnModel.Address1 = ((!string.IsNullOrEmpty(order.PickupReturnModel.Address1)) ? order.PickupReturnModel.Address1 : "") +
        //            ((!string.IsNullOrEmpty(order.PickupReturnModel.Address2)) ? "\n" + order.PickupReturnModel.Address2 : "") +
        //             ((!string.IsNullOrEmpty(order.PickupReturnModel.City)) ? "\n" + order.PickupReturnModel.City : "") +
        //            ((order.PickupReturnModel.StateProvinceId != null && order.PickupReturnModel.StateProvinceId != 0) ? (((order.PickupReturnModel.StateProvinceId != null && order.PickupReturnModel.StateProvinceId != 0) ? "," + _stateProvinceService.GetStateProvinceById(order.PickupReturnModel.StateProvinceId).Abbreviation : "")) : "") +
        //             ((!string.IsNullOrEmpty(order.PickupReturnModel.ZipCode)) ? "   " + order.PickupReturnModel.ZipCode : "") +
        //                 ((!string.IsNullOrEmpty(order.PickupReturnModel.PhoneNumber)) ? "\n" + order.PickupReturnModel.PhoneNumber : "");

        //    }

        //    ViewBag.ChassisListJson = JsonConvert.SerializeObject(order.ChassisModel);
        //    ViewBag.SizeListJson = JsonConvert.SerializeObject(Size);

        //    order.ContainersListModel = _IOrderService.GetContainersList(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId")), orderId: OrderId).ToModelContainersMappingList();
        //    return View(order);
        //}
        //[HttpPost]
        //public IActionResult UpdateOrder(OrderFormModel _model)
        //{
        //    CheckSession();
        //    ViewBag.FormName = "Order #" + _model.OrderModel.Id;

        //    try
        //    {
        //        //if (ModelState.IsValid)
        //        //{
        //        _model.OrderModel.UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserLoginId"));
        //        _model.OrderModel.CreateDate = DateTime.UtcNow;
        //        _model.OrderModel.LastUpdateDate = DateTime.UtcNow;
        //        var ModelOrder = _model.OrderModel.ToEntityOrder();
        //        ModelOrder.ClientId = Convert.ToInt32(HttpContext.Session.GetInt32("ClientId"));
        //        _IOrderService.UpdateOrder(ModelOrder);

        //        var formData = this.Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
        //        if (formData.Keys.Contains("ContainerId"))
        //        {
        //            String[] ContainerId = formData["ContainerId"].Split(",");
        //            String[] ContainerNumber = formData["ContainerNumber"].Split(",");
        //            String[] SizeId = formData["SizeId"].Split(",");
        //            String[] Weight = formData["Weight"].Split(",");
        //            String[] SealNumber = formData["SealNumber"].Split(",");
        //            String[] Temperature = formData["Temperature"].Split(",");
        //            String[] StatusId = formData["StatusId"].Split(",");
        //            String[] WRDeliveryRequestProductsIds = new string[SizeId.Length];

        //            if (formData.Keys.Contains("ContainerId"))
        //            {
        //                ContainerId = formData["ContainerId"].Split(",");
        //            }



        //            var Order = _IOrderService.GetOrder(id: ModelOrder.Id);
        //            DateTime? date = null;
        //            for (int i = 0; i < ContainerId.Count(); i++)
        //            {
        //                int Size = (SizeId[i] == "" || SizeId[i] == null || SizeId[i] == "Select") ? 0 : Convert.ToInt32(SizeId[i]);
        //                var containerList = new Containers
        //                {
        //                    ClientId = Convert.ToInt32(HttpContext.Session.GetInt32("ClientId")),
        //                    Id = Convert.ToInt32(ContainerId[i]),
        //                    SizeId = Size,
        //                    UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserLoginId")),
        //                    OrderId = ModelOrder.Id,
        //                    orders = Order,
        //                    StatusId = Convert.ToInt32((StatusId[i] != null && StatusId[i] != "" ? StatusId[i] : "0")),
        //                    SealNumber = SealNumber[i].ToString(),
        //                    ContainerNumber = ContainerNumber[i].ToString(),
        //                    Weight = Convert.ToDecimal((Weight[i] != null && Weight[i] != "" ? Weight[i] : "0")),
        //                    Temperature = Convert.ToInt32((Temperature[i] == "" || Temperature[i] == null ? "0" : Temperature[i]))
        //                };
        //                if (containerList.Id == 0)
        //                {

        //                    if (containerList.SizeId == 0)
        //                        containerList.SizeId = null;
        //                    _IOrderService.CreateContainer(containerList);
        //                }
        //                else
        //                {
        //                    if (containerList.SizeId == 0)
        //                        containerList.SizeId = null;
        //                    _IOrderService.UpdateContainer(containerList);
        //                }
        //            }
        //        }
        //        //ModelState.Clear();
        //        AddNotification(NotificationMessage.TitleSuccess, NotificationMessage.msgEditOrder, NotificationMessage.TypeSuccess);
        //        return RedirectToAction("UpdateOrder", new { OrderId = ModelOrder.Id });

        //    }
        //    catch (Exception ex)
        //    {

        //        var BillTo = _BaseTableService.GetAllBillTo(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId")));
        //        if (BillTo.Any())
        //        {
        //            _model.AvailableBillToAddress.Add(new SelectListItem { Text = "Select", Value = null });

        //            foreach (var s in BillTo)
        //            {
        //                _model.AvailableBillToAddress.Add(new SelectListItem { Text = s.CompanyName, Value = s.Id.ToString(), Selected = (s.Id == _model.OrderModel.BillToID) });
        //            }
        //        }
        //        else
        //        {
        //            _model.AvailableBillToAddress.Add(new SelectListItem { Text = "Select", Value = null });
        //        }
        //        var SalesPerson = _BaseTableService.GetAllSalesPersons(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId")), Active: true);
        //        _model.AvailableSalesPerson.Add(new SelectListItem { Text = "Select", Value = "0" });
        //        if (SalesPerson != null)
        //        {
        //            foreach (var item in SalesPerson)
        //            {
        //                _model.AvailableSalesPerson.Add(new SelectListItem { Text = item.FirstName + " " + item.LastName, Value = item.Id.ToString(), Selected = (item.Id == 0) });
        //            }
        //        }
        //        else
        //        {
        //            _model.AvailableSalesPerson.Add(new SelectListItem { Text = "Select", Value = "0" });
        //        }
        //        var Pickup = _BaseTableService.GetAllPickup(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId")));
        //        if (Pickup.Any())
        //        {
        //            _model.AvailablePickupAddress.Add(new SelectListItem { Text = "Select", Value = null });

        //            foreach (var s in Pickup)
        //            {
        //                _model.AvailablePickupAddress.Add(new SelectListItem { Text = s.CompanyName, Value = s.Id.ToString(), Selected = (s.Id == _model.OrderModel.PickupID) });
        //            }
        //        }
        //        else
        //        {
        //            _model.AvailablePickupAddress.Add(new SelectListItem { Text = "Select", Value = null });
        //        }

        //        if (Pickup.Any())
        //        {
        //            _model.AvailablePickupDeliveryAddress.Add(new SelectListItem { Text = "Select", Value = null });

        //            foreach (var s in Pickup)
        //            {
        //                _model.AvailablePickupDeliveryAddress.Add(new SelectListItem { Text = s.CompanyName, Value = s.Id.ToString(), Selected = (s.Id == _model.OrderModel.DeliveryID) });
        //            }
        //        }
        //        else
        //        {
        //            _model.AvailablePickupDeliveryAddress.Add(new SelectListItem { Text = "Select", Value = null });
        //        }

        //        if (Pickup.Any())
        //        {
        //            _model.AvailablePickupReturnAddress.Add(new SelectListItem { Text = "Select", Value = null });

        //            foreach (var s in Pickup)
        //            {
        //                _model.AvailablePickupReturnAddress.Add(new SelectListItem { Text = s.CompanyName, Value = s.Id.ToString(), Selected = (s.Id == _model.OrderModel.ReturnLocationID) });
        //            }
        //        }
        //        else
        //        {
        //            _model.AvailablePickupReturnAddress.Add(new SelectListItem { Text = "Select", Value = null });
        //        }


        //        var State = _stateProvinceService.GetStateProvincesByCountryId(countryId: 1);
        //        if (State.Any())
        //        {
        //            _model.AvailableState.Add(new SelectListItem { Text = "Select State", Value = "0" });

        //            foreach (var s in State)
        //            {
        //                _model.AvailableState.Add(new SelectListItem { Text = s.Abbreviation, Value = s.Id.ToString(), Selected = (s.Id == 0) });
        //            }
        //        }
        //        else
        //        {
        //            _model.AvailableState.Add(new SelectListItem { Text = "Select State", Value = "0" });
        //        }
        //        _model.ChassisModel = _IOrderService.GetChassisList(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId"))).ToModelChassisMappingList();
        //        var Chassis = _IOrderService.GetChassisList(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId")));
        //        if (Chassis.Any())
        //        {
        //            _model.AvailableChassis.Add(new SelectListItem { Text = "Select", Value = "0" });

        //            foreach (var s in Chassis)
        //            {
        //                _model.AvailableChassis.Add(new SelectListItem { Text = s.ChassisNumber, Value = s.Id.ToString(), Selected = (s.Id == 0) });
        //            }
        //        }
        //        else
        //        {
        //            _model.AvailableChassis.Add(new SelectListItem { Text = "Select", Value = "0" });
        //        }

        //        var Size = _IOrderService.GetSizeList(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId")), Dropdown: true);
        //        if (Size.Any())
        //        {
        //            _model.AvailableSize.Add(new SelectListItem { Text = "Select", Value = null });

        //            foreach (var s in Size)
        //            {
        //                _model.AvailableSize.Add(new SelectListItem { Text = s.Description, Value = s.Id.ToString(), Selected = (s.Id == 0) });
        //            }
        //        }
        //        else
        //        {
        //            _model.AvailableSize.Add(new SelectListItem { Text = "Select", Value = null });
        //        }

        //        _model.PickupModel = _BaseTableService.GetPickupById(Id: _model.OrderModel.PickupID, ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId"))).ToModelPickup();
        //        if (_model.PickupModel != null)
        //        {
        //            _model.PickupModel.StateProvince = _stateProvinceService.GetStateProvinceById(_model.PickupModel.StateProvinceId);

        //            _model.PickupModel.Address1 = ((!string.IsNullOrEmpty(_model.PickupModel.Address1)) ? _model.PickupModel.Address1 : "") +
        //                ((!string.IsNullOrEmpty(_model.PickupModel.Address2)) ? "\n" + _model.PickupModel.Address2 : "") +
        //                 ((!string.IsNullOrEmpty(_model.PickupModel.City)) ? "\n" + _model.PickupModel.City : "") +
        //            ((_model.PickupModel.StateProvinceId != null && _model.PickupModel.StateProvinceId != 0) ? (((_model.PickupModel.StateProvinceId != null && _model.PickupModel.StateProvinceId != 0) ? "," + _stateProvinceService.GetStateProvinceById(_model.PickupModel.StateProvinceId).Abbreviation : "")) : "") +
        //                                         ((!string.IsNullOrEmpty(_model.PickupModel.ZipCode)) ? "   " + _model.PickupModel.ZipCode : "") +

        //            ((!string.IsNullOrEmpty(_model.PickupModel.PhoneNumber)) ? "\n" + _model.PickupModel.PhoneNumber : "");

        //        }

        //        _model.BillToModel = _BaseTableService.GetBillTo(Id: _model.OrderModel.BillToID, ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId"))).ToModelBillTo();
        //        if (_model.BillToModel != null)
        //        {
        //            _model.BillToModel.StateProvince = _stateProvinceService.GetStateProvinceById(_model.BillToModel.StateProvinceId);

        //            _model.BillToModel.Address1 = ((!string.IsNullOrEmpty(_model.BillToModel.Address1)) ? _model.BillToModel.Address1 : "") +
        //                ((!string.IsNullOrEmpty(_model.BillToModel.Address2)) ? "\n" + _model.BillToModel.Address2 : "") +
        //                 ((!string.IsNullOrEmpty(_model.BillToModel.City)) ? "\n" + _model.BillToModel.City : "") +
        //            ((_model.BillToModel.StateProvinceId != null && _model.BillToModel.StateProvinceId != 0) ? (((_model.BillToModel.StateProvinceId != null && _model.BillToModel.StateProvinceId != 0) ? "," + _stateProvinceService.GetStateProvinceById(_model.BillToModel.StateProvinceId).Abbreviation : "")) : "") +
        //                 ((!string.IsNullOrEmpty(_model.BillToModel.ZipCode)) ? "   " + _model.BillToModel.ZipCode : "") +
        //                 ((!string.IsNullOrEmpty(_model.BillToModel.PhoneNumber)) ? "\n" + _model.BillToModel.PhoneNumber : "");

        //        }

        //        _model.PickupDeliveryModel = _BaseTableService.GetPickupById(Id: _model.OrderModel.DeliveryID, ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId"))).ToModelPickup();
        //        if (_model.PickupDeliveryModel != null)
        //        {
        //            _model.PickupDeliveryModel.StateProvince = _stateProvinceService.GetStateProvinceById(_model.PickupDeliveryModel.StateProvinceId);

        //            _model.PickupDeliveryModel.Address1 = ((!string.IsNullOrEmpty(_model.PickupDeliveryModel.Address1)) ? _model.PickupDeliveryModel.Address1 : "") +
        //                ((!string.IsNullOrEmpty(_model.PickupDeliveryModel.Address2)) ? "\n" + _model.PickupDeliveryModel.Address2 : "") +
        //                 ((!string.IsNullOrEmpty(_model.PickupDeliveryModel.City)) ? "\n" + _model.PickupDeliveryModel.City : "") +
        //            ((_model.PickupDeliveryModel.StateProvinceId != null && _model.PickupDeliveryModel.StateProvinceId != 0) ? (((_model.PickupDeliveryModel.StateProvinceId != null && _model.PickupDeliveryModel.StateProvinceId != 0) ? "," + _stateProvinceService.GetStateProvinceById(_model.PickupDeliveryModel.StateProvinceId).Abbreviation : "")) : "") +
        //                 ((!string.IsNullOrEmpty(_model.PickupDeliveryModel.ZipCode)) ? "   " + _model.PickupDeliveryModel.ZipCode : "") +
        //                 ((!string.IsNullOrEmpty(_model.PickupDeliveryModel.PhoneNumber)) ? "\n" + _model.PickupDeliveryModel.PhoneNumber : "");

        //        }

        //        _model.PickupReturnModel = _BaseTableService.GetPickupById(Id: _model.OrderModel.ReturnLocationID, ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId"))).ToModelPickup();
        //        if (_model.PickupReturnModel != null)
        //        {
        //            _model.PickupReturnModel.StateProvince = _stateProvinceService.GetStateProvinceById(_model.PickupReturnModel.StateProvinceId);

        //            _model.PickupReturnModel.Address1 = ((!string.IsNullOrEmpty(_model.PickupReturnModel.Address1)) ? _model.PickupReturnModel.Address1 : "") +
        //                ((!string.IsNullOrEmpty(_model.PickupReturnModel.Address2)) ? "\n" + _model.PickupReturnModel.Address2 : "") +
        //                 ((!string.IsNullOrEmpty(_model.PickupReturnModel.City)) ? "\n" + _model.PickupReturnModel.City : "") +
        //            ((_model.PickupReturnModel.StateProvinceId != null && _model.PickupReturnModel.StateProvinceId != 0) ? (((_model.PickupReturnModel.StateProvinceId != null && _model.PickupReturnModel.StateProvinceId != 0) ? "," + _stateProvinceService.GetStateProvinceById(_model.PickupReturnModel.StateProvinceId).Abbreviation : "")) : "") +
        //                 ((!string.IsNullOrEmpty(_model.PickupReturnModel.ZipCode)) ? "   " + _model.PickupReturnModel.ZipCode : "") +
        //                 ((!string.IsNullOrEmpty(_model.PickupReturnModel.PhoneNumber)) ? "\n" + _model.PickupReturnModel.PhoneNumber : "");

        //        }

        //        ViewBag.ChassisListJson = JsonConvert.SerializeObject(_model.ChassisModel);
        //        ViewBag.SizeListJson = JsonConvert.SerializeObject(Size);
        //        AddNotification(NotificationMessage.TitleError, ex.ToString(), NotificationMessage.TypeError);
        //        return View(_model);
        //    }
        //}

        [HttpGet("GetPickupAddress/{PickupId},{ClientId}")]
        public IActionResult GetPickupAddress(long PickupId,long ClientId)
        {
            ResponseModel _resp = new ResponseModel();

            var Pickup = _BaseTableService.GetPickupById(Id: PickupId, ClientId: ClientId);
            if (Pickup != null)
            {
                //Pickup.StateProvince = _stateProvinceService.GetStateProvinceById(Pickup.StateProvinceId);
                Pickup.Address1 = ((!string.IsNullOrEmpty(Pickup.Address1)) ? Pickup.Address1 : "") +
                    ((!string.IsNullOrEmpty(Pickup.Address2)) ? "\n" + Pickup.Address2 : "") +
                     ((!string.IsNullOrEmpty(Pickup.City)) ? "\n" + Pickup.City : "") +
                    ((Pickup.StateProvinceId != null && Pickup.StateProvinceId != 0) ? (((Pickup.StateProvinceId != null && Pickup.StateProvinceId != 0) ? "," + _commonService.GetStateByid(Convert.ToInt64(Pickup.StateProvinceId==null?0: Pickup.StateProvinceId)).Abbreviation : "")) : "") +
                     ((!string.IsNullOrEmpty(Pickup.ZipCode)) ? "   " + Pickup.ZipCode : "") +
                         ((!string.IsNullOrEmpty(Pickup.PhoneNumber)) ? "\n" + Pickup.PhoneNumber : "");
                _resp.Message = "Success";
                _resp.Status = 1;
                _resp.Response = Pickup;
            }
            else
            {
                _resp.Message = "Address Is Not Available..";
                _resp.Status = 0;
                _resp.Response = null;
            }
            return Ok(_resp);
        }
        [HttpGet("GetBillToAddress/{BillToId},{ClientId}")]
        public IActionResult GetBillToAddress(long BillToId,long ClientId)
        {

            ResponseModel _resp = new ResponseModel();
            var BillTo = _BaseTableService.GetBillToById(Id: BillToId, ClientId: ClientId);
            if (BillTo != null)
            {
                //BillTo.StateProvince = _stateProvinceService.GetStateProvinceById(BillTo.StateProvinceId);
                BillTo.Address1 = ((!string.IsNullOrEmpty(BillTo.Address1)) ? BillTo.Address1 : "") +
                    ((!string.IsNullOrEmpty(BillTo.Address2)) ? "\n" + BillTo.Address2 : "") +
                     ((!string.IsNullOrEmpty(BillTo.City)) ? "\n" + BillTo.City : "") +
                     ((BillTo.StateProvinceId != null && BillTo.StateProvinceId != 0) ? (((BillTo.StateProvinceId != null && BillTo.StateProvinceId != 0) ? "," + _commonService.GetStateByid(Convert.ToInt64( BillTo.StateProvinceId==null?0: BillTo.StateProvinceId)).Abbreviation : "")) : "") +

                     ((!string.IsNullOrEmpty(BillTo.ZipCode)) ? "   " + BillTo.ZipCode : "") +
                     ((!string.IsNullOrEmpty(BillTo.PhoneNumber)) ? "\n" + BillTo.PhoneNumber : "");
                _resp.Message = "Success";
                _resp.Status = 1;
                _resp.Response = BillTo;
            }
            else
            {
                _resp.Message = "Address Is Not Available..";
                _resp.Status = 0;
                _resp.Response = null;
            }
            return Ok(_resp);
        }

        //public IActionResult GetAllOrderList(DataSourceRequest command)
        //{
           

        //    var order = new OrderListModel();
        //    //order.OrderModel = _IOrderService.GetAllOrder(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId"))).ToModelOrderMappingList();
        //    var OrerListSp = _reportService.GetAllOrder(page_size: command.PageSize, page_num: command.Page, ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId")), BookingNo: "", OrderStatus: 0, OrderNo: 0, IsExport: false, GetAll: false, OrderId: 0);
        //    if (OrerListSp == null)
        //    {
        //        try { order.OrderList = OrerListSp.List.GetPaged(command.Page, command.PageSize, TotalRecords: 0); } catch { }
        //    }
        //    else
        //    {
        //        order.OrderList = OrerListSp.List.GetPaged(command.Page, command.PageSize, TotalRecords: OrerListSp.TotalRecords);
        //    }
        //    order.ContainersListModel = _IOrderService.GetContainersList(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId"))).ToModelContainersMappingList();
        //    var BillTo = _BaseTableService.GetAllBillTo(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId")));
        //    if (BillTo.Any())
        //    {
        //        order.AvailableBillToAddress.Add(new SelectListItem { Text = "Select", Value = null });

        //        foreach (var s in BillTo)
        //        {
        //            order.AvailableBillToAddress.Add(new SelectListItem { Text = s.CompanyName, Value = s.Id.ToString(), Selected = (s.Id == 0) });
        //        }
        //    }
        //    else
        //    {
        //        order.AvailableBillToAddress.Add(new SelectListItem { Text = "Select", Value = null });
        //    }

        //    var Pickup = _BaseTableService.GetAllPickup(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId")));
        //    if (Pickup.Any())
        //    {
        //        order.AvailablePickupAddress.Add(new SelectListItem { Text = "Select", Value = null });

        //        foreach (var s in Pickup)
        //        {
        //            order.AvailablePickupAddress.Add(new SelectListItem { Text = s.CompanyName, Value = s.Id.ToString(), Selected = (s.Id == 0) });
        //        }
        //    }
        //    else
        //    {
        //        order.AvailablePickupAddress.Add(new SelectListItem { Text = "Select", Value = null });
        //    }

        //    var State = _stateProvinceService.GetStateProvincesByCountryId(countryId: 1);
        //    if (State.Any())
        //    {
        //        order.AvailableState.Add(new SelectListItem { Text = "Select State", Value = "0" });

        //        foreach (var s in State)
        //        {
        //            order.AvailableState.Add(new SelectListItem { Text = s.Abbreviation, Value = s.Id.ToString(), Selected = (s.Id == 0) });
        //        }
        //    }
        //    else
        //    {
        //        order.AvailableState.Add(new SelectListItem { Text = "Select State", Value = "0" });
        //    }
        //    order.ChassisModel = _IOrderService.GetChassisList(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId"))).ToModelChassisMappingList();
        //    var Chassis = _IOrderService.GetChassisList(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId")));
        //    if (Chassis.Any())
        //    {
        //        order.AvailableChassis.Add(new SelectListItem { Text = "Select", Value = "0" });

        //        foreach (var s in Chassis)
        //        {
        //            order.AvailableChassis.Add(new SelectListItem { Text = s.ChassisNumber, Value = s.Id.ToString(), Selected = (s.Id == 0) });
        //        }
        //    }
        //    else
        //    {
        //        order.AvailableChassis.Add(new SelectListItem { Text = "Select", Value = "0" });
        //    }

        //    var Size = _IOrderService.GetSizeList(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId")));
        //    if (Size.Any())
        //    {
        //        order.AvailableSize.Add(new SelectListItem { Text = "Select", Value = null });

        //        foreach (var s in Size)
        //        {
        //            order.AvailableSize.Add(new SelectListItem { Text = s.Description, Value = s.Id.ToString(), Selected = (s.Id == 0) });
        //        }
        //    }
        //    else
        //    {
        //        order.AvailableSize.Add(new SelectListItem { Text = "Select", Value = null });
        //    }
        //    ViewBag.ChassisListJson = JsonConvert.SerializeObject(order.ChassisModel);
        //    ViewBag.SizeListJson = JsonConvert.SerializeObject(Size);

        //    return View(order);
        //}
        //[HttpPost]
        //public IActionResult GetAllOrderList(OrderListModel _modal, DataSourceRequest command)
        //{
        //    CheckSession();
        //    try
        //    {

        //        ViewBag.FormName = "Order List";
        //        var order = new OrderListModel();
        //        var OrerListSp = _reportService.GetAllOrder(page_size: command.PageSize, page_num: command.Page, OrderStatus: _modal.StatusId, ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId")), BookingNo: _modal.BookingNumber, OrderNo: _modal.OrderNumber, IsExport: false, GetAll: false, OrderId: 0);
        //        if (OrerListSp == null)
        //        {
        //            try { OrerListSp.List.GetPaged(command.Page, command.PageSize, TotalRecords: 0); } catch { }
        //        }
        //        else
        //        {
        //            order.OrderList = OrerListSp.List.GetPaged(command.Page, command.PageSize, TotalRecords: OrerListSp.TotalRecords);
        //        }

        //        order.ContainersListModel = _IOrderService.GetContainersList(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId"))).ToModelContainersMappingList();
        //        var BillTo = _BaseTableService.GetAllBillTo(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId")));
        //        if (BillTo.Any())
        //        {
        //            order.AvailableBillToAddress.Add(new SelectListItem { Text = "Select", Value = null });

        //            foreach (var s in BillTo)
        //            {
        //                order.AvailableBillToAddress.Add(new SelectListItem { Text = s.CompanyName, Value = s.Id.ToString(), Selected = (s.Id == 0) });
        //            }
        //        }
        //        else
        //        {
        //            order.AvailableBillToAddress.Add(new SelectListItem { Text = "Select", Value = null });
        //        }

        //        var Pickup = _BaseTableService.GetAllPickup(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId")));
        //        if (Pickup.Any())
        //        {
        //            order.AvailablePickupAddress.Add(new SelectListItem { Text = "Select", Value = null });

        //            foreach (var s in Pickup)
        //            {
        //                order.AvailablePickupAddress.Add(new SelectListItem { Text = s.CompanyName, Value = s.Id.ToString(), Selected = (s.Id == 0) });
        //            }
        //        }
        //        else
        //        {
        //            order.AvailablePickupAddress.Add(new SelectListItem { Text = "Select", Value = null });
        //        }

        //        var State = _stateProvinceService.GetStateProvincesByCountryId(countryId: 1);
        //        if (State.Any())
        //        {
        //            order.AvailableState.Add(new SelectListItem { Text = "Select State", Value = "0" });

        //            foreach (var s in State)
        //            {
        //                order.AvailableState.Add(new SelectListItem { Text = s.Abbreviation, Value = s.Id.ToString(), Selected = (s.Id == 0) });
        //            }
        //        }
        //        else
        //        {
        //            order.AvailableState.Add(new SelectListItem { Text = "Select State", Value = "0" });
        //        }
        //        order.ChassisModel = _IOrderService.GetChassisList(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId"))).ToModelChassisMappingList();
        //        var Chassis = _IOrderService.GetChassisList(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId")));
        //        if (Chassis.Any())
        //        {
        //            order.AvailableChassis.Add(new SelectListItem { Text = "Select", Value = "0" });

        //            foreach (var s in Chassis)
        //            {
        //                order.AvailableChassis.Add(new SelectListItem { Text = s.ChassisNumber, Value = s.Id.ToString(), Selected = (s.Id == 0) });
        //            }
        //        }
        //        else
        //        {
        //            order.AvailableChassis.Add(new SelectListItem { Text = "Select", Value = "0" });
        //        }

        //        var Size = _IOrderService.GetSizeList(ClientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId")));
        //        if (Size.Any())
        //        {
        //            order.AvailableSize.Add(new SelectListItem { Text = "Select", Value = null });

        //            foreach (var s in Size)
        //            {
        //                order.AvailableSize.Add(new SelectListItem { Text = s.Description, Value = s.Id.ToString(), Selected = (s.Id == 0) });
        //            }
        //        }
        //        else
        //        {
        //            order.AvailableSize.Add(new SelectListItem { Text = "Select", Value = null });
        //        }
        //        ViewBag.ChassisListJson = JsonConvert.SerializeObject(order.ChassisModel);
        //        ViewBag.SizeListJson = JsonConvert.SerializeObject(Size);


        //        return View(order);
        //    }
        //    catch
        //    {
        //        return View(_modal);
        //    }

        //}

        //public IActionResult DeleteContainerById(long ContainerId,long ClientId)
        //{
            
        //    ResponseModel _response = new ResponseModel();
        //    try
        //    {
        //        if (ContainerId != 0)
        //        {
        //            var Container = _IOrderService.GetContainerById(Id: ContainerId);
        //            var DespatchCount = _DispatchService.GetDispatchListbyContainerId(ContainerId: ContainerId, clientId: Convert.ToInt32(HttpContext.Session.GetInt32("ClientId"))).ToList();
        //            if (DespatchCount.Count > 0)
        //            {
        //                _response.Message = "Container is in Scheduling Process..";
        //                _response.Success = false;
        //            }
        //            else
        //            {
        //                _IOrderService.DeleteContainer(Container);
        //                _response.Message = "Success";
        //                _response.Success = true;
        //            }

        //        }
        //        else
        //        {
        //            _response.Message = "Fail";
        //            _response.Success = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.Message = ex.ToString();
        //        _response.Success = false;
        //    }
        //    return Json(_response);

        //}

        #endregion
    }
}