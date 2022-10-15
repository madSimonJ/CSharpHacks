using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpHacks.Tests
{
    public class TaskTests
    {
        [Fact]
        public async Task OnCompletedSuccessfully_ShouldExecuteAction_WhenTaskCompletesSuccessfully()
        {
            var tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(10000);
            var token = tokenSource.Token;

            var actual = false;
            
            await Task.Delay(1000, token)
                .OnCompletedSuccessfully(() => actual = true);

            actual.Should().BeTrue();
        }

        [Fact]
        public async Task OnCompletedSuccessfully_ShouldExecuteFunc_WhenTaskCompletesSuccessfully()
        {
            var tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(10000);
            var token = tokenSource.Token;

            static async Task<bool> ReturnFalse(CancellationToken token)
            {
                await Task.Delay(1000, token);
                return false;
            }

            var actual = await Task.Run(() => ReturnFalse(token), token)
                .OnCompletedSuccessfully(state => !state);

            actual.Should().BeTrue();
        }

        [Fact]
        public async Task OnCompletedSuccessfully_ShouldExecuteConvertingFunc_WhenTaskCompletesSuccessfully()
        {
            var tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(10000);
            var token = tokenSource.Token;

            static async Task<bool> ReturnTrue(CancellationToken token)
            {
                await Task.Delay(1000, token);
                return true;
            }

            var actual = await Task.Run(() => ReturnTrue(token), token)
                .OnCompletedSuccessfully(state => state.ToString());

            actual.Should().Be("True");
        }
    }
}
