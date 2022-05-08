﻿#pragma checksum "..\..\..\..\Editor\GameEditor\GameEditorView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "86BBAD6F9F7BA2D6DB0C8F30551FACA81F0CB948F57F9B9C065681C87E17633E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Syncfusion;
using Syncfusion.Windows;
using Syncfusion.Windows.Controls.Notification;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools;
using Syncfusion.Windows.Tools.Controls;
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
using UnknownElementsEditor.Editor;
using UnknownElementsEditor.Editor.GameEditor;
using UnknownElementsEditor.GameProject;


namespace UnknownElementsEditor.Editor {
    
    
    /// <summary>
    /// GameEditorView
    /// </summary>
    public partial class GameEditorView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 42 "..\..\..\..\Editor\GameEditor\GameEditorView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem saveMenuItem;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Editor\GameEditor\GameEditorView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem exitMenuItem;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Editor\GameEditor\GameEditorView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem fullScreenMenuItem;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Editor\GameEditor\GameEditorView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem windowedscreenMenuItem;
        
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
            System.Uri resourceLocater = new System.Uri("/UnknownElementsEditor;component/editor/gameeditor/gameeditorview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Editor\GameEditor\GameEditorView.xaml"
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
            this.saveMenuItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 42 "..\..\..\..\Editor\GameEditor\GameEditorView.xaml"
            this.saveMenuItem.Click += new System.Windows.RoutedEventHandler(this.OnMenuClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.exitMenuItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 45 "..\..\..\..\Editor\GameEditor\GameEditorView.xaml"
            this.exitMenuItem.Click += new System.Windows.RoutedEventHandler(this.OnMenuClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.fullScreenMenuItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 46 "..\..\..\..\Editor\GameEditor\GameEditorView.xaml"
            this.fullScreenMenuItem.Click += new System.Windows.RoutedEventHandler(this.OnMenuClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.windowedscreenMenuItem = ((System.Windows.Controls.MenuItem)(target));
            
            #line 47 "..\..\..\..\Editor\GameEditor\GameEditorView.xaml"
            this.windowedscreenMenuItem.Click += new System.Windows.RoutedEventHandler(this.OnMenuClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
