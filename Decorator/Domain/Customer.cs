using System;

namespace Decorator.Domain
{
    public class Customer
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public long LastGet { get; } = DateTime.UtcNow.Ticks;
    }
}