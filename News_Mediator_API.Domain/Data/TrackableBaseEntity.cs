using EntityFrameworkCore.Triggers;

namespace News_Mediator_API.Data
{
    public abstract class TrackableBaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        static TrackableBaseEntity()
        {
            Triggers<TrackableBaseEntity>.Inserting += entry => entry.Entity.CreatedAt = entry.Entity.UpdatedAt = DateTime.Now;
            Triggers<TrackableBaseEntity>.Updating += entry => entry.Entity.UpdatedAt = DateTime.Now;
        }
    }
}
