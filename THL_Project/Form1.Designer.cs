namespace THL_Project
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtAlphabet = new System.Windows.Forms.TextBox();
            this.txtStates = new System.Windows.Forms.TextBox();
            this.txtTransitions = new System.Windows.Forms.TextBox();
            this.txtInitialState = new System.Windows.Forms.TextBox();
            this.txtFinalStates = new System.Windows.Forms.TextBox();
            this.txtWord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvAutomate = new System.Windows.Forms.DataGridView();
            this.btnVerifyWord = new System.Windows.Forms.Button();
            this.btnDeterminize = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvAutomateDeterministe = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutomate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutomateDeterministe)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAlphabet
            // 
            this.txtAlphabet.Location = new System.Drawing.Point(237, 35);
            this.txtAlphabet.Name = "txtAlphabet";
            this.txtAlphabet.Size = new System.Drawing.Size(144, 20);
            this.txtAlphabet.TabIndex = 0;
            this.txtAlphabet.Text = "ex: a,b....";
            this.txtAlphabet.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtAlphabet.Leave += new System.EventHandler(this.txtAlphabet_Leave);
            // 
            // txtStates
            // 
            this.txtStates.Location = new System.Drawing.Point(747, 35);
            this.txtStates.Name = "txtStates";
            this.txtStates.Size = new System.Drawing.Size(156, 20);
            this.txtStates.TabIndex = 1;
            this.txtStates.Text = "ex: 1,2,3,4,5....";
            this.txtStates.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.txtStates.Leave += new System.EventHandler(this.txtStates_Leave);
            // 
            // txtTransitions
            // 
            this.txtTransitions.Location = new System.Drawing.Point(435, 97);
            this.txtTransitions.Name = "txtTransitions";
            this.txtTransitions.Size = new System.Drawing.Size(238, 20);
            this.txtTransitions.TabIndex = 2;
            this.txtTransitions.Text = "ex: 1-2:a,2-2:a/b....";
            this.txtTransitions.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.txtTransitions.Leave += new System.EventHandler(this.txtTransitions_Leave);
            // 
            // txtInitialState
            // 
            this.txtInitialState.Location = new System.Drawing.Point(281, 168);
            this.txtInitialState.Name = "txtInitialState";
            this.txtInitialState.Size = new System.Drawing.Size(100, 20);
            this.txtInitialState.TabIndex = 3;
            this.txtInitialState.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            this.txtInitialState.Leave += new System.EventHandler(this.txtInitialState_Leave);
            // 
            // txtFinalStates
            // 
            this.txtFinalStates.Location = new System.Drawing.Point(709, 168);
            this.txtFinalStates.Name = "txtFinalStates";
            this.txtFinalStates.Size = new System.Drawing.Size(116, 20);
            this.txtFinalStates.TabIndex = 4;
            this.txtFinalStates.TextChanged += new System.EventHandler(this.txtFinalStates_TextChanged);
            this.txtFinalStates.Leave += new System.EventHandler(this.txtFinalStates_Leave);
            // 
            // txtWord
            // 
            this.txtWord.Location = new System.Drawing.Point(502, 241);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(100, 20);
            this.txtWord.TabIndex = 5;
            this.txtWord.TextChanged += new System.EventHandler(this.txtWord_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Saisir l\'alphabet.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(504, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Saisir les transitions";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(790, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Saisir les états";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(289, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Saisir l\'état initial";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(706, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Saisir les états finaux";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(470, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Vérifier si un mot existe dans l\'automate.";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // dgvAutomate
            // 
            this.dgvAutomate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAutomate.Location = new System.Drawing.Point(76, 397);
            this.dgvAutomate.Name = "dgvAutomate";
            this.dgvAutomate.Size = new System.Drawing.Size(375, 215);
            this.dgvAutomate.TabIndex = 12;
            this.dgvAutomate.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAutomate_CellContentClick);
            // 
            // btnVerifyWord
            // 
            this.btnVerifyWord.Location = new System.Drawing.Point(518, 267);
            this.btnVerifyWord.Name = "btnVerifyWord";
            this.btnVerifyWord.Size = new System.Drawing.Size(75, 23);
            this.btnVerifyWord.TabIndex = 13;
            this.btnVerifyWord.Text = "Verifier";
            this.btnVerifyWord.UseVisualStyleBackColor = true;
            this.btnVerifyWord.Click += new System.EventHandler(this.btnVerifyWord_Click);
            // 
            // btnDeterminize
            // 
            this.btnDeterminize.Location = new System.Drawing.Point(811, 366);
            this.btnDeterminize.Name = "btnDeterminize";
            this.btnDeterminize.Size = new System.Drawing.Size(75, 23);
            this.btnDeterminize.TabIndex = 14;
            this.btnDeterminize.Text = "Lancer";
            this.btnDeterminize.UseVisualStyleBackColor = true;
            this.btnDeterminize.Click += new System.EventHandler(this.btnDeterminize_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(757, 350);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(190, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Lancer la déterminisation de l\'automate";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(143, 371);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(240, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "L\'affichage du AEF sous form du martrice";
            // 
            // dgvAutomateDeterministe
            // 
            this.dgvAutomateDeterministe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAutomateDeterministe.Location = new System.Drawing.Point(655, 397);
            this.dgvAutomateDeterministe.Name = "dgvAutomateDeterministe";
            this.dgvAutomateDeterministe.Size = new System.Drawing.Size(375, 215);
            this.dgvAutomateDeterministe.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 637);
            this.Controls.Add(this.dgvAutomateDeterministe);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnDeterminize);
            this.Controls.Add(this.btnVerifyWord);
            this.Controls.Add(this.dgvAutomate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtWord);
            this.Controls.Add(this.txtFinalStates);
            this.Controls.Add(this.txtInitialState);
            this.Controls.Add(this.txtTransitions);
            this.Controls.Add(this.txtStates);
            this.Controls.Add(this.txtAlphabet);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutomate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutomateDeterministe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAlphabet;
        private System.Windows.Forms.TextBox txtStates;
        private System.Windows.Forms.TextBox txtTransitions;
        private System.Windows.Forms.TextBox txtInitialState;
        private System.Windows.Forms.TextBox txtFinalStates;
        private System.Windows.Forms.TextBox txtWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvAutomate;
        private System.Windows.Forms.Button btnVerifyWord;
        private System.Windows.Forms.Button btnDeterminize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvAutomateDeterministe;
    }
}

