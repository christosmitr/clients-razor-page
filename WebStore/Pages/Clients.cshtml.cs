using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebStore.Pages
{
    public class ClientsModel : PageModel
    {
        public List<ClientInfo> listClients = new List<ClientInfo>();
        public void OnGet()
        {
            //Connection to the database
            try
            {
                
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=webstore;Integrated Security=True";
                using SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "SELECT * FROM clients";
                using SqlCommand command = new SqlCommand(query, connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ClientInfo client = new ClientInfo();

                    client.id = "" + reader.GetInt32(0);
                    client.name = reader.GetString(1);
                    client.email = reader.GetString(2);
                    client.phone = reader.GetString(3);
                    client.address = reader.GetString(4);

                    listClients.Add(client);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }
    
    public class ClientInfo
    {
        public string id;
        public string name;
        public string email;
        public string phone;
        public string address;
    }
}
