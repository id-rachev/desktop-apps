﻿

#pragma checksum "D:\Projects\Telerik Academy\Desktop and Mobile\Win 8 XAML\W8X Projects\MyRehersalMetronom\MyRehersalMetronom\Pages\HomePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "05C0C01F6D57E33703ADD96439753D45"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyRehersalMetronom.Pages
{
    partial class HomePage : global::MyRehersalMetronom.Common.LayoutAwarePage, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 12 "..\..\Pages\HomePage.xaml"
                ((global::Windows.UI.Xaml.FrameworkElement)(target)).Loaded += this.pageRoot_LoadedUiAccess;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 43 "..\..\Pages\HomePage.xaml"
                ((global::Windows.UI.Xaml.Controls.ListViewBase)(target)).ItemClick += this.GridView_ItemClickToRehersalPage;
                 #line default
                 #line hidden
                #line 44 "..\..\Pages\HomePage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.GridView_RehersalSelectionChanged;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 34 "..\..\Pages\HomePage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.GoBack;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 95 "..\..\Pages\HomePage.xaml"
                ((global::Windows.UI.Xaml.Controls.AppBar)(target)).Opened += this.bottomAppBar_Opened;
                 #line default
                 #line hidden
                #line 95 "..\..\Pages\HomePage.xaml"
                ((global::Windows.UI.Xaml.Controls.AppBar)(target)).Closed += this.bottomAppBar_Closed;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 127 "..\..\Pages\HomePage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.confirmDeleteBtn_Click;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 101 "..\..\Pages\HomePage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.openRenameBtn_Click;
                 #line default
                 #line hidden
                break;
            case 7:
                #line 102 "..\..\Pages\HomePage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Popup)(target)).Closed += this.renamePopup_Closed;
                 #line default
                 #line hidden
                break;
            case 8:
                #line 118 "..\..\Pages\HomePage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.saveRenameBtn_Click_ErrorHandling;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


