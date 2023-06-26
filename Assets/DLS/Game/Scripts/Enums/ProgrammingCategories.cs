namespace DLS.Game.Scripts.Enums
{
    [System.Flags]
    public enum ProgrammingCategories
    {
        None = 0,
        Unity = 1 << 0,
        Unreal = 1 << 1,
        ASPDotNet = 1 << 2,
        ObjectOriented = 1 << 3,
        Functional = 1 << 4,
        Web = 1 << 5,
        Console = 1 << 6,
        Algorithms = 1 << 7,
        DataStructures = 1 << 8,
        Networking = 1 << 9,
        Databases = 1 << 10,
        Security = 1 << 11,
        Mobile = 1 << 12,
        MachineLearning = 1 << 13,
        GameDevelopment = 1 << 14,
        Scripting = 1 << 15,
        GUI = 1 << 16,
        Testing = 1 << 17,
        PerformanceOptimization = 1 << 18
    }
}