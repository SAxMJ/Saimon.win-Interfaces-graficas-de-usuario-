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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Media;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;




namespace SaimonWin
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        Model m= new Model(5);
        char[] colores = new char[4];
        char[] vectorComprobacion = new char[11];
        char[] vAlmacena = new char[11];
        int pos, posVAlmacena, posMost, posIntroducida, flag,flagPanel;
        DispatcherTimer timer,timerCol,tempEAIP,tempEADMS,tempEYAC;
        CuadroDialogo c = new CuadroDialogo();
        Collection<Figura> cuadraditosColores = new Collection<Figura>();

        
        public MainWindow()
        {
            InitializeComponent();

            c.nuevaDificultad+=W_nuevaDificultad;
            c.nuevoCuadrado += W_creaNuevaFiguraCuadradoColor;

            timer = new DispatcherTimer();
            timer.Tick += Comprobar;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Stop();

            timerCol = new DispatcherTimer();
            timerCol.Tick += MetodoMuestraColores;
            timerCol.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timerCol.Stop();

            tempEADMS = new DispatcherTimer();
            tempEADMS.Tick += EsperaPreSecuencia;
            tempEADMS.Interval = new TimeSpan(0, 0, 2);
            tempEADMS.Stop();

            tempEAIP = new DispatcherTimer();
            tempEAIP.Tick += EmpiezaJuego;
            tempEAIP.Interval = new TimeSpan(0, 0, 1);
            tempEAIP.Stop();

            tempEYAC = new DispatcherTimer();
            tempEYAC.Tick += OnColorOff;
            tempEYAC.Interval = new TimeSpan(0, 0, 0, 0, 500);
            tempEYAC.Stop();


            flagPanel = 0;
        }

        //MODIFICA LA DIFICULTAD
        private void W_nuevaDificultad(Object sender,CuadroDialogo.dificultadEventArgs e){
            m.gDificultad=(int) e.dificultad;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            DialogResult result;
            result = System.Windows.Forms.MessageBox.Show("Si cierra esta ventana se cerrará el programa.\n¿Seguro que quiere salir?", "ATENCIÓN",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                c.modificaFlagPanel();
                c.Close();
                System.Windows.Application.Current.Shutdown();
            }

            else
            e.Cancel = true;
            
        }


        private void SeleccionaSonido(int seleccion)
        {

            SoundPlayer sonidoSelected;

            switch (seleccion)
            {
                case 0:
                    sonidoSelected = new SoundPlayer(System.Windows.Forms.Application.StartupPath + @"\Soniditos\Rojo.wav");
                    sonidoSelected.Play();
                    break;
                case 1:
                    sonidoSelected = new SoundPlayer(System.Windows.Forms.Application.StartupPath + @"\Soniditos\Amarillo.wav");
                    sonidoSelected.Play();
                    break;
                case 2:
                    sonidoSelected=new SoundPlayer(System.Windows.Forms.Application.StartupPath + @"\Soniditos\Azul.wav");
                    sonidoSelected.Play();
                    break;
                case 3:
                    sonidoSelected = new SoundPlayer(System.Windows.Forms.Application.StartupPath + @"\Soniditos\Verde.wav");
                    sonidoSelected.Play();
                    break;
                case 4:
                    sonidoSelected = new SoundPlayer(System.Windows.Forms.Application.StartupPath + @"\Soniditos\Fallo.wav");
                    sonidoSelected.Play();
                    break;
                case 5:
                    sonidoSelected = new SoundPlayer(System.Windows.Forms.Application.StartupPath + @"\Soniditos\Victoria.wav");
                    sonidoSelected.Play();
                    break;
                case 6:
                    sonidoSelected = new SoundPlayer(System.Windows.Forms.Application.StartupPath + @"\Soniditos\alerta.wav");
                    sonidoSelected.Play();
                    break;
                default:
                    break;
            }

        }


    
        //METODOS AVISADOS POR LOS TEMPORIZADORES
        private void Comprobar(object sender, EventArgs e)
        {
            if (vectorComprobacion[pos] != ' ')
            {
                timer.Stop();
                c.DesactivaBotonesColores();
                tempEADMS.Start();
            }
        }

        private void MetodoMuestraColores(object sender, EventArgs e)
        {
            //Cuando hemos mostrado todos los colores que llevamos hasta el momento
            //iniciamos la comprobacion de cantidad de elementos en el vector y activamos los botones
            
            timerCol.Stop();

            if (posMost > pos)
            {
                timerCol.Stop();
                ModificaLabelTurno(1);
                timer.Start();
                c.ActivaBotonesColores();

            }

            //Insertamos el cuadrado y activamos el temporizador para que los botones "parpadeen"
            if (vAlmacena[posMost] == 'R')
            {
                //CREAMOS UNA FIGURA DE COLOR ROJO
                MetodoCreaCuadradosColores("R",1);
                tempEYAC.Start();
            }
            else if (vAlmacena[posMost] == 'A')
            {
                //CREAMOS UNA FIGURA DE COLOR AZUL
                MetodoCreaCuadradosColores("A", 1);
                tempEYAC.Start();
            }
            else if (vAlmacena[posMost] == 'Y')
            {
                //CREAMOS UNA FIGURA DE COLOR AMARILLO
                MetodoCreaCuadradosColores("Y", 1);
                tempEYAC.Start();
            }
            else if (vAlmacena[posMost] == 'V')
            {
                //CREAMOS UNA FIGURA DE COLOR VERDE
                MetodoCreaCuadradosColores("V", 1);
                tempEYAC.Start();
            }
            else
            {
                //CREAMOS UNA FIGURA DE COLOR BLANCO CON FLAG 1
                MetodoCreaCuadradosColores("B", 1);
            }
            posMost++;
        }

        private void EsperaPreSecuencia(object sender, EventArgs e)
        {
            tempEADMS.Stop();

            //CREAMOS UN CUADRADO BLANCO PARA MOSTRAR POR PANTALLA
            MetodoCreaCuadradosColores("B", 1);
            compruebaColores();
        }

        private void TemporizadorEsperaAlIniciarPrograma(object sender, RoutedEventArgs e)
        {
            flag = 0;
            MetodoCreaCuadradosColores("B", flag);
            flag = 1;
            tempEAIP.Start();
            
        }

        private void OnColorOff(object sender, EventArgs e)
        {
            //CREA NUEVA FIGURA CUADRADO BLANCO CON FLAG A 1
            tempEYAC.Stop();
            MetodoCreaCuadradosColores("B", 1);
            timerCol.Start();
        
        }

        private void MetodoCreaCuadradosColores(string col, int flag)
        {
            if (col == "R")
            {
                timerCol.Stop();
                //CREAMOS UNA FIGURA DE COLOR ROJO
                Console.WriteLine("MuestraROJO");
                Figura cuad = new Figura("R");
                Canvas.SetTop(cuad.cuadradito, 170);
                Canvas.SetLeft(cuad.cuadradito, 230);
                if (cuadraditosColores.Count != 0)
                    cuadraditosColores.RemoveAt(0);

                if (Fondo.Children.Count != 0)
                    Fondo.Children.RemoveAt(0);

                cuadraditosColores.Add(cuad);
                Fondo.Children.Add(cuad.cuadradito);
                SeleccionaSonido(0);

                c.EscribeElCuadradoEnPantalla("R");
            }
            else if (col == "A")
            {
                //CREAMOS UNA FIGURA DE COLOR AZUL
                timerCol.Stop();
                Console.WriteLine("MuestraAZUL");
                Figura cuad = new Figura("A");
                Canvas.SetTop(cuad.cuadradito, 170);
                Canvas.SetLeft(cuad.cuadradito, 230);
                if (cuadraditosColores.Count != 0)
                    cuadraditosColores.RemoveAt(0);

                if (Fondo.Children.Count != 0)
                    Fondo.Children.RemoveAt(0);

                cuadraditosColores.Add(cuad);
                Fondo.Children.Add(cuad.cuadradito);
                SeleccionaSonido(2);

                c.EscribeElCuadradoEnPantalla("A");
            }
            else if (col == "Y")
            {
                //CREAMOS UNA FIGURA DE COLOR AMARILLO
                timerCol.Stop();
                Console.WriteLine("MuestraAMARILLO");
                Figura cuad = new Figura("Y");
                Canvas.SetTop(cuad.cuadradito, 170);
                Canvas.SetLeft(cuad.cuadradito, 230);
                if(cuadraditosColores.Count!=0)
                cuadraditosColores.RemoveAt(0);

                if (Fondo.Children.Count != 0)
                    Fondo.Children.RemoveAt(0);

                cuadraditosColores.Add(cuad);
                Fondo.Children.Add(cuad.cuadradito);
                SeleccionaSonido(1);
                
                c.EscribeElCuadradoEnPantalla("Y");
            }
            else if (col == "V")
            {
                //CREAMOS UNA FIGURA DE COLOR VERDE
                timerCol.Stop();
                Console.WriteLine("MuestraVERDE");
                Figura cuad = new Figura("V");
                Canvas.SetTop(cuad.cuadradito, 170);
                Canvas.SetLeft(cuad.cuadradito, 230);
                if (cuadraditosColores.Count != 0)
                    cuadraditosColores.RemoveAt(0);

                if (Fondo.Children.Count != 0)
                    Fondo.Children.RemoveAt(0);

                cuadraditosColores.Add(cuad);
                Fondo.Children.Add(cuad.cuadradito);
                SeleccionaSonido(3);

                c.EscribeElCuadradoEnPantalla("V");
            }
            else if(col=="B" && flag==0)
            {
                timerCol.Stop();
                Console.WriteLine("MuestraBLANCO");
                Figura cuad = new Figura("B");
                Canvas.SetTop(cuad.cuadradito, 170);
                Canvas.SetLeft(cuad.cuadradito, 230);
                cuadraditosColores.Add(cuad);
                Fondo.Children.Add(cuad.cuadradito);

                c.EscribeElCuadradoEnPantalla("B");
            }
            else
            {
                timerCol.Stop();
                Console.WriteLine("MuestraBLANCO");
                Figura cuad = new Figura("B");
                Canvas.SetTop(cuad.cuadradito, 170);
                Canvas.SetLeft(cuad.cuadradito, 230);
                if (cuadraditosColores.Count != 0)
                    cuadraditosColores.RemoveAt(0);

                if (Fondo.Children.Count != 0)
                    Fondo.Children.RemoveAt(0);

                cuadraditosColores.Add(cuad);
                Fondo.Children.Add(cuad.cuadradito);

                c.EscribeElCuadradoEnPantalla("B");
                           }

        }



        private void ModificaLabelTurno(int opcion)
        {
            switch (opcion)
            {
                case 0: LabelTurno.Content = "MEMORIZA LA SECUENCIA"; break;
                case 1: LabelTurno.Content = "ES TU TURNO"; break;
                case 2: LabelTurno.Content = "TURNO"; break;

            }

        }

        //MUESTRA CUADRADO AL PULSAR UN BOTON
        private void W_creaNuevaFiguraCuadradoColor(Object sender, CuadroDialogo.colorCuadradoEventArgs e)
        {
            if (e.colorCuad == "R"){
                Console.WriteLine("{0}", e.colorCuad);
                MetodoCreaCuadradosColores("R", 1);
                vectorComprobacion[posIntroducida] = 'R';
                posIntroducida++;
            }
            else if (e.colorCuad == "Y"){
                Console.WriteLine("{0}", e.colorCuad);
                MetodoCreaCuadradosColores("Y", 1);
                vectorComprobacion[posIntroducida] = 'Y';
                posIntroducida++;
            }
            else if(e.colorCuad=="A"){
                Console.WriteLine("{0}", e.colorCuad);
                MetodoCreaCuadradosColores("A", 1);
                vectorComprobacion[posIntroducida] = 'A';
                posIntroducida++;
            }
            else if (e.colorCuad == "V") {
                Console.WriteLine("{0}", e.colorCuad);
                MetodoCreaCuadradosColores("V", 1);
                vectorComprobacion[posIntroducida] = 'V';
                posIntroducida++;
            }
        }



        private void EmpiezaJuego(object sender, EventArgs e)
        {
           
            char col;
            pos = 0;

            tempEAIP.Stop();
            //MODIFICAMOS LABEL TURNO
            ModificaLabelTurno(0);
            //DESACTIVAMOS EL BOTON EMPEZAR Y EL SLIDER DE DIFICULTAD
            BotonEmpezar.IsEnabled = false;
            c.DesactivaSliderEmpezar();
            //DESACTIVAMOS LOS BOTONES DE LOS COLORES
            

            colores[0] = 'A';
            colores[1] = 'Y';
            colores[2] = 'V';
            colores[3] = 'R';

            
           //Inicializamos los vectores vectorComprobabion y vAlamacena
            for(int i=0; i<m.gDificultad+1; i++){
            vectorComprobacion[i]=' ';
            }

            for(int i=0; i<m.gDificultad+1; i++){
            vAlmacena[i]=' ';
            }
            
            Random r = new Random();
            int cAleat = r.Next(0, 4);
            col = colores[cAleat];
            posVAlmacena = 0;
            vAlmacena[posVAlmacena] = col;

            posMost = 0;
            posIntroducida = 0;

            //Avisamos al temporizador muestra colores
            timerCol.Start();

        }


        //COMPROBACION DE LA SECUENCIA INTRODUCIDA
        private int compruebaColores()
        {

            for (int i = 0; i <= pos; i++)
            {
                if (vectorComprobacion[i] != vAlmacena[i])
                {
                    //como hemos fallado se limpia tabla de pulsado
                    c.VaciaTablaDeComprobacionPulsado();
                    //Limpiamos tambien la tabla que informa de los cudrados
                    c.VaciaTablaDeCuadradosMostrados();
                    //Modificamos valor de turno
                    ModificaLabelTurno(2);
                    SeleccionaSonido(4);
                    //Generamos el sonido de haber fallado
                    if(cuadraditosColores.Count!=0)
                    cuadraditosColores.RemoveAt(0);

                    Fondo.Children.RemoveAt(0);

                    
                    System.Windows.Forms.MessageBox.Show("Sigue intentándolo.\n\nEl juego se reiniciará", "¡¡FALLASTE!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                        c.ActivaSlider();
                        BotonEmpezar.IsEnabled = true;
                        return 0;
                    
                }

            }
            
        if(pos==m.gDificultad-1){
            c.VaciaTablaDeComprobacionPulsado();
            c.VaciaTablaDeCuadradosMostrados();
            ModificaLabelTurno(2);
            SeleccionaSonido(5);

                if (cuadraditosColores.Count != 0)
                    cuadraditosColores.RemoveAt(0);

                Fondo.Children.RemoveAt(0);


                System.Windows.Forms.MessageBox.Show("Limite de colores alcancanzado.\n\nEl juego se reiniciará", "¡¡ENHORABUENA!!",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                    c.ActivaSlider();
                    BotonEmpezar.IsEnabled = true;
                    return 0;
            }


        //ANTES DE AÑADIR UN NUEVO COLOR Y MOSTRAR LA SECUENCIA VACIAMOS LA TABLA DE COMPROBACION DE PULSADO
        c.VaciaTablaDeComprobacionPulsado();
        ModificaLabelTurno(0);
        masColores();
        return 1;
        }

        //AÑADIR MAS COLORES A LA SECUENCIA
        private int masColores()
        {
            char col;

            pos++;
            Random r = new Random();
            int cAleat = r.Next(0, 3);
            col = colores[cAleat];
            posVAlmacena++;
            vAlmacena[posVAlmacena] = col;
            

            posMost = 0;
            posIntroducida = 0;
            //Lamamos al temporizador de mostrar colores
            timerCol.Start();
            return 1;

        }

        private void AbreCuadroDialogo(object sender, RoutedEventArgs e)
        {
            if (flagPanel == 0)
            {
                c.Show();
                BotonEmpezar.IsEnabled = true;
                flagPanel = 1;
            }
        }

       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
