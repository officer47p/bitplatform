﻿using Foundation.CSharpAnalyzers.SystemAnalyzers;
using Foundation.CSharpAnalyzers.Test.Helpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Foundation.CSharpAnalyzers.Test.System
{
    [TestClass]
    public class ClassWithoutModifierAnalyzerTest : CodeFixVerifier
    {
        [TestMethod]
        [TestCategory("Analyzer")]
        public void FindClassesWithoutModifier()
        {
            const string sourceCodeWithClassWithoutModifier = @"
    namespace MyNamespace
    {
        public class MyClass
        {   

        }

        class MyClass
        {   

        }
    }";
            DiagnosticResult classWithoutModifier = new DiagnosticResult
            {
                Id = nameof(ClassWithoutModifierAnalyzer),
                Message = FoundationAnalyzersResources.ClassWithoutModifierAnalyzerMessage,
                Severity = DiagnosticSeverity.Error,
                Locations = new[] { new DiagnosticResultLocation("Test0.cs", 9, 9) }
            };

            VerifyCSharpDiagnostic(sourceCodeWithClassWithoutModifier, classWithoutModifier);
        }

        protected override CodeFixProvider GetCSharpCodeFixProvider()
        {
            throw new NotImplementedException();
        }

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
        {
            return new ClassWithoutModifierAnalyzer();
        }
    }
}