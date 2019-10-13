using System;
using System.Diagnostics;

namespace CSharpHacks
{
    public static class TryCatchHacks
    {
        public static void TryCatch<TException>(this Action @try, Action<Exception> @catch)
            where TException : Exception
        {
            try { @try(); } catch (TException ex) { @catch(ex); }
        }

        public static void TryOrFailFast<TException>(this Action @try)
            where TException : Exception
            => TryCatch<TException>(@try, (ex) => Environment.FailFast(ex.Message, ex));

        public static void TryOrThrow<TException>(this Action @try)
            where TException : Exception
            => TryCatch<TException>(@try, (ex) => { throw ex; });

        public static void TryOrLogToConsole<TException>(this Action @try)
            where TException : Exception
            => TryCatch<TException>(@try, (ex) => { Console.WriteLine(ex); });

        public static void TryOrLogToDebug<TException>(this Action @try)
            where TException : Exception
            => TryCatch<TException>(@try, (ex) => { Debug.WriteLine(ex); });
    }
}
