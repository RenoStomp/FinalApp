using FinalApp.Domain.Models.Enums;

namespace FinalApp.Domain.Models.Common.BaseRequests
{
    public abstract class BaseLocation : BaseEntity
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string? ApartmentNumber { get; set; }
        public string ZipCode { get; set; }
        public Dictionary<AddressComponent, string> Address
        {
            get
            {
                var address = new Dictionary<AddressComponent, string>
                {
                    { AddressComponent.City, City },
                    { AddressComponent.Street, Street },
                    { AddressComponent.HouseNumber, HouseNumber },
                    { AddressComponent.ZipCode, ZipCode }
                };
                if (ApartmentNumber != null)
                {
                    address.Add(AddressComponent.ApartmentNumber, ApartmentNumber);
                }

                return address;
            }
        }
    }
}

