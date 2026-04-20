namespace Arkitektur.Entity.Entities.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //soft delete için yaptýk veritabanýnda silmek yerine true diyeceðiz ama hep databasede duracak .
        public bool IsDeleted { get; set; }


    }
}
