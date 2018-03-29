using System;

namespace ExpressionTree2
{
    public class Mapper<TSource, TDestination>
    {
        private readonly Func<TSource, TDestination> _func;
        public Mapper(Func<TSource, TDestination> func)
        {
            _func = func;
        }

        public TDestination Map(TSource source)
        {
            return _func(source);
        }
    }
}