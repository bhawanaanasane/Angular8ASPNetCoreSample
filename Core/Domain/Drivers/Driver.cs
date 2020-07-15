using FLA.Core.Domain.Directory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FLA.Core.Domain.Drivers
{
    public partial class Driver : BaseEntity
    {
        private ICollection<TruckInspection> _truckInspections;
        private ICollection<DrugScreen> _drugScreens;
        ////Id
        public  long DriverTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DriverCode { get; set; }
        public string SSN { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public long? StateProvinceId { get; set; }
        public virtual StateProvince StateProvince { get; set; }
        public long CountryId { get; set; }
        public string ZipCode { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public bool SmartPhoneFlag { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateLeft { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyPhoneNumber { get; set; }
        public string Notes { get; set; }
        public bool StatusFlag { get; set; }
        public string DriverLicenseNumber { get; set; }
        public DateTime? DriverLicenseExpiry { get; set; }
        public string MedicalCard { get; set; }
        public DateTime? MedicalCardExpiry { get; set; }
        public string TractorLicense { get; set; }
        public string VINNumber { get; set; }
        public string EINNumber { get; set; }
        public string TruckMake { get; set; }
        public DateTime? TruckInspectionDate { get; set; }
        public DateTime? CHPInspectionDate { get; set; }
        public DateTime? SmokeCheckDate { get; set; }
        public bool CompanyInsuredFlag { get; set; }
        public string DriverLiabilityInsuranceNumber{get;set;}
        public DateTime? DriverLiabilityExpiry { get; set; }
        public DateTime? OccInsuranceStartDate { get; set; }
        public DateTime? OccInsuranceEndDate   { get; set; }
        public DateTime? LiabilityInsuranceStartDate { get; set; }
        public DateTime? LiabilityInsuranceEndDate { get; set; }
        public string TruckOwnerFirstName { get; set; }
        public string TruckOwnerLastName { get; set; }
        public string TruckOwnerPhoneNumber { get; set; }
        public DateTime? DMVDateAdd      { get; set; }
        public DateTime? DMVDateDelete   { get; set; }
        public bool ClassALicenseFlag   { get; set; }
        public bool HazardousLicenseFlag { get; set; }
        public bool TankerLicenseFlag       { get; set; }
        public bool TriplesLicenseFlag    { get; set; }
        public bool DoublesLicenseFlag     {get; set; }
        public DateTime? TwicCardExpiry   { get; set; }
        public DateTime? TruckRegDate     { get; set; }
        public DateTime? ApportionedPlatesExpiry { get; set; }
        public string RFIDNumber        { get; set; }
        public DateTime? LeaseDateExpiry        { get; set; }
        public DateTime? PDTRLB        { get; set; }
        public DateTime? PDTRLA        { get; set; }
        public bool EmodalFlag { get; set; }
        public bool UIIAFlag        { get; set; }
        public bool ARBFlag { get; set; }
        public string FuelCardNumber   { get; set; }
        public bool ActiveDriver { get; set; }
        public DateTime? InsurenceExpiry { get; set; }
        // Id
        public long UserLogID        { get; set; }
        public long Owner_Company_Driver { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public long ClientId { get; set; }
        public OperatorType OperatorType
        {
            get { return (OperatorType)Owner_Company_Driver; }
            set { Owner_Company_Driver = (long)value; }
        }
        public virtual ICollection<TruckInspection> TruckInspections
        {
            get { return _truckInspections ?? (_truckInspections = new List<TruckInspection>()); }
            protected set { _truckInspections = value; }
        }

        public virtual ICollection<DrugScreen> DrugScreens
        {
            get { return _drugScreens ?? (_drugScreens = new List<DrugScreen>()); }
            protected set { _drugScreens = value; }
        }
    }
   
}
