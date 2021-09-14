using System;
using System.Threading.Tasks;

namespace ChainOfResponsability.Rules
{
    public class ThirdRule : Rule
    {
        public override async Task Process(Context context)
        {
            // Check for condition to stop, will pass
            if (context.Value > 20)
                return;

            context.Value = 30;
            context.Message += ", Third";

            Console.WriteLine($"Value: {context.Value}, Message: {context.Message}");

            if (Next != null)
                await Next.Process(context);
        }
    }
}