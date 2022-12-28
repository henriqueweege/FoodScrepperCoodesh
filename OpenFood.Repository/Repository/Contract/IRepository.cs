using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodScrapper.Repository.Repository.Contract
{
    public interface IRepository<T>
    {
        public T GetByCode(string code);
        public List<T> GetAll();
        public T Save(T objToSave);
    }
}
