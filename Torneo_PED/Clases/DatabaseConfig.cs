using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo_PED.Clases
{
    public class DatabaseConfig
    {
        public static string Server { get; } = "localhost";
        public static string Database { get; } = "GestorTorneos";
        public static string UserId { get; } = "sa";
        public static string Password { get; } = "1234";

        public static string ConnectionString =>
            $"Server={Server};Database={Database};User Id={UserId};Password={Password};";
    }
}
