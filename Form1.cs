using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaDeContatos
{
    public partial class frmAgendaContatos : Form
    {
        private OperacaoEnum acao;
        public frmAgendaContatos()
        {
            InitializeComponent();
        }

        private void frmAgendaContatos_Shown(object sender, EventArgs e)
        {
            AlterarBotoesIncluirAlterarExcluir(true);
            AlterarBotoesSalvarECancelar(false);
            CarregarListaContatos();
            AlterarEstadoCampos(false);

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
            AlterarEstadoCampos(true);
            acao = OperacaoEnum.INCLUIR;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            AlterarBotoesIncluirAlterarExcluir(false);
            AlterarBotoesSalvarECancelar(true);
            AlterarEstadoCampos(true);
            acao = OperacaoEnum.ALTERAR;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AlterarBotoesIncluirAlterarExcluir(true);
            AlterarBotoesSalvarECancelar(false);
            AlterarEstadoCampos(false);
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
            if (acao == OperacaoEnum.INCLUIR)
            {
                contatosList.Add(contato);
            }
            else
            {

                if (acao == OperacaoEnum.ALTERAR)
                {
                    int indice = lbxContatos.SelectedIndex;
                    contatosList.RemoveAt(indice);
                    contatosList.Insert(indice, contato);

                }
                ManipuladorArquivo.EscreverArquivo(contatosList);
                CarregarListaContatos();
                AlterarBotoesSalvarECancelar(false);
                AlterarBotoesIncluirAlterarExcluir(true);
                LimparCampos();
                AlterarEstadoCampos(false);
                {

                }
            }
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
        private void AlterarEstadoCampos(bool estado)
        {
            txbNome.Enabled = estado;
            txbEmail.Enabled = estado;
            txbTelefone.Enabled = estado;
        }

        private void lbxContatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Contato contato = (Contato)lbxContatos.Items[lbxContatos.SelectedIndex];
            txbNome.Text = contato.Nome;
            txbEmail.Text = contato.Email;
            txbTelefone.Text = contato.NumeroTelefone;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza?", "Pergunta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int indiceExcluido = lbxContatos.SelectedIndex;
                lbxContatos.SelectedIndex = 0;
                lbxContatos.Items.RemoveAt(indiceExcluido);
                List<Contato> contatosList = new List<Contato>();

                foreach (Contato contato in lbxContatos.Items)
                {
                    contatosList.Add(contato);
                }
                ManipuladorArquivo.EscreverArquivo(contatosList);
                CarregarListaContatos();
                LimparCampos();
            }
        }
    }
}
