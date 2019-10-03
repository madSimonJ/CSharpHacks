using System;
using System.Diagnostics;

namespace CSharpHacks
{
    public static class TryCatchHacks
    {
        public static void TryCatch<TException>(Action @try, Action<Exception> @catch)
            where TException : Exception
        {
            try { @try(); } catch (TException ex) { @catch(ex); }
        }

        public static void TryOrFailFast<TException>(Action @try)
            where TException : Exception
            => TryCatch<TException>(@try, (ex) => Environment.FailFast(ex.Message, ex));

        public static void TryOrThrow<TException>(Action @try)
            where TException : Exception
            => TryCatch<TException>(@try, (ex) => { throw ex; });

        public static void TryOrLogToConsole<TException>(Action @try)
            where TException : Exception
            => TryCatch<TException>(@try, (ex) => { Console.WriteLine(ex); });

        public static void TryOrLogToDebug<TException>(Action @try)
            where TException : Exception
            => TryCatch<TException>(@try, (ex) => { Debug.WriteLine(ex); });
    }
}
