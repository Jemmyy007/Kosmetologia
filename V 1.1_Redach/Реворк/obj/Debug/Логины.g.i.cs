﻿#pragma checksum "..\..\Логины.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "92821FBDAE82E0403C8B78EC82F6476D12C5D971DA3372B970A0AA6A40BD7645"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using Косметология;


namespace Косметология {
    
    
    /// <summary>
    /// Логины
    /// </summary>
    public partial class Логины : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\Логины.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataLogins;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Логины.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtKod;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Логины.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPass;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\Логины.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button txtChangeLog;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Логины.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtLogin;
        
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
            System.Uri resourceLocater = new System.Uri("/Косметология;component/%d0%9b%d0%be%d0%b3%d0%b8%d0%bd%d1%8b.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Логины.xaml"
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
            this.dataLogins = ((System.Windows.Controls.DataGrid)(target));
            
            #line 32 "..\..\Логины.xaml"
            this.dataLogins.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dataLogins_SelectionChanged_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtKod = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\Логины.xaml"
            this.txtKod.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtKod_TextChanged);
            
            #line default
            #line hidden
            
            #line 33 "..\..\Логины.xaml"
            this.txtKod.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.txtKod_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtPass = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtChangeLog = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\Логины.xaml"
            this.txtChangeLog.Click += new System.Windows.RoutedEventHandler(this.txtChangeLog_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtLogin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 37 "..\..\Логины.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

