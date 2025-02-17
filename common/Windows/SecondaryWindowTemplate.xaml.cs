// Copyright (c) Microsoft Corporation and Contributors
// Licensed under the MIT license.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace DevHome.Common.Windows;

/// <summary>
/// Class that defines the template for a <see cref="SecondaryWindow"/>
/// </summary>
internal sealed partial class SecondaryWindowTemplate : UserControl
{
    private readonly SecondaryWindow _secondaryWindow;

    public WindowTitleBar? TitleBar
    {
        get => (WindowTitleBar?)GetValue(TitleBarProperty);
        set => SetValue(TitleBarProperty, value);
    }

    public object MainContent
    {
        get => GetValue(MainContentProperty);
        set => SetValue(MainContentProperty, value);
    }

    public SecondaryWindowTemplate(SecondaryWindow window)
    {
        _secondaryWindow = window;
        this.InitializeComponent();
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        // A custom title bar is required for full window theme and Mica support.
        // https://docs.microsoft.com/windows/apps/develop/title-bar?tabs=winui3#full-customization
        _secondaryWindow.ExtendsContentIntoTitleBar = true;
        _secondaryWindow.SetTitleBar(this.WindowTitleBar);
    }

    private static readonly DependencyProperty TitleBarProperty = DependencyProperty.Register(nameof(TitleBar), typeof(WindowTitleBar), typeof(SecondaryWindowTemplate), new PropertyMetadata(null));
    private static readonly DependencyProperty MainContentProperty = DependencyProperty.Register(nameof(MainContent), typeof(object), typeof(SecondaryWindowTemplate), new PropertyMetadata(null));
}
