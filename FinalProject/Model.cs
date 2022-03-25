using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class Model
    {
        static int counter = 0;

        public Model()
        {
            this.Id = ++counter;
        }
        public int Id { get; set; }
        public string Name{ get; set; }
        public int BrandId { get; set; }

        public override string ToString()
        {
            return $"Model ID: {Id} |" +
                $"Adı: {Name} |" +
                $"Marka ID: {BrandId}";
        }
    }
}
