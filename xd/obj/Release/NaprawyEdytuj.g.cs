﻿#pragma checksum "..\..\NaprawyEdytuj.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3EF9205CFD8FE9B03B403DF8EA7ADAE0EB966ED0"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
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
using xd;


namespace xd {
    
    
    /// <summary>
    /// NaprawyEdytuj
    /// </summary>
    public partial class NaprawyEdytuj : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\NaprawyEdytuj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbx_nazwa;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\NaprawyEdytuj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbx_koszt;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\NaprawyEdytuj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbx_data;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\NaprawyEdytuj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbx_info;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\NaprawyEdytuj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_dodaj;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\NaprawyEdytuj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_anuluj;
        
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
            System.Uri resourceLocater = new System.Uri("/Baza urządzeń;component/naprawyedytuj.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NaprawyEdytuj.xaml"
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
            
            #line 8 "..\..\NaprawyEdytuj.xaml"
            ((xd.NaprawyEdytuj)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbx_nazwa = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tbx_koszt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbx_data = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tbx_info = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btn_dodaj = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\NaprawyEdytuj.xaml"
            this.btn_dodaj.Click += new System.Windows.RoutedEventHandler(this.Button_Dodaj_click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_anuluj = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\NaprawyEdytuj.xaml"
            this.btn_anuluj.Click += new System.Windows.RoutedEventHandler(this.btn_anuluj_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

