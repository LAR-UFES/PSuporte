using System;

namespace PSuporte.Domain.Data
{
    public class BaseEntity
    {
        public virtual long Id { get; set; }
        public virtual long CriadoPor { get; set; }
        public virtual DateTime CriadoEm { get; set; }
        public virtual long AtualizadoPor { get; set; }
        public virtual DateTime AtualizadoEm { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is BaseEntity)
            {
                return Id.Equals(((BaseEntity)obj).Id);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(BaseEntity c1, BaseEntity c2)
        {
            if (ReferenceEquals(c1, null))
            {
                return ReferenceEquals(c2, null);
            }
            if (ReferenceEquals(c2, null))
            {
                return false;

            }
            return c1.Id.Equals(c2.Id);
        }

        public static bool operator !=(BaseEntity c1, BaseEntity c2)
        {
            if (ReferenceEquals(c1, null))
            {
                return !ReferenceEquals(c2, null);
            }
            if (ReferenceEquals(c2, null))
            {
                return true;
            }
            return !c1.Id.Equals(c2.Id);
        }
    }
}