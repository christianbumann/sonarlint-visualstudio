﻿/*
 * SonarLint for Visual Studio
 * Copyright (C) 2016-2018 SonarSource SA
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

using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SonarLint.VisualStudio.Integration.Vsix.CFamily;

namespace SonarLint.VisualStudio.Integration.UnitTests.CFamily
{
    [TestClass]
    public class RulesMetadataCacheTest
    {
        // Rule data for C-Family plugin v6.3 (build 11371)
        private const int Active_C_Rules = 154;
        private const int Inactive_C_Rules = 104;

        private const int Active_CPP_Rules = 245;
        private const int Inactive_CPP_Rules = 146;

        private readonly RulesMetadataCache rulesMetadataCache = CFamilyHelper.DefaultRulesCache;

        [TestMethod]
        public void Settings_LanguageKey()
        {
            rulesMetadataCache.GetSettings("c").LanguageKey.Should().Be("c");
            rulesMetadataCache.GetSettings("cpp").LanguageKey.Should().Be("cpp");

            // We don't currently support ObjC rules in VS
            rulesMetadataCache.GetSettings("objc").Should().BeNull();
        }

        [TestMethod]
        public void Read_Rules()
        {
            var rulesLoader = new RulesLoader(CFamilyHelper.CFamilyFilesDirectory);
            rulesLoader.ReadRulesList().Should().HaveCount(410); // unexpanded list of keys

            rulesMetadataCache.GetSettings("c").AllPartialRuleKeys.Should().HaveCount(Active_C_Rules + Inactive_C_Rules);
            rulesMetadataCache.GetSettings("cpp").AllPartialRuleKeys.Should().HaveCount(Active_CPP_Rules + Inactive_CPP_Rules);

            // We don't currently support ObjC rules in VS
            rulesMetadataCache.GetSettings("objc").Should().BeNull();
        }

        [TestMethod]
        public void Read_Active_Rules()
        {
            var rulesLoader = new RulesLoader(CFamilyHelper.CFamilyFilesDirectory);
            rulesLoader.ReadActiveRulesList().Should().HaveCount(255); // unexpanded list of active rules

            rulesMetadataCache.GetSettings("c").ActivePartialRuleKeys.Should().HaveCount(Active_C_Rules);
            rulesMetadataCache.GetSettings("cpp").ActivePartialRuleKeys.Should().HaveCount(Active_CPP_Rules);

            // We don't currently support ObjC rules in VS
            rulesMetadataCache.GetSettings("objc").Should().BeNull();
        }

        [TestMethod]
        public void Read_Rules_Params()
        {
            rulesMetadataCache.GetSettings("cpp").RulesParameters.TryGetValue("ClassComplexity", out var parameters);
            parameters.Should()
                .Contain(new System.Collections.Generic.KeyValuePair<string, string>("maximumClassComplexityThreshold", "80"));
        }

        [TestMethod]
        public void Read_Rules_Metadata()
        {
            rulesMetadataCache.GetSettings("cpp").RulesMetadata.TryGetValue("ClassComplexity", out var metadata);
            using (new AssertionScope())
            {
                metadata.Type.Should().Be(IssueType.CodeSmell);
                metadata.DefaultSeverity.Should().Be(IssueSeverity.Critical);
            }
        }
    }
}
