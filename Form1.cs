using System.Diagnostics.Tracing;
using System.Windows.Forms;

namespace feedFordward
{
    public partial class Form1 : Form
    {
        int entradas;
        double filas;
        int avanzaCelda;
        double aux_ceros = 1;
        double aux_ceros2 = 1;

        public struct capa
        {
            public int numcapas;
            public double[] activacion;
            public double[] umbral;
        };

        public struct pesos
        {
            public double[,] w;
        };

        capa[] C1;
        pesos[] W;
        public Form1()
        {
            InitializeComponent();
        }

       
        private void btFeedfordward_Click(object sender, EventArgs e)
        {
            Limpia();
            entradas = 2;
            filas = Math.Pow(2, entradas);
            CreaTabla(entradas, filas);
            LlenarTabla(entradas, filas);
        }

        // *********************************************************************************** FUNCIONES

        public void CreaTabla(int entradas, double filas)
        {
            for (int i = 0; i < entradas; i++)
            {
                dGResultados.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "X" + (i + 1).ToString() });
            }

            for (int j = 1; j < filas; j++)
            {
                j = dGResultados.Rows.Add(new DataGridViewRow());
            }

            if (rBXOR.Checked)
            {
                dGResultados.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Y1" });
            }
            else if(rBEjercicio.Checked){
                dGResultados.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Y1" });
                dGResultados.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Y2" });
            }
            else
            {
                MessageBox.Show("Debe seleccionar una opcion");
            }
            
        }
        public void Y_esperada(int entradas)
        {
            for (int i = 0; i < 50; i++)
            {
                dGResultados.Rows[i].Cells[entradas].Value = "0";
            }

            for (int i = 50; i < 100; i++)
            {
                dGResultados.Rows[i].Cells[entradas].Value = "1";
            }
        }

        public void LlenarTabla(int entradas, double filas)
        {
            avanzaCelda = entradas - 1;

            for (int i = 0; i < filas; i++)
            {
                // Ciclo que pone 0 en el Datagrid de la tabla de verad
                for (int j = 0; j < aux_ceros; j++)
                {
                    dGResultados.Rows[i].Cells[avanzaCelda].Value = "0";
                    i++;
                }

                // Ciclo que pone 1 en el Datagrid de la tabla de verdad
                for (int b = 0; b < aux_ceros; b++)
                {
                    dGResultados.Rows[i].Cells[avanzaCelda].Value = "1";
                    i++;
                }

                i--;

                if (i == filas - 1 && avanzaCelda != 0)
                {
                    i = -1;
                    avanzaCelda--;
                    aux_ceros = Math.Pow(2, aux_ceros2);
                    aux_ceros2++;
                }
            }
        }
        public void Limpia()
        {
            dGResultados.Rows.Clear();
            dGResultados.Columns.Clear();
            lBSalida.Items.Clear();
            avanzaCelda = 0;
            aux_ceros = 1;
            aux_ceros2 = 1;
        }

        public void pesosXOR()
        {
            //W[0].w = new pesos[,] { { 1, 2 }, { 3, 4 } };
        }

       
    }
}