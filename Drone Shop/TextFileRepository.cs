using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Drone_Shop
{
    public class TextFileRepository<T> : MemoryRepository<T> where T : IVehicle
    {
        bool sync = true;
        string filePath = "C:/Users/Private/source/repos/Drone Shop/Drones.bin";

        public TextFileRepository()
        {
            ReadFromFile(filePath);
        }

        public TextFileRepository(string filePath)
        {
            if (new FileInfo(filePath).Length == 0)
                entities = new List<T>();
            else
                ReadFromFile(filePath);
            sync = false;
        }

        void SyncWrite()
        {
            if (sync)
                WriteToFile(filePath);
        }

        void SyncRead()
        {
            if (sync)
            {
                entities.Clear();
                ReadFromFile(filePath);
            }
        }

        public void ReadFromFile(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                throw new Error(ErrorCode.FileDoesNotExist);
            }

            BinaryFormatter formatter = new BinaryFormatter();

            using (Stream fStream = File.Open(filePath, FileMode.Open))
            {
                object obj = formatter.Deserialize(fStream);
                entities = (List<T>)obj;
            }
        }

        public void WriteToFile(string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (Stream fStream = new FileStream(filePath,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None))
            {
                formatter.Serialize(fStream, entities);
            }
        }

        public override void Add(T entity)
        {
            base.Add(entity);
            SyncWrite();
        }

        public override void Remove(int idx)
        {
            base.Remove(idx);
            SyncWrite();
        }

        public override void Replace(T entity, int idx)
        {
            base.Replace(entity, idx);
            SyncWrite();
        }

        public override void Print()
        {
            SyncRead();
            base.Print();
        }

        public override void Sort(IComparer<T> predicate)
        {
            base.Sort(predicate);
            SyncWrite();
        }

        public override T this[int i]
        {
            get
            {
                SyncRead();
                return base[i];
            }
            set
            {
                base[i] = value;
                SyncWrite();
            }
        }
    }
}
