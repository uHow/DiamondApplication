using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondApplication
{
    /// <summary>
    /// Klasa umożliwiająca połączenie z bazą danych i określoną tabelą oraz pozwalająca na modyfikację rekordów
    /// w tabeli.
    /// Kolejność działania :
    /// 1. Utwórz obiekt klasy
    /// 2. Wywołaj metodę connect
    /// 3. Dokonaj aktualizacji/wstawienia/usunięcia rekordu za pomocą określonych metod.
    /// 4. Wywołaj metodę disconnect
    /// </summary>
    public class Connector
    {
        private MySql.Data.MySqlClient.MySqlConnection connection;
        private MySqlCommand cmd;
        private MySqlDataReader reader;
        private string table;
        /// <summary>
        /// Konstruktor klasy, inicjalizujący zmienne prywatne - konieczne do uzyskania połączenia z bazą danych
        /// </summary>
        public Connector()
        {
            connection = new MySql.Data.MySqlClient.MySqlConnection();
            cmd = new MySqlCommand();
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
        }
        /// <summary>
        /// Metoda umożliwiająca połączenie z bazą danych oraz z określoną tabelą
        /// </summary>
        /// <param name="address">Adres IP bazy danych (192.168.0.20)</param>
        /// <param name="username">Login użytkownika bazy MySql (username)</param>
        /// <param name="password">Hasło użytkownika (password)</param>
        /// <param name="database">Nazwa bazy MySql (project)</param>
        /// <param name="table">Nazwa tabeli (diamonds)</param>
        public void Connect(string address, string username, string password, string database, string table)
        {
            this.table = table;
            connection.ConnectionString = "server=" + address + ";uid=" + username + ";pwd=" + password + ";database=" + database + ";";
            try
            {
                connection.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// Metoda kończąca połączenie z bazą danych
        /// </summary>
        public void Disconnect()
        {
            try
            {
                connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Metoda umożliwiająca wstawienie nowego wiersza w tabeli 
        /// </summary>
        /// <param name="id">Numer próbki</param>
        /// <param name="name"><Nazwa próbki/param>
        /// <param name="ratio">Stosunek sp3/sp2</param>
        /// <param name="typeDoping">Rodzaj domieszkowania</param>
        /// <param name="percentDoping">Stopień domieszkowania</param>
        public void Insert(int id, string name, double ratio, string typeDoping, double percentDoping)
        {
            try
            {
                cmd.CommandText = "Insert into " + table + " values( " + id + ", '" + name + "', " + ratio +
                    ",' " + typeDoping + "', " + percentDoping + ");";
                reader = cmd.ExecuteReader();
                reader.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Metoda umożliwiająca aktualizację rekordu w bazie danych na podstawie podanego id. W przypadku braki chęci zmian określonej
        /// kolumny należy przepisać aktualną.
        /// </summary>
        /// <param name="id">Numer próbki</param>
        /// <param name="name">Nowa nazwa próbki</param>
        /// <param name="ratio">Nowy stosunek sp3/sp2</param>
        /// <param name="typeDoping">Nowy rodzaj domieszkowania</param>
        /// <param name="percentDoping">Nowy procent domieszkowania</param>
        public void Update(int id, string name, double ratio, string typeDoping, double percentDoping)
        {
            try
            {
                cmd.CommandText = "Update " + table + " set name=' " + name + " ', ratio= " + ratio + ", typeDoping='" +
                    typeDoping + "', percentDoping= " + percentDoping + " where id= " + id + " ;";

                reader = cmd.ExecuteReader();
                reader.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Metoda umożliwiająca usunięcie rekordu na podstawie podanego numeru próbki
        /// </summary>
        /// <param name="record">Numer próbki</param>
        public void Delete(int record)
        {
            try
            {
                cmd.CommandText = "DELETE FROM " + table + " where id = " + record + ";";
                reader = cmd.ExecuteReader();
                reader.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Metoda zwracająca listę wszystkich rekordów w tabeli MySql
        /// </summary>
        /// <returns>Lista próbek diamentu</returns>
        public List<Diamond> returnList()
        {
            List<Diamond> list = new List<Diamond>();
            try
            {
                cmd.CommandText = "select *from " + table + ";";
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Diamond sample = new Diamond((int)reader[0], (string)reader[1], (double)reader[2], (string)reader[3], (double)reader[4]);
                    list.Add(sample);
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }
    }
}
