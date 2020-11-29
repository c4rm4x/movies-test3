using System;
using System.Linq.Expressions;

namespace Movies.Application.Tests.Internal
{
    /// <summary>
    /// Class to build random instances of type T
    /// </summary>
    /// <typeparam name="T">The type of the instace to create</typeparam>
    public class Builder<T> : AbstractBuilder<T>
        where T : class
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">The context (if any)</param>
        public Builder(Context context = null) : base(context)
        {
        }

        /// <summary>
        /// Sets the value of the given private property and returns this instance of builder
        /// </summary>
        /// <typeparam name="TProperty">Type of the property to set</typeparam>
        /// <param name="setter">The expression to get the property to be set</param>
        /// <param name="value">The new value</param>
        /// <returns>This builder</returns>
        public new Builder<T> With<TProperty>(
            Expression<Func<T, TProperty>> setter, TProperty value)
        {
            base.With(setter, value);

            return this;
        }
    }
}
