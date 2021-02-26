using System;

namespace Sat.Recruitment.Utils
{
    public static class EmailExtensions
    {
        public static string Normalize(string email)
        {
            try
            {
                var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

                var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

                aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

                return string.Join("@", new string[] { aux[0], aux[1] });
            }
            catch (Exception ex)
            {
                throw new Exception("Normalize email error: Email format invalid. " + ex.Message.ToString());
            }
        }
    }
}