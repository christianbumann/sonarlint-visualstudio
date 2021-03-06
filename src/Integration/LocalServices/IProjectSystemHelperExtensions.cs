﻿/*
 * SonarLint for Visual Studio
 * Copyright (C) 2016-2020 SonarSource SA
 * mailto:info AT sonarsource DOT com
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program; if not, write to the Free Software Foundation,
 * Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

using System;
using System.Linq;
using Microsoft.VisualStudio.Shell.Interop;

namespace SonarLint.VisualStudio.Integration
{
    internal static class IProjectSystemHelperExtensions
    {
        /// <summary>
        /// Returns whether or not a project is of a known test project type.
        /// </summary>
        public static bool IsKnownTestProject(this IProjectSystemHelper projectSystem, IVsHierarchy vsProject)
        {
            //TODO: is this relevant for core projects?
            if (projectSystem == null)
            {
                throw new ArgumentNullException(nameof(projectSystem));
            }

            if (vsProject == null)
            {
                throw new ArgumentNullException(nameof(vsProject));
            }

            return projectSystem.GetAggregateProjectKinds(vsProject).Contains(ProjectSystemHelper.TestProjectKindGuid);
        }
    }
}
