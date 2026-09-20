using ConsumoWS.WSCiberElectrik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumoWS
{
    public partial class frmProducto : System.Web.UI.Page
    {
        //Declaramos el servicio de forma global para poder usarlo en cualquier parte de la clase
        WBSCiberElectrikWSSoapClient servicio = new WBSCiberElectrikWSSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                MostrarProducto();
                CargarCombos();
            }
        }



        private void MostrarProducto()
        {
            try
            {
                var productos = servicio.findAllProducto();
                grvProducto.DataSource = productos;
                grvProducto.DataBind();//Agregamos los datos al gridview


            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }


        private void CargarCombos()
        {
            try
            {

                List<CategoriaBO> Categorias = servicio.findAllCategoria().ToList();
                List<MarcaBO> Marcas = servicio.findAllMarca().ToList();
                MarcaBO marca = new MarcaBO()
                {
                    codigo = 0,
                    nombre = "Seleccione una marca",
                    estado = false
                };
                CategoriaBO categoria = new CategoriaBO()
                {
                    codigo = 0,
                    nombre = "Seleccione una categoria",
                    estado = false
                };

                Categorias.Insert(0, categoria);
                Marcas.Insert(0, marca);
                cboCategoria.DataSource = Categorias;
                cboCategoria.DataTextField = "nombre";
                cboCategoria.DataValueField = "codigo";
                cboCategoria.DataBind();
                cboMarca.DataSource = Marcas;
                cboMarca.DataTextField = "nombre";
                cboMarca.DataValueField = "codigo";
                cboMarca.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }


        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarProducto();
        }



        private void RegistrarProducto()
        {

            try
            {
                var objproducto = new ProductoBO();
                var objCategoria = new CategoriaBO();
                var objMarca = new MarcaBO();
                objproducto.nombre = txtNombre.Text;
                objproducto.descripcion = txtDes.Text;
                objproducto.precio = Convert.ToDecimal(txtPre.Text);
                objproducto.cantidad = Convert.ToInt32(txtCan.Text);
                objproducto.fechaingreso = Convert.ToDateTime(txtFec.Text);

                objCategoria.codigo = Convert.ToInt32(cboCategoria.SelectedValue);
                objproducto.categoria= objCategoria;

                objMarca.codigo=Convert.ToInt32(cboMarca.SelectedValue);
                objproducto.marca = objMarca;

                objproducto.estado = chkEst.Checked;
                bool res = servicio.addProducto(objproducto);

                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se registro el producto", "alert('Se registro el producto');", true);
                    MostrarProducto();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se registro el producto", "alert(' No se registro el producto');", true);
                }




            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }


        }


        private void Limpiar()
        {
            txtCod.Text = "";
            txtNombre.Text = "";
            txtDes.Text = "";
            txtPre.Text = "";
            txtCan.Text = "";
            txtFec.Text = "";
            cboCategoria.SelectedIndex = 0;
            cboMarca.SelectedIndex = 0;
            chkEst.Checked = false;
        }


        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarProducto();
        }


        private void ActualizarProducto()
        {

            try
            {
                var objproducto = new ProductoBO();
                var objCategoria = new CategoriaBO();
                var objMarca = new MarcaBO();
                objproducto.codigo = Convert.ToInt32(txtCod.Text);
                objproducto.nombre = txtNombre.Text;
                objproducto.descripcion = txtDes.Text;
                objproducto.precio = Convert.ToDecimal(txtPre.Text);
                objproducto.cantidad = Convert.ToInt32(txtCan.Text);
                objproducto.fechaingreso = Convert.ToDateTime(txtFec.Text);

                objCategoria.codigo = Convert.ToInt32(cboCategoria.SelectedValue);
                objproducto.categoria = objCategoria;

                objMarca.codigo = Convert.ToInt32(cboMarca.SelectedValue);
                objproducto.marca = objMarca;

                objproducto.estado = chkEst.Checked;
                bool res = servicio.updateProducto(objproducto);

                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se actualizo el producto", "alert('Se actualizo el producto');", true);
                    MostrarProducto();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se actualizo el producto", "alert(' No se actualizo el producto');", true);
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }



        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarProducto();
        }


        private void EliminarProducto()
        {
            try
            {
                var objproducto = new ProductoBO();
                objproducto.codigo = Convert.ToInt32(txtCod.Text);
                bool res = servicio.deleteProducto(objproducto);
                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se elimino el producto", "alert('Se elimino el producto');", true);
                    MostrarProducto();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se elimino el producto", "alert(' No se elimino el producto');", true);
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }



        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            HabilitarProducto();
        }


        private void HabilitarProducto()
        {
            try
            {
                var objProducto = new ProductoBO();
                objProducto.codigo = Convert.ToInt32(txtCod.Text);
                bool res = servicio.enableProducto(objProducto);
                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se habilito el producto", "alert('Se habilito el producto');", true);
                    MostrarProducto();
                    Limpiar();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se habilito el producto", "alert(' No se habilito el producto');", true);
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void grvProducto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedrow = grvProducto.Rows[index];
                txtCod.Text = selectedrow.Cells[0].Text;
                txtNombre.Text = HttpUtility.HtmlDecode(selectedrow.Cells[1].Text);//Decodificamos el nombre para que se vea correctamente en el textbox y evitamos el error de que cuando se trae un nombre con acento, no lo trae correctamente, se ve como un signo de interrogación
                txtDes.Text = HttpUtility.HtmlDecode(selectedrow.Cells[2].Text);
                txtPre.Text = selectedrow.Cells[3].Text;
                txtCan.Text = selectedrow.Cells[4].Text;
                txtFec.Text =Convert.ToDateTime(selectedrow.Cells[5].Text).ToString("yyyy-MM-dd");
                cboMarca.SelectedIndex=cboMarca.Items.IndexOf(cboMarca.Items.FindByText(HttpUtility.HtmlDecode(selectedrow.Cells[6].Text)));
                cboCategoria.SelectedIndex = cboCategoria.Items.IndexOf(cboCategoria.Items.FindByText(HttpUtility.HtmlDecode(selectedrow.Cells[7].Text)));
                if (((selectedrow.Cells[8].Controls[0] as DataBoundLiteralControl).Text).Trim().Equals("Habilitado"))
                {
                    chkEst.Checked = true;
                }
                else
                {
                    chkEst.Checked = false;
                }
                //Encontrar la manera de corregir el error que cuando se trae un nombre con acento, no lo trae correctamente, se ve como un signo de interrogación
            }
        }
    }
}