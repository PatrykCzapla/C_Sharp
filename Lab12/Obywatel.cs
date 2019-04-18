using System;
using System.IO;
using System.Runtime.Serialization;

namespace p3z
{
    [Serializable]
	public class Obywatel: IDeserializationCallback
	{
		public string pesel;

        [NonSerialized]
		public string miasto;

        public string kodPocztowy;

        public void OnDeserialization(object sender)
        {
            miasto = "";
            string kp = kodPocztowy;
            StreamReader sr = new StreamReader("kody.csv");
            sr.ReadLine();
            while (sr.EndOfStream == false)
            {             
                string tmp = sr.ReadLine();
                if (tmp.Contains(kp))
                {
                    string[] result = tmp.Split(';');
                    for (int i = 1; i < result.Length; i++)
                    {
                        miasto += result[i];
                        if (i != result.Length - 1) miasto += " ";
                    }
                    return;
                }
            }
        }
    }
}
