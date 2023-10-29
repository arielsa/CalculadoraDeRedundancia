using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraDeRedundancia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        Tabla tabla;

        private void label1_Click(object sender, EventArgs e)
        {        }
        private void txt_m_TextChanged(object sender, EventArgs e)
        {

        }
        public int calcularRedundancia(int m, int r)
        {
            double n = Math.Pow(2, r);
            if ( !(m+1+r <= n ))
            {
                r++;
                r = calcularRedundancia(m, r);
            }
            return r;
        }
        public void LlenarTabla(int m, int r, Tabla tabla)
        {            
            double NalaR = Math.Pow(2, r);
            int Erre = r;
            int MmasRmasUno = m + r + 1;
            if (!(MmasRmasUno <= NalaR))
            {
                r++;
                tabla.agregarFila(new Fila(MmasRmasUno, Erre));
                 LlenarTabla(m, r, tabla);
            }                  
        }
        private void btn_calcular_Click(object sender, EventArgs e)
        {
            tabla = new Tabla();
            int redundancia =  calcularRedundancia(Convert.ToInt32(txt_m.Text), 0);
            txt_r.Text = redundancia.ToString();
            LlenarTabla(Convert.ToInt32(txt_m.Text), 0, tabla);
            int Maux = Convert.ToInt32(txt_m.Text)+redundancia+1;
            Fila fila = new Fila(Maux, redundancia);
            tabla.agregarFila(fila);
            //imprimir tabla en el datagridview
            dgv_cuadro.DataSource = null;
            dgv_cuadro.DataSource = tabla.filas;

        }
        public class Fila
        {
            public Fila()
            {                
            }
            public Fila(int m, int r)
            {
               
                Erre = r;
                MmasRmasUno = m;
                DosALaR = Math.Pow(2, r); 
            }
            
            public int Erre { get; set; }
            public int MmasRmasUno { get; set; }
            public double DosALaR { get; set; }
        }
        public class Tabla
        {
            public Tabla()
            {
                filas = new List<Fila>();
            }
            public List<Fila> filas { get; set; }

            public void agregarFila(Fila fila)
            {
                filas.Add(fila);
            }

        }
    }
}
