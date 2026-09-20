using ConsumoWS.WSCiberElectrik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumoWS
{
    public partial class frmDistrito : System.Web.UI.Page
    {
        WBSCiberElectrikWSSoapClient servicio = new WBSCiberElectrikWSSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarDistrito();
            }
        }

        private void MostrarDistrito()
        {
            try
            {
                var distritos = servicio.findAllDistrito();
                grvDistrito.DataSource = distritos;
                grvDistrito.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarDistrito();
        }

        private void RegistrarDistrito()
        {
            try
            {
                var objdistrito = new DistritoBO();
                objdistrito.codigo = servicio.setCodeDistrito();
                objdistrito.nombre = txtNombre.Text;
                objdistrito.estado = chkEst.Checked;
                bool res = servicio.addDistrito(objdistrito);

                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se registro el distrito", "alert('Se registro el distrito');", true);
                    MostrarDistrito();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se registro el distrito", "alert('No se registro el distrito');", true);
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

        protected void grvDistrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedrow = grvDistrito.Rows[index];
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
            ActualizarDistrito();
        }

        private void ActualizarDistrito()
        {
            try
            {
                var objdistrito = new DistritoBO();
                objdistrito.codigo = Convert.ToInt32(txtCod.Text);
                objdistrito.nombre = txtNombre.Text;
                objdistrito.estado = chkEst.Checked;
                bool res = servicio.updateDistrito(objdistrito);

                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se actualizo el distrito", "alert('Se actualizo el distrito');", true);
                    MostrarDistrito();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se actualizo el distrito", "alert('No se actualizo el distrito');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarDistrito();
        }

        private void EliminarDistrito()
        {
            try
            {
                var objdistrito = new DistritoBO();
                objdistrito.codigo = Convert.ToInt32(txtCod.Text);
                bool res = servicio.deleteDistrito(objdistrito);
                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se elimino el distrito", "alert('Se elimino el distrito');", true);
                    MostrarDistrito();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se elimino el distrito", "alert('No se elimino el distrito');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            HabilitarDistrito();
        }

        private void HabilitarDistrito()
        {
            try
            {
                var objdistrito = new DistritoBO();
                objdistrito.codigo = Convert.ToInt32(txtCod.Text);
                bool res = servicio.enableDistrito(objdistrito);
                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se habilito el distrito", "alert('Se habilito el distrito');", true);
                    MostrarDistrito();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se habilito el distrito", "alert('No se habilito el distrito');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}
