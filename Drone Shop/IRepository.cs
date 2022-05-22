using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone_Shop
{
    public interface IRepository<T>
    {
        public int Size { get; }
        List<T> GetAll();
        void Add(T entity);
        void Remove(int idx);
        void Replace(T entity, int idx);
        void Print();
        void Sort(IComparer<T> comp);
        public T this[int i] { get; set; }
    }
}
