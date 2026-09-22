using ConsumoWS.WSCiberElectrik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumoWS
{
    public partial class frmEmpleado : System.Web.UI.Page
    {
        //Declaramos el servicio de forma global para poder usarlo en cualquier parte de la clase
        WBSCiberElectrikWSSoapClient servicio = new WBSCiberElectrikWSSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void MostrarProductos()
        {
            try
            {
                var empleado=servicio.findAllEmpleado();
                grvEmpleado.DataSource = empleado;
                grvEmpleado.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}