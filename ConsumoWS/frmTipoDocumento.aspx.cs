using ConsumoWS.WSCiberElectrik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumoWS
{
    public partial class frmTipoDocumento : System.Web.UI.Page
    {
        WBSCiberElectrikWSSoapClient servicio = new WBSCiberElectrikWSSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarTipoDocumento();
            }
        }

        private void MostrarTipoDocumento()
        {
            try
            {
                var tipodocumentos = servicio.findAllTipodocumento();
                grvTipoDocumento.DataSource = tipodocumentos;
                grvTipoDocumento.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarTipoDocumento();
        }

        private void RegistrarTipoDocumento()
        {
            try
            {
                var objtipodocumento = new TipodocumentoBO();
                objtipodocumento.codigo = servicio.setCodeTipodocumento();
                objtipodocumento.nombre = txtNombre.Text;
                objtipodocumento.estado = chkEst.Checked;
                bool res = servicio.addTipodocumento(objtipodocumento);

                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se registro el tipo documento", "alert('Se registro el tipo documento');", true);
                    MostrarTipoDocumento();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se registro el tipo documento", "alert('No se registro el tipo documento');", true);
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

        protected void grvTipoDocumento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedrow = grvTipoDocumento.Rows[index];
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
            ActualizarTipoDocumento();
        }

        private void ActualizarTipoDocumento()
        {
            try
            {
                var objtipodocumento = new TipodocumentoBO();
                objtipodocumento.codigo = Convert.ToInt32(txtCod.Text);
                objtipodocumento.nombre = txtNombre.Text;
                objtipodocumento.estado = chkEst.Checked;
                bool res = servicio.updateTipodocumento(objtipodocumento);

                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se actualizo el tipo documento", "alert('Se actualizo el tipo documento');", true);
                    MostrarTipoDocumento();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se actualizo el tipo documento", "alert('No se actualizo el tipo documento');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarTipoDocumento();
        }

        private void EliminarTipoDocumento()
        {
            try
            {
                var objtipodocumento = new TipodocumentoBO();
                objtipodocumento.codigo = Convert.ToInt32(txtCod.Text);
                bool res = servicio.deleteTipodocumento(objtipodocumento);
                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se elimino el tipo documento", "alert('Se elimino el tipo documento');", true);
                    MostrarTipoDocumento();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se elimino el tipo documento", "alert('No se elimino el tipo documento');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            HabilitarTipoDocumento();
        }

        private void HabilitarTipoDocumento()
        {
            try
            {
                var objtipodocumento = new TipodocumentoBO();
                objtipodocumento.codigo = Convert.ToInt32(txtCod.Text);
                bool res = servicio.enableTipodocumento(objtipodocumento);
                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se habilito el tipo documento", "alert('Se habilito el tipo documento');", true);
                    MostrarTipoDocumento();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se habilito el tipo documento", "alert('No se habilito el tipo documento');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}
