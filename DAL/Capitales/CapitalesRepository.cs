using DAL.Common;
using Entities.Models.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Capitales
{
    public class CapitalesRepository : ICapitalesRepository
    {
        public readonly string _connectionString;

        public CapitalesRepository(IOptions<ConnectionStrings> connectionString)
        {
            _connectionString = connectionString.Value.EncriptacionDB;
        }

        public async Task<List<Capital>> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Capitales";

                List<Capital> list = new List<Capital>();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    cmd.CommandType = System.Data.CommandType.Text;
                    
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            Capital capital = new Capital();
                            capital.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            capital.Nombre = reader.GetString(1) ?? string.Empty;
                            capital.Acronimo = reader.GetString(2) ?? string.Empty;
                            capital.CodigoPostal = reader.GetString(3) ?? string.Empty;
                            capital.PaisID = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);

                            list.Add(capital);
                        }

                        conn.Close();

                        return list;
                    }
                }
            }
        }

        public async Task<Capital> GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Capitales WHERE ID = @Id";

                Capital capital = null;

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            capital = new Capital();
                            capital.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            capital.Nombre = reader.GetString(1) ?? string.Empty;
                            capital.Acronimo = reader.GetString(2) ?? string.Empty;
                            capital.CodigoPostal = reader.GetString(3) ?? string.Empty;
                            capital.PaisID = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                        }

                        conn.Close();

                        return capital;
                    }
                }
            }
        }

        public async Task<Capital> GetByPostalCode(string postalCode)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Capitales WHERE CodigoPostal = @CodigoPostal";

                Capital capital = null;

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@CodigoPostal", postalCode);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            capital = new Capital();
                            capital.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            capital.Nombre = reader.GetString(1) ?? string.Empty;
                            capital.Acronimo = reader.GetString(2) ?? string.Empty;
                            capital.CodigoPostal = reader.GetString(3) ?? string.Empty;
                            capital.PaisID = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                        }

                        conn.Close();

                        return capital;
                    }
                }
            }
        }

        public async Task<bool> Insert(Capital capital)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "INSERT INTO Capitales (ID, Nombre, Acronimo, CodigoPostal, PaisID) VALUES (@ID, @Nombre, @Acronimo, @CodigoPostal, @PaisID)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        cmd.Parameters.Add(new SqlParameter("@ID", System.Data.SqlDbType.NVarChar, 100) { Value = capital.ID});
                        cmd.Parameters.Add(new SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar, 100) { Value = capital.Nombre});
                        cmd.Parameters.Add(new SqlParameter("@Acronimo", System.Data.SqlDbType.NVarChar, 10) { Value = capital.Acronimo});
                        cmd.Parameters.Add(new SqlParameter("@CodigoPostal", System.Data.SqlDbType.NVarChar, 10) { Value = capital.CodigoPostal});
                        cmd.Parameters.Add(new SqlParameter("@PaisID", System.Data.SqlDbType.NVarChar, 10) { Value = capital.PaisID});

                        await cmd.ExecuteNonQueryAsync();
                        conn.Close();

                        return true;
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
