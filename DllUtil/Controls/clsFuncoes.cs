﻿/* --------------------------------------------------------------------------------------------------------------------
Fernando Passaia - https://www.linkedin.com/pub/fernando-passaia/24/622/285 - https://www.facebook.com/fernando.passaia
Blog: fernandopassaia.wordpress.com - Email/Skype: fernandopassaia@futuradata.com.br - Cel/Whatsapp: (11)98104-9080
Para feedbacks - favor utilizar o GitHub - ou enviar através dos contatos acima.

Classe para manipulação de controles de um form (como travar todos controles de um form, destravar todos controles,
limpar, circular campos obrigatórios em vermelho... você pode enviar por exemplo um TabPage completo com diversas
textbox dentro e outros componentes - que ele irá tratar. Nota: O padrão não está perfeito pois essa DLL precisou
referenciar System.Windows.Forms para tanto - caso você necessita seguir totalmente o padrão, tire essa classe daqui,
insira em seu projeto View (forms) e remova a referência dessa DLL.

 * Nota: Todos podem colaborar subindo suas melhorias, novos métodos e correções para esse projeto totalmente Opensource
 * e livre para uso de quem quiser em qualquer tipo de aplicação. Nota2: Por padrão, compila em C:\CSharp_BasicFramework
 * Caso o diretório não exista - efetue sua criação antes de abrir esse projeto e efetuar o Build.
--------------------------------------------------------------------------------------------------------------------- */

using DllValidacoes;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DllUtil.Controls
{
    public static class clsFuncoes
    {
        #region Métodos de controles do DataGridView
        /// <summary>
        /// Seleciona a próximoa linha de um DataGridView
        /// </summary>
        /// <param name="vDataGrid">Passar o nome do DataGridView a ser controlado</param>
        public static void RegistroAnterior(DataGridView vDataGrid)
        {
            if (vDataGrid.CurrentRow == null)
            {
                return;
            }

            //Seleciona a proxima linha:
            int index = vDataGrid.CurrentRow.Index - 1;
            if (index == -1)
            {
                index = 0;
            }
            index = index % vDataGrid.Rows.Count;
            vDataGrid.CurrentCell = vDataGrid.Rows[index].Cells[vDataGrid.CurrentCell.ColumnIndex];


        }

        /// <summary>
        /// Seleciona o primeiro registro de um DataGridView
        /// </summary>
        /// <param name="vDataGrid">Passar o nome do DataGridView a ser controlado</param>
        public static void PrimeiroRegistro(DataGridView vDataGrid)
        {
            if (vDataGrid.CurrentRow == null)
            {
                return;
            }

            int index = 0;
            vDataGrid.CurrentCell = vDataGrid.Rows[index].Cells[vDataGrid.CurrentCell.ColumnIndex];
        }


        /// <summary>
        /// Seleciona o último registro de um DataGridView
        /// </summary>
        /// <param name="vDataGrid">Passar o nome do DataGridView as ser controlado</param>
        public static void UltimoRegistro(DataGridView vDataGrid)
        {
            if (vDataGrid.CurrentRow == null)
            {
                return;
            }

            int index = vDataGrid.Rows.Count - 1;



            vDataGrid.CurrentCell = vDataGrid.Rows[index].Cells[vDataGrid.CurrentCell.ColumnIndex];
        }

        public static void ProximoRegistro(DataGridView vDataGrid)
        {
            //Seleciona a proxima linha:
            int index;
            if (vDataGrid.CurrentRow == null)
            {
                return;
            }


            index = vDataGrid.CurrentRow.Index;
            if (index != vDataGrid.Rows.Count - 1)
            {
                index++;
                index = index % vDataGrid.Rows.Count;
            }


            vDataGrid.CurrentCell = vDataGrid.Rows[index].Cells[vDataGrid.CurrentCell.ColumnIndex];
        }



        #endregion

        #region Funções de mensagens e alertas

        public static void MensagemInfo(string vMensagem)
        {
            MessageBox.Show(null, vMensagem, "FuturaData Business", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        /// <summary>
        /// Exibe uma messagebox de alerta
        /// </summary>
        /// <param name="vMensagem">Conteúdo da MessageBox</param>
        public static void MensagemAlerta(string vMensagem)
        {
            MessageBox.Show(null, vMensagem, "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static bool MensagemOpcao(string vMensagem)
        {
            if (MessageBox.Show(null, vMensagem, "FuturaData Business", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Método para travar controles
        /// <summary>
        /// Trava todos os controles filhos 
        /// </summary>
        /// <param name="sender">Passar o controle pai, por exemplo uma tabPage</param>
        public static void TravaControles(Control sender)
        {
            foreach (Control ctl in sender.Controls)
            {


                if (ctl is TextBox)
                {
                    (ctl as TextBox).ReadOnly = true;
                }

                if (ctl is ComboBox)
                {
                    (ctl as ComboBox).Enabled = false;
                }

                if (ctl is CheckBox)
                {
                    (ctl as CheckBox).Enabled = false;
                }

                if (ctl is Button)
                {
                    (ctl as Button).Enabled = false;
                }

                if (ctl is DataGridView)
                {
                    (ctl as DataGridView).Enabled = false;
                }

                if (ctl is MaskedTextBox)
                {
                    (ctl as MaskedTextBox).ReadOnly = true;
                }

                if (ctl is DateTimePicker)
                {
                    (ctl as DateTimePicker).Enabled = false;
                }

                if (ctl is RadioButton)
                {
                    (ctl as RadioButton).Enabled = false;
                }

                if (ctl.Controls.Count > 0)
                {
                    TravaControles(ctl);
                }



            }
        }
        #endregion Método para travar controles;

        #region Método para destravar controles
        /// <summary>
        /// Destrava todos os controles filhos 
        /// </summary>
        /// <param name="sender">Passar o controle pai, por exemplo uma tabPage</param>
        public static void DestravaControles(Control sender)
        {
            foreach (Control ctl in sender.Controls)
            {


                if (ctl is TextBox)
                {
                    (ctl as TextBox).ReadOnly = false;
                }

                if (ctl is ComboBox)
                {
                    (ctl as ComboBox).Enabled = true;
                }

                if (ctl is CheckBox)
                {
                    (ctl as CheckBox).Enabled = true;
                }

                if (ctl is Button)
                {
                    (ctl as Button).Enabled = true;
                }

                if (ctl is DataGridView)
                {
                    (ctl as DataGridView).Enabled = true;
                }

                if (ctl is MaskedTextBox)
                {
                    (ctl as MaskedTextBox).ReadOnly = false;
                }

                if (ctl is DateTimePicker)
                {
                    (ctl as DateTimePicker).Enabled = true;
                }

                if (ctl is RadioButton)
                {
                    (ctl as RadioButton).Enabled = true;
                }

                if (ctl.Controls.Count > 0)
                {
                    DestravaControles(ctl);
                }

            }
        }
        #endregion Método para travar controles;

        #region Limpa controles de um form
        public static void LimpaControles(Control sender)
        {
            foreach (Control ctl in sender.Controls)
            {
                if (ctl is TextBox)
                {
                    (ctl as TextBox).Clear();
                }

                if (ctl is MaskedTextBox)
                {
                    (ctl as MaskedTextBox).Text = "";
                    (ctl as MaskedTextBox).Clear();
                }

                //if (ctl is ComboBox)
                //{
                //    (ctl as ComboBox).SelectedIndex = -1;
                //}

                if (ctl.Controls.Count > 0)
                {
                    LimpaControles(ctl);
                }
            }
        }
        #endregion;

        #region Ajusta as casas decimais em um textbox ou maskedtextbox
        /// <summary>
        /// Ajusta os valores de um MaskedTextBox ou TextBox quando usando decimal
        /// </summary>
        /// <param name="sender">Só passar o Sender</param>
        /// <param name="MensagemErro">Passar uma string como mesagem de erro caso seja digitado letra ou um valor inválido</param>
        public static void AjustaCampoDecimal(object sender, string MensagemErro)
        {
            if ((sender is TextBoxBase))
            {
                clsNewContasMatematicas matematica = new clsNewContasMatematicas();

                string strValor = (sender as TextBoxBase).Text;
                strValor = matematica.newValidaAjustaArredonda4CasasDecimais(strValor);
                if (matematica.verificaSeEDecimal(strValor) == false)
                {
                    MessageBox.Show(MensagemErro, "FuturaData - Gestão de Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    (sender as TextBoxBase).Focus();
                }
                else
                {
                    (sender as TextBoxBase).Text = strValor;

                }
                (sender as TextBoxBase).BackColor = SystemColors.Window;

                matematica = null;
            }
        }
        #endregion Ajusta as casas decimais em um textbox ou maskedtextbox

        #region Foco Controle Com Seleção
        /// <summary>
        /// Função simples para selecionar todo o conteúdo de um textbox ou maskedtextbox
        /// </summary>
        /// <param name="sender">Poder ser um textbox ou maskedtextbox</param>
        public static void FocoControleComSelecao(object sender)
        {
            (sender as TextBoxBase).SelectionStart = 0;
            (sender as TextBoxBase).SelectionLength = (sender as TextBoxBase).Text.Length;
        }
        #endregion

        #region Método Checa Todas as CheckBox do Form
        /// <summary>
        /// Trava todos os controles filhos 
        /// </summary>
        /// <param name="sender">Passar o controle pai, por exemplo uma tabPage</param>
        public static void ChecaCheckBox(Control sender)
        {
            foreach (Control ctl in sender.Controls)
            {
                if (ctl is CheckBox)
                {
                    (ctl as CheckBox).Checked = true;
                }
            }//fim do foreach
        }
        #endregion Método para travar controles;

        #region Desenha um retangulo vermelho em um controle qualquer (como um campo obrigatório)
        /* Criei essa função para facilitar a visualização de campos necessários 
         * pode ser usada para dar foco em controles que necessitam de validação         
         */
        /// <summary>
        /// Desenha um retangulo vermelho em volta de um controle, para limpar use o this.Refresh();
        /// </summary>
        /// <param name="controle">Passar um controle qualquer (textbox, button,checkbox e etc)</param>
        public static void DesenhaRetanguloVermelho(Control controle)
        {
            Graphics gfx = controle.Parent.CreateGraphics();
            Pen Caneta = new Pen(Color.Red);
            Size tamanho = new Size(controle.Width + 2, controle.Height + 2);
            Point local = new Point(controle.Location.X, controle.Location.Y);
            local.Y = local.Y - 1;
            local.X = local.X - 1;
            Rectangle ret = new Rectangle(local, tamanho);

            try
            {
                gfx.DrawRectangle(Caneta, ret);
            }
            finally
            {
                Caneta.Dispose();
                gfx.Dispose();
            }
        }
        #endregion Desenha um retangulo vermelho em um controle qualquer

        #region Desenha um retangulo Azul Claro em Qualquer Controle (para mostrar pro usuário que está com foco)
        /* Criei essa função para facilitar a visualização de campos necessários 
         * pode ser usada para dar foco em controles que necessitam de validação
         * Fernando - 07/08/2013
         */
        /// <summary>
        /// Desenha um retangulo vermelho em volta de um controle, para limpar use o this.Refresh();
        /// </summary>
        /// <param name="controle">Passar um controle qualquer (textbox, button,checkbox e etc)</param>
        public static void DesenhaRetanguloAzulClaro(Control sender)
        {
            foreach (Control ctl in sender.Controls)
            {
                if (sender.Focused)
                {
                    Graphics gfx = sender.Parent.CreateGraphics();
                    Pen Caneta = new Pen(Color.Red);
                    Size tamanho = new Size(sender.Width + 2, sender.Height + 2);
                    Point local = new Point(sender.Location.X, sender.Location.Y);
                    local.Y = local.Y - 1;
                    local.X = local.X - 1;
                    Rectangle ret = new Rectangle(local, tamanho);

                    try
                    {
                        gfx.DrawRectangle(Caneta, ret);
                    }
                    finally
                    {
                        Caneta.Dispose();
                        gfx.Dispose();
                    }
                }
            }
        }
        #endregion Desenha um retangulo Azul Claro em Qualquer Controle (para mostrar pro usuário que está com foco)
    }//fim classe
}//fim namespace
