using System.Threading.Tasks;

namespace WpfApp
{
    public class InnocentLookingClass
    {
        private readonly bool continueOnCapturedContext;

        public InnocentLookingClass(bool continueOnCapturedContext = true)
        {
            this.continueOnCapturedContext = continueOnCapturedContext;

            DoSomeLengthyStuffAsync().Wait();
            // do some more stuff
        }

        private async Task DoSomeLengthyStuffAsync()
        {
            await SomeOtherLengthyStuffAsync().ConfigureAwait(continueOnCapturedContext);
        }

        // other class members

        private Task SomeOtherLengthyStuffAsync()
        {
            return Task.Run(() => { });
        }
    }

}
