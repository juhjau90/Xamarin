using System.Text;

namespace Phoneword
{
    /*Class that handles transforming the text into a phonenumber.
     Luokka joka suorittaa tekstin muuntamisen puhelinnumeroksi.*/
    public static class PhonewordTranslator
    {
        public static string ToNumber(string rw)
        {
            if (string.IsNullOrWhiteSpace(rw))
                return null;

            rw = rw.ToUpperInvariant();

            var neNu = new StringBuilder();

            foreach (var l in rw)
            {
                if (" -0123456789".Contains(l))
                    neNu.Append(l);
                else
                {
                    var rst = TranslateToNumber(l);

                    if (rst != null)
                        neNu.Append(rst);
                    else
                        return null;
                }
            }

            return neNu.ToString();
        }

        static bool Contains(this string kyStr, char l)
        {
            return kyStr.IndexOf(l) >= 0;
        }

        static readonly string[] dgs = {
            "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
        };

        static int? TranslateToNumber(char d)
        {
            for(int g=0; g < dgs.Length; g++)
            {
                if (dgs[g].Contains(d))
                    return 2 + g;
            }

            return null;
        }
    }
}
