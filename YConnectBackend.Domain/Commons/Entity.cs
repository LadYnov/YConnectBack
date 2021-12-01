using System;

namespace YConnectBackend.Domain.Commons
{
    public class Entity : IEntity
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