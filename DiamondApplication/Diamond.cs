using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondApplication
{
    /// <summary>
    /// Klasa diament, umożliwiająca utworzenie próbek diamentu o określonej nazwie, id, domieszkowaniu oraz stosunku sp3/sp2
    /// </summary>
    class Diamond
    {
        int number;
        string name;
        string typeDoping;
        double ratio;
        double percentDoping;
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
        /// Konstruktor klasy diament
        /// </summary>
        /// <param name="number">Id próbki w bazie danych</param>
        /// <param name="name">Nazwa próbki </param>
        /// <param name="ratio">Stosunek sp3/sp2</param>
        /// <param name="percentDoping">Procent domieszkowania Borem</param>
        Diamond(int number, string name, double ratio, double percentDoping){
            this.number = number;
            this.name = name;
            this.ratio = ratio;
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
