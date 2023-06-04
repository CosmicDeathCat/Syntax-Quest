namespace DLS.Game.Scripts.Prompts
{
    [System.Flags]
    public enum ProgrammingLanguages
    {
        None = 0,
        C = 1 << 1,
        Cpp = 1 << 2,
        CSharp = 1 << 3,
        Css = 1 << 4,
        Go = 1 << 5,
        Html = 1 << 6,
        Java = 1 << 7,
        Javascript = 1 << 8,
        Perl = 1 << 9,
        Php = 1 << 10,
        Python = 1 << 11,
        R = 1 << 12,
        Ruby = 1 << 13,
        Rust = 1 << 14,
        Sql = 1 << 15,
        Typescript = 1 << 16,
        Visualbasic = 1 << 17
    }
}