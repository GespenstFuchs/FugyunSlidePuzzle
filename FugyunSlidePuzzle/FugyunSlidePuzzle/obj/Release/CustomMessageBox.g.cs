﻿#pragma checksum "..\..\CustomMessageBox.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "07F02BD7F7483D3624D7DA87AB57CEF79E808FEB0093B408F9FD26E85986373B"
//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

using FugyunSlidePuzzle;
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


namespace FugyunSlidePuzzle {
    
    
    /// <summary>
    /// CustomMessageBox
    /// </summary>
    public partial class CustomMessageBox : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 71 "..\..\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image InfomationImage;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ErrorImage;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image WarningImage;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image QuestionImage;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MessageTextBlock;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button1;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Border1;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button2;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Border2;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\CustomMessageBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button3;
        
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
            System.Uri resourceLocater = new System.Uri("/FugyunSlidePuzzle;component/custommessagebox.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CustomMessageBox.xaml"
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
            
            #line 12 "..\..\CustomMessageBox.xaml"
            ((FugyunSlidePuzzle.CustomMessageBox)(target)).ContentRendered += new System.EventHandler(this.Window_ContentRendered);
            
            #line default
            #line hidden
            
            #line 14 "..\..\CustomMessageBox.xaml"
            ((FugyunSlidePuzzle.CustomMessageBox)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.InfomationImage = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.ErrorImage = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.WarningImage = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.QuestionImage = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.MessageTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.Button1 = ((System.Windows.Controls.Button)(target));
            
            #line 119 "..\..\CustomMessageBox.xaml"
            this.Button1.Click += new System.Windows.RoutedEventHandler(this.Button1_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Border1 = ((System.Windows.Controls.Border)(target));
            return;
            case 9:
            this.Button2 = ((System.Windows.Controls.Button)(target));
            
            #line 130 "..\..\CustomMessageBox.xaml"
            this.Button2.Click += new System.Windows.RoutedEventHandler(this.Button2_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Border2 = ((System.Windows.Controls.Border)(target));
            return;
            case 11:
            this.Button3 = ((System.Windows.Controls.Button)(target));
            
            #line 142 "..\..\CustomMessageBox.xaml"
            this.Button3.Click += new System.Windows.RoutedEventHandler(this.Button3_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

