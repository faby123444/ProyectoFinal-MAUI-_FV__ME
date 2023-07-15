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
            var nuevoRegistro = new Registro_F
            {
                Semestre = Convert.ToInt32(txtSemestre.Text),
                Materia = txtMateria.Text,
                Profesor = txtProfesor.Text,
                Calificacion = Convert.ToInt32(txtCalificacion.Text),
                Descripcion = txtDescripcion.Text,
                Cualidad = txtCualidad.Text,
                Horario = Convert.ToInt32(txtHorario.Text)
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

