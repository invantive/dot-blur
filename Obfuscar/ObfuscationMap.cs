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

namespace Obfuscar
{
    internal class ObfuscationMap
    {
        public Dictionary<TypeKey, ObfuscatedClass> ClassMap { get; } = new Dictionary<TypeKey, ObfuscatedClass>();

        public List<ObfuscatedThing> Resources { get; } = new List<ObfuscatedThing>();

        public ObfuscatedClass GetClass(TypeKey key)
        {
            if (!this.ClassMap.TryGetValue(key, out ObfuscatedClass? c))
            {
                c = new ObfuscatedClass(key.ToString());
                this.ClassMap[key] = c;
            }

            return c;
        }

        public ObfuscatedThing GetField(FieldKey key)
        {
            ObfuscatedClass c = this.GetClass(key.TypeKey);

            if (!c.Fields.TryGetValue(key, out ObfuscatedThing? t))
            {
                t = new ObfuscatedThing(key.ToString());
                c.Fields[key] = t;
            }

            return t;
        }

        public ObfuscatedThing GetMethod(MethodKey key)
        {
            ObfuscatedClass c = this.GetClass(key.TypeKey);

            if (!c.Methods.TryGetValue(key, out ObfuscatedThing? t))
            {
                t = new ObfuscatedThing(key.ToString());
                c.Methods[key] = t;
            }

            return t;
        }

        public ObfuscatedThing GetProperty(PropertyKey key)
        {
            ObfuscatedClass c = this.GetClass(key.TypeKey);

            if (!c.Properties.TryGetValue(key, out ObfuscatedThing? t))
            {
                t = new ObfuscatedThing(key.ToString());
                c.Properties[key] = t;
            }

            return t;
        }

        public ObfuscatedThing GetEvent(EventKey key)
        {
            ObfuscatedClass c = this.GetClass(key.TypeKey);

            if (!c.Events.TryGetValue(key, out ObfuscatedThing? t))
            {
                t = new ObfuscatedThing(key.ToString());
                c.Events[key] = t;
            }

            return t;
        }

        public void UpdateType(TypeKey key, ObfuscationStatus status, string text)
        {
            ObfuscatedClass c = this.GetClass(key);

            c.Update(status, text);
        }

        public void UpdateField(FieldKey key, ObfuscationStatus status, string text)
        {
            ObfuscatedThing f = this.GetField(key);

            f.Update(status, text);
        }

        public void UpdateMethod(MethodKey key, ObfuscationStatus status, string text)
        {
            ObfuscatedThing m = this.GetMethod(key);

            m.Update(status, text);
        }

        public void UpdateProperty(PropertyKey key, ObfuscationStatus status, string text)
        {
            ObfuscatedThing m = this.GetProperty(key);

            m.Update(status, text);
        }

        public void UpdateEvent(EventKey key, ObfuscationStatus status, string text)
        {
            ObfuscatedThing m = this.GetEvent(key);

            m.Update(status, text);
        }

        public void AddResource(string name, ObfuscationStatus status, string text)
        {
            ObfuscatedThing r = new ObfuscatedThing(name);

            r.Update(status, text);

            this.Resources.Add(r);
        }

        public IEnumerable<(TypeKey key, string statusText)> FindClasses(string name)
        {
            foreach (KeyValuePair<TypeKey, ObfuscatedClass> kvp in this.ClassMap)
            {
                if (kvp.Value.Status == ObfuscationStatus.Renamed)
                {
                    if (kvp.Value.StatusText?.EndsWith(name, StringComparison.Ordinal) ?? false)
                    {
                        yield return (kvp.Key, kvp.Value.StatusText);
                    }
                }
            }
        }
    }
}
