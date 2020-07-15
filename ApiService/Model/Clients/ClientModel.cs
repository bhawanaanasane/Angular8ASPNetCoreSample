using ApiService.Model.Users;
using FLA.Core.Domain.Directory;
using FLA.Core.Domain.Users;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Fla.Service.Model.Clients
{
    public class ClientModel
    {
        public ClientModel()
        {
            AvailableCountries = new List<SelectListItem>();
            AvailableStates = new List<SelectListItem>();
            AvailableRole = new List<SelectListItem>();
        }
        public long Id { get; set; }
        public UserLoginModel Login { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        [Required]
        public long? StateProvinceId { get; set; }
        public long ClientId { get; set; }
        public virtual StateProvince StateProvince { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string StartingDriverCodeNumber { get; set; }
        public string StartingOrderNumber { get; set; }
        public byte[] CompanyImage { get; set; }
        public long UserId { get; set; }
        public string ClientCode { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public IList<SelectListItem> AvailableStates { get; set; }
        public IList<SelectListItem> AvailableCountries { get; set; }
        public IList<SelectListItem> AvailableRole { get; set; }
    }
}
