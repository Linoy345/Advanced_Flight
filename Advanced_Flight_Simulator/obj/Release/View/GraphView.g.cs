﻿#pragma checksum "..\..\..\View\GraphView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BDBC41053F2640A799EB87AA74B3DA09BB8EA52037815CD2C44D8ACC2EDB5232"
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
using OxyPlot.Wpf;
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
    /// GraphView
    /// </summary>
    public partial class GraphView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\View\GraphView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox options;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\View\GraphView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal OxyPlot.Wpf.Plot plot;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\View\GraphView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal OxyPlot.Wpf.Plot CorrelatedPlot;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\View\GraphView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal OxyPlot.Wpf.Plot LinePlot;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\View\GraphView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox Anomalies;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\View\GraphView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal OxyPlot.Wpf.Plot AnomaliesPlot;
        
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
            System.Uri resourceLocater = new System.Uri("/Advanced_Flight_Simulator;component/view/graphview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\GraphView.xaml"
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
            this.options = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.plot = ((OxyPlot.Wpf.Plot)(target));
            return;
            case 3:
            this.CorrelatedPlot = ((OxyPlot.Wpf.Plot)(target));
            return;
            case 4:
            this.LinePlot = ((OxyPlot.Wpf.Plot)(target));
            return;
            case 5:
            this.Anomalies = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            this.AnomaliesPlot = ((OxyPlot.Wpf.Plot)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

