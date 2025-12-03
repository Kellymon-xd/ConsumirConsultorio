using ApiConsultorio.DTOs;
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
    public partial class FrmGetUsuarios : Form
    {
        private readonly HttpClient cliente = new HttpClient();
        public FrmGetUsuarios()
        {
            InitializeComponent();

            cliente.BaseAddress = new Uri("https://localhost:7193/api/");
            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async void FrmGetUsuarios_Load(object sender, EventArgs e)
        {
            var response = await cliente.GetAsync("Usuarios");

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Error fetching users");
                return;
            }

            string json = await response.Content.ReadAsStringAsync();
            var usuarios = JsonConvert.DeserializeObject<List<MostrarUsuarioDTO>>(json);

            dgvUsuarios.AutoGenerateColumns = true;
            dgvUsuarios.DataSource = usuarios;
        }

     


        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Debe seleccionar un usuario para editar.");
                return;
            }

            var update = new ActualizarUsuarioDTO
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Email = txtEmail.Text,
                Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text)
                            ? null  // NO tocar → API mantiene el valor anterior
                            : txtTelefono.Text
            };

            string json = JsonConvert.SerializeObject(update);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync($"Usuarios/{txtId.Text}", content);

            if (response.IsSuccessStatusCode)
                MessageBox.Show("Usuario actualizado.");
            else
            {
                string error = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Error al actualizar usuario: " + error);
            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtNombre.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            txtApellido.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
            txtEmail.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            txtCedula.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Cedula"].Value.ToString();
 

            chkActivo.Checked = (bool)dgvUsuarios.Rows[e.RowIndex].Cells["Activo"].Value;
            chkBloqueado.Checked = (bool)dgvUsuarios.Rows[e.RowIndex].Cells["Bloqueado"].Value;

            // Guardamos el ID ocultamente
            txtId.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Id_Usuario"].Value.ToString();

        }

      
    }
}
