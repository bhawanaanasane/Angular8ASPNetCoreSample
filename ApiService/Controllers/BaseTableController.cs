using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiService.Model;
using Fla.Service.BaseTable;
using Fla.Service.Clients;
using Fla.Service.Common;
using Fla.Service.Drivers;
using Fla.Service.Users;
using FLA.Core.Domain.BaseTable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseTableController : ControllerBase
    {
        #region Field

        private readonly iBaseTableService _BaseTableService;//
        private readonly iDriverService _DriverService;//

        private readonly iClientService _ClientService;
        private readonly ICommonService _commonService;
        private readonly iUserService _UserService;
        #endregion

        #region Ctor
        public BaseTableController(iBaseTableService BaseTableService, iDriverService DriverService, iClientService ClientService, ICommonService commonService, iUserService UserService)
        {
            this._BaseTableService = BaseTableService;
            this._DriverService = DriverService;
            this._ClientService = ClientService;
            this._commonService = commonService;
            this._UserService = UserService;
        }
        #endregion
        #region BillTo
        [HttpPost("CreateEditBillTo")]
        public IActionResult CreateEditBillTo(BillTo _Model)
        {
            ResponseModel _response = new ResponseModel();
            try
            {
                if (_Model != null)
                {
                    if (_Model.Id != 0)
                    {
                        _Model.CreateDate = DateTime.UtcNow;
                        _Model.LastUpdateDate = DateTime.UtcNow;
                        _Model.StateProvince = _commonService.GetStateByid(stateId: Convert.ToInt64(_Model.StateProvinceId));
                        _BaseTableService.updateBillTo(_Model);
                    }
                    else
                    {
                        _Model.CreateDate = DateTime.UtcNow;
                        _Model.LastUpdateDate = DateTime.UtcNow;
                        _Model.StateProvince = _commonService.GetStateByid(stateId: Convert.ToInt64(_Model.StateProvinceId));
                        _BaseTableService.InsertBillTo(_Model);
                    }

                    _response.Message = "Success";
                    _response.Status = 1;
                    _response.Response = null;
                }
                else
                {
                    _response.Message = "Failed";
                    _response.Status = 0;
                    _response.Response = _Model;
                }
            }
            catch (Exception ex)
            {
                _response.Message = "Failed:-" + ex.ToString();
                _response.Status = 0;
                _response.Response = _Model;
            }
            return Ok(_response);

        }

        [HttpGet("GetBillToList/{ClientId}")]
        public IActionResult GetBillToList(int ClientId)
        {
            ResponseModel _response = new ResponseModel();
            try
            {

                var Data = _BaseTableService.GetAllBillTo(ClientId: ClientId);
                if (Data != null)
                {
                    for (int i = 0; i < Data.Count; i++)
                    {
                        if (Data[i].StateProvinceId != null)
                        {
                            Data[i].StateProvince = _commonService.GetStateByid(stateId: Convert.ToInt64(Data[i].StateProvinceId));
                        }
                    }

                    _response.Message = "Success";
                    _response.Status = 1;
                    _response.Response = Data;
                }
                else
                {
                    _response.Message = "Fail";
                    _response.Status = 0;
                    _response.Response = null;
                }
            }
            catch (Exception ex)
            {
                _response.Message = "Fail:" + ex.ToString();
                _response.Status = 0;
                _response.Response = null;
            }

            return Ok(_response);
        }

        [HttpGet("DeleteBillTo/{ClientId},{BilltoId}")]
        public IActionResult DeleteBillTo(long ClientId, long BilltoId)
        {
            ResponseModel _response = new ResponseModel();
            try
            {
                var detail = _BaseTableService.GetBillToById(Id: BilltoId, ClientId: ClientId);

                if (detail != null)
                {
                    _BaseTableService.DeleteBillTo(_billto: detail);

                    _response.Message = "Success";
                    _response.Status = 1;
                    _response.Response = null;
                }
                else
                {
                    _response.Message = "Fail";
                    _response.Status = 0;
                    _response.Response = null;
                }
            }
            catch (Exception ex)
            {
                _response.Message = "Fail:" + ex.ToString();
                _response.Status = 0;
                _response.Response = null;
            }

            return Ok(_response);
        }

        [HttpGet("GetBillToEditDetail/{ClientId},{BilltoId}")]
        public IActionResult GetBillToEditDetail(long ClientId, long BilltoId)
        {
            ResponseModel _response = new ResponseModel();
            try
            {
                var data = _BaseTableService.GetBillToById(Id: BilltoId, ClientId: ClientId);
                if (data != null)
                {
                    data.StateProvince = _commonService.GetStateByid(stateId: Convert.ToInt64(data.StateProvinceId));
                    _response.Message = "Success";
                    _response.Status = 1;
                    _response.Response = data;
                }
                else
                {
                    _response.Message = "Fail";
                    _response.Status = 0;
                    _response.Response = null;
                }
            }
            catch (Exception ex)
            {
                _response.Message = "Fail:" + ex.ToString();
                _response.Status = 0;
                _response.Response = null;
            }
            return Ok(_response);
        }
        #endregion

        #region Port
        [HttpPost("CreatePortEdit")]
        public IActionResult CreatePortEdit(Ports portsModel)
        {
            ResponseModel _response = new ResponseModel();
            try
            {
                if (portsModel != null)
                {
                    if (portsModel.Id != 0)
                    {
                        var Model = _BaseTableService.GetPortById(portsModel.Id);
                        Model.PortName = portsModel.PortName;
                        Model.PortZipCode = portsModel.PortZipCode;
                        Model.StateProvinceId = portsModel.StateProvinceId;
                        Model.UserLoginId = portsModel.UserLoginId;
                        Model.WebsiteURL = portsModel.WebsiteURL;
                        Model.Active = portsModel.Active;
                        Model.Address1 = portsModel.Address1;
                        Model.Address2 = portsModel.Address2;
                        Model.City = portsModel.City;
                        Model.ClientId = portsModel.ClientId;
                        Model.ContactNo = portsModel.ContactNo;
                        Model.PortLoginFlag = portsModel.PortLoginFlag;
                        Model.CheckPort = portsModel.CheckPort;
                        Model.LastUpdateDate = DateTime.UtcNow;
                        Model.StateProvince = _commonService.GetStateByid(Convert.ToInt64(portsModel.StateProvinceId));
                        _BaseTableService.UpdatePort(Model);
                        _response.Message = "Success..";
                        _response.Response = null;
                        _response.Status = 1;
                        return Ok(_response);
                    }
                    else
                    {
                        portsModel.CreateDate = DateTime.UtcNow;
                        portsModel.LastUpdateDate = DateTime.UtcNow;
                        portsModel.StateProvince = _commonService.GetStateByid(Convert.ToInt64(portsModel.StateProvinceId));
                        _BaseTableService.InsertPort(portsModel);
                        _response.Message = "Success..";
                        _response.Response = null;
                        _response.Status = 1;
                        return Ok(_response);
                    }

                }
                else
                {
                    _response.Message = "Fill Detail";
                    _response.Response = null;
                    _response.Status = 0;
                    return Ok(_response);
                }
            }
            catch (Exception ex)
            {

                _response.Message = "Failed :" + ex.ToString();
                _response.Response = null;
                _response.Status = 0;
                return Ok(_response);
            }
        }

        [HttpGet("GetAllPort/{ClientId}")]
        public IActionResult GetAllPort(long ClientId)
        {
            ResponseModel _response = new ResponseModel();

            var Details = _BaseTableService.GetAllPortById(ClientId);
            _response.Message = "Success..";
            _response.Response = Details;
            _response.Status = 1;
            return Ok(_response);
        }
        #endregion

        #region Location
        [HttpPost("CreateEditLocation")]
        public IActionResult CreateEditLocation(PickupDelivery PickupModel)
        {
            ResponseModel _response = new ResponseModel();
            try
            {

                if (PickupModel != null)
                {
                    if (PickupModel.Id != 0)
                    {
                        var data = _BaseTableService.GetPickupById(Id: PickupModel.Id, ClientId: PickupModel.ClientId);
                        data.CompanyName = PickupModel.CompanyName;
                        data.Address1 = PickupModel.Address1;
                        data.Address2 = PickupModel.Address2;
                        data.City = PickupModel.City;
                        data.StateProvinceId = PickupModel.StateProvinceId;
                        data.ZipCode = PickupModel.ZipCode;
                        data.PhoneNumber = PickupModel.PhoneNumber;
                        data.FaxNumber = PickupModel.FaxNumber;
                        data.PortsId = PickupModel.PortsId;
                        data.Port = PickupModel.Port;
                        data.Active = PickupModel.Active;
                        _BaseTableService.updatePickup(PickupModel);
                    }
                    else
                    {
                        PickupModel.CreateDate = DateTime.UtcNow;
                        PickupModel.LastUpdateDate = DateTime.UtcNow;

                        _BaseTableService.InsertPickup(PickupModel);
                    }
                    _response.Message = "Success..";
                    _response.Response = null;
                    _response.Status = 1;
                    return Ok(_response);
                }
                else
                {
                    _response.Message = "Fail: Model Is null";
                    _response.Response = null;
                    _response.Status = 0;
                    return Ok(_response);
                }
            }

            catch (Exception ex)
            {
                _response.Message = ex.ToString();
                _response.Response = null;
                _response.Status = 0;
                return Ok(_response);

            }

        }
        [HttpGet("GetAllLocation")]
        public IActionResult GetAllLocation(long ClientId)
        {
            ResponseModel _response = new ResponseModel();
            try
            {
                var Data = _BaseTableService.GetAllPickup(ClientId: ClientId);
                _response.Message = "Success..";
                _response.Response = Data;
                _response.Status = 1;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Message = "Fail:" + ex.ToString();
                _response.Response = null;
                _response.Status = 0;
                return Ok(_response);
            }
        }
        #endregion
    }
}