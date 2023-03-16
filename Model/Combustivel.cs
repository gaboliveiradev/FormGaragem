﻿using FormGaragem.Helpers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormGaragem.Model
{
    public class Combustivel
    {
        public int id { get; set; }
        public string nome { get; set; }

        public bool Incluir()
        {
            try
            {
                Banco.openConnection();
                Banco.cmd = new MySqlCommand("USE garagem_db; INSERT INTO combustivel (nome) VALUES (@nome)", Banco.connection);
                Banco.cmd.Parameters.AddWithValue("@nome", nome);
                Banco.cmd.ExecuteNonQuery();
                Banco.closeConnection();
                return true;
            }
            catch (Exception err)
            {
                Console.WriteLine($"[005] - Ocorreu um erro ao tentar incluir um combustivel no banco de dados. \n\n {err.Message}");
                return false;
            }
        }
    }
}