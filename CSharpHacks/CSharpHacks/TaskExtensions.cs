using System;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace CSharpHacks
{
    // Accreditation: Theodor Zoulias - https://stackoverflow.com/a/60087110/2020124

    /// <summary>
    ///     Extension methods to aid working with Tasks.
    /// </summary>
    public static class TaskExtensions
    {
        /// <summary>
        ///     Executes an action when a task has been completed successfully.
        /// </summary>
        /// <param name="task">The task to await the completion of.</param>
        /// <param name="continuation">The action to perform after the task has completed.</param>
        /// <param name="continueOnCapturedContext"><c>true</c> to attempt to marshall the continuation back to the original context captured, otherwise <c>false</c>.</param>
        public static async Task OnCompletedSuccessfully(this Task task, Action continuation,
            bool continueOnCapturedContext = true)
        {
            await task.ConfigureAwait(continueOnCapturedContext);
            continuation();
        }

        /// <summary>
        ///     Executes an action when a task has been completed successfully.
        /// </summary>
        /// <param name="task">The task to await the completion of.</param>
        /// <param name="continuation">The function to perform after the task has completed.</param>
        /// <param name="continueOnCapturedContext"><c>true</c> to attempt to marshall the continuation back to the original context captured, otherwise <c>false</c>.</param>
        public static async Task OnCompletedSuccessfully(this Task task, Func<Task> continuation,
            bool continueOnCapturedContext = true)
        {
            await task.ConfigureAwait(continueOnCapturedContext);
            await continuation().ConfigureAwait(false);
        }

        /// <summary>
        ///     Executes an action when a task has been completed successfully.
        /// </summary>
        /// <param name="task">The task to await the completion of.</param>
        /// <param name="continuation">The action to perform after the task has completed.</param>
        /// <param name="continueOnCapturedContext"><c>true</c> to attempt to marshall the continuation back to the original context captured, otherwise <c>false</c>.</param>
        public static async Task OnCompletedSuccessfully<TResult>(
            this Task<TResult> task, Action<TResult> continuation,
            bool continueOnCapturedContext = true)
        {
            var result = await task.ConfigureAwait(continueOnCapturedContext);
            continuation(result);
        }

        /// <summary>
        ///     Executes an action when a task has been completed successfully.
        /// </summary>
        /// <param name="task">The task to await the completion of.</param>
        /// <param name="continuation">The function to perform after the task has completed.</param>
        /// <param name="continueOnCapturedContext"><c>true</c> to attempt to marshall the continuation back to the original context captured, otherwise <c>false</c>.</param>
        public static async Task OnCompletedSuccessfully<TResult>(
            this Task<TResult> task, Func<TResult, Task> continuation,
            bool continueOnCapturedContext = true)
        {
            var result = await task.ConfigureAwait(continueOnCapturedContext);
            await continuation(result).ConfigureAwait(false);
        }

        /// <summary>
        ///     Executes an action when a task has been completed successfully.
        /// </summary>
        /// <param name="task">The task to await the completion of.</param>
        /// <param name="continuation">The function to perform after the task has completed.</param>
        /// <param name="continueOnCapturedContext"><c>true</c> to attempt to marshall the continuation back to the original context captured, otherwise <c>false</c>.</param>
        public static async Task<TNewResult> OnCompletedSuccessfully<TResult, TNewResult>(
            this Task<TResult> task, Func<TResult, TNewResult> continuation,
            bool continueOnCapturedContext = true)
        {
            var result = await task.ConfigureAwait(continueOnCapturedContext);
            return continuation(result);
        }

        /// <summary>
        ///     Executes an action when a task has been completed successfully.
        /// </summary>
        /// <param name="task">The task to await the completion of.</param>
        /// <param name="continuation">The function to perform after the task has completed.</param>
        /// <param name="continueOnCapturedContext"><c>true</c> to attempt to marshall the continuation back to the original context captured, otherwise <c>false</c>.</param>
        public static async Task<TNewResult> OnCompletedSuccessfully<TResult, TNewResult>(
            this Task<TResult> task, Func<TResult, Task<TNewResult>> continuation,
            bool continueOnCapturedContext = true)
        {
            var result = await task.ConfigureAwait(continueOnCapturedContext);
            return await continuation(result).ConfigureAwait(false);
        }
    }
}