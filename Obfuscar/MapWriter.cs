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
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;

namespace Obfuscar
{
    interface IMapWriter
    {
        void WriteMap(ObfuscationMap map);
    }

    class TextMapWriter : IMapWriter, IDisposable
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
                // print the ones we didn't skip first
                if (classInfo.Status == ObfuscationStatus.Renamed)
                {
                    this.DumpClass(classInfo);
                }
            }

            this.writer.WriteLine();
            this.writer.WriteLine("Skipped Types:");

            foreach (ObfuscatedClass classInfo in map.ClassMap.Values)
            {
                // now print the stuff we skipped
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
            else
            {
                Debug.Assert(classInfo.Status == ObfuscationStatus.Skipped, "Status is expected to be either Renamed or Skipped.");
                this.writer.WriteLine("{0} skipped:  {1}", classInfo.Name, classInfo.StatusText);
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

            // add a blank line to separate renamed from skipped...it's pretty.
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

            // add a blank line to separate methods from field...it's pretty.
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

            // add a blank line to separate renamed from skipped...it's pretty.
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

            // add a blank line to separate props...it's pretty.
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

            // add a blank line to separate renamed from skipped...it's pretty.
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

            // add a blank line to separate events...it's pretty.
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

            // add a blank line to separate renamed from skipped...it's pretty.
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
            else
            {
                Debug.Assert(info.Status == ObfuscationStatus.Skipped, "Status is expected to be either Renamed or Skipped.");

                this.writer.WriteLine(" ) skipped:  {0}", info.StatusText);
            }
        }

        private void DumpField(TextWriter writer, FieldKey key, ObfuscatedThing info)
        {
            if (info.Status == ObfuscationStatus.Renamed)
            {
                writer.WriteLine("\t{0} {1} -> {2}", key.Type, info.Name, info.StatusText);
            }
            else
            {
                Debug.Assert(info.Status == ObfuscationStatus.Skipped, "Status is expected to be either Renamed or Skipped.");

                writer.WriteLine("\t{0} {1} skipped:  {2}", key.Type, info.Name, info.StatusText);
            }
        }

        private void DumpProperty(TextWriter writer, PropertyKey key, ObfuscatedThing info)
        {
            if (info.Status == ObfuscationStatus.Renamed)
            {
                writer.WriteLine("\t{0} {1} -> {2}", key.Type, info.Name, info.StatusText);
            }
            else
            {
                Debug.Assert(info.Status == ObfuscationStatus.Skipped, "Status is expected to be either Renamed or Skipped.");
                writer.WriteLine("\t{0} {1} skipped:  {2}", key.Type, info.Name, info.StatusText);
            }
        }

        private void DumpEvent(TextWriter writer, EventKey key, ObfuscatedThing info)
        {
            if (info.Status == ObfuscationStatus.Renamed)
            {
                writer.WriteLine("\t{0} {1} -> {2}", key.Type, info.Name, info.StatusText);
            }
            else
            {
                Debug.Assert(info.Status == ObfuscationStatus.Skipped,"Status is expected to be either Renamed or Skipped.");

                writer.WriteLine("\t{0} {1} skipped:  {2}", key.Type, info.Name, info.StatusText);
            }
        }

        public void Dispose()
        {
            this.writer.Close();
        }
    }

    class XmlMapWriter : IMapWriter, IDisposable
    {
        private readonly XmlWriter writer;

        public XmlMapWriter(TextWriter writer)
        {
            this.writer = new XmlTextWriter(writer);
        }

        public void WriteMap(ObfuscationMap map)
        {
            this.writer.WriteStartElement("mapping");
            this.writer.WriteStartElement("renamedTypes");

            foreach (ObfuscatedClass classInfo in map.ClassMap.Values)
            {
                // print the ones we didn't skip first
                if (classInfo.Status == ObfuscationStatus.Renamed)
                {
                    this.DumpClass(classInfo);
                }
            }
            this.writer.WriteEndElement();
            this.writer.WriteString("\r\n");

            this.writer.WriteStartElement("skippedTypes");

            foreach (ObfuscatedClass classInfo in map.ClassMap.Values)
            {
                // now print the stuff we skipped
                if (classInfo.Status == ObfuscationStatus.Skipped)
                {
                    this.DumpClass(classInfo);
                }
            }
            this.writer.WriteEndElement();
            this.writer.WriteString("\r\n");

            this.writer.WriteStartElement("renamedResources");

            foreach (ObfuscatedThing info in map.Resources)
            {
                if (info.Status == ObfuscationStatus.Renamed)
                {
                    this.writer.WriteStartElement("renamedResource");
                    this.writer.WriteAttributeString("oldName", info.Name);
                    this.writer.WriteAttributeString("newName", info.StatusText);
                    this.writer.WriteEndElement();
                }
            }

            this.writer.WriteEndElement();
            this.writer.WriteString("\r\n");

            this.writer.WriteStartElement("skippedResources");

            foreach (ObfuscatedThing info in map.Resources)
            {
                if (info.Status == ObfuscationStatus.Skipped)
                {
                    this.writer.WriteStartElement("skippedResource");
                    this.writer.WriteAttributeString("name", info.Name);
                    this.writer.WriteAttributeString("reason", info.StatusText);
                    this.writer.WriteEndElement();
                }
            }
            this.writer.WriteEndElement();
            this.writer.WriteString("\r\n");
            this.writer.WriteEndElement();
            this.writer.WriteString("\r\n");
        }

        private void DumpClass(ObfuscatedClass classInfo)
        {
            if (classInfo.Status != ObfuscationStatus.Renamed)
            {
                Debug.Assert(classInfo.Status == ObfuscationStatus.Skipped, "Status is expected to be either Renamed or Skipped.");
                this.writer.WriteStartElement("skippedClass");
                this.writer.WriteAttributeString("name", classInfo.Name);
                this.writer.WriteAttributeString("reason", classInfo.StatusText);
            }
            else
            {
                this.writer.WriteStartElement("renamedClass");
                this.writer.WriteAttributeString("oldName", classInfo.Name);
                this.writer.WriteAttributeString("newName", classInfo.StatusText);
            }

            int numRenamed = 0;
            foreach (KeyValuePair<MethodKey, ObfuscatedThing> method in classInfo.Methods)
            {
                if (method.Value.Status == ObfuscationStatus.Renamed)
                {
                    this.DumpMethod(method.Key, method.Value);
                    numRenamed++;
                }
            }


            foreach (KeyValuePair<MethodKey, ObfuscatedThing> method in classInfo.Methods)
            {
                if (method.Value.Status == ObfuscationStatus.Skipped)
                {
                    this.DumpMethod(method.Key, method.Value);
                }
            }


            foreach (KeyValuePair<FieldKey, ObfuscatedThing> field in classInfo.Fields)
            {
                if (field.Value.Status == ObfuscationStatus.Renamed)
                {
                    this.DumpField(this.writer, field.Key, field.Value);
                }
            }

            //

            foreach (KeyValuePair<FieldKey, ObfuscatedThing> field in classInfo.Fields)
            {
                if (field.Value.Status == ObfuscationStatus.Skipped)
                {
                    this.DumpField(this.writer, field.Key, field.Value);
                }
            }


            foreach (KeyValuePair<PropertyKey, ObfuscatedThing> field in classInfo.Properties)
            {
                if (field.Value.Status == ObfuscationStatus.Renamed)
                {
                    this.DumpProperty(this.writer, field.Key, field.Value);
                }
            }


            foreach (KeyValuePair<PropertyKey, ObfuscatedThing> field in classInfo.Properties)
            {
                if (field.Value.Status == ObfuscationStatus.Skipped)
                {
                    this.DumpProperty(this.writer, field.Key, field.Value);
                }
            }


            foreach (KeyValuePair<EventKey, ObfuscatedThing> field in classInfo.Events)
            {
                if (field.Value.Status == ObfuscationStatus.Renamed)
                {
                    this.DumpEvent(this.writer, field.Key, field.Value);
                }
            }


            foreach (KeyValuePair<EventKey, ObfuscatedThing> field in classInfo.Events)
            {
                if (field.Value.Status == ObfuscationStatus.Skipped)
                {
                    this.DumpEvent(this.writer, field.Key, field.Value);
                }
            }

            this.writer.WriteEndElement();
            this.writer.WriteString("\r\n");
        }

        private void DumpMethod(MethodKey key, ObfuscatedThing info)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}(", info.Name);
            for (int i = 0; i < key.Count; i++)
            {
                if (i > 0)
                {
                    sb.Append(",");
                }

                sb.Append(key.ParamTypes[i]);
            }

            sb.Append(")");

            if (info.Status == ObfuscationStatus.Renamed)
            {
                this.writer.WriteStartElement("renamedMethod");
                this.writer.WriteAttributeString("oldName", sb.ToString());
                this.writer.WriteAttributeString("newName", info.StatusText);
                this.writer.WriteEndElement();
                this.writer.WriteString("\r\n");
            }
            else
            {
                this.writer.WriteStartElement("skippedMethod");
                this.writer.WriteAttributeString("name", sb.ToString());
                this.writer.WriteAttributeString("reason", info.StatusText);
                this.writer.WriteEndElement();
                this.writer.WriteString("\r\n");
            }
        }

        private void DumpField(XmlWriter writer, FieldKey key, ObfuscatedThing info)
        {
            if (info.Status == ObfuscationStatus.Renamed)
            {
                writer.WriteStartElement("renamedField");
                writer.WriteAttributeString("oldName", info.Name);
                writer.WriteAttributeString("newName", info.StatusText);
                writer.WriteEndElement();
                writer.WriteString("\r\n");
            }
            else
            {
                writer.WriteStartElement("skippedField");
                writer.WriteAttributeString("name", info.Name);
                writer.WriteAttributeString("reason", info.StatusText);
                writer.WriteEndElement();
                writer.WriteString("\r\n");
            }
        }

        private void DumpProperty(XmlWriter writer, PropertyKey key, ObfuscatedThing info)
        {
            if (info.Status == ObfuscationStatus.Renamed)
            {
                writer.WriteStartElement("renamedProperty");
                writer.WriteAttributeString("oldName", info.Name);
                writer.WriteAttributeString("newName", info.StatusText);
                writer.WriteEndElement();
                writer.WriteString("\r\n");
            }
            else
            {
                writer.WriteStartElement("skippedProperty");
                writer.WriteAttributeString("name", info.Name);
                writer.WriteAttributeString("reason", info.StatusText);
                writer.WriteEndElement();
                writer.WriteString("\r\n");
            }
        }

        private void DumpEvent(XmlWriter writer, EventKey key, ObfuscatedThing info)
        {
            if (info.Status == ObfuscationStatus.Renamed)
            {
                writer.WriteStartElement("renamedEvent");
                writer.WriteAttributeString("oldName", info.Name);
                writer.WriteAttributeString("newName", info.StatusText);
                writer.WriteEndElement();
                writer.WriteString("\r\n");
            }
            else
            {
                writer.WriteStartElement("skippedEvent");
                writer.WriteAttributeString("name", info.Name);
                writer.WriteAttributeString("reason", info.StatusText);
                writer.WriteEndElement();
                writer.WriteString("\r\n");
            }
        }

        public void Dispose()
        {
            this.writer.Close();
        }
    }
}
