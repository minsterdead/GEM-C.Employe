﻿#pragma checksum "..\..\..\Views\DemarrageTempsView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "77673488AB9BB3EAD9A031E7065C11E6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.34209
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
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


namespace GEM_C_E.Views {
    
    
    /// <summary>
    /// DemarrageTempsView
    /// </summary>
    public partial class DemarrageTempsView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Views\DemarrageTempsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblProjet;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Views\DemarrageTempsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cblstProjet;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Views\DemarrageTempsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblEmploye;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Views\DemarrageTempsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cblstEmploye;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Views\DemarrageTempsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDemarrer;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Views\DemarrageTempsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSommaireTemps;
        
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
            System.Uri resourceLocater = new System.Uri("/GEM-C-E;component/views/demarragetempsview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\DemarrageTempsView.xaml"
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
            this.lblProjet = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.cblstProjet = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.lblEmploye = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.cblstEmploye = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.btnDemarrer = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\Views\DemarrageTempsView.xaml"
            this.btnDemarrer.Click += new System.Windows.RoutedEventHandler(this.Demarrer_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnSommaireTemps = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

