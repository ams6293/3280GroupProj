﻿#pragma checksum "..\..\Item.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "964DB644D4311275868FF75D34A4ECF6166779556C5D250BFFEE89A59D07A1F8"
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
    /// Book
    /// </summary>
    public partial class Book : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgItems;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnShowAllItems;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNewItem;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblItemsWindow;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteItem;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbAllItems;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbInvoiceNum;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbItemCode;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblInvNum;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblItemCode;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpdateItem;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ScrollBar dgScroll;
        
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
            System.Uri resourceLocater = new System.Uri("/3280groupProj;component/item.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Item.xaml"
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
            this.dgItems = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.btnShowAllItems = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.btnNewItem = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.lblItemsWindow = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.btnDeleteItem = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.cbAllItems = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.tbInvoiceNum = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.tbItemCode = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.lblInvNum = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.lblItemCode = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.btnUpdateItem = ((System.Windows.Controls.Button)(target));
            return;
            case 12:
            this.dgScroll = ((System.Windows.Controls.Primitives.ScrollBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

