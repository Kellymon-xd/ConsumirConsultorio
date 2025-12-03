namespace ApiConsultorio.Models
{
    public class ActividadUsuario
    {
        public string Id_Usuario { get; set; }

        public bool Activo { get; set; }
        public bool Bloqueado { get; set; }
        public int Intentos_Fallidos { get; set; }
        public string Fecha_Bloqueo { get; set; }
        public string Ultima_Actividad { get; set; }

        // 🔗 Relación inversa
        public Usuario Usuario { get; set; }
    }
}