namespace Diplomatic.Core
{
    public interface IField
    {
        bool IsValid { get; }
        string Name { get; }
        string Value { get; set; }
        string Color { get; }

        void Deconstruct(out double x, out double y, out double w, out double h);
    }
}
