using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Managers
{
    internal class BrandManager
    {
        Brand[] data = new Brand[0];
        public void Add(Brand entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }

        public void Remove(Brand entity)
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

        public void Edit(int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    string newBrandName = ScannerManager.ReadString("Yeni marka adını daxil edin: ");
                    data[i].Name = data[i].Name.Replace(data[i].Name, newBrandName);
                    break;
                }
            }
        }

        public void ShowSingleBrand(int valueId)
        {
            Brand bSingle = GetAll().FirstOrDefault(i => i.Id == valueId);

            Console.WriteLine($"------------\n" +
                $"Marka ID: {bSingle.Id} " +
                $"Marka adı: {bSingle.Name}");

           
        }

        public Brand[] GetAll()
        {
            return data;
        } 

        
    }
}
