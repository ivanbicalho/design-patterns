using System.Threading.Tasks;

namespace ChainOfResponsability.Rules
{
    public abstract class Rule
    {
        protected Rule Next;

        public Rule SetNext(Rule rule)
        {
            Next = rule;
            return Next;
        }

        public abstract Task Process(Context context);
    }
}