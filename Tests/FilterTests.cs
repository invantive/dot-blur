using Obfuscar;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace ObfuscarTests
{
    public class FilterTests
    {
        [Fact]
        public void FullPaths()
        {
            // Arrange
            Filter sut = new Filter(
                Environment.CurrentDirectory,
                new[] { Path.Combine(Environment.CurrentDirectory, "*.*") },
                new string[0]);

            // Act
            System.Collections.Generic.List<string> files = sut.ToList();

            // Assert
            Assert.Equal(
                Directory.EnumerateFiles(Environment.CurrentDirectory, "*.*").Select(f => Path.GetFullPath(f)),
                files);
        }

        [Fact]
        public void RelativePaths()
        {
            // Arrange
            string backAndForthRelativePath = Path.Combine("..", Path.GetFileName(Environment.CurrentDirectory));
            Filter sut = new Filter(
                Environment.CurrentDirectory,
                new[] { Path.Combine(backAndForthRelativePath, "*.*") },
                new string[0]);

            // Act
            System.Collections.Generic.List<string> files = sut.ToList();

            // Assert
            Assert.Equal(
                Directory.EnumerateFiles(Environment.CurrentDirectory, "*.*").Select(f => Path.GetFullPath(f)),
                files);
        }

        [Fact]
        public void Exclusion()
        {
            // Arrange
            System.Collections.Generic.List<string> expected = Directory.EnumerateFiles(Environment.CurrentDirectory, "*.*").Select(f => Path.GetFullPath(f)).ToList();
            string backAndForthRelativePath = Path.Combine("..", Path.GetFileName(Environment.CurrentDirectory));
            string oneFile = expected[0];
            expected.RemoveAt(0);
            Filter sut = new Filter(
                Environment.CurrentDirectory,
                new[] { Path.Combine(backAndForthRelativePath, "*.*") },
                new[] { oneFile });

            // Act
            System.Collections.Generic.List<string> files = sut.ToList();

            // Assert
            Assert.Equal(expected, files);
        }
    }
}
