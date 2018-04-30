namespace UsefulStuff
{
    public static class CharExtensions
    {
        public static bool IsNumeric(this char c) => char.IsDigit(c) || c == '+' || c == '-' || c == '.';
    }
}