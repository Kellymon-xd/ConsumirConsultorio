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
    public partial class FrmLogin : Form
    {
        private readonly HttpClient cliente = new HttpClient();

        public FrmLogin()
        {
            InitializeComponent();

            cliente.BaseAddress = new Uri("https://localhost:7193/api/");
            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var credenciales = new LoginDTO
            {
                email = txtEmail.Text,
                contrasena = txtPass.Text
            };
            string json = JsonConvert.SerializeObject(credenciales);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("Usuarios/login", content);
            string jsonResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonResponse);

            if (response.IsSuccessStatusCode)
            {
                lblResultado.Text = $"Login exitoso de {result["nombre"]} {result["apellido"]}";
                lblResultado.Visible = true;
                lblResultado.ForeColor = Color.Green;
                lblResultado.Left = (this.panel1.Width - lblResultado.Size.Width) / 2;
            }
        }
    }
}
