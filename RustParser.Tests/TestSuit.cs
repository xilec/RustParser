

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Nitra;
using NUnit.Framework;

namespace RustParser.Tests
{
    [TestFixture]
    public class TestSuit
    {
        [TestCaseSource("GetTests")]
        public void CanParse(string testFile, string formatedFile)
        {
            var sourceCode = File.ReadAllText(testFile);

            // Parse test code.
            var sourceSnapshot = new SourceSnapshot(sourceCode);
            var parserHost = new ParserHost();
            var compilationUnit = RustGrammar.CompilationUnit(sourceSnapshot, parserHost);

            // Check for parse errors.
            if (!compilationUnit.IsSuccess)
            {
                var message = string.Join(Environment.NewLine,
                    compilationUnit.GetErrors().Select(x =>
                    {
                        return string.Format("Line {0}, Col {1}: {2}{3}{4}{3}{5}",
                                                                    x.Location.StartLineColumn.Line, x.Location.StartLineColumn.Column, x.Message, Environment.NewLine, 
                                                                    x.Location.Source.GetSourceLine(x.Location.StartPos).GetText().Split(new[]{Environment.NewLine},StringSplitOptions.None).First(), 
                                                                    "^".PadLeft(x.Location.StartLineColumn.Column));
                    }));
                Debug.WriteLine(message);
            }

            Assert.That(compilationUnit.IsSuccess, Is.True);

            // Get pretty-printed version of parse tree.
            var parseTree = compilationUnit.CreateParseTree();
            var parsedCode = parseTree.ToString();

            // Compare pretty-printed parse tree with known good version
            // (if known good version exists).
            if (File.Exists(formatedFile))
            {
                var formatedCode = File.ReadAllText(formatedFile);
                Assert.That(parsedCode, Is.EqualTo(formatedCode));
            }
        }

        private static IEnumerable<TestCaseData> GetTests()
        {
            return Directory.GetFiles("Tests", "*.rs", SearchOption.AllDirectories)
                .Select(x => new TestCaseData(x, Path.ChangeExtension(x, ".formated")));
        }
    }
}
