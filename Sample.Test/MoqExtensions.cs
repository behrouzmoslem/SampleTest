using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Moq.Language;
using Moq.Language.Flow;

namespace Sample.Test
{
    public static class MoqExtensions
    {
        public static Mock<T> AsMock<T>(this T obj) where T : class
        {
            return Mock.Get(obj);
        }

        public delegate void OutAction<TOut>(out TOut outVal);
        public delegate void OutAction<in T1, TOut>(T1 arg1, out TOut outVal);
        public delegate void OutAction<in T1, TOut1, TOut2>(T1 arg1, out TOut1 outVal1, out TOut2 outVal2);

        public static IReturnsThrows<TMock, TReturn> OutCallback<TMock, TReturn, TOut>(this ICallback<TMock, TReturn> mock, OutAction<TOut> action)
            where TMock : class
        {
            return OutCallbackInternal(mock, action);
        }

        public static IReturnsThrows<TMock, TReturn> OutCallback<TMock, TReturn, T1, TOut>(this ICallback<TMock, TReturn> mock, OutAction<T1, TOut> action)
            where TMock : class
        {
            return OutCallbackInternal(mock, action);
        }
        public static IReturnsThrows<TMock, TReturn> OutCallback<TMock, TReturn, T1, TOut1, TOut2>(this ICallback<TMock, TReturn> mock, OutAction<T1, TOut1, TOut2> action)
            where TMock : class
        {
            return OutCallbackInternal(mock, action);
        }
        private static IReturnsThrows<TMock, TReturn> OutCallbackInternal<TMock, TReturn>(ICallback<TMock, TReturn> mock, object action)
            where TMock : class
        {
            mock.GetType()
                .Assembly.GetType("Moq.MethodCall")
                .InvokeMember("SetCallbackWithArguments", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, mock,
                    new[] { action });
            return mock as IReturnsThrows<TMock, TReturn>;
        }
    }
}
