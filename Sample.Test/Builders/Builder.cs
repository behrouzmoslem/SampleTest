using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ploeh.AutoFixture;

namespace Sample.Test.Builders
{
    public abstract class Builder<T> where T : class
    {
        protected T entity;
        protected Builder()
        {
            entity = new Fixture().Create<T>();
        }

        public Builder<T> With<TProperty>(Expression<Func<T, TProperty>> propertyPicker, TProperty value)
        {
            var memberSelectorExpression = propertyPicker.Body as MemberExpression;
            if (memberSelectorExpression != null)
            {
                var property = memberSelectorExpression.Member as PropertyInfo;
                property?.SetValue(entity, value, null);
            }
            return this;
        }

        public virtual T Build()
        {
            return entity;
        }

        public virtual List<T> BuildMany(int count)
        {
            var res = new List<T>();
            for (int i = 0; i < count; i++)
                res.Add(Build());
            return res;

        }

        public static implicit operator T(Builder<T> builder)
        {
            return builder.Build();
        }
    }
}
