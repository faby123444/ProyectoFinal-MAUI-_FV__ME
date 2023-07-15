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

        private void Actualizar_Clicked(object sender, EventArgs e)
        {
            if (lstRegistros.SelectedItem is Registro_F registroSeleccionado)
            {
                registroSeleccionado.Semestre = Convert.ToInt32(txtSemestre.Text);
                registroSeleccionado.Materia = txtMateria.Text;
                registroSeleccionado.Profesor = txtProfesor.Text;
                registroSeleccionado.Calificacion = Convert.ToInt32(txtCalificacion.Text);
                registroSeleccionado.Descripcion = txtDescripcion.Text;
                registroSeleccionado.Cualidad = txtCualidad.Text;
                registroSeleccionado.Horario = Convert.ToInt32(txtHorario.Text);

                _context.SaveChanges();
                DisplayAlert("Éxito", "Registro actualizado correctamente.", "OK");
            }
        }

        private void Eliminar_Clicked(object sender, EventArgs e)
        {
            if (lstRegistros.SelectedItem is Registro_F registroSeleccionado)
            {
                _context.Registro_F.Remove(registroSeleccionado);
                _context.SaveChanges();
                Registros_F.Remove(registroSeleccionado);
                LimpiarCampos();
                DisplayAlert("Éxito", "Registro eliminado correctamente.", "OK");
            }
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

