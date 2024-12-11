#region Copyright (c) 2007 Ryan Williams <drcforbin@gmail.com>

// <copyright>
// Copyright (c) 2007 Ryan Williams <drcforbin@gmail.com>
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// </copyright>

#endregion

using System;
using System.Collections.Generic;
using System.IO;

namespace Obfuscar
{
    internal class TextMapWriter : IMapWriter, IDisposable
    {
        private readonly TextWriter writer;

        public TextMapWriter(TextWriter writer)
        {
            this.writer = writer;
        }

        public void WriteMap(ObfuscationMap map)
        {
            this.writer.WriteLine("Renamed Types:");

            foreach (ObfuscatedClass classInfo in map.ClassMap.Values)
            {
                //
                // Print the ones we didn't skip first.
                //
                if (classInfo.Status == ObfuscationStatus.Renamed)
                {
                    this.DumpClass(classInfo);
                }
            }

            this.writer.WriteLine();
            this.writer.WriteLine("Skipped Types:");

            foreach (ObfuscatedClass classInfo in map.ClassMap.Values)
            {
                //
                // Print the skipped types.
                //
                if (classInfo.Status == ObfuscationStatus.Skipped)
                {
                    this.DumpClass(classInfo);
                }
            }

            this.writer.WriteLine();
            this.writer.WriteLine("Renamed Resources:");
            this.writer.WriteLine();

            foreach (ObfuscatedThing info in map.Resources)
            {
                if (info.Status == ObfuscationStatus.Renamed)
                {
                    this.writer.WriteLine("{0} -> {1}", info.Name, info.StatusText);
                }
            }

            this.writer.WriteLine();
            this.writer.WriteLine("Skipped Resources:");
            this.writer.WriteLine();

            foreach (ObfuscatedThing info in map.Resources)
            {
                if (info.Status == ObfuscationStatus.Skipped)
                {
                    this.writer.WriteLine("{0} ({1})", info.Name, info.StatusText);
                }
            }
        }

        private void DumpClass(ObfuscatedClass classInfo)
        {
            this.writer.WriteLine();
            if (classInfo.Status == ObfuscationStatus.Renamed)
            {
                this.writer.WriteLine("{0} -> {1}", classInfo.Name, classInfo.StatusText);
            }
            else if (classInfo.Status == ObfuscationStatus.Skipped)
            {
                this.writer.WriteLine("{0} skipped:  {1}", classInfo.Name, classInfo.StatusText);
            }
            else
            {
                throw new ObfuscarException(MessageCodes.dbr135, Translations.GetTranslationOfKey(TranslationKeys.db_dbr135_msg));
            }

            this.writer.WriteLine("{");

            int numRenamed = 0;
            foreach (KeyValuePair<MethodKey, ObfuscatedThing> method in classInfo.Methods)
            {
                if (method.Value.Status == ObfuscationStatus.Renamed)
                {
                    this.DumpMethod(method.Key, method.Value);
                    numRenamed++;
                }
            }

            //
            // Add a blank line to separate renamed from skipped.
            //
            if (numRenamed < classInfo.Methods.Count)
            {
                this.writer.WriteLine();
            }

            foreach (KeyValuePair<MethodKey, ObfuscatedThing> method in classInfo.Methods)
            {
                if (method.Value.Status == ObfuscationStatus.Skipped)
                {
                    this.DumpMethod(method.Key, method.Value);
                }
            }

            //
            // Add a blank line to separate methods from field.
            //
            if (classInfo.Methods.Count > 0 && classInfo.Fields.Count > 0)
            {
                this.writer.WriteLine();
            }

            numRenamed = 0;
            foreach (KeyValuePair<FieldKey, ObfuscatedThing> field in classInfo.Fields)
            {
                if (field.Value.Status == ObfuscationStatus.Renamed)
                {
                    this.DumpField(this.writer, field.Key, field.Value);
                    numRenamed++;
                }
            }

            //
            // Add a blank line to separate renamed from skipped.
            //
            if (numRenamed < classInfo.Fields.Count)
            {
                this.writer.WriteLine();
            }

            foreach (KeyValuePair<FieldKey, ObfuscatedThing> field in classInfo.Fields)
            {
                if (field.Value.Status == ObfuscationStatus.Skipped)
                {
                    this.DumpField(this.writer, field.Key, field.Value);
                }
            }

            //
            // Add a blank line to separate props.
            //
            if (classInfo.Properties.Count > 0)
            {
                this.writer.WriteLine();
            }

            numRenamed = 0;
            foreach (KeyValuePair<PropertyKey, ObfuscatedThing> field in classInfo.Properties)
            {
                if (field.Value.Status == ObfuscationStatus.Renamed)
                {
                    this.DumpProperty(this.writer, field.Key, field.Value);
                    numRenamed++;
                }
            }

            //
            // Add a blank line to separate renamed from skipped.
            //
            if (numRenamed < classInfo.Properties.Count)
            {
                this.writer.WriteLine();
            }

            foreach (KeyValuePair<PropertyKey, ObfuscatedThing> field in classInfo.Properties)
            {
                if (field.Value.Status == ObfuscationStatus.Skipped)
                {
                    this.DumpProperty(this.writer, field.Key, field.Value);
                }
            }

            //
            // Add a blank line to separate events.
            //
            if (classInfo.Events.Count > 0)
            {
                this.writer.WriteLine();
            }

            numRenamed = 0;
            foreach (KeyValuePair<EventKey, ObfuscatedThing> field in classInfo.Events)
            {
                if (field.Value.Status == ObfuscationStatus.Renamed)
                {
                    this.DumpEvent(this.writer, field.Key, field.Value);
                    numRenamed++;
                }
            }

            //
            // Add a blank line to separate renamed from skipped.
            //
            if (numRenamed < classInfo.Events.Count)
            {
                this.writer.WriteLine();
            }

            foreach (KeyValuePair<EventKey, ObfuscatedThing> field in classInfo.Events)
            {
                if (field.Value.Status == ObfuscationStatus.Skipped)
                {
                    this.DumpEvent(this.writer, field.Key, field.Value);
                }
            }

            this.writer.WriteLine("}");
        }

        private void DumpMethod(MethodKey key, ObfuscatedThing info)
        {
            this.writer.Write("\t{0}(", info.Name);
            for (int i = 0; i < key.Count; i++)
            {
                if (i > 0)
                {
                    this.writer.Write(", ");
                }
                else
                {
                    this.writer.Write(" ");
                }

                this.writer.Write(key.ParamTypes[i]);
            }

            if (info.Status == ObfuscationStatus.Renamed)
            {
                this.writer.WriteLine(" ) -> {0}", info.StatusText);
            }
            else if (info.Status == ObfuscationStatus.Skipped)
            {
                this.writer.WriteLine(" ) skipped:  {0}", info.StatusText);
            }
            else
            {
                throw new ObfuscarException(MessageCodes.dbr136, Translations.GetTranslationOfKey(TranslationKeys.db_dbr135_msg));
            }
        }

        private void DumpField(TextWriter writer, FieldKey key, ObfuscatedThing info)
        {
            if (info.Status == ObfuscationStatus.Renamed)
            {
                writer.WriteLine("\t{0} {1} -> {2}", key.Type, info.Name, info.StatusText);
            }
            else if (info.Status == ObfuscationStatus.Skipped)
            {
                writer.WriteLine("\t{0} {1} skipped:  {2}", key.Type, info.Name, info.StatusText);
            }
            else
            {
                throw new ObfuscarException(MessageCodes.dbr137, Translations.GetTranslationOfKey(TranslationKeys.db_dbr135_msg));
            }
        }

        private void DumpProperty(TextWriter writer, PropertyKey key, ObfuscatedThing info)
        {
            if (info.Status == ObfuscationStatus.Renamed)
            {
                writer.WriteLine("\t{0} {1} -> {2}", key.Type, info.Name, info.StatusText);
            }
            else if (info.Status == ObfuscationStatus.Skipped)
            {
                writer.WriteLine("\t{0} {1} skipped:  {2}", key.Type, info.Name, info.StatusText);
            }
            else
            {
                throw new ObfuscarException(MessageCodes.dbr134, Translations.GetTranslationOfKey(TranslationKeys.db_dbr135_msg));
            }
        }

        private void DumpEvent(TextWriter writer, EventKey key, ObfuscatedThing info)
        {
            if (info.Status == ObfuscationStatus.Renamed)
            {
                writer.WriteLine("\t{0} {1} -> {2}", key.Type, info.Name, info.StatusText);
            }
            else if(info.Status == ObfuscationStatus.Skipped)
            {
                writer.WriteLine("\t{0} {1} skipped:  {2}", key.Type, info.Name, info.StatusText);
            }
            else
            {
                throw new ObfuscarException(MessageCodes.dbr138, Translations.GetTranslationOfKey(TranslationKeys.db_dbr135_msg));
            }
        }

        public void Dispose()
        {
            this.writer.Close();
        }
    }
}
