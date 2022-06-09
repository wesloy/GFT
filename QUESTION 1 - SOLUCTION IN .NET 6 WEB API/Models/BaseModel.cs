using System.Text.Json.Serialization;

namespace Test.Models
{
    public abstract class BaseModel
    {

        public BaseModel()
        {
            Id = Guid.NewGuid();
            ClientSector = "";
        }

        public virtual Guid Id { get; set; }
        public string ClientSector { get; set; }


    }

}