using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class User
    {
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    
    public Gjinia gjinia { get; set; }
    public List<Shpenzimet> shpenzimet { get; set; }
}

    public class Shpenzimet
{
    TipiShpenzimit tipi { get; set; }
    
    ushort viti { get; set; }

    MuajiVitit muaji { get; set; }

    uint cmimi { get; set; }

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

    public enum Gjinia
{
    Mashkull,
    Femer,
    NonBinary
}