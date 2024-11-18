﻿using MySql.Data.MySqlClient;
using NotreDame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotreDame.DAL
{
    public class ClienteDAL
    {
        public void AgregarCliente(Cliente cliente) 
        { 
            using (var connection = DatabaseHelper.GetConnection()) 
            { 
                connection.Open();
                using (var command = new MySqlCommand("INSERT INTO Cliente (Nombre, Telefono, Genero, Cedula) VALUES (@Nombre, @Telefono, @Genero, @Cedula)", connection)) 
                { 
                    command.Parameters.AddWithValue("@Nombre", cliente.Nombre); 
                    command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    command.Parameters.AddWithValue("@Genero", cliente.Genero);
                    command.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                    command.ExecuteNonQuery(); 
                }
            }
        }

        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM Cliente", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clientes.Add(new Cliente
                            {
                                ClienteID = reader.GetInt32("ClienteID"),
                                Nombre = reader.GetString("Nombre"),
                                Telefono = reader.GetString("Telefono"),
                                Genero = reader.GetString("Genero"),
                                Cedula = reader.GetString("Cedula")
                            });
                        }
                    }
                }
            }
            return clientes;
        }

        public void ActualizarCliente(Cliente cliente) 
        { 
            using (var connection = DatabaseHelper.GetConnection()) 
            { 
                connection.Open(); 
                using (var command = new MySqlCommand("UPDATE Cliente SET Nombre = @Nombre, Telefono = @Telefono, Genero = @Genero, Cedula = @Cedula WHERE ClienteID = @ClienteID", connection)) 
                { 
                    command.Parameters.AddWithValue("@Nombre", cliente.Nombre); 
                    command.Parameters.AddWithValue("@Telefono", cliente.Telefono); 
                    command.Parameters.AddWithValue("@Genero", cliente.Genero); 
                    command.Parameters.AddWithValue("@Cedula", cliente.Cedula); 
                    command.Parameters.AddWithValue("@ClienteID", cliente.ClienteID); 
                    command.ExecuteNonQuery(); 
                } 
            } 
        }

        public void EliminarCliente(int clienteID) 
        { 
            using (var connection = DatabaseHelper.GetConnection()) 
            { 
                connection.Open(); 
                using (var command = new MySqlCommand("DELETE FROM Cliente WHERE ClienteID = @ClienteID", connection)) 
                { 
                    command.Parameters.AddWithValue("@ClienteID", clienteID); 
                    command.ExecuteNonQuery(); 
                } 
            }
        }
    }
}