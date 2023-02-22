﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormGaragem.Helpers;

namespace FormGaragem.View.modules.forget_password
{
    public partial class FormForgetPassword : Form
    {
        public FormForgetPassword()
        {
            InitializeComponent();
        }

        public void limparCampos()
        {
            txt_email.Clear();
            txt_user.Clear();
            btn_recuperar_senha.Enabled = true;
        }

        public void msg_retorno(bool status = false, string msg = "")
        {
            if(status)
            {
                lbl_warning.Text = msg;
                pnl_aviso.Visible = true;
                lbl_warning.Visible = true;
                pic_exit_warning.Visible = true;
            } else
            {
                pnl_aviso.Visible = true;
                lbl_warning.Visible = true;
                pic_exit_warning.Visible = true;
            }
        }

        private void btn_voltar_Click(object sender, EventArgs e)
        {
            FormLogin frmLogin = new FormLogin();
            this.Close();
            frmLogin.Show();
        }

        private void btn_recuperar_senha_Click(object sender, EventArgs e)
        {
            btn_recuperar_senha.Enabled = false;

            if (txt_email.Text == "" || txt_user.Text == "")
            {
                msg_retorno(true, "Porfavor, preencha os campos corretamente.");
                btn_recuperar_senha.Enabled = true;
            }
            else
            {
                Email mail = new Email("smtp.office365.com", 587, "mocadaautomoveis@hotmail.com", "etecjau070");
                GerarSenha pass = new GerarSenha();

                mail.sendEmailBySmtp
                (
                    destinatario: txt_email.Text,
                    subject: "Recuperação de Senha | Moçada Automóveis System",
                    body: $"Olá {txt_user.Text}, sua nova senha é: {pass.returnPass(12)}"
                ); 

                msg_retorno(true, $"Sua nova senha foi enviada com sucesso.");
                limparCampos();
            }
        }

        private void pic_exit_warning_Click(object sender, EventArgs e)
        {
            lbl_warning.Visible = false;
            pnl_aviso.Visible = false;
            lbl_warning.Visible = false;
            pic_exit_warning.Visible = false;
        }
    }
}
