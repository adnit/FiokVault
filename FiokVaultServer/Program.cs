using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace FiokVaultServer
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (File.Exists("books1.xml"))
            {
                using (XmlWriter writer = XmlWriter.Create("books134.xml"))
                {
                    writer.WriteStartElement("book");
                    writer.WriteElementString("title", "Graphics Programming using GDI+");
                    writer.WriteElementString("author", "Adnit Chand");
                    writer.WriteElementString("publisher", "Addison-Wesley");
                    writer.WriteElementString("price", "64.95");
                    writer.WriteEndElement();
                    writer.Flush();
                }
            }
            else
            {
                using (XmlWriter writer = XmlWriter.Create("books22.xml"))
                {
                    writer.WriteStartElement("book");
                    writer.WriteElementString("title", "Graphics Programming using GDI+");
                    writer.WriteElementString("author", "Adnit Chand");
                    writer.WriteElementString("publisher", "Addison-Wesley");
                    writer.WriteElementString("price", "64.95");
                    writer.WriteEndElement();
                    writer.Flush();
                }
            }
            Application.Run(new Form1());

            
        }

        private static void CreateUser(XmlWriter writer)
        {
            writer.WriteStartElement("book");
            writer.WriteElementString("title", "Graphics Programming using GDI+");
            writer.WriteElementString("author", "Adnit Chand");
            writer.WriteElementString("publisher", "Addison-Wesley");
            writer.WriteElementString("price", "64.95");
            writer.WriteEndElement();
            writer.Flush();
        }

    }

}
