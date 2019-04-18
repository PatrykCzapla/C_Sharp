using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace p3z
{
    public class EwidencjaLundosci
    {
        public readonly string name = "Ewidencja Ludnosci";

        public EwidencjaLundosci()
        {
            if (Directory.Exists(name))
            {
                Directory.Delete(name, true);
            }
            Directory.CreateDirectory(name);
        }

        public void SerializujObywatela(Obywatel o, string path)
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream fs = new FileStream(path, FileMode.CreateNew);
            bf.Serialize(fs, o);

            fs.Close();
        }

        public Obywatel DeserializujObywatela(string path)
        {
            BinaryFormatter bf = new BinaryFormatter();

            FileStream fs = new FileStream(path, FileMode.Open);
            Obywatel o = (Obywatel)bf.Deserialize(fs);

            fs.Close();

            return o;
        }

        public void DodajObywatela(Obywatel o)
        {
            string path = name;
            string bd = o.pesel[4].ToString() + o.pesel[5].ToString();
            string bm = o.pesel[2].ToString() + o.pesel[3].ToString();
            string by = o.pesel[0].ToString() + o.pesel[1].ToString();

            path += "/" + by;

            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }

            path += "/" + bm;

            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }

            path += "/" + bd;

            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }

            path += "/" + o.pesel + ".bin";

            if (File.Exists(path))
            {
                Console.WriteLine("Obywatel o podanym peselu istnieje już w bazie");
                return;
            }
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, o);
            fs.Close();
        }

        public void UsunObywatela(string pesel)
        {
            string bd = pesel[4].ToString() + pesel[5].ToString();
            string bm = pesel[2].ToString() + pesel[3].ToString();
            string by = pesel[0].ToString() + pesel[1].ToString();
            string path = name + "/" + by + "/" + bm + "/" + bd;

            if (!File.Exists(path + "/" + pesel + ".bin"))
            {
                Console.WriteLine("Obywatel o peselu {0} nie istnieje w bazie", pesel);
                return;
            }

            File.Delete(path + "/" + pesel + ".bin");
            Console.WriteLine("Usunięto obywatel o peselu {0}",pesel);

            while (path != name)
            {
                if (Directory.GetFileSystemEntries(path).Length == 0) return;               
                Directory.Delete(path);
                path = Directory.GetParent(path).FullName;
            }
        }

        public int IleUrodzonychWDniuTygodnia(DayOfWeek en)
        {
            int result = 0;
            DirectoryInfo di = new DirectoryInfo(name);
            foreach (var elem in di.GetFiles("*.bin",System.IO.SearchOption.AllDirectories))
            {
                if (elem.ToString()[1].Equals("t")) continue;
                Console.WriteLine(elem.Name);
                Console.WriteLine(elem.Name[0] + elem.Name[1]);
                //Console.WriteLine(elem.Name[0] + elem.Name[1]); 
                //Console.WriteLine(elem.Name[2] + elem.Name[3]);
                //Console.WriteLine(elem.Name[4] + elem.Name[5]);
                //DateTime dt = new DateTime((int)(elem.Name[0] + elem.Name[1]), elem.Name[2] + elem.Name[3], elem.Name[4] + elem.Name[5]);
                //if (dt.DayOfWeek == en) result++;
            }
            return result;
        }




    }
}
