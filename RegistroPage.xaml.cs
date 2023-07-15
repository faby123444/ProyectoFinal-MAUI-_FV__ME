using Microsoft.Maui.Controls;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using ProyectoFinal_MAUI__FV__ME.Data;

namespace ProyectoFinal_MAUI__FV__ME
{
    public partial class RegistroPage : ContentPage
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public ObservableCollection<Registro_F> Registros_F { get; set; }

        public RegistroPage()
        {
            InitializeComponent();
            Registros_F = new ObservableCollection<Registro_F>();

            // Ordenar los registros por calificación de manera descendente
            var registrosOrdenados = _context.Registro_F.OrderByDescending(registro => registro.Calificacion).ToList();
            foreach (var registro in registrosOrdenados)
            {
                Registros_F.Add(registro);
            }

            BindingContext = this;
        }

        private void Agregar_Clicked(object sender, EventArgs e)
        {
            Registros_F.Clear();

            foreach (var registro in _context.Registro_F.ToList())
            {
                Registros_F.Add(registro);
            }

            if (string.IsNullOrWhiteSpace(txtSemestre.Text) || string.IsNullOrWhiteSpace(txtMateria.Text) ||
                string.IsNullOrWhiteSpace(txtProfesor.Text) || string.IsNullOrWhiteSpace(txtCalificacion.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) || string.IsNullOrWhiteSpace(txtCualidad.Text) ||
                string.IsNullOrWhiteSpace(txtHorario.Text))
            {
                DisplayAlert("Error", "Necesitas completar todos los campos.", "OK");
                return;
            }

            int semestre;
            if (!int.TryParse(txtSemestre.Text, out semestre) || semestre < 1 || semestre > 10)
            {
                DisplayAlert("Error", "El semestre debe ser un número del 1 al 10.", "OK");
                return;
            }

            int calificacion;
            if (!int.TryParse(txtCalificacion.Text, out calificacion) || calificacion < 1 || calificacion > 10)
            {
                DisplayAlert("Error", "La calificación debe ser un número del 1 al 10.", "OK");
                return;
            }

            int horario;
            if (!int.TryParse(txtHorario.Text, out horario) || horario < 1 || horario > 3)
            {
                DisplayAlert("Error", "El horario debe ser un número del 1 al 3.", "OK");
                return;
            }

            var nuevoRegistro = new Registro_F
            {
                Semestre = semestre,
                Materia = txtMateria.Text,
                Profesor = txtProfesor.Text,
                Calificacion = calificacion,
                Descripcion = txtDescripcion.Text,
                Cualidad = txtCualidad.Text,
                Horario = horario
            };

            _context.Registro_F.Add(nuevoRegistro);
            _context.SaveChanges();

            // Ordenar los registros nuevamente
            var registrosOrdenados = _context.Registro_F.OrderByDescending(registro => registro.Calificacion).ToList();
            
            foreach (var registro in registrosOrdenados)
            {
                Registros_F.Add(registro);
            }

            LimpiarCampos();
            DisplayAlert("Éxito", "Registro agregado correctamente.", "OK");
        }

        private void Buscar_Clicked(object sender, EventArgs e)
        {
            string searchTerm = txtBusqueda.Text?.Trim();

            var query = _context.Registro_F.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(registro =>
                    registro.Materia.Contains(searchTerm) ||
                    registro.Profesor.Contains(searchTerm));
            }

            var resultados = query.OrderByDescending(registro => registro.Calificacion).ToList();

            if (resultados.Count == 0)
            {
                DisplayAlert("No se encontraron resultados", "No se encontraron registros que coincidan con los criterios de búsqueda.", "OK");
                return;
            }

            Registros_F.Clear();
            foreach (var resultado in resultados)
            {
                Registros_F.Add(resultado);
            }
        }

        private void ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Registro_F registro)
            {
                string detalles = $"Semestre: {registro.Semestre}\n" +
                                  $"Materia: {registro.Materia}\n" +
                                  $"Profesor: {registro.Profesor}\n" +
                                  $"Calificación: {registro.Calificacion}\n" +
                                  $"Descripción: {registro.Descripcion}\n" +
                                  $"Cualidad: {registro.Cualidad}\n" +
                                  $"Horario: {registro.Horario}";

                DisplayAlert("Detalles del registro", detalles, "OK");
            }

            // Desactivar la selección del elemento
            ((ListView)sender).SelectedItem = null;
        }

        private void LimpiarCampos()
        {
            txtSemestre.Text = string.Empty;
            txtMateria.Text = string.Empty;
            txtProfesor.Text = string.Empty;
            txtCalificacion.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtCualidad.Text = string.Empty;
            txtHorario.Text = string.Empty;
        }
    }
}
