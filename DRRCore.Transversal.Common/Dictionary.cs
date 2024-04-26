namespace DRRCore.Transversal.Common
{
    public static class Dictionary
    {
        public static Dictionary<string, string> EnvironmentDictionary=new(){
                {"P", "PRODUCTION"},
                {"Q", "QUALITY"},
                {"D", "DEVELOPMENT"}
         };
        public static Dictionary<string, string> PriorityDictionary = new(){
                {"L", "LOW"},
                {"M", "MEDIA"},
                {"H", "HIGH"}
         };
        public static Dictionary<int, string?> LanguageMigra = new(){
                {0, null},
                {1, "I"},
                {2, "E"},
                {3, "A"}
         };

    }
}
