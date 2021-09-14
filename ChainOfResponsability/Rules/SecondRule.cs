using System;
using System.Threading.Tasks;

namespace ChainOfResponsability.Rules
{
    public class SecondRule : Rule
    {
        public override async Task Process(Context context)
        {
            // Check for condition to stop, will pass
            if (context.Value > 10)
                return;

            context.Value = 20;
            context.Message += ", Second";

            Console.WriteLine($"Value: {context.Value}, Message: {context.Message}");

            if (Next != null)
                await Next.Process(context);
        }
    }
}