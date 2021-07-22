using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class User
    {
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    
    public char gjinia { get; set; }
    public List<Shpenzimet> shpenzimet { get; set; }
}

    public class Shpenzimet
{
    public TipiShpenzimit tipi { get; set; }
    
    public ushort viti { get; set; }

    public MuajiVitit muaji { get; set; }

    public uint cmimi { get; set; }

}

    public enum TipiShpenzimit
{
    Pagese,
    Blerje
}

    public enum MuajiVitit
{
    Janar,
    Shkurt
}