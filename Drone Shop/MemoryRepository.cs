using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Drone_Shop
{
    public class MemoryRepository<T> : IRepository<T> where T : IVehicle
    {
        protected List<T> entities;
        public int Size { get => entities.Count; }

        public MemoryRepository()
        {
            entities = new List<T>();;
        }

        [OnDeserializing]
        internal void OnDeserializingCallBack(StreamingContext streamingContext)
        {
            entities = new List<T>();
        }

        public List<T> GetAll()
        {
            return entities;
        }

        public virtual void Add(T entity)
        {
            entities.Add(entity);
        }

        public virtual void Remove(int idx)
        {
            if (idx < 0 || idx >= entities.Count)
                throw new Error(ErrorCode.IndexOutsideLimit);

            for (int i = idx; i < (entities.Count - 1); i++)
                entities[i] = entities[i + 1];
            entities.RemoveAt(entities.Count - 1);
        }

        public virtual void Replace(T entity, int idx)
        {
            if (idx < 0 || idx >= entities.Count)
                throw new Error(ErrorCode.IndexOutsideLimit);

            entities[idx] = entity;
        }

        public virtual void Print()
        {
            foreach (var entity in entities)
            {
                Console.WriteLine(entity);
            }
        }

        public virtual void Sort(IComparer<T> predicate)
        {
            entities.Sort(predicate);
        }

        public virtual T this[int i]
        {
            get
            {
                if (i < 0 || i >= entities.Count)
                    throw new Error(ErrorCode.IndexOutsideLimit);
                return entities[i];
            }
            set
            {
                if (i < 0 || i >= entities.Count)
                    throw new Error(ErrorCode.IndexOutsideLimit);
                entities[i] = value;
            }
        }
    }
}
