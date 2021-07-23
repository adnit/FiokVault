using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace FiokVaultServer
{
    class SignXML
    {
        public SignXML(XmlDocument xmlDoc)
        {
            try
            {
                // Create a new CspParameters object to specify
                // a key container.
                CspParameters cspParams = new CspParameters();
                cspParams.KeyContainerName = "XML_DSIG_RSA_KEY";

                // Create a new RSA signing key and save it in the container.
                RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider(cspParams);

                string Certificate = "..\\..\\..\\Certificate.crt";

                string privateKey = File.ReadAllText("..\\..\\..\\certificate\\privkey.pem");
                rsaKey.ImportFromPem(privateKey.ToCharArray());

                // Create a new XML document.
                // Load an XML file into the XmlDocument object.

                // Sign the XML document.
                SignXMLDocument(xmlDoc, rsaKey);

                Console.WriteLine("XML file signed.");

                // Save the document.
                xmlDoc.Save("test.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // Sign an XML file.
        // This document cannot be verified unless the verifying
        // code has the key with which it was signed.
        public static void SignXMLDocument(XmlDocument xmlDoc, RSA rsaKey)
        {
            // Check arguments.
            if (xmlDoc == null)
                throw new ArgumentException(nameof(xmlDoc));
            if (rsaKey == null)
                throw new ArgumentException(nameof(rsaKey));

            // Create a SignedXml object.
            SignedXml signedXml = new SignedXml(xmlDoc);

            // Add the key to the SignedXml document.
            signedXml.SigningKey = rsaKey;

            // Create a reference to be signed.
            Reference reference = new Reference();
            reference.Uri = "";

            // Add an enveloped transformation to the reference.
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            // Add the reference to the SignedXml object.
            signedXml.AddReference(reference);

            // Compute the signature.
            signedXml.ComputeSignature();

            // Get the XML representation of the signature and save
            // it to an XmlElement object.
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            // Append the element to the XML document.
            xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));
        }

    }
}
