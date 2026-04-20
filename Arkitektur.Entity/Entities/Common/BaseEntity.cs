using System.Text.Json.Serialization;

namespace Arkitektur.Entity.Entities.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //soft delete için yaptýk veritabanýnda silmek yerine true diyeceðiz ama hep databasede duracak .
        [JsonIgnore]//bu propertyi json a dahil etme
        public bool IsDeleted { get; set; }


    }
}
