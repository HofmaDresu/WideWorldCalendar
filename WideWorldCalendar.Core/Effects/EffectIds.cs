namespace WideWorldCalendar.Effects
{
    public static class EffectIds
    {
        public const string EffectGroupName = "HofmaDresu";
        public const string MainButtonEffectName = "MainButtonEffect";


        public static string ResolveEffectId(string effectName)
        {
            return $"{EffectGroupName}.{effectName}";
        }
    }
}
