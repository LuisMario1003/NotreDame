using MySql.Data.MySqlClient;
using NotreDame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotreDame.DAL
{
    public class CategoriaDAL
    {
        public void AgregarCategoria(Categoria categoria)
        {
            using (var connection = ConexionDB.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("INSERT INTO Categoria (Nombre, Precio) VALUES (@Nombre, @Precio)", connection))
                {
                    command.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                    command.Parameters.AddWithValue("@Precio", categoria.Precio);
                    command.ExecuteNonQuery();
                }
            }

        }
        public List<Categoria> ObtenerCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();
            using (var connection = ConexionDB.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM Categoria", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categorias.Add(new Categoria
                            {
                                CategoriaID = reader.GetInt32("CategoriaID"),
                                Nombre = reader.GetString("Nombre"),
                                Precio = reader.GetDecimal("Precio")
                            });
                        }
                    }
                }
            }
            return categorias;
        }

        public Categoria ObtenerCategoriaPorId(int categoriaID)
        {
            Categoria categoria = null;
            using (var connection = ConexionDB.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("SELECT * FROM Categoria WHERE CategoriaID = @CategoriaID", connection))
                {
                    command.Parameters.AddWithValue("@CategoriaID", categoriaID);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            categoria = new Categoria
                            {
                                CategoriaID = reader.GetInt32("CategoriaID"),
                                Nombre = reader.GetString("Nombre"),
                                Precio = reader.GetDecimal("Precio")
                            };
                        }
                    }
                }
            }
            return categoria;
        }

        public void ActualizarCategoria(Categoria categoria)
        {
            using (var connection = ConexionDB.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("UPDATE Categoria SET Nombre = @Nombre, Precio = @Precio WHERE CategoriaID = @CategoriaID", connection))
                {
                    command.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                    command.Parameters.AddWithValue("@Precio", categoria.Precio);
                    command.Parameters.AddWithValue("@CategoriaID", categoria.CategoriaID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarCategoria(int categoriaID)
        {
            using (var connection = ConexionDB.GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand("DELETE FROM Categoria WHERE CategoriaID = @CategoriaID", connection))
                {
                    command.Parameters.AddWithValue("@CategoriaID", categoriaID);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
