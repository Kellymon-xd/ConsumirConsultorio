using ApiConsultorio.DTOs;
using ConsumirConsultorio.DTOs.Usuarios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsumirLogin
{
    public partial class FrmRegistrar : Form
    {
        private readonly HttpClient cliente = new HttpClient();

        public FrmRegistrar()
        {
            InitializeComponent();

            cliente.BaseAddress = new Uri("https://localhost:7193/api/");
            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            this.cboRol.DropDown += new System.EventHandler(this.cboRol_DropDown);
        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            var nuevo = new CrearUsuarioDTO
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Email = txtEmail.Text,
                Contrasena = txtPass.Text,
                Cedula= txtCedula.Text,
                Telefono= txtTelefono.Text,
                IdRol = Convert.ToByte(cboRol.SelectedValue)
            };

            string json = JsonConvert.SerializeObject(nuevo);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("Usuarios", content);

            if (response.IsSuccessStatusCode)
            {
                lblResultado.Text = "Usuario registrado con éxito";
                lblResultado.Visible = true;
                lblResultado.ForeColor = Color.Green;
                lblResultado.Left = (this.panel1.Width - lblResultado.Size.Width) / 2;
            }
            else
            {
                lblResultado.Text = "Error al registrar el usuario";
                lblResultado.Visible = true;
                lblResultado.ForeColor = Color.Red;
                lblResultado.Left = (this.panel1.Width - lblResultado.Size.Width) / 2;
            }

            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = string.Empty;
                }
            }
        }

        private async void cboRol_DropDown(object sender, EventArgs e)
        {
            // Para evitar cargar dos veces si ya tiene datos
            if (cboRol.DataSource != null)
                return;

            var response = await cliente.GetAsync("Rol");

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("No se pudieron obtener los roles desde la API.");
                return;
            }

            var json = await response.Content.ReadAsStringAsync();
            var roles = JsonConvert.DeserializeObject<List<RolDTO>>(json);

            cboRol.DataSource = roles;
            cboRol.DisplayMember = "Descripcion_Rol";
            cboRol.ValueMember = "Id_Rol";
        }

    }
}
