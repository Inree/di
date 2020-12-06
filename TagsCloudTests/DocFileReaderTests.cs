﻿using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using TagsCloud.App;

namespace TagsCloudTests
{
    [TestFixture]
    public class DocFileReaderTests
    {
        private readonly DocFileReader reader = new DocFileReader();

        [Test]
        public void DocFileReader_ShouldThrow_WithWrongFileType()
        {
            var fileName = @"C:\Users\da\Desktop\abc.hguit";
            Action action = () => reader.ReadLines(fileName).ToArray();
            action.Should().Throw<ArgumentException>();
        }

        [Test]
        public void DocFileReader_ShouldReadLines_FromDocTypeFile()
        {
            var fileName = Directory.GetCurrentDirectory() + @"\FileReadersTestsFiles\DocFileReaderTestFile.docx";
            TestContext.WriteLine(fileName);
            var words = reader.ReadLines(fileName);
            words.Should().BeEquivalentTo("Abc", "Aa", "Abcg", "Def", "Gf");
        }

        [Test]
        public void DocFileReader_ShouldReturnEmptyCollection_FromEmptyDocFile()
        {
            var fileName = Directory.GetCurrentDirectory() + @"\FileReadersTestsFiles\EmptyDocFile.docx";
            TestContext.WriteLine(fileName);
            var words = reader.ReadLines(fileName);
            words.Should().BeEquivalentTo();
        }
    }
}