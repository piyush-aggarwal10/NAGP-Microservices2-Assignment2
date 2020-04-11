using Common;
using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;
using UserBDC.Interfaces;

namespace UserBDC.Classes
{
    public class UserBDC : IUserBDC
    {
        public UserDTO userDetails;

        const string connectionString = "server=35.223.231.48;user id=root;password=password;port=3306;database=mysqlnagp;";
        public UserBDC()
        {
        
        }

        public UserDTO GetUserDetails(int userId)
        {
            if(userId > 0)
            {
                UserDTO userDTO = GetDetails(userId).GetAwaiter().GetResult();
                if (userDTO != null)
                {
                    return userDTO;
                }
                return null;
            }
            return null;
        }

        async Task<UserDTO> GetDetails(int userId)
        {
            UserDTO userDetailsReceived = null;
            
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string command = "SELECT * FROM User WHERE Id = '" + userId + "'";
                    MySqlCommand cmd = new MySqlCommand(command, connection);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            userDetailsReceived = new UserDTO
                            {
                                Name = reader.GetString(1),
                                Age = reader.GetInt32(2),
                                Email = reader.GetString(3),
                            };
                        }

                    }
                    connection.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return userDetailsReceived;

        }
    }
}
