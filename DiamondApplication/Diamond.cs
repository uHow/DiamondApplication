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
        
        /// <summary>
        /// Konstruktor klasy diament
        /// </summary>
        /// <param name="number">Id próbki w bazie danych</param>
        /// <param name="name">Nazwa próbki </param>
        /// <param name="ratio">Stosunek sp3/sp2</param>
        /// <param name="percentDoping">Procent domieszkowania Borem</param>
        Diamond(int number, string name, double ratio, double percentDoping)
        {
            this.number = number;
            this.name = name;
            this.ratio = ratio;
            this.percentDoping = percentDoping;
        }
    }
}
