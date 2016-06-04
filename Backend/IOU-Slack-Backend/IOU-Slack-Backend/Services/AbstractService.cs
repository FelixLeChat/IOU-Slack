using System.Collections.Generic;

namespace IOU_Slack_Backend.Services
{
    public abstract class AbstractService<T>
    {
        public abstract List<T> GetAll();
        public abstract T Get(string id);
        public abstract void Delete(T element);
        public abstract void Create(T element);
        public abstract void Update(T element);
    }
}