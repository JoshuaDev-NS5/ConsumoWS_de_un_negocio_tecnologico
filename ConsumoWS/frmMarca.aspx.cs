using ConsumoWS.WSCiberElectrik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumoWS
{
    public partial class frmMarca : System.Web.UI.Page
    {
        //Declaramos el servicio de forma global para poder usarlo en cualquier parte de la clase
        WBSCiberElectrikWSSoapClient servicio = new WBSCiberElectrikWSSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarMarca();
            }
        }

        //Creamos un procedimiento para mostrar marca
        private void MostrarMarca()
        {
            try
            {
                var marcas = servicio.findAllMarca();
                grvMarca.DataSource = marcas;
                grvMarca.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarMarca();
        }

        private void RegistrarMarca()
        {
            try
            {
                var objmarca = new MarcaBO();
                objmarca.codigo = servicio.setCodeMarca();
                objmarca.nombre = txtNombre.Text;
                objmarca.estado = chkEst.Checked;
                bool res = servicio.addMarca(objmarca);

                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se registro la marca", "alert('Se registro la marca');", true);
                    MostrarMarca();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se registro la marca", "alert('No se registro la marca');", true);
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

        protected void grvMarca_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedrow = grvMarca.Rows[index];
                txtCod.Text = selectedrow.Cells[0].Text;
                txtNombre.Text = HttpUtility.HtmlDecode(selectedrow.Cells[1].Text);
                if (((selectedrow.Cells[2].Controls[0] as DataBoundLiteralControl).Text).Trim().Equals("Habilitado"))
                {
                    chkEst.Checked = true;
                }
                else
                {
                    chkEst.Checked = false;
                }
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarMarca();
        }

        private void ActualizarMarca()
        {
            try
            {
                var objmarca = new MarcaBO();
                objmarca.codigo = Convert.ToInt32(txtCod.Text);
                objmarca.nombre = txtNombre.Text;
                objmarca.estado = chkEst.Checked;
                bool res = servicio.updateMarca(objmarca);

                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se actualizo la marca", "alert('Se actualizo la marca');", true);
                    MostrarMarca();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se actualizo la marca", "alert('No se actualizo la marca');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarMarca();
        }

        private void EliminarMarca()
        {
            try
            {
                var objmarca = new MarcaBO();
                objmarca.codigo = Convert.ToInt32(txtCod.Text);
                bool res = servicio.deleteMarca(objmarca);
                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se elimino la marca", "alert('Se elimino la marca');", true);
                    MostrarMarca();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se elimino la marca", "alert('No se elimino la marca');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            HabilitarMarca();
        }

        private void HabilitarMarca()
        {
            try
            {
                var objmarca = new MarcaBO();
                objmarca.codigo = Convert.ToInt32(txtCod.Text);
                bool res = servicio.enableMarca(objmarca);
                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se habilito la marca", "alert('Se habilito la marca');", true);
                    MostrarMarca();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se habilito la marca", "alert('No se habilito la marca');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}
