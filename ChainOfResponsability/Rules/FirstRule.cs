using System;
using System.Threading.Tasks;

namespace ChainOfResponsability.Rules
{
    public class FirstRule : Rule
    {
        public override async Task Process(Context context)
        {
            // Check for condition to stop, will pass
            if (context.Value != 0)
                return;

            context.Value = 10;
            context.Message += "First";
            
            Console.WriteLine($"Value: {context.Value}, Message: {context.Message}");

            if (Next != null)
                await Next.Process(context);
        }
    }
}