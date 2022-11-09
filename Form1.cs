using System;
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

        /*
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

        capa[] C;
        pesos[] W;
        */


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
            if (rBXOR.Checked)
            {
                XOR(entradas, filas);
            }
            else
            {
                Ejecricio(entradas, filas);
            }
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

        public void XOR(int entradas, double filas)
        {
            //pesos[] W = new pesos[2] { 5.3985, 2.5484 };
            //W = new pesos[2] { 5.3985, 5.22};
            double[,] w = new double[2, 2] { { 5.191129, 2.758669 }, { 5.473012, 2.769596 } };
            double[] w2 = new double[2] { 5.839709, -6.186834 };
            double[] umbral = new double[2] { -1.90289, -4.127002 };
            double[] umbral2 = new double[1] { -2.570539 };
            string activacion = "";
            double ac;
            double[] activacionDouble = new double[2];

            double auxAc = 0;
            double[] acSigmoidal = new double[2];
            double acCapaSalida = 0;
            double[] auxAcDouble = new double[2];


            for (int k = 0; k < 4; k++)
            {

                for (int i = 0; i < 2; i++)
                {
                    //Primer entrada
                    for (int j = 0; j < entradas; j++)
                    {
                        activacion = (string)dGResultados.Rows[k].Cells[j].Value;
                        ac = double.Parse(activacion);
                        activacionDouble[j] = ac;
                    }

                    //Activación de la capa oculta
                    for (int j = 0; j < 2; j++)
                    {
                        auxAc = (w[j, i] * activacionDouble[j]);

                        auxAcDouble[i] = auxAcDouble[i] + auxAc;
                    }

                    activacionDouble[i] = auxAcDouble[i] + umbral[i];
                    acSigmoidal[i] = 1 / (1 + Math.Pow(Math.E, -activacionDouble[i]));

                    activacionDouble[0] = 0;
                    activacionDouble[1] = 0;
                    auxAcDouble[i] = 0;
                    //lBSalida.Items.Add(acSigmoidal[i]);
                }

                //Activación capa de salida
                for (int j = 0; j < 2; j++)
                {
                    auxAc = (w2[j] * acSigmoidal[j]);
                    acCapaSalida = acCapaSalida + auxAc;
                }

                acCapaSalida = acCapaSalida + umbral2[0];
                acCapaSalida = 1 / (1 + Math.Pow(Math.E, -acCapaSalida));
                //lBSalida.Items.Add(acCapaSalida);
                dGResultados.Rows[k].Cells[entradas].Value = acCapaSalida;
                auxAc = 0;
                acCapaSalida = 0;
                activacionDouble[0] = 0;
                activacionDouble[1] = 0;
                acSigmoidal[0] = 0;
                acSigmoidal[1] = 0;
                activacion = "";
            }
        }

        public void Ejecricio(int entradas, double filas)
        {
            //pesos[] W = new pesos[2] { 5.3985, 2.5484 };
            //W = new pesos[2] { 5.3985, 5.22};
            double[,] w = new double[2, 2] { { 1, 1 }, { 1, 1 } };
            double[] w2 = new double[2] { 1, 1 };
            double[,] w3 = new double[2, 2] { { 1, 1 }, { 1, 1 } };
            double[] umbral = new double[2] { 0.5, 0.5 };
            double[] umbral2 = new double[2] { 0.5, 0.5 };
            double[] umbral3 = new double[2] { 0.5, 0.5 };
            string activacion = "";
            double ac;
            double[] activacionDouble = new double[2];

            double auxAc = 0;
            double[] acSigmoidal = new double[2];
            double acCapaSalida = 0;
            double[] auxAcDouble = new double[2];


            for (int k = 0; k < 4; k++)
            {

                for (int i = 0; i < 2; i++)
                {
                    //Primer entrada
                    for (int j = 0; j < entradas; j++)
                    {
                        activacion = (string)dGResultados.Rows[k].Cells[j].Value;
                        ac = double.Parse(activacion);
                        activacionDouble[j] = ac;
                    }

                    //Activación de la capa oculta
                    for (int j = 0; j < 2; j++)
                    {
                        auxAc = (w[j, i] * activacionDouble[j]);
                        auxAcDouble[i] = auxAcDouble[i] + auxAc;
                    }

                    activacionDouble[i] = auxAcDouble[i] + umbral[i];
                    acSigmoidal[i] = 1 / (1 + Math.Pow(Math.E, -activacionDouble[i]));

                    activacionDouble[0] = 0;
                    activacionDouble[1] = 0;
                    auxAcDouble[i] = 0;
                    //lBSalida.Items.Add(acSigmoidal[i]);
                }

                for (int i = 0; i < 2; i++)
                {
                    //Activación de la capa oculta
                    for (int j = 0; j < 2; j++)
                    {
                        auxAc = (w[j, i] * acSigmoidal[i]);
                        auxAcDouble[i] = auxAcDouble[i] + auxAc;
                    }

                    activacionDouble[i] = auxAcDouble[i] + umbral[i];
                    acSigmoidal[i] = 1 / (1 + Math.Pow(Math.E, -activacionDouble[i]));

                    activacionDouble[0] = 0;
                    activacionDouble[1] = 0;
                    auxAcDouble[i] = 0;
                    //lBSalida.Items.Add(acSigmoidal[i]);
                }

                //Activación capa de salida
                for (int j = 0; j < 2; j++)
                {
                    auxAc = (w2[j] * acSigmoidal[j]);
                    acCapaSalida = acCapaSalida + auxAc;
                }

                acCapaSalida = acCapaSalida + umbral2[0];
                acCapaSalida = 1 / (1 + Math.Pow(Math.E, -acCapaSalida));
                //lBSalida.Items.Add(acCapaSalida);
                dGResultados.Rows[k].Cells[entradas].Value = acCapaSalida;
                auxAc = 0;
                acCapaSalida = 0;
                activacionDouble[0] = 0;
                activacionDouble[1] = 0;
                acSigmoidal[0] = 0;
                acSigmoidal[1] = 0;
                activacion = "";
            }
        }
    }
}