namespace PizzaMore.Utilities
{
    /// <summary>
    /// Usage:
    /// //Hash -> var hash = PasswordHasher.Hash("mypassword");
    /// //Verify -> var result = PasswordHasher.Verify("mypassword", hash);
    /// </summary>
    public class PasswordHasher
    {
        public static string Hash(string password)
        {
            string hashedPassword = "SECRET" + password;
            return hashedPassword;
        }
    }
}
