namespace LearningWeb_Core.Generator
{
    public class UniqCode
    {
        public static string GenerateUniqCode()
        {
            return Guid.NewGuid().ToString().Replace("-","");
        }
    }
}
