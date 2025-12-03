namespace ApiConsultorio.Models
{
    public class Medico
    {
        public int ID_Medico { get; set; }

        public string Id_Usuario { get; set; }

        public int ID_Especialidad { get; set; }

        public int ID_Contrato { get; set; }

        public string Horario_Atencion { get; set; }

        public string Telefono_Consulta { get; set; }

        // ================================
        // PROPIEDADES DE NAVEGACIÓN
        // ================================
        public virtual Usuario Usuario { get; set; }

        public virtual Especialidad Especialidad { get; set; }

        public virtual TipoContrato Contrato { get; set; }
    }
}