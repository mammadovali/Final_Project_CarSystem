using FinalProject.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Managers
{
    internal class CarManager
    {
        Car[] data = new Car[0];
        public void Add(Car entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }

        public void Remove(Car entity)
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

        public void EditYear(int value)
        {
            Car c = GetAll().FirstOrDefault(id => id.Id == value);
            DateTime newYear = ScannerManager.ReadDate("Yeni istehsal ilini daxil edin: ");
            c.Year = newYear;
        }

        public void EditPrice(int value)
        {
            Car c = GetAll().FirstOrDefault(id => id.Id == value);
            double newPrice = ScannerManager.ReadDouble("Yeni qiyməti daxil edin: ");
            c.Price = newPrice;
        }

        public void EditColor(int value)
        {
            Car c = GetAll().FirstOrDefault(id => id.Id == value);
            string newColor = ScannerManager.ReadString("Yeni rəngi daxil edin: ");
            c.Color = newColor;
        }

        public void EditEngine(int value)
        {
            Car c = GetAll().FirstOrDefault(id => id.Id == value);
            
            double newEngine = ScannerManager.ReadDouble("Yeni mühərriki daxil edin: ");
            c.Engine = newEngine;
        }

        public void EditFuelType(int value)
        {
            Car c = GetAll().FirstOrDefault(id => id.Id == value);
        l1:
            FuelTypeMenu typeOfNewFuel = ScannerManager.ReadFuelTypeMenu("Yeni yanacaq növünü daxil edin: ");

            switch (typeOfNewFuel)
            {
                case FuelTypeMenu.Benzene:
                    c.FuelType = nameof(FuelTypeMenu.Benzene);
                    break;
                case FuelTypeMenu.Diesel:
                    c.FuelType = nameof(FuelTypeMenu.Diesel);
                    break;
                case FuelTypeMenu.Hybrid:
                    c.FuelType = nameof(FuelTypeMenu.Hybrid);
                    break;
                default:
                    ScannerManager.PrintError("Menyudan seçin!");
                    goto l1;
            }
        }

        //public void EditModelId(int value)
        //{
        //    Car c = GetAll().FirstOrDefault(id => id.ModelId == value);
        //    int newModelId = ScannerManager.ReadInteger("Yeni model ID ni daxil edin: ");

        //    c.ModelId = newModelId;
        //}

        public void EditModelId(int value, int newModelId)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Id == value)
                {
                    data[i].ModelId = newModelId;
                    break;
                }

            }
        }

        public void GetSingleCar(int value)
        {
            Car c = GetAll().FirstOrDefault(id => id.Id == value);
            Console.WriteLine($"Car ID: {c.Id}\n" +
                $"Model ID: {c.ModelId}\n" +
                $"İli: {c.Year : yyyy}\n" +
                $"Qiyməti: {c.Price}\n" +
                $"Rəngi: {c.Color}\n" +
                $"Mühərrik: {c.Engine}\n" +
                $"Yanacaq növü: {c.FuelType}");
        }
       
        public Car[] GetAll()
        {
            return data;
        }
    }
}
