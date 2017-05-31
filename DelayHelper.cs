using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SyUtilsCore
{
    public static class DelayHelper
    {
        public static void DelayAction(int millisecond, Action action)
        {
            if (action == null)
                return;

            new Task(() =>
            {
                Thread.Sleep(millisecond);
                action();
            }).Start();
        }

        public static void DelayAction<T>(int millisecond, Action<T> action, T obj)
        {
            if (action == null)
                return;

            new Task(() =>
            {
                Thread.Sleep(millisecond);
                action(obj);
            }).Start();
        }

        public static void DelayAction<T1, T2>(int millisecond, Action<T1, T2> action, T1 arg1, T2 arg2)
        {
            if (action == null)
                return;

            new Task(() =>
            {
                Thread.Sleep(millisecond);
                action(arg1, arg2);
            }).Start();
        }

        public static void DelayAction<T1, T2, T3>(int millisecond, Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3)
        {
            if (action == null)
                return;

            new Task(() =>
            {
                Thread.Sleep(millisecond);
                action(arg1, arg2, arg3);
            }).Start();
        }

        public static void DelayFunc<TResult>(int millisecond, Func<TResult> func, TResult result)
        {
            if (func == null)
                return;

            new Task(() =>
            {
                Thread.Sleep(millisecond);
                result = func();
            }).Start();
        }

        public static void DelayFunc<T, TResult>(int millisecond, Func<T, TResult> func, T arg, TResult result)
        {
            if (func == null)
                return;

            new Task(() =>
            {
                Thread.Sleep(millisecond);
                result = func(arg);
            }).Start();
        }

        public static void DelayFunc<T1, T2, TResult>(int millisecond, Func<T1, T2, TResult> func, T1 arg1, T2 arg2, TResult result)
        {
            if (func == null)
                return;

            new Task(() =>
            {
                Thread.Sleep(millisecond);
                result = func(arg1, arg2);
            }).Start();
        }

        public static void DelayFunc<T1, T2, T3, TResult>(int millisecond, Func<T1, T2, T3, TResult> func, T1 arg1, T2 arg2, T3 arg3, TResult result)
        {
            if (func == null)
                return;

            new Task(() =>
            {
                Thread.Sleep(millisecond);
                result = func(arg1, arg2, arg3);
            }).Start();
        }
    }
}
