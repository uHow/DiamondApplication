using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondApplication {
    /// <summary>
    /// Klasa diament, umożliwiająca utworzenie próbek diamentu o określonej nazwie, id, domieszkowaniu oraz stosunku sp3/sp2
    /// </summary>
   public class Diamond{
        private int number;
        private string name;
        private string typeDoping;
        private double ratio;
        private double percentDoping;
        public int Number{
            get{
                return this.number;
            }
            set{
                this.number = value;
            }
        }
        public string Name{
            get{
                return this.name;
            }
            set { 
                this.name = value;
            }
        }
        public string TypeDoping{
            get{
                return this.typeDoping;
            }
            set{
                this.typeDoping = value;
            }
        }
        public double Ratio{
            get{
                return this.ratio;
            }
            set{
                this.ratio = value;
            }
        }
        public double PercentDoping{
            get{
                return this.percentDoping;
            }
            set{
                this.percentDoping = value;
            }
        }
        /// <summary>
        /// Konstruktor klasy diament, umożliwiający nadanie wstępnych wartości próbce
        /// </summary>
        /// <param name="number">Numer id próbki</param>
        /// <param name="name">Nazwa próbki</param>
        /// <param name="ratio">Stosunek sp3/sp2</param>
        /// <param name="typeDoping">Rodzaj domieszkowania</param>
        /// <param name="percentDoping">Procent domieszkowania</param>
        public Diamond(int number, string name, double ratio,string typeDoping, double percentDoping){
            this.number = number;
            this.name = name;
            this.ratio = ratio;
            this.typeDoping = typeDoping;
            this.percentDoping = percentDoping;
        }
        public Diamond(string number, string name, string ratio, string typeDoping, string percentDoping){
            this.number = int.Parse(number);
            this.name = name;
            this.ratio = double.Parse(ratio);
            this.typeDoping = typeDoping;
            this.percentDoping = double.Parse(percentDoping);
        }
    }
}
