using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea17_ListasDoblementeEnlazadas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Inventario miInventario = new Inventario();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto miProducto = new Producto(Convert.ToInt16(txtCodigo.Text), txtNombre.Text, Convert.ToSingle(txtPrecio.Text), Convert.ToInt16(txtCantidad.Text));
            miInventario.agregarProducto(miProducto);
        }

        private void btnAgregarInicio_Click(object sender, EventArgs e)
        {
            Producto miProducto = new Producto(Convert.ToInt16(txtCodigo.Text), txtNombre.Text, Convert.ToSingle(txtPrecio.Text), Convert.ToInt16(txtCantidad.Text));
            miInventario.agregarProductoEnInicio(miProducto);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Producto miProducto = new Producto(Convert.ToInt16(txtCodigo.Text), txtNombre.Text, Convert.ToSingle(txtPrecio.Text), Convert.ToInt16(txtCantidad.Text));
            miInventario.insertarProducto(miProducto, Convert.ToInt16(txtPosicion.Text));
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(miInventario.buscarProducto(Convert.ToInt16(txtCodigo.Text)).ToString());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(miInventario.borrarProducto(Convert.ToInt16(txtCodigo.Text)));
        }

        private void btnEliminarPrimero_Click(object sender, EventArgs e)
        {
            MessageBox.Show(miInventario.borrarPrimerProducto());
        }

        private void btnEliminarUltimo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(miInventario.borrarUltimoProducto());
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            txtReporte.Text = miInventario.reporte();
        }

        private void btnReporteInverso_Click(object sender, EventArgs e)
        {
            txtReporte.Text = miInventario.reporteInverso();
        }
    }
}
