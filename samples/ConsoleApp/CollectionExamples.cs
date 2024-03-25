using System.Collections.Generic;
using PlainBytes.System.Extensions.Collections;

namespace ConsoleApp
{
    public class CollectionExamples
    {
        public void CollectionAccessExtensions()
        {
            var collection = new[] {1, 2, 3};

            _ = collection.HasIndex(4);
            _ = collection.AtIndexOrDefault(4);
            _ = collection.AtIndexOrFallback(4, -1);
            _ = collection.IsEmpty();

            var directory = new Dictionary<int, int>();

            _ = directory.AtKeyOrFallback(4, -1);
        }

        public void IterationExamples()
        {
            // Extensions for IList<T>, IEnumerable<T> and Enumerable

            var collection = new[] {1, 2, 3};

            collection.For((index, value) => {});
            collection.ForEach(value => {});

            _ = collection.SelectWithIndex((index, value) => value);
            _ = collection.SelectTypeOf<double>();

            var secondCollection = new[] {4, 5};

            _ = collection.Append(secondCollection);
        }
    }
}