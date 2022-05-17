using Unity.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SoulShard.Utils
{
    public static class NativeCollectionUtility
    {
        /// <summary>
        /// Converts the given collection to a new native array.
        /// </summary>
        /// <param name="collection">The collection to convert</param>
        /// <param name="allocator">The allocation for the array</param>
        /// <typeparam name="T">The type of the contents</typeparam>
        /// <returns>The converted collection.</returns>
        public static NativeArray<T> ToNativeArray<T>(
            this IEnumerable<T> collection,
            Allocator allocator = Allocator.TempJob
        ) where T : unmanaged => new NativeArray<T>(collection.ToArray(), allocator: allocator);

        /// <summary>
        /// Converts the given collection to a new native array.
        /// </summary>
        /// <param name="collection">The collection to convert</param>
        /// <param name="allocator">The allocation for the array</param>
        /// <typeparam name="T">The type of the contents</typeparam>
        /// <returns>The converted collection.</returns>
        public static NativeArray<T> ToNativeList<T>(
            this IEnumerable<T> collection,
            Allocator allocator = Allocator.TempJob
        ) where T : unmanaged
        {
            var res = new NativeList<T>(0, allocator: allocator);
            res.AddRange(collection.ToNativeArray());
            return res;
        }

        /// <summary>
        /// Copies the contents of and disposes the NativeCollection.
        ///
        /// Since this happens often and is 4 lines long, versus an inline, this was made.
        /// </summary>
        /// <param name="collection">The collection to dispose and copy</param>
        /// <typeparam name="T">The type of the contents.</typeparam>
        /// <returns>The contents as an array.</returns>
        public static T[] DisposeCopy<T>(this NativeArray<T> collection) where T : unmanaged
        {
            T[] res = collection.ToArray();
            collection.Dispose();
            return res;
        }

        /// <summary>
        /// Copies the contents of and disposes the NativeCollection.
        ///
        /// Since this happens often and is 4 lines long, versus an inline, this was made.
        /// </summary>
        /// <param name="collection">The collection to dispose and copy</param>
        /// <typeparam name="T">The type of the contents.</typeparam>
        /// <returns>The contents as an array.</returns>
        public static T[] DisposeCopy<T>(this NativeList<T> collection) where T : unmanaged
        {
            T[] res = collection.ToArray();
            collection.Dispose();
            return res;
        }
    }
}
