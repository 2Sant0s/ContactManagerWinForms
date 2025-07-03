using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaDeContatos
{
    public partial class frmAgendaContatos : Form
    {
        public frmAgendaContatos()
        {
            InitializeComponent();
        }

        private void frmAgendaContatos_Shown(object sender, EventArgs e)
        {
            AlterarBotoesIncluirAlterarExcluir(true);
            AlterarBotoesSalvarECancelar(false);
        }
        private void AlterarBotoesSalvarECancelar(bool estado)
        {
            btnSalvar.Enabled = estado;
            btnCancelar.Enabled = estado;
        }
        private void AlterarBotoesIncluirAlterarExcluir(bool estado)
        {
            btnAdicionar.Enabled = estado;
            btnAlterar.Enabled = estado;
            btnExcluir.Enabled = estado;

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            AlterarBotoesIncluirAlterarExcluir(false);
            AlterarBotoesSalvarECancelar(true);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            AlterarBotoesIncluirAlterarExcluir(true);
            AlterarBotoesSalvarECancelar(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AlterarBotoesIncluirAlterarExcluir(true);
            AlterarBotoesSalvarECancelar(false);
        }
    }
}
