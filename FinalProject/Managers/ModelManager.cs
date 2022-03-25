using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Managers
{
    internal class ModelManager
    {
        Model[] data = new Model[0];
        public void Add(Model entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }

        public void Remove(Model entity)
        {
            int index = Array.IndexOf(data, entity);

            if (index == -1)
            {
                return;
            }

            for (int i = index; i < data.Length - 1; i++)
            {
                data[i] = data[i + 1];
            }
            Array.Resize(ref data, data.Length - 1);
        }

        public void EditModelName(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    string newModelName = ScannerManager.ReadString("Yeni model adını daxil edin: ");
                    data[i].Name = data[i].Name.Replace(data[i].Name, newModelName);
                    break;
                }
            }
        }

        public void EditBrandId(int value, int newBrandId)
        {
            
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {                                                  
                    data[i].BrandId = newBrandId;
                    break;                                      
                }

            }                      
            
        }

        public void GetSingleModel(int modelValue)
        {
            Model mod = GetAll().FirstOrDefault(id => id.Id == modelValue);
            Console.WriteLine($"Model ID: {mod.Id} | " +
                $"Model adı: {mod.Name}");
        }        

        public Model[] GetAll()
        {
            return data;
        }
    }
}
