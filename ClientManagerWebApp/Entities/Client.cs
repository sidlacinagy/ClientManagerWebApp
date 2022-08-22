using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using ClientManager.Shared.Enums;

namespace ClientManager.Api.Entities
{
    
    public class Client
    {
        [Key]
        public string IdNumber { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public ClientTypes ClientType { get; set; }

        public static Client CreateCompanyClient(string IdNumber, string PhoneNumber, string Address,string? LastName=null, string? FirstName = null)
        {
            if (String.IsNullOrEmpty(IdNumber) || String.IsNullOrEmpty(PhoneNumber) || String.IsNullOrEmpty(Address))
            {
                throw new Exception("Invalid Data");
            }
            if (!IsValidPhoneNumber(PhoneNumber))
            {
                throw new Exception("Invalid Phone Number");
            }
            return new Client
            {
                IdNumber = IdNumber,
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                Address = Address,
                ClientType = ClientTypes.Company,
            };
        }

        public static Client CreateResidentClient(string IdNumber, string PhoneNumber, string Address, string LastName , string FirstName )
        {
            if (String.IsNullOrEmpty(IdNumber) || String.IsNullOrEmpty(PhoneNumber) || String.IsNullOrEmpty(Address)
                || String.IsNullOrEmpty(LastName) || String.IsNullOrEmpty(FirstName))
            {
                throw new Exception("Invalid Data");
            }
            if (!IsValidPhoneNumber(PhoneNumber))
            {
                throw new Exception("Invalid Phone Number");
            }
            return new Client
            {
                IdNumber = IdNumber,
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                Address = Address,
                ClientType = ClientTypes.Residential,
            };
        }

        public static bool IsValidPhoneNumber(string PhoneNumber)
        {
            Regex validatePhoneNumberRegex = new Regex("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$");
            return validatePhoneNumberRegex.IsMatch(PhoneNumber);
        }
    }
}
