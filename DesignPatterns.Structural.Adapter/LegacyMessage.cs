using System;

namespace DesignPatterns.Structural.Adapter
{
    public class LegacyMessage
    {
        public virtual void Show()
        {
            Console.WriteLine("Show() em LegacyMessage");
        }
    }
}
