﻿#pragma checksum "..\..\..\View\DisplayWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "244ABCF917EF30D46AA8A091A456A27F92E8D89837644D8FF30B481FCF44CA26"
#pragma checksum "..\..\..\View\DisplayWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A79F7ED6F746E77DA749CD8906F493136DB72436D3FA62EE3FEF775639A3B414"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Advanced_Flight_Simulator;
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


namespace Advanced_Flight_Simulator {
    
    
    /// <summary>
    /// DisplayWindow
    /// </summary>
    public partial class DisplayWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\View\DisplayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Joistoc;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\View\DisplayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Advanced_Flight_Simulator.Joistic joystick;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\View\DisplayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Advanced_Flight_Simulator.Indices indices;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\View\DisplayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Advanced_Flight_Simulator.Controls controls;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\View\DisplayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Advanced_Flight_Simulator.GraphView graph;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\View\DisplayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button openDllDlgo;
        
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
            System.Uri resourceLocater = new System.Uri("/Advanced_Flight_Simulator;component/view/displaywindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\DisplayWindow.xaml"
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
            this.Joistoc = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.joystick = ((Advanced_Flight_Simulator.Joistic)(target));
            return;
            case 3:
            this.indices = ((Advanced_Flight_Simulator.Indices)(target));
            return;
            case 4:
            this.controls = ((Advanced_Flight_Simulator.Controls)(target));
            return;
            case 5:
            this.graph = ((Advanced_Flight_Simulator.GraphView)(target));
            return;
            case 6:
            
            #line 36 "..\..\..\View\DisplayWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Start);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 37 "..\..\..\View\DisplayWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Disconnect);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 38 "..\..\..\View\DisplayWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_OpenFile);
            
            #line default
            #line hidden
            return;
            case 9:
            this.openDllDlgo = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\View\DisplayWindow.xaml"
            this.openDllDlgo.Click += new System.Windows.RoutedEventHandler(this.Button_Click_OpenDllAlgo);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

