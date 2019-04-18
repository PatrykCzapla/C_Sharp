using System.Text;

namespace Lab08_a
{
    public static class ExtensionMethods
    {
        public static string DuplicateCharacters(this string a)
        {
            string result = "";
            char[] s = a.ToCharArray();
            for( int i=0; i < a.Length;i++)
            {
                result += s[i];
                result += s[i];
            }
            return result;
        }

        public static int GetPeopleCountPowerOfTwoAge(this GenericList<Person> a)
        {
            int result = 0;
            foreach(Person elem in a)
            {
                string age = elem.Age.ToString();
                char[] w = age.ToCharArray();
                int pierwszy = age.IndexOf("1");
                int ostatni = age.LastIndexOf("1");
                if (ostatni == pierwszy && ostatni > 0) result++;
            }
            return result;
        }
    }
}
