﻿

#pragma checksum "D:\Projects\Telerik Academy\Desktop and Mobile\Win 8 XAML\W8X Projects\MyRehersalMetronom\MyRehersalMetronom\Pages\RehersalPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B6A2C2184E811E2693A00B344B111B33"
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
    partial class RehersalPage : global::MyRehersalMetronom.Common.LayoutAwarePage, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 46 "..\..\Pages\RehersalPage.xaml"
                ((global::Windows.UI.Xaml.Controls.ListViewBase)(target)).ItemClick += this.timeBarsGridView_ItemClickToTimeBarPage;
                 #line default
                 #line hidden
                #line 47 "..\..\Pages\RehersalPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.timeBarsGridView_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 34 "..\..\Pages\RehersalPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.GoBack;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 103 "..\..\Pages\RehersalPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.addAfterBtn_Click;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 106 "..\..\Pages\RehersalPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.deleteBtn_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}

