﻿// Copyright (c) Microsoft Corporation and Contributors
// Licensed under the MIT license.

using System.Globalization;
using Windows.ApplicationModel.Resources;

namespace DevHome.Common.Services;

public class StringResource : IStringResource
{
    private readonly ResourceLoader _resourceLoader;

    /// <summary>
    /// Initializes a new instance of the <see cref="StringResource"/> class.
    /// <inheritdoc cref="ResourceLoader.ResourceLoader"/>
    /// </summary>
    public StringResource()
    {
        _resourceLoader = new ResourceLoader();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StringResource"/> class.
    /// <inheritdoc cref="ResourceLoader.ResourceLoader(string)"/>
    /// </summary>
    /// <param name="name">fsa</param>
    public StringResource(string name)
    {
        _resourceLoader = new ResourceLoader(name);
    }

    /// <summary>
    /// Gets the localized string of a resource key.
    /// </summary>
    /// <param name="key">Resource key.</param>
    /// <param name="args">Placeholder arguments.</param>
    /// <returns>Localized value, or resource key if the value is empty or an exception occurred.</returns>
    public string GetLocalized(string key, params object[] args)
    {
        string value;

        try
        {
            value = _resourceLoader.GetString(key);
            value = string.Format(CultureInfo.CurrentCulture, value, args);
        }
        catch
        {
            value = string.Empty;
        }

        return string.IsNullOrEmpty(value) ? key : value;
    }
}
