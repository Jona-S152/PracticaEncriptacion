﻿using DAL.Common;
using Entities.Models.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        public async Task<bool> DeleteById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string spName = SpNames.DeleteCapital;

                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    conn.Open();

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(ParametersQuery.ID, id);

                    cmd.Parameters.Add(new SqlParameter() { ParameterName = ParametersQuery.Result, SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output });

                    await cmd.ExecuteNonQueryAsync();

                    bool result = (bool)cmd.Parameters[ParametersQuery.Result].Value;

                    conn.Close();

                    return result;
                }
            }
        }

        public async Task<List<Capital>> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = SqlQueries.SelectAllCapitals;

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
                string query = SqlQueries.SelectCapitalsById;

                Capital capital = null;

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue(ParametersQuery.ID, id);

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
                string query = SqlQueries.SelectCapitalsByCodigoPostal;

                Capital capital = null;

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue(ParametersQuery.CodigoPostal, postalCode);

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
                    conn.Open();
                    string query = SqlQueries.GetByIdNamePostalCode;

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue(ParametersQuery.ID, capital.ID);
                        cmd.Parameters.AddWithValue(ParametersQuery.Nombre, capital.Nombre);
                        cmd.Parameters.AddWithValue(ParametersQuery.CodigoPostal, capital.CodigoPostal);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                                if (reader.GetInt32(0) > 0) return false;
                            }
                        }
                    }

                    query = SqlQueries.InsertCapitals;
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter(ParametersQuery.ID, System.Data.SqlDbType.NVarChar, 100) { Value = capital.ID});
                        cmd.Parameters.Add(new SqlParameter(ParametersQuery.Nombre, System.Data.SqlDbType.NVarChar, 100) { Value = capital.Nombre});
                        cmd.Parameters.Add(new SqlParameter(ParametersQuery.Acronimo, System.Data.SqlDbType.NVarChar, 10) { Value = capital.Acronimo});
                        cmd.Parameters.Add(new SqlParameter(ParametersQuery.CodigoPostal, System.Data.SqlDbType.NVarChar, 10) { Value = capital.CodigoPostal});
                        cmd.Parameters.Add(new SqlParameter(ParametersQuery.PaisID, System.Data.SqlDbType.NVarChar, 10) { Value = capital.PaisID});

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

        public async Task<bool> Update(Capital capital, int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = SpNames.UpdateCapital;
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue(ParametersQuery.ID, id);
                        cmd.Parameters.AddWithValue(ParametersQuery.Nombre, capital.Nombre);
                        cmd.Parameters.AddWithValue(ParametersQuery.Acronimo, capital.Acronimo);
                        cmd.Parameters.AddWithValue(ParametersQuery.CodigoPostal, capital.CodigoPostal);
                        cmd.Parameters.AddWithValue(ParametersQuery.PaisID, capital.PaisID);

                        cmd.Parameters.Add(new SqlParameter() { ParameterName = ParametersQuery.Result, SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output });

                        await cmd.ExecuteNonQueryAsync();

                        bool result = (bool)cmd.Parameters[ParametersQuery.Result].Value;

                        conn.Close();

                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
