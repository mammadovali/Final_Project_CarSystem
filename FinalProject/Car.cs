using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class Car
    {
        static int counter = 0;
        public Car()
        {
            this.Id = ++counter;
        }
        public int Id { get; set; }
        public int ModelId { get; set; }
        public DateTime Year { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public double Engine { get; set; }
        public string FuelType { get; set; }

        public override string ToString()
        {
            return $"Car ID: {Id}\n" +
                $"Model ID: {ModelId}\n" +
                $"Buraxılış ili: {Year: yyyy}\n" +
                $"Qiyməti: {Price}\n" +
                $"Rəngi: {Color}\n" +
                $"Mühərrik: {Engine}\n" +
                $"Yanacaq növü: {FuelType}";
        }
    }
}
