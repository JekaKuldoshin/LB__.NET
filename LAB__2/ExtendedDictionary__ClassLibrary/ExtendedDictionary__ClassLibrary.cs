using System;
using System.Collections.Generic;
using ExtendedDictionaryElement__ClassLibrary;

namespace ExtendedDictionary__ClassLibrary
{

    public class ExtendedDictionary<T, U, V>
    {
        private List<ExtendedDictionaryElement<T, U, V>> elements = new List<ExtendedDictionaryElement<T, U, V>>();

        public void Add(T key, U value1, V value2)
        {
            ExtendedDictionaryElement<T, U, V> element = new ExtendedDictionaryElement<T, U, V>(key, value1, value2);
            elements.Add(element);
        }

        public void Remove(T key)
        {
            ExtendedDictionaryElement<T, U, V> elementToRemove = elements.Find(e => EqualityComparer<T>.Default.Equals(e.Key, key));
            if (elementToRemove != null)
            {
                elements.Remove(elementToRemove);
            }
        }

        public bool ContainsKey(T key)
        {
            return elements.Exists(e => EqualityComparer<T>.Default.Equals(e.Key, key));
        }

        public bool ContainsValues(U value1, V value2)
        {
            return elements.Exists(e => EqualityComparer<U>.Default.Equals(e.Value1, value1) && EqualityComparer<V>.Default.Equals(e.Value2, value2));
        }

        public ExtendedDictionaryElement<T, U, V> this[T key]
        {
            get { return elements.Find(e => EqualityComparer<T>.Default.Equals(e.Key, key)); }
        }

        public int Count
        {
            get { return elements.Count; }
        }
    }

}