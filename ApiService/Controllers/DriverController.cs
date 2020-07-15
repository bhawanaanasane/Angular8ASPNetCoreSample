using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiService.Model;
using Fla.Service.Clients;
using Fla.Service.Drivers;
using FLA.Core.Domain.Drivers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        #region Fields
        private readonly iDriverService _driverService;
        private readonly iClientService _clientService;
        #endregion
        #region CTOR
        public DriverController(iDriverService driverService, iClientService clientService)
        {
            this._driverService = driverService;
            this._clientService = clientService;
        }
        #endregion
        #region DriverList
        [HttpGet("GetDriverList/{clientId}")]
        public IActionResult GetDriverList(int clientId)
        {
            var data = _driverService.GetAllDriver(clientId);
            return Ok(data);
        }
        #endregion
        #region Utilities
        //Get Driver Code to create Driver 
        //Bhawana 7/3/2020
        [HttpGet("GetDriverCode")]
        public IActionResult GetDriverCode(int clientId)
        {
            var data = _driverService.GetMaxDriverCode(clientId);
            return Ok(data);
        }

        #endregion
        #region Create/Edit Driver
        //Post Driver Detail
        [HttpPost("Create_EditDriver")]
        public IActionResult Create_EditDriver(Driver model)
        {
            ResponseModel _responseModel = new ResponseModel();
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Id == 0)
                    {
                        _driverService.insertDriver(model);
                        var DriverLogin = new DriverLogin();
                        DriverLogin.DriverId = model.Id;
                        DriverLogin.CreateDate = DateTime.UtcNow;
                        DriverLogin.UpdateDate = DateTime.UtcNow;
                        DriverLogin.ClientId = model.ClientId;
                        var client = _clientService.GetClientById(model.ClientId);
                        DriverLogin.ClientCode = client.ClientCode;
                        _driverService.insertDriverLogin(DriverLogin);
                        //var modelDropdown = new DriverModel();

                        //ModelState.Clear();


                    }
                    else
                    {
                        var driverData = _driverService.GetDriver(model.ClientId, model.Id);

                    }
                    _responseModel.Message = "Success";
                    _responseModel.Status = 1;
                    _responseModel.Response = null;
                    return Ok(_responseModel);

                }
                else
                {
                    _responseModel.Message = "Invalid Fields.";
                    _responseModel.Status = 0;
                    _responseModel.Response = null;
                    return Ok(_responseModel);
                }
            }
            catch (Exception ex)
            {
                //model.AvailableCountries.Add(new SelectListItem { Text = "Select Country", Value = "0" });



                _responseModel.Message = "Error";
                _responseModel.Status = 0;
                _responseModel.Response = ex.ToString();
                return Ok(_responseModel);
            }

        }
        #endregion
    }
}