
namespace ApiConsultorio.Models
{
    public class Usuario
    {
        public string Id_Usuario { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public string Cedula { get; set; }

        public string Telefono { get; set; }

        public string Contrasena { get; set; }

        public byte Id_Rol { get; set; }

        public string Fecha_Registro { get; set; }

        public bool PedirContraseña { get; set; }

        // 🔗 Relaciones

        public ActividadUsuario ActividadUsuario { get; set; }

        public Medico Medico { get; set; }
    }
}