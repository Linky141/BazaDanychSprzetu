﻿#pragma checksum "..\..\Naprawy.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A35C09E92FFA828C8C8947B9FE6504A44700EEF5"
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
    /// Naprawy
    /// </summary>
    public partial class Naprawy : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Naprawy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_sprawdz;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Naprawy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbx_wyswietl;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Naprawy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_nazwa;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Naprawy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_koszt;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Naprawy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_data;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Naprawy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblk_info;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Naprawy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_usun;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Naprawy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_dodaj;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Naprawy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_edytuj;
        
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
            System.Uri resourceLocater = new System.Uri("/Baza urządzeń;component/naprawy.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Naprawy.xaml"
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
            this.btn_sprawdz = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\Naprawy.xaml"
            this.btn_sprawdz.Click += new System.Windows.RoutedEventHandler(this.btn_sprawdz_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lbx_wyswietl = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.lbl_nazwa = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.lbl_koszt = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lbl_data = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.tblk_info = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.btn_usun = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\Naprawy.xaml"
            this.btn_usun.Click += new System.Windows.RoutedEventHandler(this.btn_usun_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_dodaj = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\Naprawy.xaml"
            this.btn_dodaj.Click += new System.Windows.RoutedEventHandler(this.btn_dodaj_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btn_edytuj = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\Naprawy.xaml"
            this.btn_edytuj.Click += new System.Windows.RoutedEventHandler(this.btn_edit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
