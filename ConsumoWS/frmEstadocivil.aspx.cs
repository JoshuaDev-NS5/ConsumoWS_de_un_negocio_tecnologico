using ConsumoWS.WSCiberElectrik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumoWS
{
    public partial class frmEstadocivil : System.Web.UI.Page
    {
        WBSCiberElectrikWSSoapClient servicio = new WBSCiberElectrikWSSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarEstadocivil();
            }
        }

        private void MostrarEstadocivil()
        {
            try
            {
                var estadociviles = servicio.findAllEstadocivil();
                grvEstadocivil.DataSource = estadociviles;
                grvEstadocivil.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarEstadocivil();
        }

        private void RegistrarEstadocivil()
        {
            try
            {
                var objestadocivil = new EstadocivilBO();
                objestadocivil.codestc = servicio.setCodeEstadocivil();
                objestadocivil.nomestc = txtNombre.Text;
                objestadocivil.estestc = chkEst.Checked;
                bool res = servicio.addEstadocivil(objestadocivil);

                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se registro el estado civil", "alert('Se registro el estado civil');", true);
                    MostrarEstadocivil();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se registro el estado civil", "alert('No se registro el estado civil');", true);
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

        protected void grvEstadocivil_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedrow = grvEstadocivil.Rows[index];
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
            ActualizarEstadocivil();
        }

        private void ActualizarEstadocivil()
        {
            try
            {
                var objestadocivil = new EstadocivilBO();
                objestadocivil.codestc = Convert.ToInt32(txtCod.Text);
                objestadocivil.nomestc = txtNombre.Text;
                objestadocivil.estestc = chkEst.Checked;
                bool res = servicio.updateEstadocivil(objestadocivil);

                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se actualizo el estado civil", "alert('Se actualizo el estado civil');", true);
                    MostrarEstadocivil();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se actualizo el estado civil", "alert('No se actualizo el estado civil');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarEstadocivil();
        }

        private void EliminarEstadocivil()
        {
            try
            {
                var objestadocivil = new EstadocivilBO();
                objestadocivil.codestc = Convert.ToInt32(txtCod.Text);
                bool res = servicio.deleteEstadocivil(objestadocivil);
                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se elimino el estado civil", "alert('Se elimino el estado civil');", true);
                    MostrarEstadocivil();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se elimino el estado civil", "alert('No se elimino el estado civil');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            HabilitarEstadocivil();
        }

        private void HabilitarEstadocivil()
        {
            try
            {
                var objestadocivil = new EstadocivilBO();
                objestadocivil.codestc = Convert.ToInt32(txtCod.Text);
                bool res = servicio.enableEstadocivil(objestadocivil);
                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se habilito el estado civil", "alert('Se habilito el estado civil');", true);
                    MostrarEstadocivil();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se habilito el estado civil", "alert('No se habilito el estado civil');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}
