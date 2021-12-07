﻿using ProyectoFinal.BLL;
using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoFinal.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cUsuario.xaml
    /// </summary>
    public partial class cUsuario : Window
    {
        public cUsuario()
        {
            InitializeComponent();
        }
        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Usuarios>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //UsuarioId
                        listado = UsuarioBLL.GetList(e => e.UsuarioId == Utilidades.ToInt(CriterioTextBox.Text));
                        DesdeDataPicker.SelectedDate = null;
                        HastaDatePicker.SelectedDate = null;
                        break;

                    case 1: //Nombre                      
                        listado = UsuarioBLL.GetList(e => e.Nombre.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        DesdeDataPicker.SelectedDate = null;
                        HastaDatePicker.SelectedDate = null;
                        break;
                }
            }
            else
            {
                listado = UsuarioBLL.GetList(c => true);
            }
            if(listado == null)
            {
                if (DesdeDataPicker.SelectedDate != null)
                    listado = UsuarioBLL.GetList(c => c.Fecha.Date >= DesdeDataPicker.SelectedDate);

                if (HastaDatePicker.SelectedDate != null)
                    listado = UsuarioBLL.GetList(c => c.Fecha.Date <= HastaDatePicker.SelectedDate);
            }
           

            // listado = UsuariosBLL.GetList();
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }

        private void enter(object sender, MouseEventArgs e)
        {
            CriterioTextBox.Text = null;
            FiltroComboBox.SelectedItem = null;
        }

        private void limpiar(object sender, MouseEventArgs e)
        {
            CriterioTextBox.Text = null;
            FiltroComboBox.SelectedItem = null;
        }
    }
}
