using ConsumoWS.WSCiberElectrik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumoWS
{
    public partial class frmRol : System.Web.UI.Page
    {
        WBSCiberElectrikWSSoapClient servicio = new WBSCiberElectrikWSSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarRol();
            }
        }

        private void MostrarRol()
        {
            try
            {
                var roles = servicio.findAllRol();
                grvRol.DataSource = roles;
                grvRol.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarRol();
        }

        private void RegistrarRol()
        {
            try
            {
                var objrol = new RolBO();
                objrol.codrol = servicio.setCodeRol();
                objrol.nomrol = txtNombre.Text;
                objrol.estrol = chkEst.Checked;
                bool res = servicio.addRol(objrol);

                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se registro el rol", "alert('Se registro el rol');", true);
                    MostrarRol();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se registro el rol", "alert('No se registro el rol');", true);
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

        protected void grvRol_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedrow = grvRol.Rows[index];
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
            ActualizarRol();
        }

        private void ActualizarRol()
        {
            try
            {
                var objrol = new RolBO();
                objrol.codrol = Convert.ToInt32(txtCod.Text);
                objrol.nomrol = txtNombre.Text;
                objrol.estrol = chkEst.Checked;
                bool res = servicio.updateRol(objrol);

                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se actualizo el rol", "alert('Se actualizo el rol');", true);
                    MostrarRol();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se actualizo el rol", "alert('No se actualizo el rol');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarRol();
        }

        private void EliminarRol()
        {
            try
            {
                var objrol = new RolBO();
                objrol.codrol = Convert.ToInt32(txtCod.Text);
                bool res = servicio.deleteRol(objrol);
                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se elimino el rol", "alert('Se elimino el rol');", true);
                    MostrarRol();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se elimino el rol", "alert('No se elimino el rol');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            HabilitarRol();
        }

        private void HabilitarRol()
        {
            try
            {
                var objrol = new RolBO();
                objrol.codrol = Convert.ToInt32(txtCod.Text);
                bool res = servicio.enableRol(objrol);
                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se habilito el rol", "alert('Se habilito el rol');", true);
                    MostrarRol();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se habilito el rol", "alert('No se habilito el rol');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}
