using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTree2
{
    public class MappingGenerator
    {
        public Func<TSource, TDestination> Generate<TSource, TDestination>()
        {
            var sourceParam = Expression.Parameter(typeof(TSource));
            var bindings = new List<MemberBinding>();

            foreach (var sourceProperty in typeof(TSource).GetProperties())
            {
                if (!sourceProperty.CanRead)
                    continue;

                var targetProperty = typeof(TDestination).GetProperty(sourceProperty.Name);
                if (targetProperty == null)
                    continue;

                if (!targetProperty.CanWrite)
                    throw new ArgumentException("Property " + sourceProperty.Name + " is not writable in " +
                                                typeof(TDestination).FullName);

                if (!targetProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                    throw new ArgumentException("Property " + sourceProperty.Name + " has an incompatible type in " +
                                                typeof(TDestination).FullName);

                bindings.Add(Expression.Bind(targetProperty, Expression.Property(sourceParam, sourceProperty)));
            }
            Expression initializer = Expression.MemberInit(Expression.New(typeof(TDestination)), bindings);
            return Expression.Lambda<Func<TSource, TDestination>>(initializer, sourceParam).Compile();
        }
    }
}