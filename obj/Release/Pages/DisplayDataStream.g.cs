﻿#pragma checksum "..\..\..\Pages\DisplayDataStream.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0D77BEE2F2FF04A7A4F3EB696CBA75134F2EA7CA395D6B3B61F2AC8EB361CE46"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using SQClient.Pages;
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


namespace SQClient.Pages {
    
    
    /// <summary>
    /// DisplayDataStream
    /// </summary>
    public partial class DisplayDataStream : SQClient.Pages.BaseUart, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\Pages\DisplayDataStream.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboPort;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Pages\DisplayDataStream.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton tglbtnConnect;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Pages\DisplayDataStream.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton tglbtnRecognize;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Pages\DisplayDataStream.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxPeople;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Pages\DisplayDataStream.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxFace;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Pages\DisplayDataStream.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRegister;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Pages\DisplayDataStream.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\Pages\DisplayDataStream.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstboxHis;
        
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
            System.Uri resourceLocater = new System.Uri("/SQClient;component/pages/displaydatastream.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\DisplayDataStream.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.comboPort = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.tglbtnConnect = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 40 "..\..\..\Pages\DisplayDataStream.xaml"
            this.tglbtnConnect.Click += new System.Windows.RoutedEventHandler(this.ConnectOnClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tglbtnRecognize = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 42 "..\..\..\Pages\DisplayDataStream.xaml"
            this.tglbtnRecognize.Click += new System.Windows.RoutedEventHandler(this.RecognizeOnClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbxPeople = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.cbxFace = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.btnRegister = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\Pages\DisplayDataStream.xaml"
            this.btnRegister.Click += new System.Windows.RoutedEventHandler(this.RegisterOnClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\Pages\DisplayDataStream.xaml"
            this.btnDelete.Click += new System.Windows.RoutedEventHandler(this.DeleteOnClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lstboxHis = ((System.Windows.Controls.ListBox)(target));
            return;
            case 9:
            
            #line 75 "..\..\..\Pages\DisplayDataStream.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ClearOnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

