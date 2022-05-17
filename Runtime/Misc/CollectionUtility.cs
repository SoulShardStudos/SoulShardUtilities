using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SoulShard.Utils
{
    /// <summary>
    /// contains some basic functions to generate and manager collections
    /// </summary>
    public static class CollectionUtility
    {
        #region Other
        /// <summary>
        /// gets a specific component from every gameobject in the list, and returns a list of the components.
        /// </summary>
        /// <typeparam name="T">the component to get from every object</typeparam>
        /// <param name="toGetComponentFrom">the array to get the components from</param>
        /// <returns>the collection of monobehaviors</returns>
        public static IEnumerable<T> GetComponentFromGameObjectList<T>(
            IEnumerable<GameObject> toGetComponentFrom
        ) where T : Component
        {
            int ct = toGetComponentFrom.Count();
            T[] @return = new T[ct];
            int i = 0;
            foreach (GameObject g in toGetComponentFrom)
            {
                @return[i] = g.GetComponent<T>();
                i++;
            }
            return @return;
        }

        public static uint CountOccurences<T>(this IEnumerable<T> collection, T occurence)
            where T : IEquatable<T>
        {
            uint count = 0;
            foreach (T t in collection)
                if (t.Equals(occurence))
                    count++;
            return count;
        }

        #endregion
        #region Collection Generation
        /// <summary>
        /// generates a new 2d array with a default value
        /// TODO: DEPRECATE WHEN DOTNET 6 COMES TO UNITY
        /// </summary>
        /// <typeparam name="T">the type of the collection</typeparam>
        /// <param name="xLength">the x length of the array</param>
        /// <param name="yLength">the y length of the array</param>
        /// <param name="defaultValue">the default value for the array</param>
        /// <returns>the new collection</returns>
        public static T[,] Gen<T>(int xLength, int yLength, T defaultValue)
        {
            T[,] @return = new T[xLength, yLength];
            if (defaultValue == null)
                return null;
            for (int i = 0; i < xLength; i++)
            {
                for (int e = 0; e < yLength; e++)
                    @return[i, e] = defaultValue;
            }
            return @return;
        }

        /// <summary>
        /// generates a new array with a default value
        /// TODO: DEPRECATE WHEN DOTNET 6 COMES TO UNITY
        /// </summary>
        /// <typeparam name="T">the type of the collection</typeparam>
        /// <param name="length">the length of the new collection</param>
        /// <param name="defaultValue">the default value of the collection</param>
        /// <returns>the new collection</returns>
        public static T[] Gen<T>(int length, T defaultValue)
        {
            T[] @return = new T[length];
            for (int i = 0; i < length; i++)
                @return[i] = defaultValue;
            return @return;
        }

        #endregion
        #region Index Management Methods
        /// <summary>
        /// checks whether an index exists within a collection
        /// </summary>
        /// <param name="index">the index within the collection</param>
        /// <param name="collectionSize">the size of the collection</param>
        /// <returns></returns>
        public static bool IndexExists(int index, int collectionSize) =>
            index < collectionSize && index >= 0;

        #region 2D flattened array helpers, ydominant
        /// <summary>
        /// gets the index within a flattened 2d array from a 2d position in that array
        /// </summary>
        /// <param name="pos"> the 2d position within the array</param>
        /// <param name="collectionSize"> the size of the collection along the virtual x axis</param>
        /// <returns>the index within the collection</returns>
        public static int GetIndex(Vector2Int pos, int collectionSize) =>
            pos.x + pos.y * collectionSize;

        /// <summary>
        /// returns the 2d position from an index within the flattened 2d collection
        /// </summary>
        /// <param name="index">the index within the collection</param>
        /// <param name="collectionSize">the size of the collection along the virtual x axis</param>
        /// <returns>the 2d position this index represents</returns>
        public static Vector2Int GetPosition(int index, int collectionSize) =>
            new Vector2Int(index % collectionSize, (int)Mathf.Floor(index / collectionSize));

        /// <summary>
        /// checks if a position exists within the 2d collection
        /// </summary>
        /// <param name="position">the position within the collection</param>
        /// <param name="size">the size of the collection</param>
        /// <returns></returns>
        public static bool PositionExists(Vector2Int position, Vector2Int size) =>
            position.x < size.x && position.y < size.y;
        #endregion
        #endregion
        #region Better To String
        /// <summary>
        /// converts the contents of a collection to a string, in a format where you can read the collection contents
        /// </summary>
        /// <typeparam name="T">the collection type</typeparam>
        /// <param name="collection">the collection to convert</param>
        /// <returns>the formatted string</returns>
        public static string BetterToString<T>(
            this IEnumerable<T> collection,
            string delimiter = ", "
        )
        {
            if (collection == null)
                return null;
            string @return = "";
            int ct = collection.Count();
            int i = 0;
            foreach (T t in collection)
            {
                @return += t?.ToString() + (i + 1 != ct ? delimiter : "");
                i++;
            }
            return @return;
        }

        /// <summary>
        /// Converts the contents of a collection to a string, in a format where you can read the collection contents.
        /// </summary>
        /// <typeparam name="T">the collection type</typeparam>
        /// <param name="collection">the collection to convert</param>
        /// <returns>the formatted string</returns>
        public static string BetterToString<T>(
            this IEnumerable<T> collection,
            Func<T, string> stringConversion,
            string delimiter = ", "
        )
        {
            if (collection == null)
                return null;
            int ct = collection.Count();
            string @return = "";
            int i = 0;
            foreach (T t in collection)
            {
                @return += stringConversion(t) + (i + 1 != ct ? delimiter : "");
                i++;
            }
            return @return;
        }
        #endregion
    }
}
