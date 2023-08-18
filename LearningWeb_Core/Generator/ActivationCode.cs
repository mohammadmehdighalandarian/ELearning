namespace LearningWeb_Core.Generator
{
    public class ActivationCode
    {
        public static string GenerateActivationCode()
        {
            return Guid.NewGuid().ToString().Replace("-","");
        }
    }
}
