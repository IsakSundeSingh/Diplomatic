namespace Diplomatic.Core
{
    public interface IField
    {
        bool IsValid { get; }
        string Name { get; }
        string Value { get; set; }

        void Deconstruct(out int x, out int y, out int w, out int h);
    }
}