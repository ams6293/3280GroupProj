﻿#pragma checksum "..\..\..\Search\Search.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A49565827862431D91308584B32527078F96988E28F270FC352107FE7C0530C5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
using _3280groupProj;


namespace _3280groupProj {
    
    
    /// <summary>
    /// Search
    /// </summary>
    public partial class Search : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Search\Search.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgInvoices;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Search\Search.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox invoiceNumberDropDown;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Search\Search.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox invoiceDateDropDown;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Search\Search.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox totalChargeDropDown;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Search\Search.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ClearBtn;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Search\Search.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button selectBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/3280groupProj;component/search/search.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Search\Search.xaml"
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
            this.dgInvoices = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.invoiceNumberDropDown = ((System.Windows.Controls.ComboBox)(target));
            
            #line 12 "..\..\..\Search\Search.xaml"
            this.invoiceNumberDropDown.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.invoiceNumberDropDown_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.invoiceDateDropDown = ((System.Windows.Controls.ComboBox)(target));
            
            #line 13 "..\..\..\Search\Search.xaml"
            this.invoiceDateDropDown.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.invoiceDateDropDown_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.totalChargeDropDown = ((System.Windows.Controls.ComboBox)(target));
            
            #line 14 "..\..\..\Search\Search.xaml"
            this.totalChargeDropDown.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.totalChargeDropDown_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ClearBtn = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Search\Search.xaml"
            this.ClearBtn.Click += new System.Windows.RoutedEventHandler(this.ClearBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.selectBtn = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\Search\Search.xaml"
            this.selectBtn.Click += new System.Windows.RoutedEventHandler(this.selectBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

