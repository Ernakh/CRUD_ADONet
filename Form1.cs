using System.Data;

namespace WinFormsADONet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Programador programador = new Programador();
            programador.nome = txBNome.Text;
            programador.linguagem = txbLinguagem.Text;
            programador.banco = txbBanco.Text;


            bool retorno = programador.gravarProgramador();

            if (retorno)
            {
                MessageBox.Show("Gravado com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro ao gravar!");
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Banco bd = new Banco();

            string sql = "select * from programadores where nome = '" + txbNomeC.Text + "'";

            DataTable dt = new DataTable();

            dt = bd.executarConsultaGenerica(sql);

            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Banco bd = new Banco();

            string sql = "select * from programadores";

            DataTable dt = new DataTable();

            dt = bd.executarConsultaGenerica(sql);

            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Programador programador = new Programador();
            programador.consultaProgramador(int.Parse(textBox1.Text));
            MessageBox.Show(programador.nome);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Programador programador = new Programador();
            programador.id = int.Parse(txbIdD.Text);

            programador = programador.consultaProgramador(programador.id);

            if (programador == null)
            {
                MessageBox.Show("Erro ao excluir: O programador não foi encontrado (404)!");
                return;
            }

            bool retorno = programador.excluirProgramador();

            if (retorno == true)
            {
                MessageBox.Show("Excluído com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro ao executar a exclusão!");
            }

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Programador programador = new Programador();
            programador.id = int.Parse(txbIdA.Text);
            programador.nome =  txbNomeA.Text;
            programador.linguagem = txbLinguagemA.Text;
            programador.banco = txbBancoA.Text;

            bool retorno = programador.atualizarProgramador();

            if(retorno)
            {
                MessageBox.Show("Alterado com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro ao alterar!");
            }
        }
    }
}