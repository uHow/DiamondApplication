using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using DiamondApplication;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;



namespace DiamondApplication.Tests
{
    [TestClass()]
    public class ConnectorTests
    {
        [TestMethod()]
        public void InsertTest()
        {

            MySql.Data.MySqlClient.MySqlConnection connection2 = new MySql.Data.MySqlClient.MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader;
            int id = 0;
            string name = "nazwa";
            double ratio = 1;
            string type = "typ";
            double percent = 10;
            cmd.Connection = connection2;
            cmd.CommandType = System.Data.CommandType.Text;
            connection2.ConnectionString = "server=192.168.0.20;uid=username;pwd=password;;database=project;";

            connection2.Open();
            cmd.CommandText = "delete from diamonds";
            reader = cmd.ExecuteReader();
            reader.Close();
            connection2.Close();

            Connector conn = new Connector();
            conn.Connect("192.168.0.20", "username", "password", "project", "diamonds");
            conn.Insert(1, "test", 2, "bor", 33);
            conn.Disconnect();

            connection2.Open();
            cmd.CommandText = "select * from diamonds;";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = (int)reader[0];
                name = (string)reader[1];
                ratio = (double)reader[2];
                type = (string)reader[3];
                percent = (double)reader[4];

            }

            Assert.AreEqual(id, 1);
            Assert.AreEqual(name, "test");
            Assert.AreEqual(ratio, 2);
            Assert.AreEqual(type, "bor");
            Assert.AreEqual(percent, 33);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            int numberOfRows = 0;
            int numberOfRows2 = 0;
            MySql.Data.MySqlClient.MySqlConnection connection2 = new MySql.Data.MySqlClient.MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader;
            cmd.Connection = connection2;
            cmd.CommandType = System.Data.CommandType.Text;
            connection2.ConnectionString = "server=192.168.0.20;uid=username;pwd=password;;database=project;";

            connection2.Open();
            cmd.CommandText = "select * from diamonds;";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                numberOfRows++;
            }
            reader.Close();
            connection2.Close();

            Connector conn = new Connector();
            conn.Connect("192.168.0.20", "username", "password", "project", "diamonds");
            conn.Delete(1);
            conn.Disconnect();

            connection2.Open();
            cmd.CommandText = "select * from diamonds;";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                numberOfRows2++;
            }
            reader.Close();
            connection2.Close();

            Assert.AreEqual(numberOfRows - 1, numberOfRows2);
        }

        [TestMethod()]
        public void returnListTest()
        {
            MySql.Data.MySqlClient.MySqlConnection connection2 = new MySql.Data.MySqlClient.MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader;
            List<Diamond> lista = new List<Diamond>();
            cmd.Connection = connection2;
            cmd.CommandType = System.Data.CommandType.Text;
            connection2.ConnectionString = "server=192.168.0.20;uid=username;pwd=password;;database=project;";

            connection2.Open();
            cmd.CommandText = "delete from diamonds";
            reader = cmd.ExecuteReader();
            reader.Close();
            cmd.CommandText = "Insert into diamonds values(1,'nazwa',1.3,'bor',13);";
            reader = cmd.ExecuteReader();
            reader.Close();
            connection2.Close();

            Connector conn = new Connector();
            conn.Connect("192.168.0.20", "username", "password", "project", "diamonds");
            lista = conn.returnList();
            conn.Disconnect();

            Assert.AreEqual(lista[0].Number, 1);
            Assert.AreEqual(lista[0].Name, "nazwa");
            Assert.AreEqual(lista[0].Ratio, 1.3);
            Assert.AreEqual(lista[0].TypeDoping, "bor");
            Assert.AreEqual(lista[0].PercentDoping, 13);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            MySql.Data.MySqlClient.MySqlConnection connection2 = new MySql.Data.MySqlClient.MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader reader;
            int id = 0;
            string name = "nazwa";
            double ratio = 1;
            string type = "typ";
            double percent = 10;
            cmd.Connection = connection2;
            cmd.CommandType = System.Data.CommandType.Text;
            connection2.ConnectionString = "server=192.168.0.20;uid=username;pwd=password;;database=project;";

            connection2.Open();
            cmd.CommandText = "delete from diamonds";
            reader = cmd.ExecuteReader();
            reader.Close();
            cmd.CommandText = "Insert into diamonds values(1,'nazwa',1.3,'bor',13);";
            reader = cmd.ExecuteReader();
            reader.Close();
            connection2.Close();

            Connector conn = new Connector();
            conn.Connect("192.168.0.20", "username", "password", "project", "diamonds");
            conn.Update(1, "nowa", 1, "azot", 14);
            conn.Disconnect();

            connection2.Open();
            cmd.CommandText = "select * from diamonds;";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = (int)reader[0];
                name = (string)reader[1];
                ratio = (double)reader[2];
                type = (string)reader[3];
                percent = (double)reader[4];

            }
            reader.Close();

            Assert.AreEqual(id, 1);
            Assert.AreEqual(name, "nowa");
            Assert.AreEqual(ratio, 1);
            Assert.AreEqual(type, "azot");
            Assert.AreEqual(percent, 14);
        }
    }
}