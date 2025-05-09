using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatApiWinForms
{
    public partial class Form1 : Form
    {
        private readonly HttpClient httpClient = new HttpClient();
        private List<Breed> breedsList = new List<Breed>();
        private Breed selectedBreed;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadBreedsAsync();
        }

        private async Task LoadBreedsAsync()
        {
            try
            {
                string url = "https://api.thecatapi.com/v1/breeds";
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                breedsList = JsonSerializer.Deserialize<List<Breed>>(json);

                listBoxBreeds.DataSource = breedsList;
                listBoxBreeds.DisplayMember = "name";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar razas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void listBoxBreeds_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxBreeds.SelectedItem is Breed breed)
            {
                selectedBreed = breed;
                labelCatInfo.Text = $"Nombre: {breed.name}\nOrigen: {breed.origin}\nDescripción: {breed.description}";
                if (!string.IsNullOrEmpty(breed.reference_image_id))
                {
                    await LoadBreedImageAsync(breed.reference_image_id);
                }
                else
                {
                    pictureBoxCat.Image = null;
                }
            }
        }

        private async Task LoadBreedImageAsync(string imageId)
        {
            try
            {
                string imageUrl = $"https://cdn2.thecatapi.com/images/{imageId}.jpg";
                var imageStream = await httpClient.GetStreamAsync(imageUrl);
                pictureBoxCat.Image = Image.FromStream(imageStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureBoxCat.Image = null;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBoxBreeds.ClearSelected();
            pictureBoxCat.Image = null;
            labelCatInfo.Text = "";
            selectedBreed = null;
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            if (selectedBreed != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Archivo JSON|*.json",
                    Title = "Guardar información de la raza"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var json = JsonSerializer.Serialize(selectedBreed, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(saveFileDialog.FileName, json);
                    MessageBox.Show("Guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No hay raza seleccionada para guardar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    public class Breed
    {
        public string id { get; set; }
        public string name { get; set; }
        public string origin { get; set; }
        public string description { get; set; }
        public string reference_image_id { get; set; }
    }
}
