using System;

namespace YConnectBackend.Domain.Commons
{
    public class Entity 
    {
        public uint Id { get; set; }
        

        public Entity()
        {
        }

         
    }

    public interface IEntity
    {
        public uint Id { get; set; }
    }
}