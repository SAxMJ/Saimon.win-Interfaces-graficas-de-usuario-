﻿#pragma checksum "..\..\..\CuadroDialogo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EE2827876268441D39543DB699522EC98B4D39A4C80550A3C8CCE03916FEA737"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SaimonWin {
    
    
    /// <summary>
    /// CuadroDialogo
    /// </summary>
    public partial class CuadroDialogo : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\CuadroDialogo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BotonRojo;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\CuadroDialogo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BotonAmarillo;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\CuadroDialogo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BotonAzul;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\CuadroDialogo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BotonVerde;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\CuadroDialogo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView TablaCompruebaPulsado;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\CuadroDialogo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView TablaCuadradoEnPantalla;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\CuadroDialogo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelDiff;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\CuadroDialogo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider SliderDificultad;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SaimonWin;component/cuadrodialogo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CuadroDialogo.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 4 "..\..\..\CuadroDialogo.xaml"
            ((SaimonWin.CuadroDialogo)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BotonRojo = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\CuadroDialogo.xaml"
            this.BotonRojo.Click += new System.Windows.RoutedEventHandler(this.PulsaBotonRojo);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BotonAmarillo = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\CuadroDialogo.xaml"
            this.BotonAmarillo.Click += new System.Windows.RoutedEventHandler(this.PulsaBotonAmarillo);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BotonAzul = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\CuadroDialogo.xaml"
            this.BotonAzul.Click += new System.Windows.RoutedEventHandler(this.PulsaBotonAzul);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BotonVerde = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\CuadroDialogo.xaml"
            this.BotonVerde.Click += new System.Windows.RoutedEventHandler(this.PulsaBotonVerde);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TablaCompruebaPulsado = ((System.Windows.Controls.ListView)(target));
            return;
            case 7:
            this.TablaCuadradoEnPantalla = ((System.Windows.Controls.ListView)(target));
            return;
            case 8:
            this.LabelDiff = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.SliderDificultad = ((System.Windows.Controls.Slider)(target));
            
            #line 34 "..\..\..\CuadroDialogo.xaml"
            this.SliderDificultad.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.ModificaDificultad);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

