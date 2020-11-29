using System;
using System.Collections.Generic;

namespace Movies.Application.Tests.Internal
{
    /// <summary>
    /// Base class to build a collection of random instances
    /// </summary>
    public static class BuilderCollection
    {
        /// <summary>
        /// Generates the random collection
        /// </summary>
        /// <typeparam name="TEntity">Type of the entities to build</typeparam>
        /// <param name="generator">Entities generator</param>
        /// <param name="minNumberOfItems">Min number of items</param>
        /// <param name="maxNumberOfItems">Max number of items</param>
        /// <returns>The collection of random items</returns>
        public static IEnumerable<TEntity> Generate<TEntity>(
            Func<TEntity> generator,
            int minNumberOfItems = 1,
            int maxNumberOfItems = 10)
        {
            var numberOfItems = GetRand(minNumberOfItems, maxNumberOfItems);

            for (var i = 0; i < numberOfItems; i++)
                yield return generator();
        }

        /// <summary>
        /// Generates the random collection
        /// </summary>
        /// <typeparam name="TEntity">Type of the entities to build</typeparam>
        /// <param name="minNumberOfItems">Min number of items</param>
        /// <param name="maxNumberOfItems">Max number of items</param>
        /// <returns>The collection of random items</returns>
        public static IEnumerable<TEntity> Generate<TEntity>(
            int minNumberOfItems = 1,
            int maxNumberOfItems = 10)
        {
            return Generate(() => ObjectMother.Create<TEntity>(), minNumberOfItems, maxNumberOfItems);
        }

        private static int GetRand(int min, int max) => new Random().Next(min, max);
    }
}
