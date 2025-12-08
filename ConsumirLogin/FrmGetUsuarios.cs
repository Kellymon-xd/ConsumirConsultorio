using ApiConsultorio.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        private string usuarioSeleccionadoId = null;

        public FrmGetUsuarios()
        {
            InitializeComponent();

            cliente.BaseAddress = new Uri("https://localhost:7193/api/");
            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
        }

        private async void FrmGetUsuarios_Load(object sender, EventArgs e)
        {
            await CargarUsuarios();
        }

        private async Task CargarUsuarios()
        {
            var response = await cliente.GetAsync("Usuarios");

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("Error al obtener los usuarios");
                return;
            }

            string json = await response.Content.ReadAsStringAsync();
            var usuarios = JsonConvert.DeserializeObject<List<MostrarUsuarioDTO>>(json);

            dgvUsuarios.DataSource = usuarios;

            if (!dgvUsuarios.Columns.Contains("btnEliminar"))
            {
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.HeaderText = "Eliminar";
                btnEliminar.Name = "btnEliminar";
                btnEliminar.Text = "X";
                btnEliminar.Width = 50;
                btnEliminar.UseColumnTextForButtonValue = true;

                dgvUsuarios.Columns.Add(btnEliminar);
            }
        }

        // ------------------------
        // CARGAR DATOS AL CLICK
        // ------------------------
        private async void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var fila = dgvUsuarios.Rows[e.RowIndex].DataBoundItem as MostrarUsuarioDTO;

            usuarioSeleccionadoId = fila.Id_Usuario;

            txtNombre.Text = fila.Nombre;
            txtApellido.Text = fila.Apellido;
            txtEmail.Text = fila.Email;
            txtCedula.Text = fila.Cedula;

            ckbActivo.Checked = fila.Activo;
            ckbBloqueado.Checked = fila.Bloqueado;

            var response = await cliente.GetAsync($"Usuarios/{usuarioSeleccionadoId}");

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("No se pudo obtener detalle del usuario.");
                return;
            }

            string json = await response.Content.ReadAsStringAsync();

            var detalle = JsonConvert.DeserializeObject<dynamic>(json);

            txtTelefono.Text = detalle.telefono;
        }


        // ------------------------
        // BOTÓN EDITAR
        // ------------------------
        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionadoId == null)
            {
                MessageBox.Show("Seleccione un usuario primero.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Todos los campos deben estar completos.");
                return;
            }

            // ------------------------
            // PUT (actualizar datos)
            // ------------------------
            var bodyPut = new
            {
                nombre = txtNombre.Text,
                apellido = txtApellido.Text,
                email = txtEmail.Text,
                telefono = txtTelefono.Text
            };

            string jsonPut = JsonConvert.SerializeObject(bodyPut);
            var contenidoPut = new StringContent(jsonPut, Encoding.UTF8, "application/json");

            var responsePut = await cliente.PutAsync($"Usuarios/{usuarioSeleccionadoId}", contenidoPut);


            // ------------------------
            // PATCH ACTIVO
            // ------------------------
            var bodyActivo = new
            {
                activo = ckbActivo.Checked
            };

            var contenidoActivo = new StringContent(
                JsonConvert.SerializeObject(bodyActivo),
                Encoding.UTF8,
                "application/json"
            );

            var responseActivo = await cliente.PatchAsync(
                $"Usuarios/{usuarioSeleccionadoId}/activo",
                contenidoActivo
            );


            // ------------------------
            // PATCH BLOQUEADO
            // ------------------------
            var bodyBloq = new
            {
                bloqueado = ckbBloqueado.Checked
            };

            var contenidoBloq = new StringContent(
                JsonConvert.SerializeObject(bodyBloq),
                Encoding.UTF8,
                "application/json"
            );

            var responseBloq = await cliente.PatchAsync(
                $"Usuarios/{usuarioSeleccionadoId}/bloqueado",
                contenidoBloq
            );

            bool putOk = responsePut.IsSuccessStatusCode;

            // PATCH puede devolver 200 o 204
            bool activoOk =
                responseActivo.StatusCode == System.Net.HttpStatusCode.OK ||
                responseActivo.StatusCode == System.Net.HttpStatusCode.NoContent;

            bool bloqueadoOk =
                responseBloq.StatusCode == System.Net.HttpStatusCode.OK ||
                responseBloq.StatusCode == System.Net.HttpStatusCode.NoContent;

            // ✅ El PUT manda
            if (putOk)
            {
                MessageBox.Show(
                    "✅ Usuario actualizado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                await CargarUsuarios();
            }
            else
            {
                MessageBox.Show(
                    "❌ No se pudo actualizar el usuario.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

        }

        // ------------------------
        // ELIMINAR
        // ------------------------
        private async void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsuarios.Columns[e.ColumnIndex].Name != "btnEliminar") return;

            var fila = dgvUsuarios.Rows[e.RowIndex].DataBoundItem as MostrarUsuarioDTO;

            DialogResult confirmar = MessageBox.Show(
                "¿Eliminar este usuario?",
                "Confirmación",
                MessageBoxButtons.YesNo
            );

            if (confirmar == DialogResult.No) return;

            var response = await cliente.DeleteAsync($"Usuarios/{fila.Id_Usuario}");

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Usuario eliminado.");
                await CargarUsuarios();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar.");
            }
        }
    }
}
