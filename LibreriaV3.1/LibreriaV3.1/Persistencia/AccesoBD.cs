using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaV3._1.Persistencia
{
    class AccesoBD
    {
        private static MySqlConnection connection = null;
        private MySqlTransaction transaccion;

        public AccesoBD()
        {
            connection = ConexionJDBC.AbrirConexion();
        }

        protected void StartTrasaction()
        {
            transaccion = connection.BeginTransaction();
        }
        protected void Commit()
        {
            transaccion.Commit();
        }

        protected void Rollback()
        {
            transaccion.Rollback();
        }
    }
}
