using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class XMLManager
{
    public void SerializarListaDeProductos(List<Producto> productos, string filePath)

    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Producto>));
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            serializer.Serialize(sw, productos);
        }
    }
    public List<Producto> DeserializarListaProductos(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Producto>));
        using (StreamReader reader = new StreamReader(filePath))
        {
            return (List<Producto>)serializer.Deserialize(reader);
        }
    }
}