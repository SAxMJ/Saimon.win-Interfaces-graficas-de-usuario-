using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Timers;
using System.ComponentModel;
using System.Media;
using System.Collections.ObjectModel;
using System.Windows.Forms;


namespace SaimonWin
{
    /// <summary>
    /// Lógica de interacción para CuadroDialogo.xaml
    /// </summary>
    /// 

   
    public partial class CuadroDialogo : Window
    {
        int flagPanel=0;
        public event dificultadEventHandler nuevaDificultad;
        public delegate void dificultadEventHandler(Object sender,dificultadEventArgs e);

        public class dificultadEventArgs:EventArgs{
            public double dificultad { get; set; }
            public dificultadEventArgs(double d)
            {
                dificultad = d;
            }
        }
        void OnNuevaDificultad(double d){
            if(nuevaDificultad!=null){
                nuevaDificultad(this, new dificultadEventArgs(d));
            }
        }

        public event muestraCuadradoColorEventHandler nuevoCuadrado;
        public delegate void muestraCuadradoColorEventHandler(Object sender, colorCuadradoEventArgs e);

        public class colorCuadradoEventArgs : EventArgs
        {
            public string colorCuad { get; set; }
            public colorCuadradoEventArgs(string col)
            {
                colorCuad = col;
            }
        }
        void OnNuevoCuadrado(string col)
        {
            if (nuevoCuadrado != null)
            {
                nuevoCuadrado(this, new colorCuadradoEventArgs(col));
            }
        }

        public CuadroDialogo()
        {
            InitializeComponent();
            
        }

        private void PulsaBotonRojo(object sender, RoutedEventArgs e){

            OnNuevoCuadrado("R");
            TablaCompruebaPulsado.Items.Add("R");
            
        }

        private void PulsaBotonAmarillo(object sender, RoutedEventArgs e){

            OnNuevoCuadrado("Y");
            TablaCompruebaPulsado.Items.Add("Y");
        }

        private void PulsaBotonVerde(object sender, RoutedEventArgs e){

            OnNuevoCuadrado("V");
            TablaCompruebaPulsado.Items.Add("V");
        }

        private void PulsaBotonAzul(object sender, RoutedEventArgs e){

            OnNuevoCuadrado("A");
            TablaCompruebaPulsado.Items.Add("A");
            
        }

        public void EscribeElCuadradoEnPantalla(string cuadColor)
        {
            //Primero vacio la tabla de los cuadrados y luego inserto el valor
            VaciaTablaDeCuadradosMostrados();

            if (cuadColor == "R")
            {
                TablaCuadradoEnPantalla.Items.Add("CUAD ROJO");
            }
            else if (cuadColor == "Y")
            {
                TablaCuadradoEnPantalla.Items.Add("CUAD AMARILLO");
            }
            else if (cuadColor == "V")
            {
                TablaCuadradoEnPantalla.Items.Add("CUAD VERDE");
            }
            else if (cuadColor == "A")
            {
                TablaCuadradoEnPantalla.Items.Add("CUAD AZUL");
            }
            else
            {
                TablaCuadradoEnPantalla.Items.Add("CUAD BLANCO");
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e){

        }

        private void ModificaDificultad(object sender, RoutedPropertyChangedEventArgs<double> e){

            int convierteDificultad=(int) e.NewValue;

            OnNuevaDificultad(convierteDificultad);
            LabelDiff.Content = String.Format("{0}", convierteDificultad);
            
        }

        public void VaciaTablaDeComprobacionPulsado(){

            TablaCompruebaPulsado.Items.Clear();
        }

        public void VaciaTablaDeCuadradosMostrados()
        {
            TablaCuadradoEnPantalla.Items.Clear();
        }

        public void DesactivaSliderEmpezar()
        {
            SliderDificultad.IsEnabled = false;
        }

        public void ActivaSlider()
        {
            SliderDificultad.IsEnabled = true;
        }

        public void DesactivaBotonesColores()
        {
            BotonAmarillo.IsEnabled=false;
            BotonRojo.IsEnabled=false;
            BotonAzul.IsEnabled=false;
            BotonVerde.IsEnabled = false;
        }

        public void ActivaBotonesColores()
        {
            BotonAmarillo.IsEnabled = true;
            BotonRojo.IsEnabled = true;
            BotonAzul.IsEnabled = true;
            BotonVerde.IsEnabled = true;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (flagPanel == 0) { 
            System.Windows.Forms.MessageBox.Show("No es posible cerrar el cuadro de diálogo mientras estás jugando", "ERORR",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Cancel = true;
        }

            else
            {
                e.Cancel = false;
            }

        }

        public void modificaFlagPanel()
        {
            flagPanel = 1;
        }

        }
}
