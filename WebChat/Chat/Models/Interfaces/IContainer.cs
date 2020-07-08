using System;

namespace WebChat.Chat.Models.Interfaces
{
    public interface IContainer<in T> : ICloneable
    {
        void Add(T entity);
        object CloneFrom(int id);
    }
}