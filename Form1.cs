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
            CarregarListaContatos();

        }
        private void AlterarBotoesSalvarECancelar(bool estado)
        {
            btnSalvar.Enabled = estado;
            btnCancelar.Enabled = estado;
        }
        private void AlterarBotoesIncluirAlterarExcluir(bool estado)
        {
            btnIncluir.Enabled = estado;
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

        private void frmAgendaContatos_Load(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Contato contato = new Contato()
            {
                Nome = txbNome.Text,
                Email = txbEmail.Text,
                NumeroTelefone = txbTelefone.Text
            };

            List<Contato> contatosList = new List<Contato>();

            foreach (Contato ContatoDaLista in lbxContatos.Items)
            {
                contatosList.Add(ContatoDaLista);
            }

            contatosList.Add(contato);
            ManipuladorArquivo.EscreverArquivo(contatosList);
            CarregarListaContatos();
            AlterarBotoesSalvarECancelar(false);
            AlterarBotoesIncluirAlterarExcluir(true);
            LimparCampos();
        }
        private void CarregarListaContatos()
        {
            lbxContatos.Items.Clear();
            lbxContatos.Items.AddRange(ManipuladorArquivo.LerArquivo().ToArray());
        }
        private void LimparCampos()
        {
            txbNome.Text = "";
            txbTelefone.Text = "";
            txbEmail.Text = "";
        }
    }
}
