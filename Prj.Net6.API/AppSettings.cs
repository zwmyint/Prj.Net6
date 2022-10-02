namespace Prj.Net6.API
{
    public class NestedSettings
    {
        public string Message { get; set; } = null!;
    }
    public class AppSettings
    {
        public int KeyOne { get; set; }
        public bool KeyTwo { get; set; }
        public NestedSettings KeyThree { get; set; } = null!;
    }
}
