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
   public class Diamond
    {
        int number;
        string name;
        string typeDoping;
        double ratio;
        double percentDoping;
        /// <summary>
        /// Konstruktor klasy diament, umożliwiający nadanie wstępnych wartości próbce
        /// </summary>
        /// <param name="number">Numer id próbki</param>
        /// <param name="name">Nazwa próbki</param>
        /// <param name="ratio">Stosunek sp3/sp2</param>
        /// <param name="typeDoping">Rodzaj domieszkowania</param>
        /// <param name="percentDoping">Procent domieszkowania</param>
        public Diamond(int number, string name, double ratio,string typeDoping, double percentDoping)
        {
            this.number = number;
            this.name = name;
            this.ratio = ratio;
            this.typeDoping = typeDoping;
            this.percentDoping = percentDoping;
        }
    }
}
