using ConsumoWS.WSCiberElectrik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumoWS
{
    public partial class frmCategoria : System.Web.UI.Page
    {
        //Declaramos el servicio de forma global para poder usarlo en cualquier parte de la clase
        WBSCiberElectrikWSSoapClient servicio = new WBSCiberElectrikWSSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarCategoria();
            }

        }

        //Creamos un procedimineto para mostrar categoria
        private void MostrarCategoria()
        {
            try
            {
                var categorias = servicio.findAllCategoria();
                grvCategoria.DataSource = categorias;
                grvCategoria.DataBind();//Agregamos los datos al gridview


            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarCategoria();
            Limpiar();

        }

        private void RegistrarCategoria()
        {

            try
            {
                var objcategoria = new CategoriaBO();
                objcategoria.nombre = txtNombre.Text;
                objcategoria.estado = chkEst.Checked;
                bool res = servicio.addCategoria(objcategoria);

                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se registro la categoria", "alert('Se registro la categoria');", true);
                    MostrarCategoria();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se registro la categoria", "alert(' No se registro la categoria');", true);
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
            chkEst.Checked = false;
        }

        protected void grvCategoria_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedrow = grvCategoria.Rows[index];
                txtCod.Text = selectedrow.Cells[0].Text;
                txtNombre.Text = HttpUtility.HtmlDecode(selectedrow.Cells[1].Text);//Decodificamos el nombre para que se vea correctamente en el textbox y evitamos el error de que cuando se trae un nombre con acento, no lo trae correctamente, se ve como un signo de interrogación
                if (((selectedrow.Cells[2].Controls[0] as DataBoundLiteralControl).Text).Trim().Equals("Habilitado"))
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

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarCategoria();
        }


        private void ActualizarCategoria()
        {

            try
            {

                var objcategoria = new CategoriaBO();
                objcategoria.codigo = Convert.ToInt32(txtCod.Text);
                objcategoria.nombre = txtNombre.Text;
                objcategoria.estado = chkEst.Checked;
                bool res = servicio.updateCategoria(objcategoria);

                if (res)
                {
                    ScriptManager.RegisterStartupScript(this,GetType(), "Se actualizo la categoria", "alert('Se actualizo la categoria');", true);
                    MostrarCategoria();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this,GetType(), "No se actualizo la categoria", "alert(' No se actualizo la categoria');", true);
                }

                
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }



        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarCategoria();
        }

        private void EliminarCategoria()
        {
            try
            {
                var objcategoria = new CategoriaBO();
                objcategoria.codigo = Convert.ToInt32(txtCod.Text);
                bool res = servicio.deleteCategoria(objcategoria);
                if(res)
                {
                    ScriptManager.RegisterStartupScript(this,GetType(), "Se elimino la categoria", "alert('Se elimino la categoria');", true);
                    MostrarCategoria();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this,GetType(), "No se elimino la categoria", "alert(' No se elimino la categoria');", true);
                }

                
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            HabilitarCategoria();
        }

        private void HabilitarCategoria()
        {
            try
            {
                var objCategoria = new CategoriaBO();
                objCategoria.codigo = Convert.ToInt32(txtCod.Text);
                bool res = servicio.enableCategoria(objCategoria);
                if (res)
                {
                    ScriptManager.RegisterStartupScript(this,GetType(), "Se habilito la categoria", "alert('Se habilito la categoria');", true);
                    MostrarCategoria();
                    Limpiar();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this,GetType(), "No se habilito la categoria", "alert(' No se habilito la categoria');", true);
                }
                    
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}