using ConsumoWS.WSCiberElectrik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumoWS
{
    public partial class frmSexo : System.Web.UI.Page
    {
        WBSCiberElectrikWSSoapClient servicio = new WBSCiberElectrikWSSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarSexo();
            }
        }

        private void MostrarSexo()
        {
            try
            {
                var sexos = servicio.findAllSexo();
                grvSexo.DataSource = sexos;
                grvSexo.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarSexo();
        }

        private void RegistrarSexo()
        {
            try
            {
                var objsexo = new SexoBO();
                objsexo.codigo = servicio.setCodeSexo();
                objsexo.nombre = txtNombre.Text;
                objsexo.estado = chkEst.Checked;
                bool res = servicio.addSexo(objsexo);

                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se registro el sexo", "alert('Se registro el sexo');", true);
                    MostrarSexo();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se registro el sexo", "alert('No se registro el sexo');", true);
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

        protected void grvSexo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Seleccionar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedrow = grvSexo.Rows[index];
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
            ActualizarSexo();
        }

        private void ActualizarSexo()
        {
            try
            {
                var objsexo = new SexoBO();
                objsexo.codigo = Convert.ToInt32(txtCod.Text);
                objsexo.nombre = txtNombre.Text;
                objsexo.estado = chkEst.Checked;
                bool res = servicio.updateSexo(objsexo);

                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se actualizo el sexo", "alert('Se actualizo el sexo');", true);
                    MostrarSexo();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se actualizo el sexo", "alert('No se actualizo el sexo');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarSexo();
        }

        private void EliminarSexo()
        {
            try
            {
                var objsexo = new SexoBO();
                objsexo.codigo = Convert.ToInt32(txtCod.Text);
                bool res = servicio.deleteSexo(objsexo);
                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se elimino el sexo", "alert('Se elimino el sexo');", true);
                    MostrarSexo();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se elimino el sexo", "alert('No se elimino el sexo');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            HabilitarSexo();
        }

        private void HabilitarSexo()
        {
            try
            {
                var objsexo = new SexoBO();
                objsexo.codigo = Convert.ToInt32(txtCod.Text);
                bool res = servicio.enableSexo(objsexo);
                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Se habilito el sexo", "alert('Se habilito el sexo');", true);
                    MostrarSexo();
                    Limpiar();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "No se habilito el sexo", "alert('No se habilito el sexo');", true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}
