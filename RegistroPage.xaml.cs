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
            Registros_F = new ObservableCollection<Registro_F>(_context.Registro_F.ToList());

            BindingContext = this;
        }

        private void Agregar_Clicked(object sender, EventArgs e)
        {
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
            Registros_F.Add(nuevoRegistro);

            LimpiarCampos();
            DisplayAlert("Éxito", "Registro agregado correctamente.", "OK");
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


