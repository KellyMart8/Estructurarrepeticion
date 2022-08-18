namespace pjSegurosVida
{
    public partial class frmProforma : Form
    {
        public frmProforma()
        {
            InitializeComponent();
        }

        private void frmProforma_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Capturando los datos
            string razon = txtRazonSocial.Text;
            string tipo = cboTipo.Text;
            int cantidad = int.Parse(txtCantidad.Text);

            //Calculando pago mensual por tipo de seguro
            double pagoMensual = 0;

            switch (tipo)
            {
                case "Inversion clasica":
                    if (cantidad <= 10)
                        pagoMensual = 50 * cantidad;
                    else
                        pagoMensual = (50 * cantidad) + (10 * (cantidad - 10)); break;

                case "Inversion Platino":
                    if (cantidad <= 9)
                        pagoMensual = 80 * cantidad;
                    else
                        pagoMensual = (80 * cantidad + (8 + (cantidad - 9))); break;
                case "Inversion Oro":
                    if (cantidad <= 6)
                        pagoMensual = 150 * cantidad;
                    else
                        pagoMensual = (150 * cantidad) + (15 * (cantidad - 6)); break;
            }

            //Imprimir el detalle de la proforma

            ListViewItem fila = new ListViewItem(tipo);
            fila.SubItems.Add(cantidad.ToString()); 
            fila.SubItems.Add(pagoMensual.ToString("0.00")); 
            lvProforma.Items.Add(fila);
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            //Determinar el total de personas aseguradas

            int totalAsegurados = 0;

            for(int i = 0; i < lvProforma.Items.Count; i++)                 //items son filas
            {
                if(lvProforma.Items[i].SubItems[0].Text != " ")
                totalAsegurados += int.Parse(lvProforma.Items[i].SubItems[1].Text);     //+= es para acumular
            }

            //Determinar 

            double total = 0;
            for (int i = 0; i < lvProforma.Items.Count; i++) 
            {
                if (lvProforma.Items[i].SubItems[0].Text != " ")
                    total += double.Parse(lvProforma.Items[i].SubItems[2].Text);
            }

            //Impresion de las estadisticas

            lvEstadisticas.Items.Clear();
            string[] elementosFila = new string[2];
            ListViewItem row;

            elementosFila[0] = "Total de peersonas aseguradas";
            elementosFila [1] = totalAsegurados.ToString();
            row = new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);

            elementosFila[0] = "Monto a cancelar";
            elementosFila[1] = total.ToString("C");
            row = new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Estas seguro de anular la proforma?",
                                               "Seguros",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Exclamation);
            if (r == DialogResult.Yes)
            {
                txtRazonSocial.Clear();
                cboTipo.Text = "(Seleccione tipo)";
                txtCantidad.Clear();
                txtRazonSocial.Focus();
                lvProforma.Items.Clear();
                lvEstadisticas.Items.Clear ();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Seguro de querer salir del sistema?",
                                               "Seguros",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);

            if(r == DialogResult.Yes)   
                this.Close();  
        }
    }
}