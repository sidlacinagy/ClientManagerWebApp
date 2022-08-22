using ClientManager.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClientManager.Shared.Dtos
{
    public class ClientDto
    {
        [Required]
        public string IdNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public ClientTypes ClientType { get; set; }

        public ClientDto ShallowCopy()
        {
            return (ClientDto) this.MemberwiseClone();
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                ClientDto c = (ClientDto)obj;
                return (IdNumber.Equals(c.IdNumber)) && 
                    (FirstName.Equals(c.FirstName)) && 
                    (LastName.Equals(c.LastName)) && 
                    (PhoneNumber.Equals(c.PhoneNumber)) && 
                    (Address.Equals(c.Address)) && 
                    (ClientType.Equals(c.ClientType));
            }
        }
    }
}