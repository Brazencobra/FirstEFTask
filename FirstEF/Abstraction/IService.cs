using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstEF.Abstraction
{
    internal interface IService<T>
    {
        void Create(T model);

        void Update(T model);

        void Delete(int Id);
        public List<T> GetAll();

        public T GetById(int Id);
    }
}
