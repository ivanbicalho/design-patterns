using System;
using System.Threading.Tasks;

namespace ChainOfResponsability.Rules
{
    public class FourthRule : Rule
    {
        public override async Task Process(Context context)
        {
            // Check for condition to stop, will break
            if (context.Value > 22)
                return;
            
            context.Value = 40;
            context.Message += ", Fourth";

            Console.WriteLine($"Value: {context.Value}, Message: {context.Message}");
            
            if (Next !=  null)
                await Next.Process(context);
        }
    }
}