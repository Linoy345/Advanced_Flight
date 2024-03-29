﻿#pragma checksum "..\..\..\..\View\controls.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7C651424DC1BE837A1A00F507FFFC1962141DFFFAB8C3617C00BD82F7C02A23D"
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
    /// Controls
    /// </summary>
    public partial class Controls : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\View\controls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image back;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\View\controls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image play;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\View\controls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton playRadioButton;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\View\controls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image pause;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\View\controls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton pauseRadioButton;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\View\controls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image stop;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\View\controls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image next;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\View\controls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock time;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\View\controls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider slider;
        
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
            System.Uri resourceLocater = new System.Uri("/Advanced_Flight_Simulator;component/view/controls.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\controls.xaml"
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
            this.back = ((System.Windows.Controls.Image)(target));
            
            #line 23 "..\..\..\..\View\controls.xaml"
            this.back.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.back_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.play = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.playRadioButton = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 4:
            this.pause = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.pauseRadioButton = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.stop = ((System.Windows.Controls.Image)(target));
            
            #line 31 "..\..\..\..\View\controls.xaml"
            this.stop.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.stop_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 7:
            this.next = ((System.Windows.Controls.Image)(target));
            
            #line 32 "..\..\..\..\View\controls.xaml"
            this.next.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.next_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 8:
            this.time = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.slider = ((System.Windows.Controls.Slider)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

