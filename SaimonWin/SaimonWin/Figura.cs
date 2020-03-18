using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;


namespace SaimonWin
{
    class Figura
    {
        public Color color;
        public int x, y;
        public Shape cuadradito = new Rectangle();

        public Figura(string colElegido)
        {
            x = 150;
            y = 150;
            color = new Color();

            if (colElegido == "R")
            {
                color.A = (byte)255;
                color.R = (byte)255;
                color.G = (byte)0;
                color.B = (byte)0;
                cuadradito.Width = x;
                cuadradito.Height = y;
                cuadradito.Fill = new SolidColorBrush(color);
            }
            else if (colElegido == "A")
            {
                color.A = (byte)255;
                color.R = (byte)0;
                color.G = (byte)0;
                color.B = (byte)255;
                cuadradito.Width = x;
                cuadradito.Height = y;
                cuadradito.Fill = new SolidColorBrush(color);
            }
            else if (colElegido == "Y")
            {
                color.A = (byte)255;
                color.R = (byte)255;
                color.G = (byte)255;
                color.B = (byte)0;
                cuadradito.Width = x;
                cuadradito.Height = y;
                cuadradito.Fill = new SolidColorBrush(color);
            }
            else if (colElegido == "V")
            {
                color.A = (byte)255;
                color.R = (byte)0;
                color.G = (byte)255;
                color.B = (byte)0;
                cuadradito.Width = x;
                cuadradito.Height = y;
                cuadradito.Fill = new SolidColorBrush(color);
            }
            else
            {
                color.A = (byte)255;
                color.R = (byte)255;
                color.G = (byte)255;
                color.B = (byte)255;
                cuadradito.Width = x;
                cuadradito.Height = y;
                cuadradito.Fill = new SolidColorBrush(color);
            }

        }
        
    }
}
