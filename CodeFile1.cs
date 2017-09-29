using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Teste_Online;
using MySql.Data.MySqlClient;


namespace Teste_Online2
{
    public class Analise
    {
        String _estoqueMySql = "";
        MySqlConnection estoque = null;

        public Analise()
        {
            _estoqueMySql = "server=localhost;user id=root;password=Deepak;database=cadastro";
        }
        public DataTable selecionaMercadoriaU()
        {
            try
            {
                String est = "SELECT * FROM Estoque";
                estoque = new MySqlConnection(_estoqueMySql);
                MySqlCommand gra = new MySqlCommand(est, estoque);
                MySqlDataAdapter gd = new MySqlDataAdapter();
                gd.SelectCommand = gra;
                DataTable gg = new DataTable();
                gd.Fill(gg);
                return gg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MercadoriaU selecionaMercadoria(int codigo)
        {
            try
            {
                String est = "SELECT * FROM Estoque WHERE codigo = @codigo";
                estoque = new MySqlConnection(_estoqueMySql);
                MySqlCommand gra = new MySqlCommand(est, estoque);
                gra.Parameters.AddWithValue("@codigo", codigo);
                estoque.Open();
                MySqlDataReader dg;

                MercadoriaU mercadoria = new MercadoriaU();
                dg = gra.ExecuteReader(CommandBehavior.CloseConnection);

                while (dg.Read())
                {
                    mercadoria.Codigo = Convert.ToInt32(dg["Codigo"]);
                    mercadoria.Tipo = dg["Tipo"].ToString();
                    mercadoria.Nome = dg["Nome"].ToString();
                    mercadoria.Preco = Convert.ToDecimal(dg["Preco"]);
                    mercadoria.Quantidade = Convert.ToInt32(dg["Quantidade"]);
                }
                return mercadoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<MercadoriaU> selecionaListaMercadoria()
        {
            try
            {
                using (MySqlConnection estoque1 = new MySqlConnection(_estoqueMySql))
                {
                    using (MySqlCommand command = new MySqlCommand("Select * from Estoque", estoque1))
                    {
                        estoque1.Open();
                        List<MercadoriaU> listaMercadoriaU = new List<MercadoriaU>();
                        using (MySqlDataReader dg = command.ExecuteReader())
                        {
                            while (dg.Read())
                            {
                                MercadoriaU mercadoria = new MercadoriaU();
                                mercadoria.Codigo = (int)dg["Codigo"];
                                mercadoria.Nome = (String)dg["Nome"];
                                mercadoria.Tipo = (String)dg["Tipo"];
                                mercadoria.Preco = Convert.ToDecimal(dg["Preco"]);
                                mercadoria.Quantidade = (int)dg["Quantidade"];
                                listaMercadoriaU.Add(mercadoria);
                            }
                        }
                        return listaMercadoriaU;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar estoque " + ex.Message);
            }
        }

        public void inserirMercadoria(MercadoriaU mercadoria)
        {
            try
            {
                String est = "INSERT INTO Estoque (nome,preco) VALUES (@nome,@preco)";
                estoque = new MySqlConnection(_estoqueMySql);
                MySqlCommand gra = new MySqlCommand(est, estoque);
                gra.Parameters.AddWithValue("@nome", mercadoria.Nome);
                gra.Parameters.AddWithValue("@preco", mercadoria.Preco);
                estoque.Open();
                gra.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                estoque.Close();
            }
        }


        public void modificaMercadoria(MercadoriaU mercadoria)
        {
            try
            {
                String est = "UPDATE Estoque SET  tipo=@tipo, nome=@nome ,preco=@preco, quantidade=@quantidade WHERE codigo= @codigo";
                estoque = new MySqlConnection(_estoqueMySql);
                MySqlCommand gra = new MySqlCommand(est, estoque);
                gra.Parameters.AddWithValue("@codigo", mercadoria.Codigo);
                gra.Parameters.AddWithValue("@tipo", mercadoria.Tipo);
                gra.Parameters.AddWithValue("@nome", mercadoria.Nome);
                gra.Parameters.AddWithValue("@preco", mercadoria.Preco);
                gra.Parameters.AddWithValue("@quantidade", mercadoria.Quantidade);
                estoque.Open();
                gra.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                estoque.Close();
            }
        }

        public void deleteMercadoria(MercadoriaU mercadoria)
        {
            try
            {
                String est = "DELETE FROM Estoque WHERE codigo = @codigo ";
                MySqlConnection estoque = new MySqlConnection(_estoqueMySql);
                MySqlCommand gra = new MySqlCommand(est, estoque);
                gra.Parameters.AddWithValue("@codigo", mercadoria.Codigo);
                estoque.Open();
                gra.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                estoque.Close();
            }
        }
    }
}