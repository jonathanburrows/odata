﻿// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System;

namespace Microsoft.AspNetCore.OData.Query
{
    /// <summary>
    /// Represents an <see cref="Attribute"/> that can be placed on a property to specify that the property cannot be used in the $orderby OData query option.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class UnsortableAttribute : Attribute
    {
    }
}
