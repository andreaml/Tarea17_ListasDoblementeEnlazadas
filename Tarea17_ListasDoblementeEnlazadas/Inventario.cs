using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea17_ListasDoblementeEnlazadas
{
    class Inventario
    {
        private Producto _primero;
        private Producto _ultimo;

        public Inventario()
        {
            _primero = null;
            _ultimo = null;
        }

        public void agregarProducto(Producto productoNuevo)
        {
            if (_primero == null)
            {
                _primero = productoNuevo;
                _ultimo = productoNuevo;
            }
            else
            {
                _ultimo.siguiente = productoNuevo;
                productoNuevo.anterior = _ultimo;
                _ultimo = productoNuevo;
            }
        }

        public void agregarProductoEnInicio(Producto productoNuevo)
        {
            if (_primero == null)
            {
                _primero = productoNuevo;
                _ultimo = productoNuevo;
            }
            else
            {
                productoNuevo.siguiente = _primero;
                _primero.anterior = productoNuevo;
                _primero = productoNuevo;
            }
        }

        public void insertarProducto(Producto productoNuevo, int pos)
        {
            if (_primero != null)
            {
                if (pos <= cantidadProductos(_primero, 0))
                {
                    if (pos == 1)
                        agregarProductoEnInicio(productoNuevo);
                    else
                    {
                        Producto productoEnPosicion = buscarProductoPorPosicion(_primero, pos - 1, 0);
                        productoEnPosicion.anterior.siguiente = productoNuevo;
                        productoNuevo.anterior = productoEnPosicion.anterior;
                        productoNuevo.siguiente = productoEnPosicion;
                        productoEnPosicion.anterior = productoNuevo;
                    }
                }
                else
                    agregarProducto(productoNuevo);
            }
            else
                agregarProducto(productoNuevo);
        }

        private Producto buscarProductoPorPosicion(Producto ultimo, int posBuscar, int posActual)
        {
            if (posActual == posBuscar)
                return ultimo;
            else
                return buscarProductoPorPosicion(ultimo.siguiente, posBuscar, ++posActual);
        }

        private int cantidadProductos(Producto ultimo, int cantidad)
        {
            if (ultimo.siguiente == null)
                return ++cantidad;
            else
                return cantidad + cantidadProductos(ultimo.siguiente, ++cantidad);
        }

        public Producto buscarProducto(int codigoProducto)
        {
            if (_primero != null)
                return buscarProducto(_primero, codigoProducto);
            return null;
        }

        private Producto buscarProducto(Producto actual, int codigoProducto)
        {
            if (actual.codigo == codigoProducto)
                return actual;
            else
                return buscarProducto(actual.siguiente, codigoProducto);
        }

        public string borrarProducto(int codigoProducto)
        {
            string mensaje = "Producto no encontrado";
            Producto busquedaProducto = buscarProducto(codigoProducto);
            if (busquedaProducto != null)
            {
                if (busquedaProducto == _primero)
                {
                    mensaje = borrarPrimerProducto();
                }
                else if (busquedaProducto == _ultimo)
                {
                    mensaje = borrarUltimoProducto();
                }
                else
                {
                    busquedaProducto.anterior.siguiente = busquedaProducto.siguiente;
                    busquedaProducto.siguiente.anterior = busquedaProducto.anterior;
                    mensaje = "Producto eliminado";
                }

            }
            return mensaje;
        }

        public string borrarPrimerProducto()
        {
            if (_primero != null)
            {
                _primero = _primero.siguiente;
                _primero.anterior = null;
                return "Producto eliminado";
            }
            else
                return "Error";
        }

        public string borrarUltimoProducto()
        {
            if (_ultimo != null)
            {
                _ultimo = _ultimo.anterior;
                _ultimo.siguiente = null;
                return "Producto eliminado";
            }
            else
                return "Error";
        }

        public string reporte()
        {
            string reporte = "";
            Producto actual = _primero;
            while (actual != null)
            {
                reporte += actual.ToString() + Environment.NewLine + "----------------------------" + Environment.NewLine;
                actual = actual.siguiente;
            }
            return reporte;
        }

        public string reporteInverso()
        {
            if (_primero != null)
                return reporteInverso(_primero);
            else
                return "";
        }

        private string reporteInverso(Producto ultimo)
        {
            string reporte = "";
            if (ultimo.siguiente != null)
                reporte = reporteInverso(ultimo.siguiente) + ultimo.ToString() + Environment.NewLine + "----------------------------" + Environment.NewLine;
            else
                reporte = ultimo.ToString() + Environment.NewLine + "----------------------------" + Environment.NewLine;
            return reporte;
        }

        ///////// Agregar Producto con recursividad. /////////
        //public void agregarProducto(Producto productoNuevo)
        //{
        //    if (_primero == null)
        //        _primero = productoNuevo;
        //    else
        //        agregarProducto(_primero, productoNuevo);
        //}

        //private void agregarProducto(Producto ultimo, Producto nuevo)
        //{
        //    if (ultimo.siguiente == null)
        //        ultimo.siguiente = nuevo;
        //    else
        //        agregarProducto(ultimo.siguiente, nuevo);
        //}
        ///////// FIN Agregar Producto con recursividad. /////////

        //private Producto _buscarProductoAnterior(int codigoProducto)
        //{
        //    Producto actual = _primero;
        //    while (actual != null)
        //    {
        //        if (actual.siguiente.codigo == codigoProducto)
        //            return actual;
        //        actual = actual.siguiente;
        //    }
        //    return null;
        //}
    }
}
