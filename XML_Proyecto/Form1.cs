namespace XML_Proyecto
{
    public partial class Form1 : Form
    {
        private List<Producto> productos = new List<Producto>();
        private XMLManager xmlManager = new XMLManager();
        private string filePath = "productos.xml";
        public Form1()
        {
            InitializeComponent();
        }
        //Botón añadir
        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = textBox2.Text;
            decimal precio = decimal.Parse(textBox3.Text);
            int cantidad = int.Parse(textBox4.Text);

            Producto producto = new Producto
            {
                Nombre = nombre,
                Precio = precio,
                Cantidad = cantidad
            };
            productos.Add(producto);
            MostrarProductos();
            LimpiarCampos();
        }
        //Guardar XML
        private void button2_Click(object sender, EventArgs e)
        {
            xmlManager.SerializarListaDeProductos(productos, filePath);
            MessageBox.Show("Lista de productos guardada en XML.");
        }
        //Mostrar XML
        private void button3_Click(object sender, EventArgs e)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("El archivo XML no existe en la ubicación especificada");
                return;
            }
            productos = xmlManager.DeserializarListaProductos(filePath);
            MostrarProductos();
        }
        //Borrar archivo XML
        private void button4_Click(object sender, EventArgs e)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                MessageBox.Show("Archivo borrado eliminado con éxito.");
                productos.Clear();
                MostrarProductos();
            }
            else
            {
                MessageBox.Show("Error al eliminar el archivo");
            }
        }
        private void MostrarProductos()
        {
            textXML.Clear();
            foreach (var producto in productos)
            {
                textXML.AppendText($"Nombre: {producto.Nombre}, Precio: {producto.Precio}, Cantidad: {producto.Cantidad}\n");
            }
        }
        private void LimpiarCampos()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
