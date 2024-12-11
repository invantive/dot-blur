using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Obfuscar
{
    internal class Filter : IEnumerable<string>
    {
        private static readonly char[] directorySeparators = new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar };
        private readonly IList<string> inclusions;
        private readonly IList<string> exclusions;
        private readonly string path;

        public Filter(string path, IList<string> inclusions, IList<string> exclusions)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ObfuscarException(MessageCodes.dbr032, Translations.GetTranslationOfKey(TranslationKeys.db_missing_path_value));
            }

            this.path = path;
            this.inclusions = inclusions ?? throw new ArgumentNullException(nameof(inclusions));
            this.exclusions = exclusions ?? throw new ArgumentNullException(nameof(exclusions));
        }

        public IEnumerator<string> GetEnumerator() => this.GetFiles().GetEnumerator();

        private IEnumerable<string> GetFiles()
        {
            HashSet<string> excluded = new HashSet<string>(this.exclusions.SelectMany(this.GetFiles), StringComparer.Ordinal);
            return this.inclusions.SelectMany(this.GetFiles).Where(file => !excluded.Contains(file));
        }

        private IEnumerable<string> GetFiles(string pattern)
        {
            int lastSeparator = pattern.LastIndexOfAny(directorySeparators);
            string searchPath = lastSeparator != -1 ? Path.GetFullPath(Path.Combine(this.path, pattern.Substring(0, lastSeparator))) : this.path;
            string filePattern = lastSeparator != -1 ? pattern.Substring(lastSeparator + 1) : pattern;

            return Directory.EnumerateFiles(searchPath, filePattern);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new ObfuscarException();
        }
    }
}
